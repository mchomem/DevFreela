namespace DevFreela.Core.Services;

public interface IPaymentService
{
    void ProcessPaymentAsync(PaymentInfoDto paymentInfoDto);
}
