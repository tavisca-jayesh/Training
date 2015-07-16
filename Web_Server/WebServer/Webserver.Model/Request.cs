using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Configuration;
using System.IO;

namespace Webserver.Model
{
    public class Request
    {
        private static string _path = ConfigurationManager.AppSettings["path"];
        private Dictionary<string, string> _header { get; set; }
        private static string _scheme = "http";

        internal Socket Socket { get; private set; }
        static Request()
        {
            // TODO: Complete member initialization
            var isSecure = false;
            bool.TryParse(ConfigurationManager.AppSettings["is-secure"], out isSecure);
            if (isSecure) _scheme = "https";
        }

        public string TypeAccepted
        {
            get
            {
                return this._header["Type_Accept"];
            }
        }
        public string Connection { get { return this._header["Connection"]; } }
        public string LanguageAccepted { get { return this._header["Language_Accepted"]; } }

        public string Version { get; private set; }
        public string Body { get; private set; }
        public string Method { get; private set; }
        public string Host { get; private set; }
        public string Url { get; private set; }
        public Uri Uri { get; private set; }

        public string File { get; set; }
        public string ApplicationPath
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_path)) throw new Exception("application path is not set in the configuration.");
                return _path;
            }
        }
        public string Path { get; private set; }
        public string Query { get; set; }

        public Request(Socket socket)
        {

            if (socket == null)
                throw new ArgumentException();
            this.Socket = socket;
            var request = Encoding.UTF32.GetString(ReadBytes());
            if (string.IsNullOrEmpty(request))
            {
                return;
            }
            this._header = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            string[] splitLine = request.Split(new string[] { ErrorCodes.RETURN_LINE_FEED }, StringSplitOptions.None);
            string[] requestLine = splitLine[0].Split(' ');

            ProcessRequest(requestLine);
            ProcessHeader(splitLine);
            CreateUri();
            ResolvePath();
        }

        private byte[] ReadBytes()
        {
            var bucket = new byte[1024];
            using (var buffer = new MemoryStream())
            {
                while (true)
                {
                    var bytesRead = this.Socket.Receive(bucket);
                    if (bytesRead > 0)
                        buffer.Write(bucket, 0, bytesRead);

                    if (this.Socket.Available == 0)
                        break;
                }
                return buffer.ToArray();
            }
        }

        private void ProcessHeader(string[] splitLine)
        {
            for (int index = 1; index < splitLine.Length; index++)
            {
                //Last field of header is Body
                if (index == splitLine.Length - 1)
                    this.Body = splitLine[index];

                string[] temp = splitLine[index].Split(':');

                for (int index2 = 0; index2 < temp.Length - 1; index2++)
                {
                    ///Handling Host field 
                    if (temp[0] == "Host")
                    {
                        if (temp.Length > 2)
                            this.Host = temp[1].Trim() + ":" + temp[2].Trim();
                        else
                            this.Host = temp[1];
                    }
                    else
                        this._header[temp[0]] = temp[1];
                }
            }
        }
        private void ResolvePath()
        {
            var segments = new List<string>();
            for (int index = 0; index < this.Uri.Segments.Length; index++)
            {
                string segment = this.Uri.Segments[index];
                segments.Add(segment);
                var extensionIndex = segment.IndexOf(".");
                if (extensionIndex != -1)
                {
                    segment = segment.Trim('/').ToLower();
                    this.File = System.IO.Path.GetExtension(segment).Trim('.');
                    break;
                }
            }
            var localPath = string.Join("", segments).Trim('/');
            this.Path = System.IO.Path.Combine(this.ApplicationPath, localPath.Replace("/", "\\"));
        }

        private void CreateUri()
        {
            var baseUrl = string.Format("{0}:{1}/{2}", _scheme, this.Host, this.Url);
            if (string.IsNullOrWhiteSpace(this.Query))
                this.Uri = new Uri(baseUrl);
            else
                this.Uri = new Uri(baseUrl + this.Query);
        }

        private void ProcessRequest(string[] requestLine)
        {
            if (requestLine.Length != 3)
                throw new Exception("Invalid request");
            this.Method = requestLine[0].Trim();
            this.Url = requestLine[1].TrimStart('/');
            if (string.IsNullOrWhiteSpace(this.Url))
                this.Url = ConfigurationManager.AppSettings["default-page"];

            var queryIndex = this.Url.IndexOf("?");   // url 
            if (queryIndex != -1)
            {
                this.Query = this.Url.Substring(queryIndex, this.Url.Length - queryIndex);
                this.Url = this.Url.Replace(this.Query, "");
            }
            this.Version = requestLine[2];   // version
        }
    }
}