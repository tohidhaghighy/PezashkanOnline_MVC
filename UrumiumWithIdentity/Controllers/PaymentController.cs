using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UrumiumWithIdentity.Controllers
{
    public partial class PaymentController : Controller
    {
        // GET: Payment
        public virtual ActionResult Index()
        {
            return View();
        }
        public virtual ActionResult Payment()
        {
            System.Net.ServicePointManager.Expect100Continue = false;
            ServiceReferenceTest.PaymentGatewayImplementationServicePortTypeClient zp = new ServiceReferenceTest.PaymentGatewayImplementationServicePortTypeClient();
            string Authority;

            int Status = zp.PaymentRequest("YOUR-ZARINPAL-MERCHANT-CODE", 10000, "تست درگاه زرین پال در تاپ لرن", "Iman@Madaeny.com", "09124140939", "http://localhost:52029/Payment/Verify?id=1", out Authority);

            if (Status == 100)
            {
                // Response.Redirect("https://www.zarinpal.com/pg/StartPay/" + Authority);
                Response.Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + Authority);
            }
            else
            {
                ViewBag.Error = "Error : " + Status;
            }
            return View();
        }

        public virtual ActionResult Verify(int id)
        {


            if (Request.QueryString["Status"] != "" && Request.QueryString["Status"] != null && Request.QueryString["Authority"] != "" && Request.QueryString["Authority"] != null)
            {
                if (Request.QueryString["Status"].ToString().Equals("OK"))
                {
                    long RefID;
                    System.Net.ServicePointManager.Expect100Continue = false;
                    ServiceReferenceTest.PaymentGatewayImplementationServicePortTypeClient zp = new ServiceReferenceTest.PaymentGatewayImplementationServicePortTypeClient();

                    int Status = zp.PaymentVerification("YOUR-ZARINPAL-MERCHANT-CODE", Request.QueryString["Authority"].ToString(), 10000, out RefID);

                    if (Status == 100)
                    {
                        ViewBag.IsSuccess = true;
                        ViewBag.RefId = RefID;
                        // Response.Write("Success!! RefId: " + RefID);
                    }
                    else
                    {
                        ViewBag.Status = Status;
                    }

                }
                else
                {
                    Response.Write("Error! Authority: " + Request.QueryString["Authority"].ToString() + " Status: " + Request.QueryString["Status"].ToString());
                }
            }
            else
            {
                Response.Write("Invalid Input");
            }
            return View();
        }
    }
}