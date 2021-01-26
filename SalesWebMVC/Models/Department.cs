using System;
using System.Linq;
using System.Collections.Generic;


namespace SalesWebMVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        //Constructors 
        public Department()
        {
        }

        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        // Methods

        /* Adds a new Seller 
         * @param SalesRecord sr
         */
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }


        /* Returns the total sales amount for a given period of time
         * @param DateTime initial, DateTime final
         * @return double total
         */
        public double TotalSales(DateTime initial, DateTime final)
        {
            return this.Sellers.Sum(seller => seller.TotalSales(initial, final));
        }
    }
}
