namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> Get(string? query)
    {
        var getAllProjectsQuery = new GetAllProjectQuery(query);

        var projects = await _mediator.Send(getAllProjectsQuery);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetProjectByIdQuery(id);

        var project = await _mediator.Send(query);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id}, command);
    }

    [HttpPut]
    public async Task<IActionResult> Put(int id, [FromBody] UpdateProjectCommand command)
    {
        if (command.Description.Length > 200)
            return BadRequest();

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/1/comments
    [HttpPost("{id}/comments")]
    public async Task<IActionResult> PostComment(int id, [FromBody] CreateCommentCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    public async Task<IActionResult> Start(int id)
    {
        var command = new StartProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    // api/projects/1/finish
    public async Task<IActionResult> Finish(int id)
    {
        var command = new FinishProjectCommand(id);

        await _mediator.Send(command);

        return NoContent();
    }
}
