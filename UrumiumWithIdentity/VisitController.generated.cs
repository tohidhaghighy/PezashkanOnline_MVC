// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
// 0108: suppress "Foo hides inherited member Foo. Use the new keyword if hiding was intended." when a controller and its abstract parent are both processed
// 0114: suppress "Foo.BarController.Baz()' hides inherited member 'Qux.BarController.Baz()'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword." when an action (with an argument) overrides an action in a parent controller
#pragma warning disable 1591, 3008, 3009, 0108, 0114
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace UrumiumWithIdentity.Controllers
{
    public partial class VisitController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected VisitController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddVisitPayment()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddVisitPayment);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ReturnVisitPayment()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ReturnVisitPayment);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Finishvisit()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Finishvisit);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public VisitController Actions { get { return MVC.Visit; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Visit";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Visit";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string AddVisitPayment = "AddVisitPayment";
            public readonly string ReturnVisitPayment = "ReturnVisitPayment";
            public readonly string Finishvisit = "Finishvisit";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string AddVisitPayment = "AddVisitPayment";
            public const string ReturnVisitPayment = "ReturnVisitPayment";
            public const string Finishvisit = "Finishvisit";
        }


        static readonly ActionParamsClass_AddVisitPayment s_params_AddVisitPayment = new ActionParamsClass_AddVisitPayment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddVisitPayment AddVisitPaymentParams { get { return s_params_AddVisitPayment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddVisitPayment
        {
            public readonly string visitid = "visitid";
            public readonly string doctorid = "doctorid";
            public readonly string amount = "amount";
            public readonly string date = "date";
        }
        static readonly ActionParamsClass_ReturnVisitPayment s_params_ReturnVisitPayment = new ActionParamsClass_ReturnVisitPayment();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ReturnVisitPayment ReturnVisitPaymentParams { get { return s_params_ReturnVisitPayment; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ReturnVisitPayment
        {
            public readonly string Vresult = "Vresult";
        }
        static readonly ActionParamsClass_Finishvisit s_params_Finishvisit = new ActionParamsClass_Finishvisit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Finishvisit FinishvisitParams { get { return s_params_Finishvisit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Finishvisit
        {
            public readonly string visitid = "visitid";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string ReturnVisitPayment = "ReturnVisitPayment";
            }
            public readonly string ReturnVisitPayment = "~/Views/Visit/ReturnVisitPayment.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_VisitController : UrumiumWithIdentity.Controllers.VisitController
    {
        public T4MVC_VisitController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void AddVisitPaymentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, int doctorid, string amount, string date);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddVisitPayment(int visitid, int doctorid, string amount, string date)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddVisitPayment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "doctorid", doctorid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "amount", amount);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "date", date);
            AddVisitPaymentOverride(callInfo, visitid, doctorid, amount, date);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ReturnVisitPaymentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, UrumiumWithIdentity.Models.VerifyResultPayment Vresult);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ReturnVisitPayment(UrumiumWithIdentity.Models.VerifyResultPayment Vresult)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ReturnVisitPayment);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "Vresult", Vresult);
            ReturnVisitPaymentOverride(callInfo, Vresult);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void FinishvisitOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Finishvisit(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Finishvisit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            FinishvisitOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
