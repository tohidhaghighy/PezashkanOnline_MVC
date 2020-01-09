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
    public class CityService:ICityService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<City> _City;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public CityService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _City = _unitOfWork.Set<City>();
        }
        public async Task<bool> AddCity(string name,int stateid)
        {
            try
            {
                _City.Add(new City()
                {
                    Name = name,
                    StateId = stateid
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteCity(int cityid)
        {
            var find = await _City.FirstOrDefaultAsync(a => a.Id == cityid);
            if (find != null)
            {
                _City.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<City>> GetAllCity()
        {
            return await _City.OrderBy(a => a.Name).ToListAsync();
        }

        public async Task<List<CityWithoutFroegnkey>> GetAllCityWebservice()
        {
            List<CityWithoutFroegnkey> alllist = new List<CityWithoutFroegnkey>();
            var find= await _City.OrderBy(a => a.Name).ToListAsync();
            if (find!=null)
            {
                foreach (var item in find)
                {
                    CityWithoutFroegnkey newcity = new CityWithoutFroegnkey();
                    newcity.Id = item.Id;
                    newcity.Name = item.Name;
                    newcity.StateId = item.StateId;
                    alllist.Add(newcity);
                }
            }
            return alllist;
        }
        
        public async Task<List<City>> GetStateCity(int stateid)
        {
            return await _City.Where(a=>a.StateId==stateid).OrderBy(a => a.Name).ToListAsync();
        }
    }
}
