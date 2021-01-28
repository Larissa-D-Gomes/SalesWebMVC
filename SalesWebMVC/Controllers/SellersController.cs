using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;
using SalesWebMVC.Models;

namespace SalesWebMVC.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        //Contructor 
        public SellersController(SellerService sellerService)
        {
            this._sellerService = sellerService;
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
            return View();
        }

        // Create -> POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            this._sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}
