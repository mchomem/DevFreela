namespace DevFreela.Application.Commands.CreateSkill;

public class CreateSkillCommand : IRequest<int>
{
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
}
