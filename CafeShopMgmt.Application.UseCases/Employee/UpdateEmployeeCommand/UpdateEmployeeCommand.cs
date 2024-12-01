using CafeShopMgmt.Application.UseCases.Commons.Bases;
using MediatR;

namespace CafeShopMgmt.Application.UseCases.Employee.UpdateEmployeeCommand
{
    public class UpdateEmployeeCommand : IRequest<BaseResponse<bool>>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
        public Guid? CafeShopId { get; set; }
        public bool Status { get; set; }
    }
}
