namespace DevFreela.Application.Commands.CreateComment;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit> // o Unit representa que não será retornado nada (void)
{
    private readonly IProjectRepository _projectRepository;

    public CreateCommentCommandHandler(IProjectRepository projectRepository)
        => _projectRepository = projectRepository;

    public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

        await _projectRepository.AddCommentAsync(comment);

        return Unit.Value;
    }
}
