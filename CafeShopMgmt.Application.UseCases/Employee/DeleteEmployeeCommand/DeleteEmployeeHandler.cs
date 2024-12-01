using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.DeleteEmployeeCommand
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public DeleteEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(command.EmployeeId);

                if (employee is null)
                {
                    // If employee is not found
                    response.success = false;
                    response.Message = "Employee not found.";
                }
                else
                {
                    employee.Status = false;

                    var updateResult = await _employeeRepository.UpdateAsync(employee);

                    if (updateResult)
                    {
                        response.success = true;
                        response.Message = "Employee successfully deactivated.";
                    }
                    else
                    {
                        response.success = false;
                        response.Message = "Failed to deactivate employee.";
                    }
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
