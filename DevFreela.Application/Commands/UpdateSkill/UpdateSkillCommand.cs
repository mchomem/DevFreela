namespace DevFreela.Application.Commands.UpdateSkill;

public class UpdateSkillCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Description { get; set; }
}
