using Business.Dtos;
using Business.Factories;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(ProjectServices projectServiceses) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectDto dto)
    {
        var newProject = ProjectFactory.Create(dto);
        await projectServiceses.CreateProjectAsync(newProject);
        return Ok(new { message = "Project saved successfully" });
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProjectAsync([FromRoute] string id)
    {
        await projectServiceses.DeleteAsync(id);
        return Ok(new { message = "Project deleted successfully" });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectAsync([FromBody] ProjectDto project, string id)
    {
        await projectServiceses.UpdateAsync(project, id);
        return Ok(new { message = "Project updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var projects = await projectServiceses.GetAllAsync();

        return Ok(projects);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        
        var project = await projectServiceses.GetByIdAsync(id);

        return Ok(project);
    }
    
}