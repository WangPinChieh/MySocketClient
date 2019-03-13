using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MySocketClient
{
    class Program
    {
        public static Socket m_SocketClient;
        static void Main(string[] args)
        {
            StartSocketClient();
        }
        public static void StartSocketClient() {
            IPAddress _IPAddress = IPAddress.Parse("127.0.0.1");
            IPEndPoint _IPEndPoint = new IPEndPoint(_IPAddress, 11000);
            m_SocketClient = new Socket(_IPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                m_SocketClient.Connect(_IPEndPoint);
                Console.WriteLine("Socket connected to : " + m_SocketClient.RemoteEndPoint.ToString());
                while (true)
                {
                    byte[] _Message = Encoding.ASCII.GetBytes(Console.ReadLine());
                    byte[] _Response = new byte[1024];

                    int _BytesSent = m_SocketClient.Send(_Message);
                    int _BytesReceived = m_SocketClient.Receive(_Response);
                    Console.WriteLine("Echo from the server : " + Encoding.ASCII.GetString(_Response, 0, _BytesReceived));
                }
            }
            catch (Exception exp) { }
        }
    }
}
