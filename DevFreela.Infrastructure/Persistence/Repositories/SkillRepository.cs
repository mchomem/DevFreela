using Dapper;
using DevFreela.Core.DTOs;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

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
