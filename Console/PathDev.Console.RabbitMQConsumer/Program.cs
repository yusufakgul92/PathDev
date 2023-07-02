using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PathDev.Infrastructure.DataAccess.Service.Order;
using Microsoft.Extensions.DependencyInjection;
using PathDev.Core.Model.Interface.Service.Order;
using PathDev.Infrastructure.DataAccess.Service.EF;
using PathDev.Core.Model.Interface.Service.Redis;
using PathDev.Infrastructure.DataAccess.Service.Redis;
using PathDev.Core.Model.Redis.Cart;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PathDev.Core.Model.Interface.Service.RabbitMQ;
using PathDev.Infrastructure.DataAccess.Service.RabbitMQ;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(configuration);
services.AddSingleton<IOrderService, OrderService>();
services.AddSingleton<IRabbitMQService, RabbitMQService>();
services.AddSingleton(typeof(IRedisService<>), typeof(RedisService<>)); // Update this line
services.AddHttpContextAccessor();
services.AddDbContext<PathDevDbContext>(options =>
    options.UseSqlServer(@"Server=EBILGI-YAKGUL\MSSQLSERVER01;Database=PathDev;User Id=sa;Password=crysis_92;MultipleActiveResultSets=True;TrustServerCertificate=True;"));

using var serviceProvider = services.BuildServiceProvider();
var orderService = serviceProvider.GetRequiredService<IOrderService>();

// rest of your code...


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

//Set Event object which listen message from chanel which is sent by producer
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    orderService.Complete(JsonConvert.DeserializeObject<string>(message));

    Console.WriteLine($"Product message received: {message}");
};

//read the message
channel.BasicConsume(queue: "order", autoAck: true, consumer: consumer);

Console.ReadKey();