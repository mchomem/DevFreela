namespace DevFreela.Application.Commands.DeleteSkill;

public class DeleteSkillCommand : IRequest<Unit>
{
    public DeleteSkillCommand(int id) => Id = id;

    public int Id { get; private set; }
}
