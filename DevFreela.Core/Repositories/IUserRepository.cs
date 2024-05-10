namespace DevFreela.Core.Repositories;

public interface IUserRepository
{
    public Task<User> GetByIdAsync(int id);
    public Task<int> AddAsync(User user);
}
