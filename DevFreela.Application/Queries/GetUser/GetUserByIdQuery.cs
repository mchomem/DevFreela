namespace DevFreela.Application.Queries.GetUser;

public class GetUserByIdQuery : IRequest<UserViewModel>
{
    public GetUserByIdQuery(int id)
        => Id = id;

    public int Id { get; private set; }
}
