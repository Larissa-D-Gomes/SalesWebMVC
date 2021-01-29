using System.Linq;
using System.Collections.Generic;
using SalesWebMVC.Models;

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
        public List<Department> FindAll()
        {
            return this._context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
