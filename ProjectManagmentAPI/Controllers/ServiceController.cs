using Business.Dtos;
using Business.Factories;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController(ServiceServices serviceServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateServiceAsync([FromBody] ServiceDto dto)
    {
        var newProject = ProjectFactory.Create(dto);
        await serviceServices.CreateServiceAsync(newProject);
        return Ok(new { message = "Service saved successfully" });
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteServiceAsync([FromRoute] string id)
    {
        await serviceServices.DeleteAsync(id);
        return Ok(new { message = "Service deleted successfully" });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateServiceAsync([FromBody] ServiceDto service, string id)
    {
        await serviceServices.UpdateAsync(service, id);
        return Ok(new { message = "Service updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var owners = await serviceServices.GetAllAsync();

        return Ok(owners);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        
        var owner = await serviceServices.GetByIdAsync(id);

        return Ok(owner);
    }
}