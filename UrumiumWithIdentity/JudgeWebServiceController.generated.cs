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
    public partial class JudgeWebServiceController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected JudgeWebServiceController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeInfo()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public JudgeWebServiceController Actions { get { return MVC.JudgeWebService; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "JudgeWebService";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "JudgeWebService";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetAllJudge = "GetAllJudge";
            public readonly string GetJudgeCost = "GetJudgeCost";
            public readonly string GetJudgeInfo = "GetJudgeInfo";
            public readonly string UpdateJudgeInfo = "UpdateJudgeInfo";
            public readonly string GetJudgeVisitList = "GetJudgeVisitList";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetAllJudge = "GetAllJudge";
            public const string GetJudgeCost = "GetJudgeCost";
            public const string GetJudgeInfo = "GetJudgeInfo";
            public const string UpdateJudgeInfo = "UpdateJudgeInfo";
            public const string GetJudgeVisitList = "GetJudgeVisitList";
        }


        static readonly ActionParamsClass_GetJudgeInfo s_params_GetJudgeInfo = new ActionParamsClass_GetJudgeInfo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetJudgeInfo GetJudgeInfoParams { get { return s_params_GetJudgeInfo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetJudgeInfo
        {
            public readonly string mobile = "mobile";
        }
        static readonly ActionParamsClass_UpdateJudgeInfo s_params_UpdateJudgeInfo = new ActionParamsClass_UpdateJudgeInfo();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateJudgeInfo UpdateJudgeInfoParams { get { return s_params_UpdateJudgeInfo; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateJudgeInfo
        {
            public readonly string mobile = "mobile";
            public readonly string name = "name";
            public readonly string bankcode = "bankcode";
            public readonly string description = "description";
            public readonly string cityid = "cityid";
            public readonly string image = "image";
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
    public partial class T4MVC_JudgeWebServiceController : UrumiumWithIdentity.Controllers.JudgeWebServiceController
    {
        public T4MVC_JudgeWebServiceController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetAllJudgeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetAllJudge()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetAllJudge);
            GetAllJudgeOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetJudgeCostOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeCost()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeCost);
            GetJudgeCostOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetJudgeInfoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string mobile);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeInfo(string mobile)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeInfo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mobile", mobile);
            GetJudgeInfoOverride(callInfo, mobile);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void UpdateJudgeInfoOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string mobile, string name, string bankcode, string description, int cityid, string image);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> UpdateJudgeInfo(string mobile, string name, string bankcode, string description, int cityid, string image)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateJudgeInfo);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "mobile", mobile);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "name", name);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "bankcode", bankcode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "description", description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cityid", cityid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "image", image);
            UpdateJudgeInfoOverride(callInfo, mobile, name, bankcode, description, cityid, image);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetJudgeVisitListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeVisitList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeVisitList);
            GetJudgeVisitListOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
