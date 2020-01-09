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
    public class SitePageInfoService:ISitePageInfoService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<SitePagesInfo> _SitePagesInfo;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion


        public SitePageInfoService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _SitePagesInfo = _unitOfWork.Set<SitePagesInfo>();
        }
        public async Task<bool> AddSitePagesInfo(string aboutus,string coorporationwithus,string siterolls)
        {
            await DeleteSitePagesInfo();
            try
            {

                _SitePagesInfo.Add(new SitePagesInfo()
                {
                    AboutUs=aboutus,
                    CoorprateWithUs=coorporationwithus,
                    SiteRolles=siterolls
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSitePagesInfo()
        {
            var find = await _SitePagesInfo.ToListAsync();
            if (find != null)
            {
                foreach (var item in find)
                {
                    _SitePagesInfo.Remove(item);
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<SitePagesInfo> GetSitePageInfo()
        {
            var find= await _SitePagesInfo.FirstOrDefaultAsync();
            if (find!=null)
            {
                return find;
            }
            else
            {
                
            }
            return null;
        }
    }
}
