using System.IO;
using System.Web;
namespace Product.BAL.Tool
{
    public  class ImageProcess
    {
        public string Save(HttpPostedFileBase fileResim, string filePath)
        {
            string err = "";
            try
            {
                if (fileResim != null && fileResim.ContentLength > 0)
                {
                    filePath = HttpContext.Current.Server.MapPath("~" + filePath);
                    if (File.Exists(filePath)) File.Delete(filePath);
                    fileResim.SaveAs(filePath);
                }
            }
            catch (System.Exception ex)
            {
                err = ex.Message;
            }
            return err;
        }


    }
}
