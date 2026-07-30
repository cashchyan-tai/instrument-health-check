using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Pegatron
{
    public class Switch : ISwitchBox
    {
        public string Vendor { get; } = "Woken Technology";
        public string Model { get; } = "2 Port RF Switch Box";
        public string SN { get; } = "0169A00180001W";
        public string Name = "Switch Box";
        public int PortSGDUT { get; } = 0;
        public int PortSADUT { get; } = 1;
        public string IP = "192.168.100.251";

        private Socket sender;

        public Switch()
        {
            
        }

        public bool Connect(string ipStr = "", int timeout = 1500)
        {
            //MessageBox.Show("connecting");
            try
            {
                DateTime startTime = DateTime.Now;
                int port = 23;

                if (!string.IsNullOrEmpty(ipStr))
                    IP = ipStr;
                IPAddress ipAddress = IPAddress.Parse(IP);
                //Local test
                //IPHostEntry host = Dns.GetHostEntry("localhost");
                //IPAddress ipAddress = host.AddressList[0];

                IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

                // Create a TCP/IP  socket.
                sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                sender.ReceiveTimeout = timeout;
                sender.SendTimeout = timeout;
                DateTime timeTime = DateTime.Now.AddMilliseconds(timeout);

                // Connect the socket to the remote endpoint. Catch any errors.
                try
                {
                    // Connect to Remote EndPoint
                    var result = sender.BeginConnect(remoteEP, null, null);
                    result.AsyncWaitHandle.WaitOne(timeout, true);

                    //Console.WriteLine("Socket connected to {0}",
                    //    sender.RemoteEndPoint.ToString());

                    //string checkPortNum = currentPort();

                    //return checkPortNum == "0" || checkPortNum == "1" ? true : false;
                    return sender.Connected;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message, "Unexpected error during connection");
                    return false;
                }
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Unexpected exception on IP address");
                return false;
            }
        }

        public void Disconnect()
        {
            if (sender == null || !sender.Connected) return;
            try
            {
                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes("QUIT");

                // Send the data through the socket.
                int bytesSent = sender.Send(msg);

                if (!sender.Connected) return;

                // Release the socket.
                //sender.Shutdown(SocketShutdown.Both);
                sender.Close();
                sender = null;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message, "Unexpected exception while disconnecting");
            }
        }

        public bool SetPort(int portNum)
        {
            if (sender == null || !sender.Connected)
            {
                if (!string.IsNullOrEmpty(IP))
                {
                    bool conn = Connect(IP);
                    if (!conn) { return false; }
                }
                else
                    return false;
            }

            try
            {
                byte[] bytes = new byte[1024];
                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes("SETP=" + portNum);

                // Send the data through the socket.
                sender.SendTimeout = 500;
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.
                sender.ReceiveTimeout = 500;
                int bytesRec = sender.Receive(bytes);
                string chk = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                return chk.Contains("1") ? true : false;
                //return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message + "Please try restarting SwitchBox", "Unexpected exception when setting port " + portNum);
                return false;
            }
        }

        public string currentPort()
        {
            if (sender == null || !sender.Connected)
            {
                if (!string.IsNullOrEmpty(IP))
                {
                    bool conn = Connect(IP);
                    if (!conn) { return ""; }
                }
                else
                    return "";
            }

            try
            {
                byte[] bytes = new byte[1024];
                // Encode the data string into a byte array.
                byte[] msg = Encoding.ASCII.GetBytes("SETP?");

                // Send the data through the socket.
                sender.SendTimeout = 500;
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.
                sender.ReceiveTimeout = 500;
                int bytesRec = sender.Receive(bytes);
                string currentPort = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                return currentPort;
            }
            catch (Exception e)
            {
                if (!(e.Message.Contains("Thread was being aborted") || e.Message.Contains("after a period of time")))
                    System.Windows.Forms.MessageBox.Show(e.Message, "Unexpected exception when checking current port");
                return "";
            }
        }

        //public new bool Connect(string sIpAddress = "192.168.100.251")
        //{
        //    IP = sIpAddress;
        //    string checkPort = currentPort();
        //    return checkPort == "1" || checkPort == "0" ? true : false;
        //}

        //public void Disconnect()
        //{
        //    SendHttpRequest(@$"QUIT");
        //}

        //public bool SetPort(int portNum)
        //{
        //    return SendHttpRequest(@$"SETP=" + portNum) == 1 ? true : false;
        //}

        //public string currentPort()
        //{
        //    return SendHttpRequest(@$"SETP?").ToString();
        //}

        //private char SendHttpRequest(string instruction, int nTimeOut = 4000, int port = 23, Uri? uri = null)
        //{
        //    uri = new Uri("http://" + IP);

        //    // Construct a minimalistic HTTP/1.1 request
        //    //byte[] requestBytes = Encoding.ASCII.GetBytes(@$"GET {uri.AbsoluteUri} HTTP/1.0 Host: {uri.Host} Connection: Close");
        //    byte[] requestBytes = Encoding.ASCII.GetBytes(instruction);

        //    // Create and connect a dual-stack socket
        //    using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
        //    socket.ReceiveTimeout = nTimeOut;
        //    socket.Connect(uri.Host, port);

        //    // Send the request.
        //    // For the tiny amount of data in this example, the first call to Send() will likely deliver the buffer completely,
        //    // however this is not guaranteed to happen for larger real-life buffers.
        //    // The best practice is to iterate until all the data is sent.
        //    int bytesSent = 0;
        //    while (bytesSent < requestBytes.Length)
        //        bytesSent += socket.Send(requestBytes, bytesSent, requestBytes.Length - bytesSent, SocketFlags.None);

        //    if (instruction.Contains("QUIT"))
        //        return 'f';

        //    // Do minimalistic buffering assuming ASCII response
        //    byte[] responseBytes = new byte[256];
        //    char[] responseChars = new char[256];

        //    DateTime timeOutTime = DateTime.Now + TimeSpan.FromMilliseconds(nTimeOut);
        //    while (true)
        //    {
        //        int bytesReceived = socket.Receive(responseBytes);

        //        // Receiving 0 bytes means EOF has been reached
        //        if (bytesReceived == 0) break;
        //        if (DateTime.Now > timeOutTime)
        //        {
        //            responseChars[0] = '0';
        //            break;
        //        }

        //        // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
        //        int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

        //        // Print the contents of the 'responseChars' buffer to Console.Out
        //        //Console.Out.Write(responseChars, 0, charCount);
        //    }

        //    return responseChars[0];
        //}
    }
}
