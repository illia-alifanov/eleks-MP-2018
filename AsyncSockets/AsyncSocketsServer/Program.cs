using System;
using System.Net;

namespace AsyncSocketsServer
{
    class Program
    {
        static void Main(string[] args)
        {
            int connectionsNumber;
            int receiveSize;
            IPEndPoint localEndPoint;
            int port;

            try
            {
                connectionsNumber = 10;
                receiveSize = 1024;
                string addressFamily = "ipv4";
                port = 8000;

                if (addressFamily.Equals("ipv4"))
                {
                    localEndPoint = new IPEndPoint(IPAddress.Any, port);
                }
                else if (addressFamily.Equals("ipv6"))
                {
                    localEndPoint = new IPEndPoint(IPAddress.IPv6Any, port);
                }
                else
                {
                    throw new ArgumentException("Invalid address family specified");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Press any key to start the server ...");
            Console.ReadKey();

            // Server starts listening for incoming connection requests
            Server server = new Server(connectionsNumber, receiveSize);
            server.Init();
            server.StartListen(localEndPoint);
        }
    }
}

