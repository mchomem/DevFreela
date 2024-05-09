using Dapper;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Infrastructure.Persistence.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly DevFreelaDbContext _dbContext;
    private readonly string _connectionString;

    public ProjectRepository(DevFreelaDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _connectionString = configuration.GetConnectionString("DevFreelaCs");
    }

    public async Task<List<Project>> GetAllAsync()
        => await _dbContext.Projects.ToListAsync();

    public async Task<Project> GetByIdAsync(int id)
    {
        var project = await _dbContext.Projects
                    .Include(x => x.Client)
                    .Include(x => x.Freelancer)
                    .SingleOrDefaultAsync(x => x.Id == id);

        if (project == null)
            return null!;

        return project;
    }

    public async Task AddAsync(Project project)
    {
        await _dbContext.Projects.AddAsync(project);
        await _dbContext.SaveChangesAsync();
    }

    public async Task AddCommentAsync(ProjectComment projectComment)
    {
        await _dbContext.ProjectComments.AddAsync(projectComment);
        await _dbContext.SaveChangesAsync();
    }

    public async Task StartAsync(Project project)
    {
        using (var sqlConnection = new SqlConnection(_connectionString))
        {
            sqlConnection.Open();

            var script = "update Projects set Status = @status, StartedAt = @startedAt where Id = @id";

            await sqlConnection.ExecuteAsync(script, new { status = project.Status, startedAt = project.StartedAt, id = project.Id });
        }
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
