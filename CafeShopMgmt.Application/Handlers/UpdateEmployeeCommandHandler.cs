using MediatR;
using CafeShopMgmt.Application.Dto;
using CafeShopMgmt.Application.Interfaces;
using CafeShopMgmt.Domain.Entities;
using CafeShopMgmt.Infrastructure.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CafeShopMgmt.Application.Commands;

namespace CafeShopMgmt.Application.Handlers
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null) return null;

            // Update employee properties
            employee.Name = request.Name;
            employee.EmailAddress = request.EmailAddress;
            employee.PhoneNumber = request.PhoneNumber;
            employee.Gender = request.Gender;

            await _employeeRepository.UpdateAsync(employee);

            // Map to DTO and return
            return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
