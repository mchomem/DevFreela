namespace DevFreela.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DevFreelaDbContext _dbContext;

    public UserRepository(DevFreelaDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<User> GetByIdAsync(int id)
        => await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

    public async Task<int> AddAsync(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user.Id;
    }

    public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        => await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == passwordHash);
}
