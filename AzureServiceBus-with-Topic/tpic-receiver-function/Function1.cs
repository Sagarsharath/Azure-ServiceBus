using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace tpic_receiver_function
{
    public static class Function1
    {
		// read this key from config
         const string TopicName = "first-topic";
        const string SubscriptionName = "sub-b";
        [FunctionName("Function1")]


        public static void Run([ServiceBusTrigger(TopicName, SubscriptionName, Connection = "topicConnection")]string mySbMsg, ILogger log) //topicConnection is the connection string from configuration file
        {
            log.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
            Console.WriteLine("message : "+mySbMsg);
        }
    }
}
