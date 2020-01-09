using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;
using UrumiumMVC.ServiceLayer.Contract.FooterInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.FooterService
{
    public class FooterService: IFooterService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<FooterItem> _FooterItems;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion


        public FooterService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _FooterItems = _unitOfWork.Set<FooterItem>();
        }


        public async Task<bool> AddFooter(FooterItem footerItem)
        {
            try
            {
                _FooterItems.Add(footerItem);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteFooter(int id)
        {
            var find = await _FooterItems.FirstOrDefaultAsync(a=>a.Id==id);
            if (find != null)
            {
                _FooterItems.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<FooterItem>> GetFooter()
        {
            return await _FooterItems.ToListAsync();
        }
    }
}
