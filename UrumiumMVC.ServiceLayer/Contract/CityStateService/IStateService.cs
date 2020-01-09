using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.ViewModel.EntityViewModel.CityState;

namespace UrumiumMVC.ServiceLayer.Contract.CityStateService
{
    public interface IStateService
    {
        Task<bool> AddState(string name);
        Task<bool> DeleteState(int Stateid);
        Task<List<State>> GetAllState();
        Task<List<StateViewModel>> GetAllStateWebservice();
    }
}
