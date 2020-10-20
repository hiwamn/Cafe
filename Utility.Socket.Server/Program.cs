
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Utility.SocketHandler.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerHandler handler = new ServerHandler();
            handler.Initial(new Common.SocketParameters {IP = "127.0.0.1",Port = 579 });


            while (true)
            {
                Thread.Sleep(1);
            }
        }
    }
}
