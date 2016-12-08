using Product.BAL.Provider;
using Product.Entity.Model;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Product.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
        public ActionResult Index()
        {
            var categoryList = _dbCategory.GetAll().ToList();
            return View(categoryList);
        }
        #region Category Create
        public ActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _dbCategory.Add(model);
            return Redirect("Index");
        }
        #endregion

        #region Category Edit
        public ActionResult Edit(int? id)
        {
            if (id==null||id==0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _dbCategory.GetById(id.Value);
            if (model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
           
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bool state= _dbCategory.Update(model);
            if (state)
            {
                TempData["err"]= "İşlem Başarılı";
            }
           
            return RedirectToAction("Index");
        }
        #endregion

        #region Category Detail
        public ActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _dbCategory.GetById(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);

            
        }
        #endregion
        #region Category Delete
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _dbCategory.GetById(id.Value);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = _dbCategory.GetById(id);
            bool state = _dbCategory.Delete(model);
            if (state)
            {
                TempData["err"] = "İşlen Başarılı";
            }

            return RedirectToAction("Index");
        }
        #endregion
    }
}