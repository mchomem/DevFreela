namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> // "CreateUserCommand" é a classe de entrada de dados, a ser validado.
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido!");

        RuleFor(x => x.Password)
            .Must(ValidPassowrd) // Usando um método customizado
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maíscula, uma minúscula, e um caracteres especial");

        RuleFor(x => x.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório");
    }

    public bool ValidPassowrd(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
