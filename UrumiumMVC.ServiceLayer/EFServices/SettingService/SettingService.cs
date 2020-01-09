using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;
using UrumiumMVC.ServiceLayer.Contract.SettingInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.SettingService
{
    public class SettingService : ISettingService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Setting> _Settings;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion
        

        public SettingService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Settings = _unitOfWork.Set<Setting>();
        }
        public async Task<bool> AddSetting(Setting settings)
        {
            await DeleteSetting();
            try
            {
                _Settings.Add(settings);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSetting()
        {
            var find = await _Settings.ToListAsync();
            if (find != null)
            {
                foreach (var item in find)
                {
                    _Settings.Remove(item);
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Setting> GetSetting()
        {
            return await _Settings.FirstOrDefaultAsync();
        }
        
    }
}
