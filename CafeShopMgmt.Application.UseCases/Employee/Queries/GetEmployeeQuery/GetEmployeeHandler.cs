using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeQuery
{
    public class GetEmployeeHandler : IRequestHandler<GetEmployeeQuery, BaseResponse<List<EmployeeDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<List<EmployeeDto>>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<EmployeeDto>>();

            try
            {
                var employee = await _employeeRepository.GetEmployeesAsync(request.cafeShopName);

                if (employee is not null)
                {
                    response.Data = _mapper.Map<List<EmployeeDto>>(employee);
                    response.success = true;
                    response.Message = "succeed";
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
