using DepartmentManager.Data.Entities;

namespace DepartmentManager.Domain.Models.Responses;

public class ApartmentResponse
{
    public string Id { get; set; }
    public string ApartmentNumber { get; set; }
    public List<UserResponse> Users { get; set; }
}