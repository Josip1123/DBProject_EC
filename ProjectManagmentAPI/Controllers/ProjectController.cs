using Business.Dtos;
using Business.Factories;
using Business.Services;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController(ProjectService services) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProjectAsync([FromBody] ProjectDto dto)
    {
        var newProject = ProjectFactory.Create(dto);
        await services.CreateProjectAsync(newProject);
        return Ok(new { message = "Project saved successfully" });
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProjectAsync([FromRoute] string id)
    {
        await services.DeleteAsync(id);
        return Ok(new { message = "Project deleted successfully" });
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateProjectAsync([FromBody] ProjectDto project, string id)
    {
        await services.UpdateAsync(project, id);
        return Ok(new { message = "Project updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var projects = await services.GetAllAsync();

        return Ok(projects);
    }
    
}