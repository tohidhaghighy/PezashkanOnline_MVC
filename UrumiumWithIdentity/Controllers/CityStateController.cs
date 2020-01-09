using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ViewModel.EntityViewModel.CityState;

namespace UrumiumWithIdentity.Controllers
{
    public partial class CityStateController : Controller
    {
        ICityService _cityservices;
        IStateService _stateservices;
        readonly IUnitOfWork _uow;
        public CityStateController(ICityService newcityservice, IStateService newstateservice,
            IUnitOfWork uow)
        {
            _cityservices = newcityservice;
            _stateservices = newstateservice;
            _uow = uow;
        }
        // GET: CityState
        public async virtual Task<ActionResult> City()
        {
            CityViewModel cityView = new CityViewModel();
            cityView.Cities = await _cityservices.GetAllCity();
            cityView.States = await _stateservices.GetAllState();
            return View(cityView);
        }

        public async virtual Task<ActionResult> State()
        {
            return View(await _stateservices.GetAllState());
        }


        [HttpPost]
        public async Task<Boolean> AddCity(string name, int stateid)
        {
            return await _cityservices.AddCity(name, stateid);
        }

        [HttpPost]
        public async Task<Boolean> AddState(string name)
        {
            return await _stateservices.AddState(name);
        }

        [HttpPost]
        public async Task<Boolean> DeleteCity(int id)
        {
            return await _cityservices.DeleteCity(id);
        }

        [HttpPost]
        public async Task<Boolean> DeleteState(int id)
        {
            return await _stateservices.DeleteState(id);
        }


    }
}