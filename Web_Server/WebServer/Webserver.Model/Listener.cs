using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Webserver.Model
{
    internal class Listener
    {
        private TcpListener _tcpListener;
        public Listener(string host, int port)
        {
            _tcpListener = new TcpListener(IPAddress.Parse(host), port);
        }

        public void Start()
        {
            this._tcpListener.Start();
            while (true)
            {
                var socket = this._tcpListener.AcceptSocket();
                if (socket.Connected == false)
                    continue;
                Application.RequestQueue.Enqueue(socket);
            }
        }
        public void Stop()
        {
            this._tcpListener.Stop();
        }
    }
}