using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Domain.Entities;
using CafeShopMgmt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;

namespace CafeShopMgmt.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
        {
            var count = await _context.Employee.CountAsync();
            return count;
        }

        public async Task<List<EmployeeDto>> GetEmployeesAsync(string? CafeShopName)
        {
            var query = from employee in _context.Employee
                        join cafe in _context.CafeShop on employee.CafeShopId equals cafe.Id into cafes
                        from cafe in cafes.DefaultIfEmpty()
                        where employee.Status == true
                              && (cafe == null || cafe.Status == true)
                        select new
                        {
                            Employee = employee,
                            StartWorkingDate = employee.StartWorkingDate,
                            CafeShopName = cafe != null ? cafe.Name : null,
                        };


            if (!string.IsNullOrWhiteSpace(CafeShopName))
            {
                query = query.Where(x => x.CafeShopName != null && x.CafeShopName.ToLower().Contains(CafeShopName.ToLower()));
            }

            var rawData = await query.ToListAsync();

            var employees = rawData
                .Select(x => new EmployeeDto
                {
                    Id = x.Employee.Id,
                    Name = x.Employee.Name,
                    EmailAddress = x.Employee.EmailAddress,
                    PhoneNumber = x.Employee.PhoneNumber,
                    DaysWorked = x.StartWorkingDate.HasValue
                        ? (int)(DateTime.Now - x.StartWorkingDate.Value).TotalDays
                        : 0,
                    CafeShopName = x.CafeShopName,
                    Gender = x.Employee.Gender,
                    Status = x.Employee.Status,
                    CafeShopId = x.Employee.CafeShopId
                })
                .OrderByDescending(x => x.DaysWorked)
                .ToList();

            return employees;
        }

        //public async Task<List<EmployeeDto>> GetEmployeesAsync(string? CafeShopName, int pageNumber, int pageSize)
        //{
        //    var query = from employee in _context.Employee
        //                join cafe in _context.CafeShop on employee.CafeShopId equals cafe.Id into cafes
        //                from cafe in cafes.DefaultIfEmpty()
        //                where employee.Status == true
        //                      && (cafe == null || cafe.Status == true)
        //                select new
        //                {
        //                    Employee = employee,
        //                    StartWorkingDate = employee.StartWorkingDate,
        //                    CafeShopName = cafe != null ? cafe.Name : null,
        //                };

        //    if (!string.IsNullOrWhiteSpace(CafeShopName))
        //    {
        //        query = query.Where(x => x.CafeShopName != null && x.CafeShopName.ToLower().Contains(CafeShopName.ToLower()));
        //    }

        //    var rawData = await query
        //        .Skip((pageNumber - 1) * pageSize)  // Skip records based on page number
        //        .Take(pageSize)  // Take only the number of records as defined by pageSize
        //        .ToListAsync();

        //    var employees = rawData
        //        .Select(x => new EmployeeDto
        //        {
        //            Id = x.Employee.Id,
        //            Name = x.Employee.Name,
        //            EmailAddress = x.Employee.EmailAddress,
        //            PhoneNumber = x.Employee.PhoneNumber,
        //            DaysWorked = x.StartWorkingDate.HasValue
        //                ? (int)(DateTime.Now - x.StartWorkingDate.Value).TotalDays
        //                : 0,
        //            CafeShopName = x.CafeShopName,
        //            Status = x.Employee.Status,
        //            CafeShopId = x.Employee.CafeShopId
        //        })
        //        .OrderByDescending(x => x.DaysWorked)
        //        .ToList();

        //    return employees;
        //}



        public async Task<Employee> GetEmployeeByIdAsync(string EmpId)
        {
            Employee? employee = null;
            try
            {            
                employee = await _context.Employee.AsNoTracking().SingleOrDefaultAsync(e => e.Id == EmpId);
            }
            catch (Exception)
            {
                return employee;
            }
          
            return employee;
        }

        public async Task<bool> AddAsync(Employee employee)
        {
            try
            {
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;  
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public async Task<bool> UpdateAsync(Employee employee)
        {
            try
            {
                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
         
        }

        public async Task<List<Employee>> GetEmployeesByCafeShopIdAsync(Guid cafeShopId)
        {
            return await _context.Employee.Where(e => e.CafeShopId == cafeShopId).ToListAsync();
        }

        public async Task<bool> UpdateEmployeesAsync(List<Employee> employees)
        {
            try
            {
                _context.Employee.UpdateRange(employees);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(Employee employee)
        {
            try
            {
                _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
