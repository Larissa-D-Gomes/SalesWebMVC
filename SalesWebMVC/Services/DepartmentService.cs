using System.Linq;
using System.Collections.Generic;
using SalesWebMVC.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        // Constructor
        public DepartmentService(SalesWebMVCContext context)
        {
            this._context = context;
        }

        // Methods

        /* Returns a sorted list that contains all the departments from DB
         * @return List<Seller>
         */
        public async Task<List<Department>> FindAllAsync()
        {
            return await this._context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
