using MediatR;
using CafeShopMgmt.Application.Commands;
using CafeShopMgmt.Application.Dto;
using CafeShopMgmt.Domain.Entities;
using CafeShopMgmt.Infrastructure.Repositories;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using CafeShopMgmt.Application.Interfaces;

namespace CafeShopMgmt.Application.Handlers
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                EmailAddress = request.EmailAddress,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender
            };

            await _employeeRepository.AddAsync(employee);

            // Map the entity to DTO
            return _mapper.Map<EmployeeDto>(employee);
        }

    }  
}
