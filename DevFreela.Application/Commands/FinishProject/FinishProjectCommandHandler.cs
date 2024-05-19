namespace DevFreela.Application.Commands.FinishProject;

public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, bool>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IPaymentService _paymentService;

    public FinishProjectCommandHandler(IProjectRepository projectRepository, IPaymentService paymentService)
    {
        _projectRepository = projectRepository;
        _paymentService = paymentService;
    }

    public async Task<bool> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.IdProject);

        var paymentInfoDto = new PaymentInfoDto(request.IdProject, request.CreditCardNumber, request.Cvv, request.ExpiresAt, request.FullName, request.Amount);

        _paymentService.ProcessPaymentAsync(paymentInfoDto);
        
        project.SetPaymentPending();

        await _projectRepository.SaveChangesAsync();

        return true;
    }
}
