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
    public partial class NoskheWebServiceController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected NoskheWebServiceController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetNoskheMedicine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNoskheMedicine);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetNoskheMedicineNotFinally()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNoskheMedicineNotFinally);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SearchMedicine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SearchMedicine);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMedicine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMedicine);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> FinalyMedicine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FinalyMedicine);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CheckFinalyMedicine()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckFinalyMedicine);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMedicineToNoskhe()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMedicineToNoskhe);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DeleteMedicineFromNoskhe()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteMedicineFromNoskhe);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public NoskheWebServiceController Actions { get { return MVC.NoskheWebService; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "NoskheWebService";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "NoskheWebService";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetNoskheMedicine = "GetNoskheMedicine";
            public readonly string GetNoskheMedicineNotFinally = "GetNoskheMedicineNotFinally";
            public readonly string SearchMedicine = "SearchMedicine";
            public readonly string AddMedicine = "AddMedicine";
            public readonly string FinalyMedicine = "FinalyMedicine";
            public readonly string CheckFinalyMedicine = "CheckFinalyMedicine";
            public readonly string AddMedicineToNoskhe = "AddMedicineToNoskhe";
            public readonly string DeleteMedicineFromNoskhe = "DeleteMedicineFromNoskhe";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetNoskheMedicine = "GetNoskheMedicine";
            public const string GetNoskheMedicineNotFinally = "GetNoskheMedicineNotFinally";
            public const string SearchMedicine = "SearchMedicine";
            public const string AddMedicine = "AddMedicine";
            public const string FinalyMedicine = "FinalyMedicine";
            public const string CheckFinalyMedicine = "CheckFinalyMedicine";
            public const string AddMedicineToNoskhe = "AddMedicineToNoskhe";
            public const string DeleteMedicineFromNoskhe = "DeleteMedicineFromNoskhe";
        }


        static readonly ActionParamsClass_GetNoskheMedicine s_params_GetNoskheMedicine = new ActionParamsClass_GetNoskheMedicine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetNoskheMedicine GetNoskheMedicineParams { get { return s_params_GetNoskheMedicine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetNoskheMedicine
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_GetNoskheMedicineNotFinally s_params_GetNoskheMedicineNotFinally = new ActionParamsClass_GetNoskheMedicineNotFinally();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetNoskheMedicineNotFinally GetNoskheMedicineNotFinallyParams { get { return s_params_GetNoskheMedicineNotFinally; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetNoskheMedicineNotFinally
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_SearchMedicine s_params_SearchMedicine = new ActionParamsClass_SearchMedicine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SearchMedicine SearchMedicineParams { get { return s_params_SearchMedicine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SearchMedicine
        {
            public readonly string text = "text";
            public readonly string mobile = "mobile";
        }
        static readonly ActionParamsClass_AddMedicine s_params_AddMedicine = new ActionParamsClass_AddMedicine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddMedicine AddMedicineParams { get { return s_params_AddMedicine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddMedicine
        {
            public readonly string text = "text";
            public readonly string description = "description";
            public readonly string mobile = "mobile";
        }
        static readonly ActionParamsClass_FinalyMedicine s_params_FinalyMedicine = new ActionParamsClass_FinalyMedicine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_FinalyMedicine FinalyMedicineParams { get { return s_params_FinalyMedicine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_FinalyMedicine
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_CheckFinalyMedicine s_params_CheckFinalyMedicine = new ActionParamsClass_CheckFinalyMedicine();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CheckFinalyMedicine CheckFinalyMedicineParams { get { return s_params_CheckFinalyMedicine; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CheckFinalyMedicine
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_AddMedicineToNoskhe s_params_AddMedicineToNoskhe = new ActionParamsClass_AddMedicineToNoskhe();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddMedicineToNoskhe AddMedicineToNoskheParams { get { return s_params_AddMedicineToNoskhe; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddMedicineToNoskhe
        {
            public readonly string visitid = "visitid";
            public readonly string text = "text";
            public readonly string count = "count";
        }
        static readonly ActionParamsClass_DeleteMedicineFromNoskhe s_params_DeleteMedicineFromNoskhe = new ActionParamsClass_DeleteMedicineFromNoskhe();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteMedicineFromNoskhe DeleteMedicineFromNoskheParams { get { return s_params_DeleteMedicineFromNoskhe; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteMedicineFromNoskhe
        {
            public readonly string id = "id";
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
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_NoskheWebServiceController : UrumiumWithIdentity.Controllers.NoskheWebServiceController
    {
        public T4MVC_NoskheWebServiceController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetNoskheMedicineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetNoskheMedicine(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNoskheMedicine);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            GetNoskheMedicineOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetNoskheMedicineNotFinallyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetNoskheMedicineNotFinally(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetNoskheMedicineNotFinally);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            GetNoskheMedicineNotFinallyOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SearchMedicineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string text, string mobile);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SearchMedicine(string text, string mobile)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SearchMedicine);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mobile", mobile);
            SearchMedicineOverride(callInfo, text, mobile);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AddMedicineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string text, string description, string mobile);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMedicine(string text, string description, string mobile)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMedicine);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "description", description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mobile", mobile);
            AddMedicineOverride(callInfo, text, description, mobile);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void FinalyMedicineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> FinalyMedicine(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.FinalyMedicine);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            FinalyMedicineOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void CheckFinalyMedicineOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> CheckFinalyMedicine(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CheckFinalyMedicine);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            CheckFinalyMedicineOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AddMedicineToNoskheOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, string text, int count);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMedicineToNoskhe(int visitid, string text, int count)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMedicineToNoskhe);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "count", count);
            AddMedicineToNoskheOverride(callInfo, visitid, text, count);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DeleteMedicineFromNoskheOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DeleteMedicineFromNoskhe(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteMedicineFromNoskhe);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteMedicineFromNoskheOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
