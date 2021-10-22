using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client;

namespace PBT205_Assessment1_Group4_AIJ
{
    public class SetupRabbitMQ
    {
        // RabbitMQ setup variables
        private String userName = "";
        private String password = "";
        private String roomName = "";
        private String exchangeName = "";
        private String queueName;
        IModel channel;
        IConnection connection;

        public SetupRabbitMQ(String userName, String password, String roomName, String exchangeName, String exchangeType)
        {
            // Setup rabbitmq            
            var factory = new ConnectionFactory();
            factory.Uri = new Uri($"amqp://{userName}:{password}@localhost:5672");
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            this.queueName = Guid.NewGuid().ToString();

            // Store variables
            this.userName = userName;
            this.password = password;
            this.roomName = roomName;
            this.exchangeName = exchangeName;

            // Declare exchange and queues
            channel.ExchangeDeclare(exchange: this.exchangeName,
                                    type: exchangeType);

            channel.QueueDeclare(queue: this.queueName,
                                 durable: true,
                                 exclusive: true,
                                 autoDelete: true);

            channel.QueueBind(queue: queueName,
                              exchange: exchangeName,
                              routingKey: this.roomName);
        }

        public IModel GetModel()
        {
            // Gets the channel
            return channel;
        }

        public IConnection GetConnection()
        {
            // Gets the connection
            return connection;
        }

        public String GetExchangeRoomName()
        {
            // Gets the exchangename
            return exchangeName;
        }

        public String GetQueueName()
        {
            // Gets the queuename
            return queueName;
        }

        public String GetRoomName()
        {
            // Gets the chatroomname
            return roomName;
        }
    }
}