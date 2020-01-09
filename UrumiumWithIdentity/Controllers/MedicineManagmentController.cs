using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.MedicineInterface;
using UrumiumMVC.ViewModel.EntityViewModel.MedicineViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class MedicineManagmentController : Controller
    {
        IMedicineService _medicineservices;
        IGroupService _groupservices;
        IDoctorService _doctorservice;
        readonly IUnitOfWork _uow;
        public MedicineManagmentController(IMedicineService newmedicineservice, IGroupService newgroupservice,IDoctorService doctorservice,
            IUnitOfWork uow)
        {
            _medicineservices = newmedicineservice;
            _groupservices = newgroupservice;
            _doctorservice = doctorservice;
            _uow = uow;
        }


        // GET: MedicineManagment
        public async virtual Task<ActionResult> Index(string id)
        {
            var finddoctor = await _doctorservice.GetDoctorwithguidid(id);
            if (finddoctor!=null)
            {
                var MedicineList = new MedicineVM()
                {
                    groups = null,
                    medicines = await _medicineservices.GetAllMedicine(finddoctor.Id),
                    Doctorid=finddoctor.Id
                };
                return View(MedicineList);
            }
            return View();
        }

        [HttpPost]
        public virtual async Task<Boolean> AddItem(int doctorid, string name, string description)
        {
            await _medicineservices.AddMedicine(doctorid, name, description);
            return true;
        }


        [HttpPost]
        public async Task<Boolean> DeleteItem(int id)
        {
            return await _medicineservices.DeleteMedicine(id);
        }


        [HttpPost]
        public virtual async Task<Boolean> UpdateItem(int id, string name, string description)
        {
            await _medicineservices.UpdateMedicine(id, name, description, true);
            return true;
        }
        
        [HttpPost]
        public virtual async Task<ActionResult> SearchItem(int doctorid,string text)
        {

            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_MedicineListAjax", await _medicineservices.SearchMedicine(doctorid,text))
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


        [HttpPost]
        public virtual async Task<ActionResult> SearchItemForNoskhe(int doctorid, string text)
        {

            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_NoskheMedicinListAjax", await _medicineservices.SearchMedicine(doctorid, text))
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

        [HttpPost]
        public virtual async Task<ActionResult> AddItemSearch(int doctorid, string name, string description)
        {
            await _medicineservices.AddMedicine(doctorid, name, description);
            try
            {
                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_NoskheMedicinListAjax", await _medicineservices.SearchMedicine(doctorid, description))
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