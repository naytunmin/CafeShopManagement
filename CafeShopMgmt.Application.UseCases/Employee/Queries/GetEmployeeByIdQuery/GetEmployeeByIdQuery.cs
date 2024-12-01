using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.Queries.GetEmployeeByIdQuery
{
    public class GetEmployeeByIdQuery : IRequest<BaseResponse<List<EmployeeDto>>>
    {
        public string? EmployeeId { get; set; }
    }
}
