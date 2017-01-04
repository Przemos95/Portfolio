using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        IProductRepository repository;

        public AdminController(IProductRepository repo)
        {
            repository = repo;
        }

        public ActionResult Index()
        {
            IEnumerable<Product> Products = repository.Products;
            return View(Products);
        }

        public ActionResult Edit(int id)
        {
            Product p = repository.Products
                .FirstOrDefault(s => s.ProductID == id);
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                if (p.ProductID == 0)
                    repository.SaveProduct(p);
                else repository.UpdateProduct(p);

                TempData["message"] = string.Format("Pomyślnie zapisano {0}", p.Name);
                return RedirectToAction("Index");
            }
            else
                return View(p);
        }

        public ActionResult Delete(string name, int id)
        {
            repository.DeleteProduct(id);
            TempData["message"] = string.Format("Usunięto {0}", name);
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View("Edit", new Product());
        }
    }
}