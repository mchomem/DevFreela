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
}
