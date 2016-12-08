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
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
        public ActionResult Index(int? id)
        {
          
            var catModel = _dbCategory.Get(x=>x.Id==id.Value);
            
            if (catModel == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var catViewModel = new CategoryModel {
                CurrentCategory = catModel,
                ListCategory = _dbCategory.GetAll().ToList(),
                ListProduct = catModel.Products.ToList()

            };
            return View(catViewModel);
        }
    }
}