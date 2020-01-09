using DataLayer.Context;
using OstanAg.Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.Common.UploadJson;
using UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.SearchDayInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class DayManagmentController : Controller
    {
        IDayService _dayservice;
        IDayDoctorService _daydoctorservice;
        readonly IUnitOfWork _uow;

        public DayManagmentController(IDayService dayservice, IDayDoctorService daydoctorservice,
           IUnitOfWork uow)
        {
            _dayservice = dayservice;
            _daydoctorservice = daydoctorservice;
            _uow = uow;
        }
        public virtual ActionResult Index()
        {
            return View();
        }


        public virtual async Task<ActionResult> AddItem(string id, int doctorid = 0, string date = "", string description = "", int countuser = 0)
        {
            if (doctorid != 0 && description != "" && date != "" && countuser != 0)
            {
                await _daydoctorservice.AddDayDoctor(doctorid, date, description, countuser);
            }

            return Redirect("/UserMainPages/Doctor?id=" + id);
        }


        [HttpPost]
        public virtual async Task<ActionResult> DeleteItem(int id, int doctorid)
        {
            try
            {
                await _daydoctorservice.DeleteDoctorDays(id);

                return new JsonNetResult
                {
                    Data = new
                    {
                        success = true,
                        View = this.RenderPartialViewToString("_DayDoctorListAjax", await _daydoctorservice.GetAllDoctorDays(doctorid))
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