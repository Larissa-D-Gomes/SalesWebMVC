using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Services.Exceptions;
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
                return RedirectToAction(nameof(Error), new { message = "Id not provided"});

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

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

        public IActionResult Details(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });

            var obj = _sellerService.FindById(id.Value);

            if (obj == null)
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            List<Department> departments = this._departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        // Edit -> POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DBConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }
    }
}
