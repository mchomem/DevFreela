using DevFreela.Application.ViewModels;
using DevFreela.Core.Repositories;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectQueryHandler : IRequestHandler<GetAllProjectQuery, List<ProjectViewModel>>
{
    private readonly IProjectRepository _projectRepository;

    public GetAllProjectQueryHandler(IProjectRepository projectRepository)
        => _projectRepository = projectRepository;

    public async Task<List<ProjectViewModel>> Handle(GetAllProjectQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectRepository.GetAllAsync();

        var projectsViewModel =  projects
            .Select(x => new ProjectViewModel(x.Id, x.Title, x.CreatedAt))
            .ToList();

        return projectsViewModel;
    }
}
