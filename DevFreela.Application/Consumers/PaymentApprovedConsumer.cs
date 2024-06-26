﻿namespace DevFreela.Application.Consumers;

public class PaymentApprovedConsumer : BackgroundService
{
    private const string PAYMENT_APPROVED_QUEUE = "PaymentsApproved";
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly IServiceProvider _serviceProvider;

    public PaymentApprovedConsumer(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        _serviceProvider = serviceProvider;

        var factory = new ConnectionFactory
        {
            HostName = configuration.GetSection("RabbitMQ:HostName").Value,
            Port = Convert.ToInt32(configuration.GetSection("RabbitMQ:Port").Value),
            UserName = configuration.GetSection("RabbitMQ:UserName").Value,
            Password = configuration.GetSection("RabbitMQ:Password").Value,
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: PAYMENT_APPROVED_QUEUE,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (sender, eventArgs) =>
        {
            var paymentApprovedBytes = eventArgs.Body.ToArray();
            var paymentApprovedJson = Encoding.UTF8.GetString(paymentApprovedBytes);
            var paymentApprovedIntegrationEvent = JsonSerializer.Deserialize<PaymentApprovedIntegrationEvent>(paymentApprovedJson);

            await FinishProject(paymentApprovedIntegrationEvent.IdProject);

            _channel.BasicAck(eventArgs.DeliveryTag, false);
        };

        _channel.BasicConsume(PAYMENT_APPROVED_QUEUE, false, consumer);

        return Task.CompletedTask;
    }

    public async Task FinishProject(int id)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var projectRepository = scope.ServiceProvider.GetRequiredService<IProjectRepository>();

            var project = await projectRepository.GetByIdAsync(id);

            project.Finish();

            await projectRepository.SaveChangesAsync();
        }
    }
}
