using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebServer
{
    class HandlerFactory
    {
        private List<string> _knownExtensions = new List<string>();
        public HandlerFactory()
        {
            _knownExtensions.Add(".html");
            _knownExtensions.Add(".htm");
            _knownExtensions.Add(".css");
            _knownExtensions.Add(".js");
            _knownExtensions.Add(".txt");
            _knownExtensions.Add(".ico");
        }
        // This function was originally a virtual function
        public IProcessor CreateHandler(string url, Socket clientSocket, string contentPath)
        {
            IProcessor requestProcessor = null;
            string extension = GetExtensionFromUrl(url);

            if (_knownExtensions.Contains(extension))
            {

                switch (extension)
                {

                    case ".html":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".htm":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".css":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".js":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    case ".txt":
                        requestProcessor = new TextRequestHandler(clientSocket, contentPath);
                        break;
                    default:
                        requestProcessor = new NotFoundErrorHandler(clientSocket);
                        break;
                }
            }
            else
            {
                requestProcessor = new InternalErrorHandler(clientSocket);
            }
            return requestProcessor;
        }

        private string GetExtensionFromUrl(string url)
        {
            return url.Substring(url.LastIndexOf('.'));
        }
    }
}
