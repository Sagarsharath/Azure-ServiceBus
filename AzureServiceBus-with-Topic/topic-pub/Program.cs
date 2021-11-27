
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
namespace CoreSenderApp
{

    class Program
    {
		// read this key from config
        const string ServiceBusConnectionString = "Endpoint=sb://topics-service-bus.servicebus.windows.net/;SharedAccessKeyName=first-policy;SharedAccessKey=cU4aCAjzYAtYqPSUBD08BB4sstBlltCQ9iZb3KRRPNE=";
        const string TopicName = "first-topic";
        static ITopicClient topicClient;

        public static async Task Main(string[] args)
        {
            const int numberOfMessages = 5;
            topicClient = new TopicClient(ServiceBusConnectionString, TopicName);

            Console.WriteLine("Press ENTER key to exit after sending all the messages.");

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            Console.ReadKey();

            await topicClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
                for (var i = 0; i < numberOfMessagesToSend; i++)
                {
                    // Create a new message to send to the topic
                    string messageBody = $"Message {i}";
                    var message = new Message(Encoding.UTF8.GetBytes(messageBody));

                    // Write the body of the message to the console
                    Console.WriteLine($"Sending message: {messageBody}");

                    // Send the message to the topic
                    await topicClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}