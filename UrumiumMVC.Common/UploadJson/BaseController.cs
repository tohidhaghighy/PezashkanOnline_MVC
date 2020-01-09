using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UrumiumMVC.Common.UploadJson
{
    public class BaseController : System.Web.Mvc.Controller
    {
        // GET: Base
        public virtual ActionResult Upload()
        {
            var files = new List<string>();
            foreach (var requestFile in Request.Files.AllKeys)
            {
                var file = Request.Files[requestFile];
                var cover = this.Upload(file, "/ImageManager/temp");
                files.Add(cover);
            }

            return Json(new FileUploadJsonResult().GetJson($"/{ControllerContext.RouteData.Values["controller"]}/DeletePicture", "/Contents/Temp/", files));
        }

        public virtual ActionResult CkUpload()
        {
            var files = new List<string>();

            foreach (var requestFile in Request.Files.AllKeys)
            {
                var file = Request.Files[requestFile];
                var cover = this.Upload(file, "/Contents/Ckfinder");
                files.Add(cover);
                var cKEditor = Request["CKEditor"];
                // Required: Function number as indicated by CKEditor.
                var funcNum = Request["CKEditorFuncNum"];
                var baseUrl = "/ImageManager/Ckfinder/";
                var url = baseUrl + cover;
                var msg = "بارگزاری با موفقیت انجام شد";
                return Content(
                    $"<script type='text/javascript'>window.parent.CKEDITOR.tools.callFunction(1, '{url}', '{msg}')</script>");
            }
            return Content("");
            //return Json(new FileUploadJon().GetJson($"/{ControllerContext.RouteData.Values["controller"]}/DeletePicture", "/Contents/Temp/", files));
        }


        public virtual JsonResult CkUploaddraganddrop()
        {
            var files = new List<string>();

            foreach (var requestFile in Request.Files.AllKeys)
            {
                var file = Request.Files[requestFile];
                var cover = this.Upload(file, "/ImageManager/Ckfinder");
                files.Add(cover);
                //var cKEditor = Request["CKEditor"];
                // Required: Function number as indicated by CKEditor.
                //var funcNum = Request["CKEditorFuncNum"];
                var baseUrl = "/ImageManager/Ckfinder/";
                var url = baseUrl + cover;
                var msg = "بارگزاری با موفقیت انجام شد";
                return new JsonNetResult
                {
                    Data = new
                    {
                        uploaded = 1,
                        fileName = cover,
                        url = url
                    }
                };
            }
            return new JsonNetResult
            {
                Data = new
                {
                    uploaded = 1,
                    fileName = "",
                    url = ""
                }
            };
            //return Json(new FileUploadJon().GetJson($"/{ControllerContext.RouteData.Values["controller"]}/DeletePicture", "/Contents/Temp/", files));
        }

    }
}
