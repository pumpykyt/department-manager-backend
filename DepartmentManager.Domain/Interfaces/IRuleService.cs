using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;

namespace DepartmentManager.Domain.Interfaces;

public interface IRuleService
{
    Task CreateRuleAsync(RuleCreateRequest model);
    Task<List<RuleResponse>> GetHouseRulesAsync();
    Task DeleteRuleAsync(string id);
}