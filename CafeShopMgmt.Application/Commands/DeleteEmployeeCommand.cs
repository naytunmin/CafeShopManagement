using MediatR;

namespace CafeShopMgmt.Application.Commands
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteEmployeeCommand(string id)
        {
            Id = id;
        }
    }
}
