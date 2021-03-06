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
    public partial class DoctorManagmentController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected DoctorManagmentController(Dummy d) { }

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
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddItem()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddItem);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> UpdateItem()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateItem);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> UpdateItemClient()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateItemClient);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SearchItem()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SearchItem);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeActive()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeActive);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeComboItem()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeComboItem);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeComboItemUpdate()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeComboItemUpdate);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorBimeList()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorBimeList);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DeleteDoctorBime()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteDoctorBime);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public DoctorManagmentController Actions { get { return MVC.DoctorManagment; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "DoctorManagment";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "DoctorManagment";
        [GeneratedCode("T4MVC", "2.0")]
        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string AddItem = "AddItem";
            public readonly string UpdateItem = "UpdateItem";
            public readonly string UpdateItemClient = "UpdateItemClient";
            public readonly string SearchItem = "SearchItem";
            public readonly string ChangeActive = "ChangeActive";
            public readonly string ChangeComboItem = "ChangeComboItem";
            public readonly string ChangeComboItemUpdate = "ChangeComboItemUpdate";
            public readonly string DoctorBimeList = "DoctorBimeList";
            public readonly string DeleteDoctorBime = "DeleteDoctorBime";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string AddItem = "AddItem";
            public const string UpdateItem = "UpdateItem";
            public const string UpdateItemClient = "UpdateItemClient";
            public const string SearchItem = "SearchItem";
            public const string ChangeActive = "ChangeActive";
            public const string ChangeComboItem = "ChangeComboItem";
            public const string ChangeComboItemUpdate = "ChangeComboItemUpdate";
            public const string DoctorBimeList = "DoctorBimeList";
            public const string DeleteDoctorBime = "DeleteDoctorBime";
        }


        static readonly ActionParamsClass_AddItem s_params_AddItem = new ActionParamsClass_AddItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_AddItem AddItemParams { get { return s_params_AddItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_AddItem
        {
            public readonly string cityid = "cityid";
            public readonly string name = "name";
            public readonly string description = "description";
            public readonly string cost = "cost";
            public readonly string groupid = "groupid";
            public readonly string username = "username";
            public readonly string password = "password";
            public readonly string file = "file";
        }
        static readonly ActionParamsClass_UpdateItem s_params_UpdateItem = new ActionParamsClass_UpdateItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateItem UpdateItemParams { get { return s_params_UpdateItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateItem
        {
            public readonly string id = "id";
            public readonly string cityid = "cityid";
            public readonly string name = "name";
            public readonly string description = "description";
            public readonly string cost = "cost";
            public readonly string spetialdoctor = "spetialdoctor";
            public readonly string groupid = "groupid";
            public readonly string nezampezeshkicode = "nezampezeshkicode";
            public readonly string fileupdate = "fileupdate";
        }
        static readonly ActionParamsClass_UpdateItemClient s_params_UpdateItemClient = new ActionParamsClass_UpdateItemClient();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_UpdateItemClient UpdateItemClientParams { get { return s_params_UpdateItemClient; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_UpdateItemClient
        {
            public readonly string id = "id";
            public readonly string accountnumber = "accountnumber";
            public readonly string cityidupdate = "cityidupdate";
            public readonly string name = "name";
            public readonly string description = "description";
            public readonly string cost = "cost";
            public readonly string groupid = "groupid";
            public readonly string nezampezeshkicode = "nezampezeshkicode";
            public readonly string fileupdate = "fileupdate";
        }
        static readonly ActionParamsClass_SearchItem s_params_SearchItem = new ActionParamsClass_SearchItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_SearchItem SearchItemParams { get { return s_params_SearchItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_SearchItem
        {
            public readonly string text = "text";
        }
        static readonly ActionParamsClass_ChangeActive s_params_ChangeActive = new ActionParamsClass_ChangeActive();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangeActive ChangeActiveParams { get { return s_params_ChangeActive; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangeActive
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ChangeComboItem s_params_ChangeComboItem = new ActionParamsClass_ChangeComboItem();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangeComboItem ChangeComboItemParams { get { return s_params_ChangeComboItem; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangeComboItem
        {
            public readonly string stateid = "stateid";
        }
        static readonly ActionParamsClass_ChangeComboItemUpdate s_params_ChangeComboItemUpdate = new ActionParamsClass_ChangeComboItemUpdate();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ChangeComboItemUpdate ChangeComboItemUpdateParams { get { return s_params_ChangeComboItemUpdate; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ChangeComboItemUpdate
        {
            public readonly string stateid = "stateid";
        }
        static readonly ActionParamsClass_DoctorBimeList s_params_DoctorBimeList = new ActionParamsClass_DoctorBimeList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DoctorBimeList DoctorBimeListParams { get { return s_params_DoctorBimeList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DoctorBimeList
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_DeleteDoctorBime s_params_DeleteDoctorBime = new ActionParamsClass_DeleteDoctorBime();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_DeleteDoctorBime DeleteDoctorBimeParams { get { return s_params_DeleteDoctorBime; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_DeleteDoctorBime
        {
            public readonly string id = "id";
            public readonly string doctorid = "doctorid";
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
                public readonly string _BimeListAjax = "_BimeListAjax";
                public readonly string _CityComboBox = "_CityComboBox";
                public readonly string _CityComboBoxUpdate = "_CityComboBoxUpdate";
                public readonly string _DoctorListAjax = "_DoctorListAjax";
                public readonly string _GroupComboBoxList = "_GroupComboBoxList";
                public readonly string _InsuranceComboBoxList = "_InsuranceComboBoxList";
                public readonly string Index = "Index";
            }
            public readonly string _BimeListAjax = "~/Views/DoctorManagment/_BimeListAjax.cshtml";
            public readonly string _CityComboBox = "~/Views/DoctorManagment/_CityComboBox.cshtml";
            public readonly string _CityComboBoxUpdate = "~/Views/DoctorManagment/_CityComboBoxUpdate.cshtml";
            public readonly string _DoctorListAjax = "~/Views/DoctorManagment/_DoctorListAjax.cshtml";
            public readonly string _GroupComboBoxList = "~/Views/DoctorManagment/_GroupComboBoxList.cshtml";
            public readonly string _InsuranceComboBoxList = "~/Views/DoctorManagment/_InsuranceComboBoxList.cshtml";
            public readonly string Index = "~/Views/DoctorManagment/Index.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_DoctorManagmentController : UrumiumWithIdentity.Controllers.DoctorManagmentController
    {
        public T4MVC_DoctorManagmentController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void AddItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int cityid, string name, string description, int cost, int groupid, string username, string password, System.Web.HttpPostedFileBase file);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> AddItem(int cityid, string name, string description, int cost, int groupid, string username, string password, System.Web.HttpPostedFileBase file)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AddItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cityid", cityid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "name", name);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "description", description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cost", cost);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "groupid", groupid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "username", username);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "password", password);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "file", file);
            AddItemOverride(callInfo, cityid, name, description, cost, groupid, username, password, file);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void UpdateItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, int cityid, string name, string description, int cost, bool spetialdoctor, int groupid, string nezampezeshkicode, System.Web.HttpPostedFileBase fileupdate);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> UpdateItem(int id, int cityid, string name, string description, int cost, bool spetialdoctor, int groupid, string nezampezeshkicode, System.Web.HttpPostedFileBase fileupdate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cityid", cityid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "name", name);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "description", description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cost", cost);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "spetialdoctor", spetialdoctor);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "groupid", groupid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "nezampezeshkicode", nezampezeshkicode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "fileupdate", fileupdate);
            UpdateItemOverride(callInfo, id, cityid, name, description, cost, spetialdoctor, groupid, nezampezeshkicode, fileupdate);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void UpdateItemClientOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, string accountnumber, int cityidupdate, string name, string description, int cost, int groupid, string nezampezeshkicode, System.Web.HttpPostedFileBase fileupdate);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> UpdateItemClient(int id, string accountnumber, int cityidupdate, string name, string description, int cost, int groupid, string nezampezeshkicode, System.Web.HttpPostedFileBase fileupdate)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UpdateItemClient);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accountnumber", accountnumber);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cityidupdate", cityidupdate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "name", name);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "description", description);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "cost", cost);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "groupid", groupid);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "nezampezeshkicode", nezampezeshkicode);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "fileupdate", fileupdate);
            UpdateItemClientOverride(callInfo, id, accountnumber, cityidupdate, name, description, cost, groupid, nezampezeshkicode, fileupdate);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void SearchItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string text);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> SearchItem(string text)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SearchItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "text", text);
            SearchItemOverride(callInfo, text);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ChangeActiveOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeActive(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeActive);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ChangeActiveOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ChangeComboItemOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int stateid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeComboItem(int stateid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeComboItem);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "stateid", stateid);
            ChangeComboItemOverride(callInfo, stateid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void ChangeComboItemUpdateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int stateid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> ChangeComboItemUpdate(int stateid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeComboItemUpdate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "stateid", stateid);
            ChangeComboItemUpdateOverride(callInfo, stateid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DoctorBimeListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DoctorBimeList(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DoctorBimeList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DoctorBimeListOverride(callInfo, id);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

        [NonAction]
        partial void DeleteDoctorBimeOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, int doctorid);

        [NonAction]
        public override System.Threading.Tasks.Task<System.Web.Mvc.ActionResult> DeleteDoctorBime(int id, int doctorid)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DeleteDoctorBime);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "doctorid", doctorid);
            DeleteDoctorBimeOverride(callInfo, id, doctorid);
            return System.Threading.Tasks.Task.FromResult(callInfo as System.Web.Mvc.ActionResult);
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009, 0108, 0114
