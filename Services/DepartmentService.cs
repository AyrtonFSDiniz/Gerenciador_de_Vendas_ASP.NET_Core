using Microsoft.EntityFrameworkCore;
using SaleWebMVC.Data;
using SaleWebMVC.Models;

namespace SaleWebMVC.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly SaleWebMVCContext _context;

        public DepartmentService(SaleWebMVCContext context)
        {
            _context = context;
        }
        
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
