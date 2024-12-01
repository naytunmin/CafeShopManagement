using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.DeleteEmployeeCommand
{
    public class DeleteEmployeeCommand: IRequest<BaseResponse<bool>>
    {
        public string EmployeeId { get; set; }
    }
}
