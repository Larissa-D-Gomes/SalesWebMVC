using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Services;

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

        public IActionResult Index()
        {
            var list = this._sellerService.FindAll();
            return View(list);
        }
    }
}
