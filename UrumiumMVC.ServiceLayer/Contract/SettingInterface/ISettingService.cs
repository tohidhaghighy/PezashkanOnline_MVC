using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;

namespace UrumiumMVC.ServiceLayer.Contract.SettingInterface
{
    public interface ISettingService
    {
        Task<Setting> GetSetting();
        Task<Boolean> AddSetting(Setting settings);
        Task<Boolean> DeleteSetting();
    }
}
