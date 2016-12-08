using Product.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Product.Web.Controllers
{
    public class PdfController : Controller
    {
        // GET: Pdf
        public ActionResult Index()
        {
            return View();
            
        }
     
        public ActionResult Viewer(string path)
        {
            var url = new ViewerModel();
            url.path = path;
            return View(url);

        }
    }
}