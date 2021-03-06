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
    public partial class UserMainPagesController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected UserMainPagesController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Doctor()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Doctor);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Judge()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Judge);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Illness()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Illness);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Pharmacy()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Pharmacy);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorVisitList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorDateSearchVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorDateSearchVisitList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> IllnessVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IllnessVisitList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> IllnessParvandeDoctorList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IllnessParvandeDoctorList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> JudgeVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.JudgeVisitList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ViolationList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ViolationList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> NotificationList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.NotificationList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public UserMainPagesController Actions { get { return MVC.UserMainPages; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "UserMainPages";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "UserMainPages";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Doctor = "Doctor";
            public readonly string Judge = "Judge";
            public readonly string Illness = "Illness";
            public readonly string Pharmacy = "Pharmacy";
            public readonly string DoctorVisitList = "DoctorVisitList";
            public readonly string DoctorDateSearchVisitList = "DoctorDateSearchVisitList";
            public readonly string IllnessVisitList = "IllnessVisitList";
            public readonly string IllnessParvandeDoctorList = "IllnessParvandeDoctorList";
            public readonly string JudgeVisitList = "JudgeVisitList";
            public readonly string PharmacyVisitList = "PharmacyVisitList";
            public readonly string TaiideModir = "TaiideModir";
            public readonly string ViolationList = "ViolationList";
            public readonly string NotificationList = "NotificationList";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Doctor = "Doctor";
            public const string Judge = "Judge";
            public const string Illness = "Illness";
            public const string Pharmacy = "Pharmacy";
            public const string DoctorVisitList = "DoctorVisitList";
            public const string DoctorDateSearchVisitList = "DoctorDateSearchVisitList";
            public const string IllnessVisitList = "IllnessVisitList";
            public const string IllnessParvandeDoctorList = "IllnessParvandeDoctorList";
            public const string JudgeVisitList = "JudgeVisitList";
            public const string PharmacyVisitList = "PharmacyVisitList";
            public const string TaiideModir = "TaiideModir";
            public const string ViolationList = "ViolationList";
            public const string NotificationList = "NotificationList";
        }


        static readonly ActionParamsClass_Doctor s_params_Doctor = new ActionParamsClass_Doctor();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Doctor DoctorParams { get { return s_params_Doctor; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Doctor
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Judge s_params_Judge = new ActionParamsClass_Judge();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Judge JudgeParams { get { return s_params_Judge; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Judge
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Illness s_params_Illness = new ActionParamsClass_Illness();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Illness IllnessParams { get { return s_params_Illness; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Illness
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Pharmacy s_params_Pharmacy = new ActionParamsClass_Pharmacy();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Pharmacy PharmacyParams { get { return s_params_Pharmacy; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Pharmacy
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DoctorVisitList s_params_DoctorVisitList = new ActionParamsClass_DoctorVisitList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DoctorVisitList DoctorVisitListParams { get { return s_params_DoctorVisitList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DoctorVisitList
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DoctorDateSearchVisitList s_params_DoctorDateSearchVisitList = new ActionParamsClass_DoctorDateSearchVisitList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DoctorDateSearchVisitList DoctorDateSearchVisitListParams { get { return s_params_DoctorDateSearchVisitList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DoctorDateSearchVisitList
        {
            public readonly string date = "date";
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_IllnessVisitList s_params_IllnessVisitList = new ActionParamsClass_IllnessVisitList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_IllnessVisitList IllnessVisitListParams { get { return s_params_IllnessVisitList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_IllnessVisitList
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_IllnessParvandeDoctorList s_params_IllnessParvandeDoctorList = new ActionParamsClass_IllnessParvandeDoctorList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_IllnessParvandeDoctorList IllnessParvandeDoctorListParams { get { return s_params_IllnessParvandeDoctorList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_IllnessParvandeDoctorList
        {
            public readonly string doctorid = "doctorid";
            public readonly string illnessid = "illnessid";
        }
        static readonly ActionParamsClass_JudgeVisitList s_params_JudgeVisitList = new ActionParamsClass_JudgeVisitList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_JudgeVisitList JudgeVisitListParams { get { return s_params_JudgeVisitList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_JudgeVisitList
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ViolationList s_params_ViolationList = new ActionParamsClass_ViolationList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ViolationList ViolationListParams { get { return s_params_ViolationList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ViolationList
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_NotificationList s_params_NotificationList = new ActionParamsClass_NotificationList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_NotificationList NotificationListParams { get { return s_params_NotificationList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_NotificationList
        {
            public readonly string type = "type";
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
                public readonly string _DayDoctorListAjax = "_DayDoctorListAjax";
                public readonly string _notifylist = "_notifylist";
                public readonly string _VisitDoctorListAjax = "_VisitDoctorListAjax";
                public readonly string Doctor = "Doctor";
                public readonly string DoctorVisitList = "DoctorVisitList";
                public readonly string Illness = "Illness";
                public readonly string IllnessParvandeDoctorList = "IllnessParvandeDoctorList";
                public readonly string IllnessVisitList = "IllnessVisitList";
                public readonly string Judge = "Judge";
                public readonly string JudgeVisitList = "JudgeVisitList";
                public readonly string Pharmacy = "Pharmacy";
                public readonly string PharmacyVisitList = "PharmacyVisitList";
                public readonly string TaiideModir = "TaiideModir";
                public readonly string ViolationList = "ViolationList";
            }
            public readonly string _DayDoctorListAjax = "~/Views/UserMainPages/_DayDoctorListAjax.cshtml";
            public readonly string _notifylist = "~/Views/UserMainPages/_notifylist.cshtml";
            public readonly string _VisitDoctorListAjax = "~/Views/UserMainPages/_VisitDoctorListAjax.cshtml";
            public readonly string Doctor = "~/Views/UserMainPages/Doctor.cshtml";
            public readonly string DoctorVisitList = "~/Views/UserMainPages/DoctorVisitList.cshtml";
            public readonly string Illness = "~/Views/UserMainPages/Illness.cshtml";
            public readonly string IllnessParvandeDoctorList = "~/Views/UserMainPages/IllnessParvandeDoctorList.cshtml";
            public readonly string IllnessVisitList = "~/Views/UserMainPages/IllnessVisitList.cshtml";
            public readonly string Judge = "~/Views/UserMainPages/Judge.cshtml";
            public readonly string JudgeVisitList = "~/Views/UserMainPages/JudgeVisitList.cshtml";
            public readonly string Pharmacy = "~/Views/UserMainPages/Pharmacy.cshtml";
            public readonly string PharmacyVisitList = "~/Views/UserMainPages/PharmacyVisitList.cshtml";
            public readonly string TaiideModir = "~/Views/UserMainPages/TaiideModir.cshtml";
            public readonly string ViolationList = "~/Views/UserMainPages/ViolationList.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_UserMainPagesController : UrumiumWithIdentity.Controllers.UserMainPagesController
    {
        public T4MVC_UserMainPagesController() : base(Dummy.Instance) { }

        [NonAction]
        partial void DoctorOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Doctor(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Doctor);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DoctorOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void JudgeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Judge(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Judge);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            JudgeOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void IllnessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Illness(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Illness);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            IllnessOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void PharmacyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Pharmacy(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Pharmacy);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            PharmacyOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DoctorVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorVisitList(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorVisitList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DoctorVisitListOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DoctorDateSearchVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string date, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorDateSearchVisitList(string date, string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorDateSearchVisitList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "date", date);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DoctorDateSearchVisitListOverride(callInfo, date, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void IllnessVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> IllnessVisitList(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IllnessVisitList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            IllnessVisitListOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void IllnessParvandeDoctorListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int doctorid, int illnessid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> IllnessParvandeDoctorList(int doctorid, int illnessid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.IllnessParvandeDoctorList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "doctorid", doctorid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "illnessid", illnessid);
            IllnessParvandeDoctorListOverride(callInfo, doctorid, illnessid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void JudgeVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> JudgeVisitList(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.JudgeVisitList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            JudgeVisitListOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void PharmacyVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> PharmacyVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PharmacyVisitList);
            PharmacyVisitListOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void TaiideModirOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> TaiideModir()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.TaiideModir);
            TaiideModirOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ViolationListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ViolationList(string id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ViolationList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ViolationListOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void NotificationListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int type);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> NotificationList(int type)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.NotificationList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "type", type);
            NotificationListOverride(callInfo, type);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
