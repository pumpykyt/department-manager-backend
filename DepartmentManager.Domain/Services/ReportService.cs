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

public class ReportService : IReportService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public ReportService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateReportAsync(ReportCreateRequest model)
    {
        var entity = _mapper.Map<ReportCreateRequest, Report>(model);
        entity.Id = Guid.NewGuid().ToString();
        await _context.Reports.AddAsync(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }

    public async Task<List<ReportResponse>> GetApartmentReportsAsync(string apartmentId)
    {
        var entities = await _context.Reports.Include(t => t.User)
                                             .Where(t => t.ApartmentId == apartmentId)
                                             .ToListAsync();
        return _mapper.Map<List<Report>, List<ReportResponse>>(entities);
    }

    public async Task<List<ReportResponse>> GetApartmentReportsByUserIdAsync(string userId)
    {
        var user = await _context.Users.Include(t => t.Apartment)
                                       .ThenInclude(t => t.Reports)
                                       .SingleOrDefaultAsync(t => t.Id == userId);
        return _mapper.Map<List<Report>, List<ReportResponse>>(user.Apartment.Reports.ToList());
    }
}