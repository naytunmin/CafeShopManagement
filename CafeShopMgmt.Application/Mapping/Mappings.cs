using AutoMapper;
using CafeShopMgmt.Application.Dto;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.Mapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();  // Mapping from Entity to DTO

        }
    }
}
