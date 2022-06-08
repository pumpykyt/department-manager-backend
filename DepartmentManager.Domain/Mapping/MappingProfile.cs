using AutoMapper;
using DepartmentManager.Data.Entities;
using DepartmentManager.Domain.Models.Requests;
using DepartmentManager.Domain.Models.Responses;

namespace DepartmentManager.Domain.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<RuleCreateRequest, Rule>();
        CreateMap<Rule, RuleResponse>();
        CreateMap<ApartmentCreateRequest, Apartment>();
        CreateMap<Apartment, ApartmentResponse>();
        CreateMap<ReportCreateRequest, Report>();
        CreateMap<Report, ReportResponse>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FullName));
        CreateMap<User, UserResponse>();
    }
}