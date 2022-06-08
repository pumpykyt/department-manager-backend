using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController : ControllerBase
{
    private readonly IApartmentService _apartmentService;
    
    public ApartmentController(IApartmentService apartmentService)
    {
        _apartmentService = apartmentService;
    }

    [HttpPost]
    public async Task<IActionResult> PostApartment(ApartmentCreateRequest model)
    {
        await _apartmentService.CreateApartmentAsync(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> AddUserToApartment(ApartmentUserRequest model)
    {
        await _apartmentService.AddUserToApartment(model.UserId, model.ApartmentId);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetApartments() 
        => Ok(await _apartmentService.GetApartmentsAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetApartment([FromRoute] string id) 
        => Ok(await _apartmentService.GetApartmentAsync(id));

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetApartmentByUserId([FromRoute] string userId) 
        => Ok(await _apartmentService.GetApartmentByUserId(userId));

    [HttpDelete("user/{userId}")]
    public async Task<IActionResult> DeleteUserFromApartment([FromRoute] string userId)
    {
        await _apartmentService.DeleteUserFromApartmentAsync(userId);
        return Ok();
    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteApartment([FromRoute] string id)
    {
        await _apartmentService.DeleteApartmentAsync(id);
        return Ok();
    }
}