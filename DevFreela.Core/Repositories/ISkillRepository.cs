namespace DevFreela.Core.Repositories;

public interface ISkillRepository
{
    public Task<List<SkillDTO>> GetAllAsync();
}
