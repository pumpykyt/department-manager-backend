using System.Net;
using AutoMapper;
using DepartmentManager.Data;
using DepartmentManager.Data.Entities;
using DepartmentManager.Domain.Exceptions;
using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace DepartmentManager.Domain.Services;

public class RuleService : IRuleService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RuleService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateRuleAsync(RuleCreateRequest model)
    {
        var entity = _mapper.Map<RuleCreateRequest, Rule>(model);
        entity.Id = Guid.NewGuid().ToString();
        await _context.Rules.AddAsync(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }

    public async Task<List<RuleResponse>> GetHouseRulesAsync()
    {
        var entities = await _context.Rules.ToListAsync();
        return _mapper.Map<List<Rule>, List<RuleResponse>>(entities);
    }

    public async Task DeleteRuleAsync(string id)
    {
        var entity = await _context.Rules.SingleOrDefaultAsync(t => t.Id == id);
        _context.Rules.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }
}