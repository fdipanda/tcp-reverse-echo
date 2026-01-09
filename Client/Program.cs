using System;
using System.IO;
using System.Net.Sockets;

namespace MessageMirrorClient
{
    class MessageMirrorClient
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Reverse Echo Client...");

            int serverPort = 7500;
            TcpClient connection = new TcpClient("localhost", serverPort);
            NetworkStream netStream = connection.GetStream();
            StreamReader streamReader = new StreamReader(netStream);
            StreamWriter streamWriter = new StreamWriter(netStream) { AutoFlush = true };

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("Type your message: ");
                string messageToSend = Console.ReadLine();

                streamWriter.WriteLine(messageToSend);

                string responseFromServer = streamReader.ReadLine();
                Console.WriteLine($"Reply from server: {responseFromServer}");

                if (messageToSend.Equals("end", StringComparison.OrdinalIgnoreCase) &&
                    responseFromServer.Equals("dne", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Termination acknowledged.");
                    isRunning = false;
                }
            }

            connection.Close();
        }
    }
}
