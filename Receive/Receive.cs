﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Receive
{
    public class Receive
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using(var connection = factory.CreateConnection())
            {
                using(var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "hello",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, eventArgs) => 
                    {
                        var body = eventArgs.Body;
                        var message = Encoding.UTF8.GetString(body);
                        Console.WriteLine($"Received {message}");
                    };
                    channel.BasicConsume(queue: "hello", autoAck: true, consumer: consumer);

                    Console.WriteLine("Console still open...");
                    Console.Read();
                }
            }
        }
    }
}
