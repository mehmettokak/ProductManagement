using Product.Admin.ViewModel;
using Product.BAL.Provider;
using Product.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Product.Admin.Controllers
{
    public class ProductFeatureController : Controller
    {
        // GET: ProductFeature
    
        private readonly DbProvider<product> _dbProduct = new DbProvider<product>();
        private readonly DbProvider<ProductFeature> _dbProductFeature = new DbProvider<ProductFeature>();
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var dbprod = _dbProduct.GetById(id.Value);
            var prodModel = new ProductModel();
            prodModel.Id = dbprod.Id;
            prodModel.Name = dbprod.Name;
            prodModel.ProductFeatures = _dbProductFeature.GetAll(x => x.ProductId == id.Value).ToList();



            return View(prodModel);
        }
      public ActionResult Create(int id)
        {
            var dbmodel = _dbProduct.GetById(id);
            var model = new FeatureModel() {
                Product=dbmodel
            };
            return View(model);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Create(int? id,FeatureModel model)
        {
           //inputlar bos olıursa otamatık valıdatıon hatası verılecektir.model.isvalid kontrolune gerek yok
            var dbFeatureProd = new ProductFeature() {
               Name=model.Name,
               Value=model.Value,
               ProductId=id.Value 
            };
            var state = _dbProductFeature.Add(dbFeatureProd);
            if (state)
            {
                TempData["err"] = "İşlem Başarılı";
            }
            return RedirectToAction("Index",new {id= id.Value });
        }
        public ActionResult Edit (int id)
        {
            var dbModel = _dbProductFeature.GetById(id);
            var myModel = new FeatureModel() {
                Id=dbModel.Id,
                Name=dbModel.Name,
                Value=dbModel.Value,
                Product=dbModel.Product
            };
           
            return View(myModel);
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Edit(FeatureModel model)
        {
           
            var myModel = new ProductFeature()
            {
                Id = model.Id,
                Name = model.Name,
                Value = model.Value,
                ProductId=model.Product.Id
            };
            var state = _dbProductFeature.Update(myModel);
            if (state)
            {
                TempData["err"] = "İşlem Başarılı";
            }
           
            return RedirectToAction("Index",new {id=myModel.ProductId });
        }
        public ActionResult Details(int id)
        {
            var dbModel = _dbProductFeature.GetById(id);
            if (dbModel!=null)
            {
                var myModel = new FeatureModel()
                {
                    Id = dbModel.Id,
                    Name = dbModel.Name,
                    Value = dbModel.Value,
                    Product = dbModel.Product
                };
                return View(myModel);
            }
            return View();
           
        }
        public ActionResult Delete (int id)
        {
            
            var dbModel = _dbProductFeature.GetById(id);

            var myModel = new FeatureModel()
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Value = dbModel.Value,
                Product = dbModel.Product
            };
            return View(myModel);
        }
        [HttpPost]
      public ActionResult Delete(FeatureModel model)
        {
            var dbModel = _dbProductFeature.GetById(model.Id);
            var state = _dbProductFeature.Delete(dbModel);
            if (state)
            {
                TempData["err"] = "İşlem Başarılı";
            }
            return RedirectToAction("Index",new { id=model.Product.Id});
        }
    }
}