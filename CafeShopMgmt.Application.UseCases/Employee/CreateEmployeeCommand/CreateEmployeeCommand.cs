using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.CreateEmployeeCommand
{
    public class CreateEmployeeCommand : IRequest<BaseResponse<bool>>
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public Guid? CafeShopId { get; set; }
    }
}
