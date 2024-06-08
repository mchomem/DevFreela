namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;

    public SkillRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DevFreelaCs")!;
    }

    public async Task<List<SkillDTO>> GetAllAsync()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "select Id, Description from Skills";

            var skills = await sqlConnection.QueryAsync<SkillDTO>(script);

            return skills.ToList();
        }
    }

    public async Task<Skill> GetByIdAsync(int id)
    {
        var skill = await _dbContext.Skills
            .SingleOrDefaultAsync(x => x.Id == id)!;

        if (skill == null)
            return null!;

        return skill;
    }

    public async Task AddAsync(Skill skill)
    {
        await _dbContext.Skills.AddAsync(skill);
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Skill skill)
    {
        _dbContext.Skills.Remove(skill);
        await Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}
