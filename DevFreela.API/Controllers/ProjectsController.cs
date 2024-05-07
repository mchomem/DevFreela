using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public IActionResult Get([FromQuery] string query)
    {
        var projects = _projectService.GetAll(query);

        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var project = _projectService.GetById(id);

        if(project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public IActionResult Post([FromBody] NewProjectInputModel inputModel)
    {
        if(inputModel.Title.Length > 50)
            return BadRequest();

        var id = _projectService.Create(inputModel);

        return CreatedAtAction(nameof(GetById), new { id }, inputModel);
    }

    [HttpPut]
    public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel)
    {
        if (inputModel.Description.Length > 200)
            return BadRequest();

        _projectService.Update(inputModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _projectService.Delete(id);

        return NoContent();
    }

    // api/projects/1/comments
    [HttpPost("{id}/comments")]
    public IActionResult PostComment(int id, [FromBody] CreateCommentInputModel inputModel)
    {
        _projectService.CreateComment(inputModel);
        
        return NoContent();
    }

    // api/projects/1/start
    [HttpPut("{id}/start")]
    public IActionResult Start(int id)
    {
        _projectService.Start(id);

        return NoContent();
    }

    [HttpPut("{id}/finish")]
    // api/projects/1/finish
    public IActionResult Finish(int id)
    {
        _projectService.Finish(id);

        return NoContent();
    }
}
