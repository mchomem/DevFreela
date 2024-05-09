using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateUser;
using DevFreela.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    //private readonly IUserService _userService;
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
        => _mediator = mediator;

    // api/users/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var query = new GetUserByIdQuery(id);

        var user = await _mediator.Send(query);

        if(user == null)
            return NotFound();

        return Ok(user);
    }
    
    // api/users
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
    {
        var id = await _mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = 1 }, command);
    }

    // api/users/1/login
    [HttpPut("{id}/login")]
    public IActionResult Login(int id, [FromBody] LoginModel login)
    {
        return NoContent();
    }
}
