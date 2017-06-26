using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace Receiver
{
    class Program
    {
        const string connectionString = "";
        const string queueName = "";

        static void Main(string[] args)
        {
           

            //var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            //client.OnMessage(message =>
            //{
            //    Console.WriteLine($"Message id: {message.MessageId}");
            //    Console.WriteLine($"Message body: {message.GetBody<string>()}");
            //});
            //Console.ReadKey();
            //client.Close();

            ConsoleKeyInfo consoleKeyInfo;
            do
            {
                ReadMessages();
                Console.WriteLine("Waiting for an enter key to reading messages...");
                consoleKeyInfo = Console.ReadKey();
            } while (consoleKeyInfo.Key == ConsoleKey.Enter);
        }

        private static void ReadMessages()
        {
            Console.WriteLine("Reading...");
            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            bool queueStillHasMessages = true;
            while (queueStillHasMessages)
            {
                BrokeredMessage message = client.Receive();
                if (message != null)
                {
                    Console.WriteLine($"Message id: {message.MessageId}");
                    Console.WriteLine($"Message body: {message.GetBody<string>()}");
                    message.Complete();
                }
                else
                {
                    queueStillHasMessages = false;
                }
            }
            client.Close();
        }
    }
}