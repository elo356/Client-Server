using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client_Server
{
    class Client
    {
        IPHostEntry host;
        IPAddress ipAddr;
        IPEndPoint endPoint;

        Socket client;

        public Client(string ip, int port)
        {
            host = Dns.GetHostByName(ip);
            ipAddr = host.AddressList[0];
            endPoint = new IPEndPoint(ipAddr, port);

            client = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }

        public void Start()
        {
            client.Connect(endPoint);
        }

        public void Send(string msg)
        {
            byte[] b = Encoding.ASCII.GetBytes(msg);
            client.Send(b);
            Console.WriteLine("Mensaje ENviado");
        }
    }
}
