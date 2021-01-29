using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;
using SalesWebMVC.Models.ViewModels;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        //Contructor 
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            this._sellerService = sellerService;
            this._departmentService = departmentService;
        }

        //Actions
        public IActionResult Index()
        {
            var list = this._sellerService.FindAll();
            return View(list);
        }

        // Create -> GET
        public IActionResult Create()
        {
            var departments = this._departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        // Create -> POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            this._sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        // Delete -> GET
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var obj = _sellerService.FindById(id.Value);

            if(obj == null)
                return NotFound();

            return View(obj);
        }

        // Delete -> POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            this._sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
