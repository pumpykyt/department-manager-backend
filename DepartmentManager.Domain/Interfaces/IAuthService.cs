using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;

namespace DepartmentManager.Domain.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest model);
    Task<AuthResponse> RegisterAsync(RegisterRequest model);
    Task<UserResponse> GetUserAsync(string userId);
    Task<List<UserResponse>> GetUsersAsync();
}