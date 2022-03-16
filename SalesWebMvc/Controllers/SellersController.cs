using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _sellerService;

        public SellersController(SellerService SellerService) {
            _sellerService = SellerService;
        }

        public IActionResult Index()
        {
            /*
             * Injetamos o service
             * pegamos todos os vendedores no banco e mandamos para view
             */
            var list = _sellerService.FindAll();
            return View(list);
        }
    }
}
