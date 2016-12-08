using Product.Admin.Models;
using Product.BAL.Tool;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Product.Admin.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files

        public ActionResult Index()
        {
            return View();
        }
        private string _StorageRoot;
        private string StorageRoot
        {
            get
            {
                if (_StorageRoot == null)
                    _StorageRoot = Path.Combine(Server.MapPath("~/" + ConfigurationManager.AppSettings["DIR_FILE_UPLOADS"]));
                return _StorageRoot;
            }
        }
        
        [HttpPost]
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Uploads()
        {
            var fileData = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                UploadWholeFile(Request, fileData);
            }

            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;

            var result = new ContentResult
            {
                Content = "{\"files\":" + serializer.Serialize(fileData) + "}",
            };
            return result;
        }

        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                HttpPostedFileBase file = request.Files[i];

                var fileId = Guid.NewGuid();
                var fileName = Path.GetFileName(file.FileName);
                var fileNameEncoded = HttpUtility.HtmlEncode(fileName);
                var fullPath = Path.Combine(StorageRoot, fileId + "-" + fileName);

                file.SaveAs(fullPath);

                statuses.Add(new ViewDataUploadFilesResult()
                {
                    url = "/Upload/" + fileId + "-" + fileNameEncoded,
                    thumbnail_url = "/Upload/" + fileId + "-" + fileNameEncoded, //@"data:image/png;base64," + EncodeFile(fullName),
                    name = fileNameEncoded,
                    type = file.ContentType,
                    size = file.ContentLength,
                    delete_url = "/Upload/" + fileId + "-" + fileNameEncoded,
                    delete_type = "DELETE"
                });
            }
        }

        //[AcceptVerbs(HttpVerbs.Delete)]
        //public ActionResult Delete(string id, string filename)
        //{
        //    if (id == null || filename == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var filePath = Path.Combine(_StorageRoot, id + "-" + filename);

        //    if (System.IO.File.Exists(filePath))
        //    {
        //        System.IO.File.Delete(filePath);
        //    }

        //    return RedirectToAction("Index", "Home");
        //}


       
        
    }
}