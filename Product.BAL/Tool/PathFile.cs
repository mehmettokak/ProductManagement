using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.BAL.Tool
{
   public static class PathFile
    {
        public static string ToSetFilePath(this string filePath)
        {
            var reFilePath = "";

            if (!string.IsNullOrEmpty(filePath))
            {
                var imageServerPath = ConfigurationManager.AppSettings["ImageServerUrl"];
                reFilePath = imageServerPath + filePath;
            }

            return reFilePath;
        }
    }
}
