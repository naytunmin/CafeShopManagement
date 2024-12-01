using CafeShopMgmt.Application.Interface.Persistence;
using CafeShopMgmt.Application.dto;
using CafeShopMgmt.Domain.Entities;
using CafeShopMgmt.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CafeShopMgmt.Infrastructure.Repositories
{
    public class CafeShopRepository : ICafeShopRepository
    {
        private readonly ApplicationDbContext _context;

        public CafeShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CafeShopDto>> GetCafeShopAsync(string? location)
        {
            var query = from cafe in _context.CafeShop
                        join employee in _context.Employee on cafe.Id equals employee.CafeShopId into employees
                        from employee in employees.DefaultIfEmpty()
                        where cafe.Status == true
                        group employee by new
                        {
                            cafe.Id,
                            cafe.Name,
                            cafe.Description,
                            cafe.Logo,
                            cafe.Location
                        } into grouped
                        select new
                        {
                            CafeId = grouped.Key.Id,
                            CafeName = grouped.Key.Name,
                            Description = grouped.Key.Description,
                            Logo = grouped.Key.Logo,
                            Location = grouped.Key.Location,
                            EmployeeCount = grouped.Count(e => e != null && e.Status == true)
                        };

            if (!string.IsNullOrWhiteSpace(location))
            {
                query = query.Where(c => c.Location != null && c.Location.ToLower().Contains(location.ToLower()));
            }
            
            var cafes = await query.ToListAsync();

            if (!string.IsNullOrWhiteSpace(location) && !cafes.Any())
            {
                return new List<CafeShopDto>();
            }

            var result = cafes
                .Select(c => new CafeShopDto
                {
                    Id = c.CafeId,
                    Name = c.CafeName,
                    Description = c.Description,
                    Logo = c.Logo,
                    Location = c.Location,
                    EmployeeCount = c.EmployeeCount,
                    Status = true
                })
                .OrderByDescending(c => cafes.First(x => x.CafeId == c.Id).EmployeeCount)
                .ToList();

            return result;
        }

        public async Task<CafeShop> GetCafeShopByIdAsync(Guid shopId)
        {
            CafeShop? cafeShop = null;
            try
            {
                cafeShop = await _context.CafeShop.AsNoTracking().SingleOrDefaultAsync(e => e.Id == shopId);
            }
            catch (Exception)
            {
                return cafeShop;
            }
          
            return cafeShop;
        }

        public async Task<bool> AddAsync(CafeShop cafeShop)
        {
            try
            {
                await _context.CafeShop.AddAsync(cafeShop);
                await _context.SaveChangesAsync();
                return true;  
            }
            catch (Exception)
            {
                return false; 
            }
        }

        public async Task<bool> UpdateAsync(CafeShop cafeShop)
        {
            try
            {
                _context.CafeShop.Update(cafeShop);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }    
        }

        public async Task<bool> DeleteAsync(CafeShop cafeShop)
        {
            try
            {
                _context.CafeShop.Remove(cafeShop);
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
