using Product.BAL.Provider;
using Product.BAL.Tool;
using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Web.Controllers
{

    public class HomeController : Controller
    {
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
       
        public ActionResult Index()
        {
            var catList = _dbCategory.GetAll().ToList();
            
            return View(catList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            

            return View();
        }
    }
}