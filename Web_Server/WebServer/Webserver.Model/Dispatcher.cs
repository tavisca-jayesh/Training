using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Webserver.Model
{
    public class Dispatcher
    {
        private static Dictionary<string, Type> _mapping = new Dictionary<string, Type>();
        private bool _running = true;
        static Dispatcher()
        {
            var type = typeof(IProcessor);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(assemblies => assemblies.GetTypes()
                    .Where(predicate => type.IsAssignableFrom(predicate) && predicate.IsClass));

            types.ToList().ForEach(typeofHandler =>
            {
                var instance = Activator.CreateInstance(typeofHandler) as IProcessor;
                if (string.IsNullOrWhiteSpace(instance.TypesIncluded))
                    throw new ArgumentNullException();
                instance.TypesIncluded.Split(',').ToList().ForEach(fileType =>
                {
                    _mapping[fileType.ToLower()] = typeofHandler;
                });
            });
        }
        internal void Start()
        {
            Socket socket;
            while (_running)
            {
                if (Application.RequestQueue.TryDequeue(out socket) == false)
                    continue;
                Task.Factory.StartNew(() =>
                {
                    this.Dispatch(socket);
                });
            }
        }
        internal void Stop()
        {
            this._running = false;
        }
        private void Dispatch(Socket socket)
        {
            var request = new Request(socket);
            try
            {
                if (string.IsNullOrEmpty(request.File))
                {
                    SendEmptyResponse(request);
                }
                else
                {
                    var handler = this.CheckHandler(request.File);
                    new Worker(request).Process(handler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                InternalServerResponse(request);
            }
        }
        private void InternalServerResponse(Request request)
        {
            var Response = new Response(request);
            Response.Status = ErrorCodes.ERROR_CODE_500;
            Response.Message = "Internal server error";
            Response.Send();
        }

        private IProcessor CheckHandler(string extension)
        {
            if (_mapping.ContainsKey(extension) == false)
                throw new Exception("Handler not found");
            return (Activator.CreateInstance(_mapping[extension])) as IProcessor;
        }
        private void SendEmptyResponse(Request request)
        {
            var Response = new Response(request);
            Response.Status = ErrorCodes.ERROR_CODE_200;
            Response.Message = "Contents not available";
            Response.Send();
        }
    }
}