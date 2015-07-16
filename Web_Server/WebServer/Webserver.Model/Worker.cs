using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Webserver.Model
{
    internal class Worker
    {
        private Request _request;

        public Worker(Request request)
        {
            if (request == null)
                throw new ArgumentException();
            this._request = request;
        }

        public void Process(IProcessor processor)
        {
            if (processor == null)
                throw new ArgumentException();
            Response response;
            try
            {
                response = processor.Process(this._request);
                response.Status = ErrorCodes.ERROR_CODE_200;
                response.Message = "OK";
            }
            catch (ResourceNotFoundException resourceUnavailable)
            {
                response = new Response(this._request);
                response.Status = ErrorCodes.ERROR_CODE_404;
                response.Message = "Not Found";
            }
            catch (Exception ex)
            {
                response = new Response(this._request);
                response.Status = ErrorCodes.ERROR_CODE_500;
                response.Message = "Internal Server Error";
            }
            response.Send();
        }
    }
}