

using System.Text;
using RabbitMQ.Client;
//create Connection
ConnectionFactory connectionFactory = new();
connectionFactory.Uri = new("amqps://bqkozkbb:Pei9-L7Q68-ZwjrrWKGGK6Dz_i8jpUeW@stingray.rmq.cloudamqp.com/bqkozkbb");

//create channel

using IConnection connection= connectionFactory.CreateConnection();
using IModel channel = connection.CreateModel();

//create queue

channel.QueueDeclare(queue: "example-queue",exclusive:false);

//send message to queue
while (true)
{
    Console.WriteLine("Send Message:");
    string message = Console.ReadLine();

    byte[] messageBytes = Encoding.UTF8.GetBytes(message);
    channel.BasicPublish(exchange: "", routingKey: "example-queue", body: messageBytes);
}
