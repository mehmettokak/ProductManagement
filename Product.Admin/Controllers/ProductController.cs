using Product.Admin.ViewModel;
using Product.BAL.Provider;
using Product.BAL.Tool;
using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Product.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly DbProvider<product> _dbProduct = new DbProvider<product>();
        private readonly DbProvider<Category> _dbCategory = new DbProvider<Category>();
        private readonly DbProvider<ProductImage> _dbProductImage = new DbProvider<ProductImage>();
        // GET: Product
        public ActionResult Index()
        {
            var listModel = new List<ProductModel>();
            ProductModel myModel = null;
            var dbModel = _dbProduct.GetAll().ToList();
            foreach (var item in dbModel)
            {
                myModel = new ProductModel() {
                    Id = item.Id,
                    Name = item.Name,
                    CategoryName = item.Category.Name
                    
                };
                listModel.Add(myModel); 
                
            }

            return View(listModel);
        }
        public ActionResult Create()
        {
            getCategoriList();//dropdownlist için
            return View(new ProductModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model, IEnumerable<HttpPostedFileBase> files)
        {
            var dbmodel = new product()
            {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Name = model.Name
            };

            bool state = _dbProduct.Add(dbmodel);

            var _ip = new ImageProcess();
            var prodImage = new ProductImage();
            string err = "";
            bool state1 = false;
            foreach (var Image in files)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    //file.SaveAs(Path.Combine(Server.MapPath("/Upload"), Guid.NewGuid() + Path.GetExtension(file.FileName)));sunucudakı klasore resmi yukler
                    prodImage.ImageUrl = "/Upload/" + Path.GetFileNameWithoutExtension(Image.FileName) + Path.GetExtension(Image.FileName);
                    prodImage.ProductId = dbmodel.Id;
                    err = _ip.Save(Image, prodImage.ImageUrl);
                   
                     state1=_dbProductImage.Add(prodImage);                      
                }
            }
          
            if (state&&state1&&err=="")
                {
                    TempData["err"] = "İşlem Başarılı";
                }

                return RedirectToAction("Index");
           
        }
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dbProd = _dbProduct.GetById(id.Value);

            if (dbProd == null)//model bos gelirse
            {
                return HttpNotFound();
            }
            var prodModel = new ProductModel() {
                Id = dbProd.Id,
                Name = dbProd.Name,
                CategoryId = dbProd.CategoryId,
                ProductImages=dbProd.ProductImages
               
        };
            getCategoriList(prodModel.CategoryId);//ürün id sine baglı kategori adı ile baslasın 
            return View(prodModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductModel model,IEnumerable<HttpPostedFileBase> files)
        {
            //if (!ModelState.IsValid)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var dbModel = new product() {
                Id = model.Id,
                CategoryId = model.CategoryId,
                Name=model.Name,
              
            };
            bool state=   _dbProduct.Update(dbModel);
            string err = "";
            bool state1 = false;
            var prodImage = new ProductImage();
            var _ip = new ImageProcess();
            foreach (var Image in files)
            {
                if (Image != null && Image.ContentLength > 0)
                {
                    //file.SaveAs(Path.Combine(Server.MapPath("/Upload"), Guid.NewGuid() + Path.GetExtension(file.FileName)));sunucudakı klasore resmi yukler
                    prodImage.ImageUrl = "/Upload/" + Path.GetFileNameWithoutExtension(Image.FileName) + Path.GetExtension(Image.FileName);
                    prodImage.ProductId = model.Id;
                    err = _ip.Save(Image, prodImage.ImageUrl);

                    state1 = _dbProductImage.Add(prodImage);
                }
            }

            if (state && state1 && err == "")
            {
                TempData["err"] = "İşlem Başarılı";
            }
           
            return RedirectToAction("Index");
        }
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dbProd = _dbProduct.GetById(id.Value);

            if (dbProd == null)//model bos gelirse
            {
                return HttpNotFound();
            }
            var prodModel = new ProductModel()
            {
                Id = dbProd.Id,
                Name = dbProd.Name,
                CategoryId = dbProd.CategoryId,
                ProductImages = dbProd.ProductImages,
                CategoryName=dbProd.Category.Name

            };
            return View(prodModel);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var dbProd = _dbProduct.GetById(id.Value);

            if (dbProd == null)//model bos gelirse
            {
                return HttpNotFound();
            }
            var prodModel = new ProductModel()
            {
                Id = dbProd.Id,
                Name = dbProd.Name,
                CategoryId = dbProd.CategoryId,
                ProductImages = dbProd.ProductImages,
                CategoryName = dbProd.Category.Name

            };
            return View(prodModel);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var model = _dbProduct.GetById(id);
                var state = _dbProduct.Delete(model);
                if (state)
                {
                    TempData["err"] = "İşlem Başarılı";
                }
            }
            catch (Exception)
            { }
       
            return RedirectToAction("Index");
        }
        private void getCategoriList(object catg=null)//obje tipinde nesne alıabılır veya bos gelebılır yanı parametre alabılır ,parametre olmasada olur.
        {
            var catList = _dbCategory.GetAll().ToList();
            var selectList = new SelectList(catList,"Id","Name",catg);//catg secili olarak gostermesi icin.eger dolu gelırse
            ViewData.Add("CategoryId", selectList);
        }
    }
}