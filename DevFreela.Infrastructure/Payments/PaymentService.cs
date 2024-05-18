namespace DevFreela.Infrastructure.Payments;

public class PaymentService : IPaymentService
{
    private readonly IMessageBusService _messageBusService;
    private const string QUEUE_NAME = "Payments";

    public PaymentService(IMessageBusService messageBusService)
    {
        _messageBusService = messageBusService;
    }

    public void ProcessPaymentAsync(PaymentInfoDto paymentInfoDto)
    {
        var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDto);

        var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

        _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
    }
}
