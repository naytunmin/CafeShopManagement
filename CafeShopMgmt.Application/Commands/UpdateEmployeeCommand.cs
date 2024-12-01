using CafeShopMgmt.Application.Dto;
using MediatR;

namespace CafeShopMgmt.Application.Commands
{
    public class UpdateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
    }
}