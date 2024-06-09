namespace DevFreela.Application.Validators;

public class CreateProjectCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateProjectCommentCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .WithMessage("Contéudo é obrigatório");

        RuleFor(x => x.Content)
            .MaximumLength(1000)
            .WithMessage("Tamanho máximo de Contéudo é de 1000 caracteres.");
    }
}
