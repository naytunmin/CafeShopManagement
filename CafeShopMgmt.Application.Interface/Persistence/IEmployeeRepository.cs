using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Domain.Entities;

namespace CafeShopMgmt.Application.Interface.Persistence
{
    public interface IEmployeeRepository
    {
        Task<int> CountAsync();

        //Task<List<EmployeeDto>> GetEmployeesAsync(string? CafeShopName, int pageNumber, int pageSize);

        Task<List<EmployeeDto>> GetEmployeesAsync(string? CafeShopName);
        Task<bool> AddAsync(Employee employee);
        Task<bool> UpdateAsync(Employee employee);
        Task<bool> DeleteAsync(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(string EmpId);
        Task<List<Employee>> GetEmployeesByCafeShopIdAsync(Guid cafeShopId);
        Task<bool> UpdateEmployeesAsync(List<Employee> employees);
    }
}
