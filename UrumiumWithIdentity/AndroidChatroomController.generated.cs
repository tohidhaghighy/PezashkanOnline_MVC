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
    public partial class AndroidChatroomController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected AndroidChatroomController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetIllnessMassage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetIllnessMassage);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> PostNewIllnessMassage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostNewIllnessMassage);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeMassage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeMassage);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> PostNewJudgeMassage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostNewJudgeMassage);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public AndroidChatroomController Actions { get { return MVC.AndroidChatroom; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "AndroidChatroom";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "AndroidChatroom";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string GetIllnessMassage = "GetIllnessMassage";
            public readonly string PostNewIllnessMassage = "PostNewIllnessMassage";
            public readonly string GetJudgeMassage = "GetJudgeMassage";
            public readonly string PostNewJudgeMassage = "PostNewJudgeMassage";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string GetIllnessMassage = "GetIllnessMassage";
            public const string PostNewIllnessMassage = "PostNewIllnessMassage";
            public const string GetJudgeMassage = "GetJudgeMassage";
            public const string PostNewJudgeMassage = "PostNewJudgeMassage";
        }


        static readonly ActionParamsClass_GetIllnessMassage s_params_GetIllnessMassage = new ActionParamsClass_GetIllnessMassage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetIllnessMassage GetIllnessMassageParams { get { return s_params_GetIllnessMassage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetIllnessMassage
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_PostNewIllnessMassage s_params_PostNewIllnessMassage = new ActionParamsClass_PostNewIllnessMassage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PostNewIllnessMassage PostNewIllnessMassageParams { get { return s_params_PostNewIllnessMassage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PostNewIllnessMassage
        {
            public readonly string visitid = "visitid";
            public readonly string userid = "userid";
            public readonly string text = "text";
            public readonly string isuser = "isuser";
            public readonly string type = "type";
        }
        static readonly ActionParamsClass_GetJudgeMassage s_params_GetJudgeMassage = new ActionParamsClass_GetJudgeMassage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_GetJudgeMassage GetJudgeMassageParams { get { return s_params_GetJudgeMassage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_GetJudgeMassage
        {
            public readonly string visitid = "visitid";
        }
        static readonly ActionParamsClass_PostNewJudgeMassage s_params_PostNewJudgeMassage = new ActionParamsClass_PostNewJudgeMassage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_PostNewJudgeMassage PostNewJudgeMassageParams { get { return s_params_PostNewJudgeMassage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_PostNewJudgeMassage
        {
            public readonly string visitid = "visitid";
            public readonly string userid = "userid";
            public readonly string text = "text";
            public readonly string isuser = "isuser";
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
            }
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_AndroidChatroomController : UrumiumWithIdentity.Controllers.AndroidChatroomController
    {
        public T4MVC_AndroidChatroomController() : base(Dummy.Instance) { }

        [NonAction]
        partial void GetIllnessMassageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetIllnessMassage(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetIllnessMassage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            GetIllnessMassageOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void PostNewIllnessMassageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, string userid, string text, bool isuser, int type);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> PostNewIllnessMassage(int visitid, string userid, string text, bool isuser, int type)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostNewIllnessMassage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userid", userid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "isuser", isuser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "type", type);
            PostNewIllnessMassageOverride(callInfo, visitid, userid, text, isuser, type);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void GetJudgeMassageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> GetJudgeMassage(int visitid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.GetJudgeMassage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            GetJudgeMassageOverride(callInfo, visitid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void PostNewJudgeMassageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int visitid, string userid, string text, bool isuser, int type);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> PostNewJudgeMassage(int visitid, string userid, string text, bool isuser, int type)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostNewJudgeMassage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "visitid", visitid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "userid", userid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "isuser", isuser);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "type", type);
            PostNewJudgeMassageOverride(callInfo, visitid, userid, text, isuser, type);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
