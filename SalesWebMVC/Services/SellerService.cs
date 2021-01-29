using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using Microsoft.EntityFrameworkCore;

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

        /* Returns a seller from DB by id
         * @return Seller
         */
        public Seller FindById(int id)
        {
            return this._context.Seller.Include(obj => obj.Department).FirstOrDefault(s => s.Id == id);
        }

        /* Removes a seller from DB by id
         */
        public void Remove(int id)
        {
            var obj = this._context.Seller.Find(id);
            this._context.Seller.Remove(obj);
            this._context.SaveChanges();
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
