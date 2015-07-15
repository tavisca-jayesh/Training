using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Threading;
using System.Configuration;

namespace WebServer
{
    class Dispatcher
    {
        private Socket _clientSocket = null;
        private static HandlerFactory handlerFactory = new HandlerFactory();
        public Dispatcher(Socket clientSocket)
        {
            _clientSocket = clientSocket;
         }
        public void HandleClient()
        {
            var requestParse = new RequestParser();
            string requestString = DecodeRequest(_clientSocket);
            if (string.IsNullOrWhiteSpace(requestString) == false)
            {
                requestParse.Parser(requestString);
                Console.WriteLine(requestParse.HttpUrl);
                int dotPosition = requestParse.HttpUrl.LastIndexOf('.') + 1;
                if (dotPosition > 0)
                {
                    var requestHandler = handlerFactory.CreateHandler(requestParse.HttpUrl, _clientSocket, ConfigurationManager.AppSettings["Path"]);

                    if (requestParse.HttpMethod.Equals("get", StringComparison.InvariantCultureIgnoreCase))
                    {

                        //var createResponse = new CreateResponse(_clientSocket, ConfigurationManager.AppSettings["Path"]);
                        requestHandler.DoGet(requestParse.HttpUrl);
                    }
                    else
                    {
                        Console.WriteLine("unimplemented methode");
                        Console.ReadLine();
                    }
                }
                else   //find default file as index .htm of index.html
                {
                    TextRequestHandler htmlRequestHandler = new TextRequestHandler(_clientSocket, ConfigurationManager.AppSettings["Path"]);
                    htmlRequestHandler.DoGet(requestParse.HttpUrl);
                }
            }
            StopClientSocket(_clientSocket);  //closes the connection
        }

        public void StopClientSocket(Socket clientSocket)
        {
            if (clientSocket != null)
                clientSocket.Close();
        }

        private string DecodeRequest(Socket clientSocket)
        {
            Encoding _charEncoder = Encoding.UTF8;
            var receivedBufferlen = 0;
            var buffer = new byte[10240];
            try
            {
                receivedBufferlen = clientSocket.Receive(buffer);
            }
            catch (Exception)
            {
                //Console.WriteLine("buffer full");
                Console.ReadLine();
            }
            return _charEncoder.GetString(buffer, 0, receivedBufferlen);
        }
    }
}
