using Microsoft.AspNetCore.Mvc;
using SaleWebMVC.Models;

namespace SaleWebMVC.Services
{
    public interface IDepartmentService
    {
        Task<List<Department>> FindAllAsync();
    }
}
