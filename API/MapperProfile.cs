using Application.Dtos;
using AutoMapper;
using Domain;

namespace API
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Department, DepartmentRequest>().ReverseMap();
            CreateMap<Employee, EmployeeRequest>().ReverseMap();
            CreateMap<Project, ProjectRequest>().ReverseMap();
            CreateMap<Employee,EmployeeDepartmentResponse>().ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));
        }
    }
}
