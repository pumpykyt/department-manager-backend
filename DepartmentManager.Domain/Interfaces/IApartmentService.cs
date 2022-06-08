using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;

namespace DepartmentManager.Domain.Interfaces;

public interface IApartmentService
{
    Task CreateApartmentAsync(ApartmentCreateRequest model);
    Task<List<ApartmentResponse>> GetApartmentsAsync();
    Task<ApartmentResponse> GetApartmentByUserId(string userId);
    Task<ApartmentResponse> GetApartmentAsync(string id);
    Task AddUserToApartment(string userId, string apartmentId);
    Task DeleteUserFromApartmentAsync(string userId);
    Task DeleteApartmentAsync(string id);
}