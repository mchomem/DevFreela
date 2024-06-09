namespace DevFreela.Application.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .WithMessage("Título é obrigatório");

        RuleFor(x => x.Title)
            .MaximumLength(50)
            .WithMessage("Tamanho máximo de Título é de 50 caracteres.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull()
            .WithMessage("Descrição é obrigatório");

        RuleFor(x => x.Description)
            .MaximumLength(3000)
            .WithMessage("Tamanho máximo de Descrição é de 3000 caracteres.");

        RuleFor(x => x.TotalCost)
            .Must(CheckFirstDecimalDigit)
            .WithMessage("O valor antes da vírgula deve ter até 18 dígitos.");

        RuleFor(x => x.TotalCost)
            .Must(CheckSecondDecimalDigit)
            .WithMessage("O valor depois da vírgula deve ter até 2 dígitos");
    }

    private bool CheckFirstDecimalDigit(decimal value)
    {
        string[] decimalParts = value.ToString().Split(',');

        string decimalPart1 = decimalParts[0];

        if (decimalPart1.Length <= 18) return true;

        return false;
    }
    
    private bool CheckSecondDecimalDigit(decimal value)
    {
        string[] decimalParts = value.ToString().Split(',');

        string decimalPart2 = decimalParts[1];

        if (decimalPart2.Length <= 2) return true;

        return false;
    }
}
