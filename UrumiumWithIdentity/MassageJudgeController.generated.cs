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
    public partial class MassageJudgeController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected MassageJudgeController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMassageIllness()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMassageIllness);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMassageJudge()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMassageJudge);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public MassageJudgeController Actions { get { return MVC.MassageJudge; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "MassageJudge";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "MassageJudge";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string AddMassageIllness = "AddMassageIllness";
            public readonly string AddMassageJudge = "AddMassageJudge";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string AddMassageIllness = "AddMassageIllness";
            public const string AddMassageJudge = "AddMassageJudge";
        }


        static readonly ActionParamsClass_AddMassageIllness s_params_AddMassageIllness = new ActionParamsClass_AddMassageIllness();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddMassageIllness AddMassageIllnessParams { get { return s_params_AddMassageIllness; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddMassageIllness
        {
            public readonly string visitid = "visitid";
            public readonly string text = "text";
            public readonly string isuser = "isuser";
        }
        static readonly ActionParamsClass_AddMassageJudge s_params_AddMassageJudge = new ActionParamsClass_AddMassageJudge();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddMassageJudge AddMassageJudgeParams { get { return s_params_AddMassageJudge; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddMassageJudge
        {
            public readonly string visitid = "visitid";
            public readonly string text = "text";
            public readonly string isuser = "isuser";
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
    public partial class T4MVC_MassageJudgeController : UrumiumWithIdentity.Controllers.MassageJudgeController
    {
        public T4MVC_MassageJudgeController() : base(Dummy.Instance) { }

        [NonAction]
        partial void AddMassageIllnessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, string text, bool isuser);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMassageIllness(int visitid, string text, bool isuser)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMassageIllness);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "isuser", isuser);
            AddMassageIllnessOverride(callInfo, visitid, text, isuser);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AddMassageJudgeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, string text, bool isuser);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddMassageJudge(int visitid, string text, bool isuser)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddMassageJudge);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "isuser", isuser);
            AddMassageJudgeOverride(callInfo, visitid, text, isuser);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
