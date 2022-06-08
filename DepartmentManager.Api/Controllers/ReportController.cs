using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReportController : ControllerBase
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpPost]
    public async Task<IActionResult> PostReport(ReportCreateRequest model)
    {
        await _reportService.CreateReportAsync(model);
        return Ok();
    }

    [HttpGet("{apartmentId}")]
    public async Task<IActionResult> GetApartmentReports([FromRoute] string apartmentId) 
        => Ok(await _reportService.GetApartmentReportsAsync(apartmentId));

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetApartmentReportsByUserId([FromRoute] string userId) 
        => Ok(await _reportService.GetApartmentReportsByUserIdAsync(userId));
}