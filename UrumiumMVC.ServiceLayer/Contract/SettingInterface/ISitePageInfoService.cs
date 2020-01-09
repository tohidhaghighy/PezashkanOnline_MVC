using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;

namespace UrumiumMVC.ServiceLayer.Contract.SettingInterface
{
    public interface ISitePageInfoService
    {
        Task<bool> AddSitePagesInfo(string aboutus, string coorporationwithus, string siterolls);
        Task<bool> DeleteSitePagesInfo();
        Task<SitePagesInfo> GetSitePageInfo();
    }
}
