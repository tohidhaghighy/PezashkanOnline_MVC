using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using UrumiumMVC.ServiceLayer.Contract.BimeDoctorInterface;
using UrumiumMVC.ServiceLayer.Contract.BimeInterface;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;

namespace UrumiumWithIdentity.Controllers
{
    public class TestController : ApiController
    {
        IBimeDoctorService _bimedoctorservice;
        readonly IUnitOfWork _uow;

        public TestController(IBimeDoctorService doctorservice, IBimeDoctorService bimedoctorservice,
           IUnitOfWork uow)
        {
            _bimedoctorservice = bimedoctorservice;
            _uow = uow;
        }
        [HttpPost]
        public async System.Threading.Tasks.Task<HttpResponseMessage> ImagePostAsync()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                // Show all the key-value pairs.
                foreach (var key in provider.FormData.AllKeys)
                {
                    foreach (var val in provider.FormData.GetValues(key))
                    {
                        Trace.WriteLine(string.Format("{0}: {1}", key, val));
                    }
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
    }
}
