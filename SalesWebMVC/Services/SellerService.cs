using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Services.Exceptions;
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
        public async Task<List<Seller>> FindAllAsync()
        {
            return await this._context.Seller.ToListAsync();
        }

        /* Returns a seller from DB by id
         * @return Seller
         */
        public async Task<Seller> FindByIdAsync(int id)
        {
            return await this._context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(s => s.Id == id);
        }

        /* Removes a seller from DB by id
         */
        public async Task RemoveAsync(int id)
        {
            var obj = await this._context.Seller.FindAsync(id);
            this._context.Seller.Remove(obj);
            await this._context.SaveChangesAsync();
        }

        /* Inserts into DB a new seller
         * @param Seller obj
         */
        public async Task InsertAsync(Seller obj)
        {
            this._context.Add(obj);
            await this._context.SaveChangesAsync();      
        }

        /* Updates a seller
         * @param Seller obj
         */
        public async Task UpdateAsync(Seller obj)
        {
            if (! await _context.Seller.AnyAsync(x => x.Id == obj.Id))
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }
        }
    }
}
