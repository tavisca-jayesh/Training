using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Webserver.Model;

namespace Webserver.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int port = 0;
                if (int.TryParse(ConfigurationManager.AppSettings["port"], out port) == false)
                    throw new SystemException("Invalid port");

                string host = ConfigurationManager.AppSettings["host"];
                if (string.IsNullOrEmpty(host))
                    throw new SystemException("Invalid Host");

                var server = new Server(host, port);
                server.Start();

                Console.ReadKey();
                server.Stop();

            }
            catch (SystemException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}