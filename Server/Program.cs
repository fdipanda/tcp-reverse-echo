using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MessageMirrorServer
{
    public class MessageMirrorServer
    {
        public static void Main()
        {
            Console.WriteLine("Starting Reverse Echo Server...");

            int serverPort = 7500;
            TcpListener listener = new TcpListener(IPAddress.Loopback, serverPort);
            listener.Start();

            Console.WriteLine("Awaiting client connection...");

            TcpClient client = listener.AcceptTcpClient();
            NetworkStream socketStream = client.GetStream();
            StreamReader inputReader = new StreamReader(socketStream, Encoding.ASCII);
            StreamWriter outputWriter = new StreamWriter(socketStream, Encoding.ASCII) { AutoFlush = true };

            bool serverActive = true;
            while (serverActive)
            {
                string incomingData = inputReader.ReadLine();
                if (incomingData == null)
                {
                    Console.WriteLine("Client has disconnected.");
                    break;
                }

                string mirroredData = GetReversedString(incomingData);
                outputWriter.WriteLine(mirroredData);
                Console.WriteLine($"Original: {incomingData} | Reversed: {mirroredData}");

                if (incomingData.Equals("end", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Shutdown command received. Terminating server...");
                    serverActive = false;
                }
            }

            client.Close();
            listener.Stop();
        }

        private static string GetReversedString(string text)
        {
            char[] characters = text.ToCharArray();
            Array.Reverse(characters);
            return new string(characters);
        }
    }
}
