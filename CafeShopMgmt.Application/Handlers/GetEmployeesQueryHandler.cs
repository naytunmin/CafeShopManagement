using MediatR;
using AutoMapper;
using CafeShopMgmt.Application.Dto;
using CafeShopMgmt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CafeShopMgmt.Application.Queries;
using CafeShopMgmt.Application.Interfaces;

namespace CafeShopMgmt.Application.Handlers
{
    public class GetEmployeesQueryHandler : IRequestHandler<GetEmployeesQuery, EmployeeListResponseDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeListResponseDto> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetEmployeesAsync(request.CafeShopName);

            return new EmployeeListResponseDto
            {
                TotalCount = employees.Count,
                Data = employees
            };
        }
    }
}
