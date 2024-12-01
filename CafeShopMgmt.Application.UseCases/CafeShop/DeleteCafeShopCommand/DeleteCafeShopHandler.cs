using AutoMapper;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.CafeShop.DeleteCafeShopCommand
{
    public class DeleteCafeShopHandler: IRequestHandler<DeleteCafeShopCommand, BaseResponse<bool>>
    {
        private readonly ICafeShopRepository _cafeShopRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public DeleteCafeShopHandler(
            ICafeShopRepository cafeShopRepository,
            IEmployeeRepository employeeRepository,
            IMapper mapper)
        {
            _cafeShopRepository = cafeShopRepository ?? throw new ArgumentNullException(nameof(cafeShopRepository));
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<bool>> Handle(DeleteCafeShopCommand command, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var cafeShop = await _cafeShopRepository.GetCafeShopByIdAsync(command.cafeShopId);

                if (cafeShop is null)
                {
                    // If employee is not found
                    response.success = false;
                    response.Message = "Cafe Shop not found.";
                }
                else
                {
                    cafeShop.Status = false;

                    var updateResult = await _cafeShopRepository.UpdateAsync(cafeShop);

                    if (updateResult)
                    {
                        // Deactivate all Employees linked to the CafeShop
                        var employees = await _employeeRepository.GetEmployeesByCafeShopIdAsync(command.cafeShopId);
                        foreach (var employee in employees)
                        {
                            employee.Status = false;
                        }

                        var updateEmployeesResult = await _employeeRepository.UpdateEmployeesAsync(employees);

                        if (updateEmployeesResult)
                        {
                            response.success = true;
                            response.Message = "Cafe Shop successfully deactivated.";
                        }
                        else
                        {
                            response.success = false;
                            response.Message = "Failed to deactivate Cafe Shop.";
                        }                        
                    }
                    else
                    {
                        response.success = false;
                        response.Message = "Failed to deactivate Cafe Shop.";
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
