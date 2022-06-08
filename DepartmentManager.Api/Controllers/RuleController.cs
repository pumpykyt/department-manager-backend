using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RuleController : ControllerBase
{
    private readonly IRuleService _ruleService;
    
    public RuleController(IRuleService ruleService)
    {
        _ruleService = ruleService;
    }

    [HttpPost]
    public async Task<IActionResult> PostRule(RuleCreateRequest model)
    {
        await _ruleService.CreateRuleAsync(model);
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetHouseRules() =>
        Ok(await _ruleService.GetHouseRulesAsync());

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteHouse([FromRoute] string id)
    {
        await _ruleService.DeleteRuleAsync(id);
        return Ok();
    }
}