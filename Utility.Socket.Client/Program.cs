using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utility.SocketHandler.Client
{
    class Program
    {

        static void Main(string[] args)
        {
            ClientHandler client = new ClientHandler();
            client.Initial(Guid.NewGuid().ToString());
            //client.SendCommand(Common.Data.Command.Enter);

            


            while (true)
            {

                Thread.Sleep(2000);

                //client.SendMesaage(DateTime.Now.ToString());
                Thread.Sleep(1);
            }

        }
    }
}
