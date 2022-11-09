using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using System.Net.Sockets;

namespace Client_Server
{
    class Server
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket server;
        Socket client;

        [Obsolete]
        public Server(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr,port);

            server = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(endPoint);
            server.Listen(10);
        }
        public void Start()
        {
            Thread t;
            while (true)
            {
                Console.Write("Esperando Conecciones...");
                client = server.Accept();
                t = new Thread(clientConnection);
                t.Start(client);
                Console.WriteLine("Nueva coneccion establecida");
            }
        }
        public void clientConnection(object s)
        {
            Socket client = (Socket)s;
            byte[] buffer;
            string message;
            int endIndex;

            while (true)
            {
                buffer = new byte[1024];
                client.Receive(buffer);
                message = Encoding.ASCII.GetString(buffer);
                endIndex = message.IndexOf("\0");
                if (endIndex > 0)
                {
                    message = message.Substring(0, endIndex);
                }
                Console.WriteLine("Se resivio el mensaje: " + message);
                Console.Out.Flush();
            }
        }
    }
}
