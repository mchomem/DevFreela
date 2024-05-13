namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int id);
    public Task<int> AddAsync(User user);
    public Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    public Task<User> ChangePasswordAsync(User user, string newPasswordHash);
}
