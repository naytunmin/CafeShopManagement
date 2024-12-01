using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeQuery
{
    public class GetEmployeeQuery : IRequest<BaseResponse<List<EmployeeDto>>>
    {
        public string? cafeShopName { get; set; }
    }
}
