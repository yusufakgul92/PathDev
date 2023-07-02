using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Configuration;
using Newtonsoft.Json;
using PathDev.Core.Model.Interface.Service.RabbitMQ;
using RabbitMQ.Client;
using IConnection = MongoDB.Driver.Core.Connections.IConnection;
using IModel = Microsoft.EntityFrameworkCore.Metadata.IModel;

namespace PathDev.Infrastructure.DataAccess.Service.RabbitMQ
{
    public class RabbitMQService : IRabbitMQService
    {
        public void PublishToQueu()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "customer",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                channel.BasicPublish(exchange: "",
                    routingKey: "customer",
                    basicProperties: null);
            }
        }

        public void SendOrder<T>(T message)
        {

            //PublishToQueu();

            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();

            //Here we create channel with session and model
            using var channel = connection.CreateModel();

            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare("order", exclusive: false);

            //Serialize the message
            string json = JsonConvert.SerializeObject(message);
            byte[] body = Encoding.UTF8.GetBytes(json);

            //put the data on to the product queue
            channel.BasicPublish(exchange: "", routingKey: "order", body: body);
        }
    }
}
