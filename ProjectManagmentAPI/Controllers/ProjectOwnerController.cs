using Business.Dtos;
using Business.Factories;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagmentAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ProjectOwnerController(ProjectOwnerServices ownerServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProjectOwnerAsync([FromBody] ProjectOwnerDto dto)
    {
        var newProject = ProjectFactory.Create(dto);
        await ownerServices.CreateProjectOwnerAsync(newProject);
        return Ok(new { message = "Project Owner saved successfully" });
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProjectOwnerAsync([FromRoute] string id)
    {
        await ownerServices.DeleteAsync(id);
        return Ok(new { message = "Project Owner deleted successfully" });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProjectOwnerAsync([FromBody] ProjectOwnerDto owner, string id)
    {
        await ownerServices.UpdateAsync(owner, id);
        return Ok(new { message = "Project Owner updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var owners = await ownerServices.GetAllAsync();

        return Ok(owners);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        
        var owner = await ownerServices.GetByIdAsync(id);

        return Ok(owner);
    }
}