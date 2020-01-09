using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.ViewModel.EntityViewModel.CityState;

namespace UrumiumMVC.ServiceLayer.Contract.CityStateService
{
    public interface ICityService
    {
        Task<bool> AddCity(string name, int stateid);
        Task<bool> DeleteCity(int cityid);
        Task<List<City>> GetAllCity();
        Task<List<City>> GetStateCity(int stateid);


        //webservice list city
        Task<List<CityWithoutFroegnkey>> GetAllCityWebservice();
    }
}
