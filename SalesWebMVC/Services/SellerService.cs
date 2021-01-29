using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;

namespace SalesWebMVC.Services
{
    public class SellerService
    {
        private readonly SalesWebMVCContext _context;

        // Constructor
        public SellerService(SalesWebMVCContext context)
        {
            this._context = context;
        }

        //Methods

        /* Returns a list that contains all the sellers from DB
         * @return List<Seller>
         */
        public List<Seller> FindAll()
        {
            return this._context.Seller.ToList();
        }

        /* Inserts into DB a new seller
         * @param Seller obj
         */
        public void Insert(Seller obj)
        {
            this._context.Add(obj);
            this._context.SaveChanges();      
        }
    }
}
