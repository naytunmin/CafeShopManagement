using MediatR;
using CafeShopMgmt.Application.Dto;

namespace CafeShopMgmt.Application.Commands
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public char Gender { get; set; }
    }

}
