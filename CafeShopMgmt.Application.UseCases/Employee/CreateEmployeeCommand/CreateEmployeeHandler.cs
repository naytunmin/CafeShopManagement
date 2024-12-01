using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Domain.Entities;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.CreateEmployeeCommand
{
    public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var employee = _mapper.Map<Domain.Entities.Employee>(command);

                employee.Id = GenerateEmployeeId();
                employee.Status = true;

                if (command.CafeShopId.HasValue && command.CafeShopId.Value != Guid.Empty)
                {
                   employee.StartWorkingDate = DateTime.Now;
                }

                response.Data = await _employeeRepository.AddAsync(employee);

                if (response.Data)
                {
                    response.success = true;
                    response.Message = "Employee successfully create.";
                }
                else
                {
                    response.success = false;
                    response.Message = "Failed to create employee.";
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        private string GenerateEmployeeId()
        {
            var prefix = "UI";
            var dateTimePart = DateTime.Now.ToString("HHmmss");
            var random = new Random();
            var randomPart = random.Next(0, 9);
            return $"{prefix}{dateTimePart}{randomPart}";
        }
    }
}
