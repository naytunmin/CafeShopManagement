using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Domain.Entities;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.UpdateEmployeeCommand
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, BaseResponse<bool>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public UpdateEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var db_employee = await _employeeRepository.GetEmployeeByIdAsync(command.Id);
                if(db_employee is not null)
                {
                    var employee = _mapper.Map<Domain.Entities.Employee>(command);
                    if (!db_employee.CafeShopId.HasValue &&
                        !db_employee.StartWorkingDate.HasValue &&
                        command.CafeShopId.HasValue && 
                        command.CafeShopId.Value != Guid.Empty)
                    {
                        employee.StartWorkingDate = DateTime.Now;
                    }
                    else
                    {
                        employee.StartWorkingDate = db_employee.StartWorkingDate;
                    }

                    response.Data = await _employeeRepository.UpdateAsync(employee);

                    if (response.Data)
                    {
                        response.success = true;
                        response.Message = "Employee successfully Update.";
                    }
                    else
                    {
                        response.success = false;
                        response.Message = "Failed to Update employee.";
                    }
                }
                else
                {
                    response.success = false;
                    response.Message = "Employee not found in system.";
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
