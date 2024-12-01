using AutoMapper;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeByIdQuery;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeByIdQuery
{
    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, BaseResponse<List<EmployeeDto>>>
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<BaseResponse<List<EmployeeDto>>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<List<EmployeeDto>>();

            try
            {
                var employee = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

                if(employee is not null)
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
