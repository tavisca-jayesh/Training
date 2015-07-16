using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Webserver.Model
{
    public class Response
    {
        public Response(Request request)
        {
            if (request == null)
                throw new ArgumentException();
            this.Request = request;
            this.Body = new byte[] { };
        }
        private string _contentType = "";
        public Request Request { get; private set; }
        public byte[] Body { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    return;
                _contentType = value;
            }
        }
        public string HttpVersion
        {
            get
            {
                return this.Request.Version;
            }
        }
        public int ContentLength
        {
            get
            {
                return this.Body != null ? this.Body.Length : 0;
            }
        }
        public void Send()
        {
            try
            {
                byte[] bytes = GetByte(CreateRespose());
                var socket = this.Request.Socket;
                socket.Send(bytes);
                socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private byte[] GetByte(string response)  // message body
        {
            var bytes = Encoding.UTF32.GetBytes(response);
            var stream = new MemoryStream();
            stream.Write(bytes, 0, bytes.Length);
            if (this.Body != null)
                stream.Write(this.Body, 0, this.Body.Length);
            return stream.ToArray();
        }
        private string CreateRespose()
        {
            StringBuilder httpResponse = new StringBuilder();

            httpResponse.Append(this.HttpVersion).Append(" ");
            httpResponse.Append(this.Status).Append(" ");
            httpResponse.Append(this.Message).Append(" ");
            httpResponse.Append("Content-Type:").Append(this.ContentType);  //content type to header

            return httpResponse.ToString();
        }
    }
}