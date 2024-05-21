namespace DevFreela.Application.Commands.CreateSkill;

public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand, int>
{
    private readonly ISkillRepository _skillRepository;

    public CreateSkillCommandHandler(ISkillRepository skillRepository)
        => _skillRepository = skillRepository;

    public async Task<int> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new Skill(request.Description);

        await _skillRepository.AddAsync(skill);

        return skill.Id;
    }
}
