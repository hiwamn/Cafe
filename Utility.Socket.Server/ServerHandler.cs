using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Utility.SocketHandler.Common;
using static Utility.SocketHandler.Common.Data;

namespace Utility.SocketHandler.Server
{
    public partial class ServerHandler
    {
        public ServerHandler(

            )
        {

        }
        //The collection of all clients logged into the room (an array of type ClientInfo)
        List<ClientInfo> clientList;

        //The main socket on which the server listens to the clients
        Socket serverSocket;

        byte[] byteData = new byte[1024];
        public string host { get; set; }
        public int port { get; set; }

        public void Initial(SocketParameters parameters)
        {
            host = parameters.IP;
            port = parameters.Port;
            IPAddress ipAddress = IPAddress.Parse(host);





            clientList = new List<ClientInfo>();
            try
            {


                //We are using UDP sockets
                serverSocket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Dgram, ProtocolType.Udp);

                //Assign the any IP of the machine and listen on port number 1000
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, port);

                //Bind this address to the server
                serverSocket.Bind(ipEndPoint);

                //IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                IPEndPoint ipeSender = new IPEndPoint(ipAddress, port);
                //The epSender identifies the incoming clients
                EndPoint epSender = (EndPoint)ipeSender;


                //Start receiving data
                serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length,
                    SocketFlags.None, ref epSender, new AsyncCallback(OnReceive), epSender);
                Console.WriteLine(Encoding.Default.GetString(byteData));
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
                //IP address of the server machine
                IPAddress ipAddress = IPAddress.Parse(host);

                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                //IPEndPoint ipeSender = new IPEndPoint(ipAddress, port);
                EndPoint epSender = (EndPoint)ipeSender;

                serverSocket.EndReceiveFrom(ar, ref epSender);

                //Transform the array of bytes received from the user into an
                //intelligent form of object Data
                Data msgReceived = new Data(byteData);

                //Console.WriteLine(msgReceived.strMessage);

                //We will send this object in response the users request
                //Data msgToSend = new Data();



                //If the message is to login, logout, or simple text message
                //then when send to others the type of the message remains the same


                switch (msgReceived.cmdCommand)
                {
                    case Command.Enter:


                        ClientInfo clientInfo = new ClientInfo();
                        clientInfo.endpoint = epSender;
                        clientInfo.strName = msgReceived.strName;

                        clientList.Add(clientInfo);

                        if (clientList.Count >= 2)
                        {
                            var mess1 = new Data
                            {
                                cmdCommand = Command.Message,
                                strName = clientList[0].strName,
                                strMessage = "Next User=>" + clientList[1].strName
                            }; 
                            var mess2 = new Data
                            {
                                cmdCommand = Command.Message,
                                strName = clientList[1].strName,
                                strMessage = "Next User=>" + clientList[0].strName
                            };


                            SendMessage(serverSocket, mess1, clientList[0].endpoint);
                            SendMessage(serverSocket, mess2, clientList[1].endpoint);
                        }

                        break;

                    //case Command.Logout:

                    //    //When a user wants to log out of the server then we search for her 
                    //    //in the list of clients and close the corresponding connection

                    //    int nIndex = 0;
                    //    foreach (ClientInfo client in clientList)
                    //    {
                    //        if (client.endpoint == epSender)
                    //        {
                    //            clientList.RemoveAt(nIndex);
                    //            break;
                    //        }
                    //        ++nIndex;
                    //    }

                    //    msgToSend.strMessage = "<<<" + msgReceived.strName + " has left the room>>>";
                    //    break;

                    case Command.Message:
                        //Fill the info for the message to be send

                        var msgToSend = new Data();
                        msgToSend.cmdCommand = Command.Message;
                        msgToSend.strName = msgReceived.strName;
                        msgToSend.strMessage = $"{msgReceived.strName} : {msgReceived.strMessage}";

                        var mess = msgToSend.ToByte();

                        foreach (ClientInfo client in clientList)
                        {

                            if (client.strName == msgReceived.strName)
                            {
                                //Thread.Sleep(500);
                                //Send the message to all users
                                serverSocket.BeginSendTo(mess, 0, mess.Length, SocketFlags.None, client.endpoint,
                                    new AsyncCallback(OnSend), client.endpoint);
                                break;
                            }
                        }

                        break;

                }



                //If the user is logging out then we need not listen from her
                if (msgReceived.cmdCommand != Command.Logout)
                {
                    byteData = new byte[1024];
                    //Start listening to the message send by the user
                    serverSocket.BeginReceiveFrom(byteData, 0, byteData.Length, SocketFlags.None, ref epSender,
                        new AsyncCallback(OnReceive), null);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void SendMessage(Socket serverSocket, Data mess1, EndPoint endpoint)
        {
            var mess = mess1.ToByte();
            serverSocket.BeginSendTo(mess, 0, mess.Length, SocketFlags.None, endpoint,
                                new AsyncCallback(OnSend), endpoint);
        }

        public void OnSend(IAsyncResult ar)
        {
            try
            {
                serverSocket.EndSend(ar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
