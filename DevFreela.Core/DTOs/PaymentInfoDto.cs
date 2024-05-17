namespace DevFreela.Core.DTOs;

public class PaymentInfoDto
{
    public PaymentInfoDto(int id, string creditCardNumber, string cvv, string expiresAt, string fullName, decimal amount)
    {
        Id = id;
        CreditCardNumber = creditCardNumber;
        Cvv = cvv;
        ExpiresAt = expiresAt;
        FullName = fullName;
        Amount = amount;
    }

    public int Id { get; private set; }
    public string CreditCardNumber { get; private set; }
    public string Cvv { get; private set; }
    public string ExpiresAt { get; private set; }
    public string FullName { get; private set; }
    public decimal Amount { get; private set; }
}
