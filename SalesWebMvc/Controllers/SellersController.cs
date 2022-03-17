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
        private readonly DepartamentService _departamentService;

        public SellersController(SellerService SellerService, DepartamentService DepartamentService) {
            _sellerService = SellerService;
            _departamentService = DepartamentService;
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
            var departaments = _departamentService.FindAll();
            var ViewModel = new SellerFormViewModel { Departaments = departaments };
            return View(ViewModel);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //protege contra ataque csrs que visa usar o token de sessao para fazer requisicoes a aplicacao
        public IActionResult Create(Seller seller)
        {
            _sellerService.Inser(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);


        }


    }
}
