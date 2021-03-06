﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SalesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [Range(100.0, 50000.0, ErrorMessage = "{0} must be from {1} to {2}")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString ="$ {0:F2}")]
        public double BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} required.")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
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
