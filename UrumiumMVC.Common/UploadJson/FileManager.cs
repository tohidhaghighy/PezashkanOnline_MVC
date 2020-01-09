using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UrumiumMVC.Common.UploadJson
{
    public static class FileManager
    {
        public static string Upload(this BaseController controller, HttpPostedFileBase postedFile, string path)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(postedFile.FileName);
            var imagePath = Path.Combine(controller.Server.MapPath(path), fileName);
            postedFile.SaveAs(imagePath);
            return fileName;
        }


        public static bool DeleteFile(this BaseController controller, string id, string folder)
        {
            var imagePath = Path.Combine(controller.Server.MapPath(folder), id);
            if (File.Exists(imagePath))
            {
                File.Delete(imagePath);
                return true;
            }
            return false;

        }

    }
}
