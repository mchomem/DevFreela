namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    public Task<List<SkillDTO>> GetAllAsync();
    public Task<Skill> GetByIdAsync(int id);
    public Task AddAsync(Skill skill);
    public Task SaveChangesAsync();
    public Task DeleteAsync(Skill skill);
}
