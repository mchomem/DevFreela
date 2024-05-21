namespace DevFreela.Application.Queries.GetSkillById;

public class GetSkillByIdQueryHandler : IRequestHandler<GetSkillByIdQuery, SkillDetailsViewModel>
{
    private readonly ISkillRepository _skillRepository;

    public GetSkillByIdQueryHandler(ISkillRepository skillRepository)
        => _skillRepository = skillRepository;

    public async Task<SkillDetailsViewModel> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id);

        var skillDetailViewModel = new SkillDetailsViewModel
            (
                skill.Id,
                skill.Description,
                skill.CreatedAt
            );

        return skillDetailViewModel;
    }
}
