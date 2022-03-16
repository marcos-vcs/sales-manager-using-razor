using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
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

        public IActionResult Create() 
        {
            return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //protege contra ataque csrs que visa usar o token de sessao para fazer requisicoes a aplicacao
        public IActionResult Create(Seller seller)
        {
            _sellerService.Inser(seller);
            return RedirectToAction(nameof(Index));
        }


    }
}
