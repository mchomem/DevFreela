namespace DevFreela.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        => _mediator = mediator;

    // api/users/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserByIdQuery(id);

        var user = await _mediator.Send(query);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // api/users
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = id }, command);
    }

    [AllowAnonymous]
    [HttpPut("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var loginUserViewModel = await _mediator.Send(command);

        if(loginUserViewModel == null)
            return BadRequest();

        return Ok(loginUserViewModel);
    }
}
