namespace DevFreela.Application.Validators;

public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectCommandValidator()
    {
        RuleFor(x => x.Description)
            .MaximumLength(255)
            .WithMessage("Tamanho máximo de Descrição é de 255 caracteres.");

        RuleFor(x => x.Title)
            .MaximumLength(30)
            .WithMessage("Tamanho máximo de Título é de 30 caracteres.");
    }
}
