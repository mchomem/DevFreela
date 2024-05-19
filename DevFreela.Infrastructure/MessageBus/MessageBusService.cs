namespace DevFreela.Infrastructure.MessageBus;

public class MessageBusService : IMessageBusService
{
    private readonly ConnectionFactory _factory;

    // Caso exista um servidor com o RabbitMQ configurado, utilizar as configurações do appsettings.json e conjunto com o IConfiguration.
    public MessageBusService(IConfiguration configuration)
    {
        _factory = new ConnectionFactory
        {
            HostName = configuration.GetSection("RabbitMQ:HostName").Value,
            Port = Convert.ToInt32(configuration.GetSection("RabbitMQ:Port").Value),
            UserName = configuration.GetSection("RabbitMQ:UserName").Value,
            Password = configuration.GetSection("RabbitMQ:Password").Value,
        };
    }

    public void Publish(string queue, byte[] message)
    {
        using (var connection = _factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                // Garantir que a fila esteja criada
                channel.QueueDeclare(
                    queue: queue,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                // Publicar a mensagem
                channel.BasicPublish(
                    exchange: string.Empty,
                    routingKey: queue,
                    basicProperties: null,
                    body: message);
            }
        }
    }
}
