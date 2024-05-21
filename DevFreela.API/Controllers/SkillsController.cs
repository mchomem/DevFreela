namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class SkillsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SkillsController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetAllSkillsQuery();
        
        var skills = await _mediator.Send(query);
        
        return Ok(skills);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetSkillByIdQuery(id);

        var skill = await _mediator.Send(query);
        
        return skill != null ? Ok(skill) : NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }
}
