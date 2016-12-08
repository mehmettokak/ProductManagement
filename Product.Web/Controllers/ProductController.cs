using Product.BAL.Provider;
using Product.Entity.Model;
using Product.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
        private readonly DbProvider<product> _dbProduct = new DbProvider<product>();
        public ActionResult Index(int? id)
        {
            var prod = _dbProduct.GetById(id.Value);
            if (prod==null)
            {
                return RedirectToAction("Index","Home");
            }
            var prodViewModel = new ProductModel {
                CurrentProduct = prod,
                ListCategory = _dbCategory.GetAll().ToList()
            };
            return View(prodViewModel);
        }
    }
}