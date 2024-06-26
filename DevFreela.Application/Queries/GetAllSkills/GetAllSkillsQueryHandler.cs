﻿namespace DevFreela.Application.Queries.GetAllSkills;

public class GetAllSkillsQueryHandler : IRequestHandler<GetAllSkillsQuery, List<SkillDTO>>
{
    private readonly ISkillRepository _skillRepository;

    public GetAllSkillsQueryHandler(ISkillRepository skillRepository)
        => _skillRepository = skillRepository;

    public async Task<List<SkillDTO>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
        => await _skillRepository.GetAllAsync();
}
