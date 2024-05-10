namespace DevFreela.Infrastructure.Persistence.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly string _connectionString;

    public SkillRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DevFreelaCs");
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
}
