using EmployeeManagement.Data.Models.DTOs;
using EmployeeManagement.Data.Models;
using AutoMapper;

namespace EmployeeManagement.Service.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.BirthDate.Year))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName)) // Map Department.Name to DepartmentName
                .ForMember(dest => dest.DesignationName, opt => opt.MapFrom(src => src.Designation.DesignationName)); // Map Designation.Name to DesignationName

            CreateMap<EmployeeDTO, Employee>(); // If you need mapping in reverse (e.g., for updates)

            // PagedResult<Employee> to PagedResult<EmployeeDTO> mapping
            CreateMap<PagedResult<Employee>, PagedResult<EmployeeDTO>>()
                .ForMember(dest => dest.Records, opt => opt.MapFrom(src => src.Records));
                
        }
    }
}
