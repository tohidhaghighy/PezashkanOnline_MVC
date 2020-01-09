using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.ServiceLayer.Contract.CityStateService;
using UrumiumMVC.ViewModel.EntityViewModel.CityState;

namespace UrumiumMVC.ServiceLayer.EFServices.CityStateService
{
    public class StateService:IStateService
    {

        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<State> _State;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public StateService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _State = _unitOfWork.Set<State>();
        }

        public async Task<bool> AddState(string name)
        {
            try
            {
                _State.Add(new State()
                {
                    Name = name
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteState(int Stateid)
        {
            var find = await _State.FirstOrDefaultAsync(a => a.Id == Stateid);
            if (find != null)
            {
                _State.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<State>> GetAllState()
        {
            return await _State.OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<List<StateViewModel>> GetAllStateWebservice()
        {
            List<StateViewModel> allstates = new List<StateViewModel>();
            var find= await _State.OrderBy(a => a.Name).ToListAsync();
            if (find!=null)
            {
                foreach (var item in find)
                {
                    StateViewModel newstate = new StateViewModel();
                    newstate.Id = item.Id;
                    newstate.Name = item.Name;
                    allstates.Add(newstate);

                }
            }
            return allstates;
        }
    }
}
