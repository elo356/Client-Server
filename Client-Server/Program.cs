using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            //habra dos veces este programa, en uno de ellos haga el siguiente
            //bool true para correrlo como servidor, al iniciar primero corra el porgrama servidor
            bool runningServer = false;

            if (runningServer)
            {
                //correr como servidor
                Server s = new Server("0.0.0.0", 4040);
                s.Start();
            }
            else
            {
                //correr como cliente
                Client c = new Client("192.168.68.118", 4040);
                c.Start();
                string msg;
                while (true)
                {
                    Console.Write("Ingrese mensaje: ");
                    msg = Console.ReadLine();
                    c.Send(msg);
                }
            }

            Console.ReadKey();
        }
    }
}
