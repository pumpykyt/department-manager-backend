namespace DepartmentManager.Domain.Models.Requests;

public class ReportCreateRequest
{
    public string Text { get; set; }
    public string UserId { get; set; }
    public string ApartmentId { get; set; }
}