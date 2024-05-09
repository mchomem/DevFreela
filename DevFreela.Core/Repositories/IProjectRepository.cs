using DevFreela.Core.Entities;

namespace DevFreela.Core.Repositories;

public interface IProjectRepository
{
    public Task<List<Project>> GetAllAsync();
    public Task<Project> GetByIdAsync(int id);
    public Task AddAsync(Project project);
    public Task AddCommentAsync(ProjectComment projectComment);
    public Task StartAsync(Project project);
    public Task SaveChangesAsync();
}
