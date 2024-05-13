﻿namespace DevFreela.Application.Commands.CreateProject;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
{
    private readonly IProjectRepository _projectRepository;

    public CreateProjectCommandHandler(IProjectRepository projectRepository)
        => _projectRepository = projectRepository;

    public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
            (
                request.Title,
                request.Description,
                request.IdUser,
                request.IdFreelancer,
                request.TotalCost
            );

        await _projectRepository.AddAsync(project);

        return project.Id;
    }
}
