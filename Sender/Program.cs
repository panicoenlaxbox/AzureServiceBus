using System;
using Microsoft.ServiceBus.Messaging;

namespace Sender
{
    class Program
    {
        const string connectionString = "";
        const string queueName = "";

        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKeyInfo;
            bool send = true;
            do
            {
                Console.WriteLine("Waiting for an enter key to sending a new message...");
                consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Enter)
                    SendMessage();
                else
                    send = false;
            } while (send);
        }

        private static void SendMessage()
        {
            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            var message = new BrokeredMessage($"This is a test message {DateTime.Now}!");

            client.Send(message);
            client.Close();
        }
    }
}