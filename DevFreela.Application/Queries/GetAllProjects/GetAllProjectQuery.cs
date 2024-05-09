using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllProjects;

public class GetAllProjectQuery : IRequest<List<ProjectViewModel>>
{
    public GetAllProjectQuery(string query)
        => Query = query;

    public string Query { get; private set; }
}
