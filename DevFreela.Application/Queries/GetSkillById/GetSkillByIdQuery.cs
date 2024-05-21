namespace DevFreela.Application.Queries.GetSkillById;

public class GetSkillByIdQuery : IRequest<SkillDetailsViewModel>
{
    public GetSkillByIdQuery(int id) => Id = id;

    public int Id { get; private set; }
}
