using Business.Dtos;
using Business.Factories;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagmentAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController(CustomerServices customerServices) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateCustomerAsync([FromBody] CustomerDto dto)
    {
        var newProject = ProjectFactory.Create(dto);
        await customerServices.CreateCustomerAsync(newProject);
        return Ok(new { message = "Customer saved successfully" });
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteCustomerAsync([FromRoute] string id)
    {
        await customerServices.DeleteAsync(id);
        return Ok(new { message = "Customer deleted successfully" });
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomerAsync([FromBody] CustomerDto customer, string id)
    {
        await customerServices.UpdateAsync(customer, id);
        return Ok(new { message = "Customer updated successfully" });
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        
        var owners = await customerServices.GetAllAsync();

        return Ok(owners);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetAsync([FromRoute] string id)
    {
        
        var owner = await customerServices.GetByIdAsync(id);

        return Ok(owner);
    }
}