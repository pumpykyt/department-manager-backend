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

public class ApartmentService : IApartmentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    
    public ApartmentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task CreateApartmentAsync(ApartmentCreateRequest model)
    {
        var entity = _mapper.Map<ApartmentCreateRequest, Apartment>(model);
        entity.Id = Guid.NewGuid().ToString();
        await _context.Apartments.AddAsync(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }

    public async Task<List<ApartmentResponse>> GetApartmentsAsync()
    {
        var entities = await _context.Apartments.Include(t => t.Users).ToListAsync();
        return _mapper.Map<List<Apartment>, List<ApartmentResponse>>(entities);
    }

    public async Task<ApartmentResponse> GetApartmentByUserId(string userId)
    {
        var user = await _context.Users.Include(t => t.Apartment)
                                       .ThenInclude(t => t.Reports)
                                       .Include(t => t.Apartment)
                                       .ThenInclude(t => t.Users)
                                       .SingleOrDefaultAsync(t => t.Id == userId);
        return _mapper.Map<Apartment, ApartmentResponse>(user.Apartment);
    }

    public async Task<ApartmentResponse> GetApartmentAsync(string id)
    {
        var entity = await _context.Apartments.Include(t => t.Users).SingleOrDefaultAsync(t => t.Id == id);
        return _mapper.Map<Apartment, ApartmentResponse>(entity);
    }

    public async Task AddUserToApartment(string userId, string apartmentId)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
        user.ApartmentId = apartmentId;
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }

    public async Task DeleteUserFromApartmentAsync(string userId)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
        user.ApartmentId = null;
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }

    public async Task DeleteApartmentAsync(string id)
    {
        var entity = await _context.Apartments.SingleOrDefaultAsync(t => t.Id == id);
        _context.Apartments.Remove(entity);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
    }
}