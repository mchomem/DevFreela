namespace DevFreela.Core.Services;

public interface IPaymentService
{
    Task<bool> ProcessPaymentAsync(PaymentInfoDto paymentInfoDto);
}
