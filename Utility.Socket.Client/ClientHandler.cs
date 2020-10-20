using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utility.SocketHandler.Common;
using static Utility.SocketHandler.Common.Data;

namespace Utility.SocketHandler.Client
{
    public class ClientHandler
    {
        public Socket clientSocket;
        public EndPoint epServer;

        public string strName { get; set; }
        public string host { get; set; }
        public int port { get; set; }

        byte[] byteData = new byte[1024];



        public void Initial(string Name)
        {
            try
            {
                host = ConfigurationManager.AppSettings["Host"];
                port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                //Using UDP sockets
                clientSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                //IP address of the server machine
                IPAddress ipAddress = IPAddress.Parse(host);
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                epServer = (EndPoint)ipEndPoint;

                Data msgToSend = new Data();
                msgToSend.cmdCommand = Command.Enter;
                msgToSend.strMessage = null;
                msgToSend.strName = Name;
                strName = Name;

                byte[] sent = msgToSend.ToByte();

                //Login to the server
                clientSocket.BeginSendTo(sent, 0, sent.Length,
                    SocketFlags.None, epServer, new AsyncCallback(OnSend), null);

                byteData = new byte[1024];

                ipAddress = IPAddress.Parse(host);
                //Server is listening on port 1000
                ipEndPoint = new IPEndPoint(ipAddress, port);

                epServer = (EndPoint)ipEndPoint;
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                           new AsyncCallback(OnReceive), null);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SendMesaage(string Text)
        {
            try
            {
                //Fill the info for the message to be send
                Data msgToSend = new Data();

                msgToSend.strName = strName;
                msgToSend.strMessage = Text;
                msgToSend.cmdCommand = Command.Message;

                byte[] byteData = msgToSend.ToByte();

                //Send it to the server
                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer, new AsyncCallback(OnSend), null);
                //byteData = new byte[1024];
                ////Start listening to the data asynchronously
                //clientSocket.BeginReceiveFrom(byteData,
                //                           0, byteData.Length,
                //                           SocketFlags.None,
                //                           ref epServer,
                //                           new AsyncCallback(OnReceive),
                //                           null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SendCommand(Command cmd)
        {
            try
            {
                var ipAddress = IPAddress.Parse(host);
                //Server is listening on port 1000
                var ipEndPoint = new IPEndPoint(ipAddress, port);

                epServer = (EndPoint)ipEndPoint;
                //The user has logged into the system so we now request the server to send
                //the names of all users who are in the chat room
                Data msgToSend = new Data();
                msgToSend.cmdCommand = cmd;
                msgToSend.strName = strName;
                msgToSend.strMessage = null;

                byteData = msgToSend.ToByte();

                clientSocket.BeginSendTo(byteData, 0, byteData.Length, SocketFlags.None, epServer,
                    new AsyncCallback(OnSend), null);

                //byteData = new byte[1024];
                ////Start listening to the data asynchronously
                //clientSocket.BeginReceiveFrom(byteData,
                //                           0, byteData.Length,
                //                           SocketFlags.None,
                //                           ref epServer,
                //                           new AsyncCallback(OnReceive),
                //                           null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnSend(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                

                
                clientSocket.EndReceive(ar);

                //Convert the bytes received into an object of type Data                
                Data msgReceived = new Data(byteData);


                //Accordingly process the message received
                switch (msgReceived.cmdCommand)
                {
                    case Command.Enter:
                        Console.WriteLine(msgReceived.cmdCommand);
                        Console.WriteLine(msgReceived.strMessage);
                        //lstChatters.Items.Add(msgReceived.strName);
                        break;

                    case Command.Logout:
                        //lstChatters.Items.Remove(msgReceived.strName);
                        break;

                    case Command.Message:
                        Console.WriteLine(msgReceived.strMessage);
                        break;

                    case Command.List:
                        //lstChatters.Items.AddRange(msgReceived.strMessage.Split('*'));
                        //lstChatters.Items.RemoveAt(lstChatters.Items.Count - 1);
                        //txtChatBox.Text += "<<<" + strName + " has joined the room>>>\r\n";
                        break;
                }

                //if (msgReceived.strMessage != null && msgReceived.cmdCommand != Command.List)
                //    txtChatBox.Text += msgReceived.strMessage + "\r\n";

                byteData = new byte[1024];

                IPAddress ipAddress = IPAddress.Parse(host);
                //Server is listening on port 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                epServer = (EndPoint)ipEndPoint;
                clientSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epServer,
                           new AsyncCallback(OnReceive), null);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
