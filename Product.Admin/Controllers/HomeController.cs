using Product.Admin.ViewModel;
using Product.BAL.Provider;
using Product.Entity.Model;
using System.Data.Entity;
using System.Web.Mvc;

namespace Product.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
        private readonly DbProvider<product> _dbproduct = new DbProvider<product>();
        private readonly DbProvider<ProductImage> _dbProductImage = new DbProvider<ProductImage>();
        private readonly DbProvider<ProductFeature> _dbProductFeature = new DbProvider<ProductFeature>();
        public ActionResult Index()
        {
            var model = new HomePageModel() {
                CategoryCount = _dbCategory.Count(),
                ProductCount = _dbproduct.Count(),
                ProductImageCount = _dbProductImage.Count(),
                ProductFeatureCount = _dbProductFeature.Count()

            };
          
            return View(model);
        }

      
    }
}