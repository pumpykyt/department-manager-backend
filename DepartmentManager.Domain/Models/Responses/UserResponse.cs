﻿namespace DepartmentManager.Domain.Models.Responses;

public class UserResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FullName { get; set; }
    public string ApartmentId { get; set; }
}