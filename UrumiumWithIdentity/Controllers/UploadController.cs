using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.BimeDoctorInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class UploadController : Controller
    {


        IBimeDoctorService _bimedoctorservice;
        readonly IUnitOfWork _uow;

        public UploadController(IBimeDoctorService doctorservice, IBimeDoctorService bimedoctorservice,
           IUnitOfWork uow)
        {
            _bimedoctorservice = bimedoctorservice;
            _uow = uow;
        }
        // GET: Upload
        [HttpPost]
        public virtual async Task<ActionResult> Upload(HttpPostedFileBase fileupdate = null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/DoctorChat/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        data= "/uploads/DoctorChat/" + fileName
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }

        [HttpPost]
        public virtual async Task<ActionResult> UploadImage(HttpPostedFileBase audio_data = null)
        {
            string imageurl = "";
            if (audio_data != null)
            {
                var fileName = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/uploads/DoctorChat/"), fileName+".wav");
                audio_data.SaveAs(path);
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        data = "/uploads/DoctorChat/" + fileName + ".wav"
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }


        [HttpPost]
        public virtual async Task<ActionResult> JudgeUpload(HttpPostedFileBase fileupdate = null)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/JudgeChat/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        data = "/uploads/JudgeChat/" + fileName
                    }
                };
            }

            return new JsonNetResult
            {
                Data = new
                {
                    success = false
                }
            };
        }
    }
}