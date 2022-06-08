using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;

namespace DepartmentManager.Domain.Interfaces;

public interface IReportService
{
    Task CreateReportAsync(ReportCreateRequest model);
    Task<List<ReportResponse>> GetApartmentReportsAsync(string apartmentId);
    Task<List<ReportResponse>> GetApartmentReportsByUserIdAsync(string userId);
}