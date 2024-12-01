using MediatR;
using CafeShopMgmt.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using CafeShopMgmt.Application.Commands;
using CafeShopMgmt.Application.Interfaces;

namespace CafeShopMgmt.Application.Handlers
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null) return false;

            await _employeeRepository.DeleteAsync(employee);

            return true;
        }
    }
}
