using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class BimeManagmentController : Controller
    {
        // GET: BimeManagment
        IDoctorService _doctorservice;
        IBimeService _bimeservices;
        readonly IUnitOfWork _uow;

        public BimeManagmentController(IDoctorService doctorservice, IBimeService insuranceservice,
           IUnitOfWork uow)
        {
            _doctorservice = doctorservice;
            _bimeservices = insuranceservice;
            _uow = uow;
        }

        public async virtual Task<ActionResult> Index()
        {
            return View(await _bimeservices.GetAllInsurance());
        }


        [HttpPost]
        public virtual async Task<ActionResult> AddItem(string name, string description, HttpPostedFileBase file)
        {
            if (name != "")
            {
                string imageurl = "";
                if (file != null)
                {
                    var fileName = Guid.NewGuid() + file.FileName;
                    var path = Path.Combine(Server.MapPath("~/uploads/Insurance/"), fileName);
                    file.SaveAs(path);
                    imageurl = fileName;
                }

                await _bimeservices.AddInsurance(name, description, imageurl);

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _bimeservices.DeleteInsurance(id);
        }

        [HttpPost]
        public virtual async Task<ActionResult> UpdateItem(int id, string name, string description, HttpPostedFileBase fileupdate)
        {
            string imageurl = "";
            if (fileupdate != null)
            {
                var fileName = Guid.NewGuid() + fileupdate.FileName;
                var path = Path.Combine(Server.MapPath("~/uploads/Insurance/"), fileName);
                fileupdate.SaveAs(path);
                imageurl = fileName;
            }

            await _bimeservices.UpdateInsurance(id, name, description, imageurl);
            return RedirectToAction("Index");
        }



        [HttpPost]
        public virtual async Task<ActionResult> SearchItem(string text)
        {
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_InsuranceListAjax", await _bimeservices.SearchInsurance(text))
                    }
                };
            }
            catch (Exception)
            {

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
}