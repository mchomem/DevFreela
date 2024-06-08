namespace DevFreela.Application.Validators;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand> // "CreateUserCommand" é a classe de entrada de dados, a ser validado.
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty()
            .NotNull()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.FullName)
            .MaximumLength(100)
            .WithMessage("Tamanho máximo do Nome é de 100 caracteres.");

        RuleFor(x => x.Password)
            .Must(CheckValidPassowrd) // Usando um método customizado
            .WithMessage("Senha deve conter pelo menos 8 caracteres, um número, uma letra maíscula, uma minúscula, e um caracteres especial");

        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .WithMessage("E-mail é obrigatório");

        RuleFor(x => x.Email)
            .MaximumLength(100)
            .WithMessage("Tamanho máximo de E-mail é de 100 caracteres.");

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("E-mail inválido!");

        RuleFor(x => x.BirthDate)
            .Must(date => date != DateTime.MinValue)
            .WithMessage("Valor inválido para data. A data não pode ser '01/01/0001'.");

        RuleFor(x => x.Role)
            .NotEmpty()
            .NotNull()
            .WithMessage("Role é obrigatório");

        RuleFor(x => x.Role)
            .MaximumLength(20)
            .WithMessage("Tamanho máximo de Role é de 20 caracteres.");
    }

    public bool CheckValidPassowrd(string password)
    {
        var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

        return regex.IsMatch(password);
    }
}
