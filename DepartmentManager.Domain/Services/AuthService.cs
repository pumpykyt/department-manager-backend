using System.Net;
using AutoMapper;
using DepartmentManager.Data;
using DepartmentManager.Data.Entities;
using DepartmentManager.Domain.Configs;
using DepartmentManager.Domain.Exceptions;
using DepartmentManager.Domain.Helpers;
using DepartmentManager.Domain.Interfaces;
using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DepartmentManager.Domain.Services;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly JwtConfig _jwtConfig;
    private readonly IMapper _mapper;
    
    public AuthService(DataContext context, IOptions<JwtConfig> options, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _jwtConfig = options.Value;
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Email == model.Email);
        if (user is null) throw new HttpException(HttpStatusCode.Unauthorized);
        var isVerified = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
        if (!isVerified) throw new HttpException(HttpStatusCode.Unauthorized, "Wrong credentials");
        var jwt = JwtHelper.GenerateJwt(user.Id, user.Email, user.Role, _jwtConfig);
        return new AuthResponse { Token = jwt };
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(t => t.Email == model.Email);
        if(user is not null) throw new HttpException(HttpStatusCode.Conflict);
        var newUser = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = model.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
            FullName = model.FullName,
            Role = "user"
        };
        await _context.Users.AddAsync(newUser);
        var result = await _context.SaveChangesAsync();
        if (result == 0) throw new HttpException(HttpStatusCode.InternalServerError);
        var jwt = JwtHelper.GenerateJwt(newUser.Id, newUser.Email, newUser.Role, _jwtConfig);
        return new AuthResponse { Token = jwt };
    }

    public async Task<UserResponse> GetUserAsync(string userId)
    {
        var entity = await _context.Users.SingleOrDefaultAsync(t => t.Id == userId);
        return _mapper.Map<User, UserResponse>(entity);
    }

    public async Task<List<UserResponse>> GetUsersAsync()
    {
        var entities = await _context.Users.ToListAsync();
        return _mapper.Map<List<User>, List<UserResponse>>(entities);
    }
}