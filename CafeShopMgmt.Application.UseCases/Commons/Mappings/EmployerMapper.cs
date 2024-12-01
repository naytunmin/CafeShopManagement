using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.Employee.CreateEmployeeCommand;
using CafeShopMgmt.Application.UseCases.Employee.UpdateEmployeeCommand;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.UseCases.Commons.Mappings
{
    public class EmployerMapper: Profile
    {
        public EmployerMapper()
        {
            CreateMap<Domain.Entities.Employee, EmployeeDto>().ReverseMap();
            CreateMap<Domain.Entities.Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Domain.Entities.Employee, UpdateEmployeeCommand>().ReverseMap();
        }
    }
}
