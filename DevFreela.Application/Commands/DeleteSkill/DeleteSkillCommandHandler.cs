namespace DevFreela.Application.Commands.DeleteSkill;

public class DeleteSkillCommandHandler : IRequestHandler<DeleteSkillCommand>
{
    private readonly ISkillRepository _skillRepository;

    public DeleteSkillCommandHandler(ISkillRepository skillRepository)
        => _skillRepository = skillRepository;

    public async Task<Unit> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        await _skillRepository.DeleteAsync(skill);

        await _skillRepository.SaveChangesAsync();

        return Unit.Value;
    }
}
