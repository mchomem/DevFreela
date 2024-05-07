using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Services.Implementations;

public class SkillService : ISkillService
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;

    public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration )
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DevFreelaCs");
    }

    public List<SkillViewModel> GetAll()
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "select Id, Description from Skills";

            return sqlConnection.Query<SkillViewModel>(script).ToList();
        }

        //var skills = _dbContext.Skills;

        //var skillsViewModel = skills
        //    .Select(x => new SkillViewModel(x.Id, x.Description))
        //    .ToList();

        //return skillsViewModel;
    }
}
