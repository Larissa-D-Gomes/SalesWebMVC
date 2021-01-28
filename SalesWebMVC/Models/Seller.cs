using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public double BaseSalary { get; set; }
        public DateTime BirthDate { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        //Constructor
        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.BaseSalary = baseSalary;
            this.BirthDate = birthDate;
            this.Department = department;
        }

        // Methods

        /* Adds a new Sale Record 
         * @param SalesRecord sr
         */
        public void AddSale(SalesRecord sr)
        {
            this.Sales.Add(sr);
        }

        /* Removes a new Sale Record 
         * @param SalesRecord sr
         */
        public void AddRemove(SalesRecord sr)
        {
            this.Sales.Remove(sr);
        }

        /* Returns the total sales amount for a given period of time
         * @param DateTime initial, DateTime final
         * @return double total
         */
        public double TotalSales(DateTime initial, DateTime final)
        {
            return this.Sales.Where(p => initial <= p.Date && p.Date <= final).Sum(sr => sr.Amount);
        }
    }
}
