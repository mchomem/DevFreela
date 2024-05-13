namespace DevFreela.Application.Commands.LoginUserChangePassword;

public class LoginUserChangePasswordCommand : IRequest<UserViewModel>
{
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}
