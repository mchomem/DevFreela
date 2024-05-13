namespace DevFreela.Application.Commands.LoginUserChangePassword;

public class LoginUserChangePasswordCommandHandler : IRequestHandler<LoginUserChangePasswordCommand, UserViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthService _authService;

    public LoginUserChangePasswordCommandHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<UserViewModel> Handle(LoginUserChangePasswordCommand request, CancellationToken cancellationToken)
    {
        var OldPasswordHash = _authService.ComputeSha256Hash(request.OldPassword);

        var userUpdate = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, OldPasswordHash);

        if (userUpdate == null)
            return null;

        var newPasswordHash = _authService.ComputeSha256Hash(request.NewPassword);

        var user = await _userRepository.ChangePasswordAsync(userUpdate, newPasswordHash);

        return new UserViewModel(user.FullName, user.Email);
    }
}
