namespace DevFreela.Application.Commands.UpdateSkill;

public class UpdateSkillCommandHandler : IRequestHandler<UpdateSkillCommand, Unit>
{
    private readonly ISkillRepository _skillRepository;

    public UpdateSkillCommandHandler(ISkillRepository  skillRepository)
        => _skillRepository = skillRepository;

    public async Task<Unit> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        skill.Update(request.Description);

        await _skillRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
