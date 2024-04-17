using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

//create connection
ConnectionFactory connectionFactory = new();
connectionFactory.Uri = new("amqps://bqkozkbb:Pei9-L7Q68-ZwjrrWKGGK6Dz_i8jpUeW@stingray.rmq.cloudamqp.com/bqkozkbb");

//create channel
using IConnection connection= connectionFactory.CreateConnection();
using IModel channel = connection.CreateModel();

//create queue

channel.QueueDeclare(queue: "example-queue", exclusive: false);

EventingBasicConsumer consumer = new(channel);
channel.BasicConsume("example-queue", false, consumer);

consumer.Received += (sender, e) =>
{
    //e.Body.Span;
    //e.Body.ToArray(); I can recieve message in byte array format
    Console.WriteLine(Encoding.UTF8.GetString(e.Body.Span));
};

Console.ReadLine();

 