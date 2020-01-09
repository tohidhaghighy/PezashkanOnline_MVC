using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Menu;
using UrumiumMVC.ServiceLayer.Contract.MenuInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.MenuService
{
    public class MenuService : IMenuService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Menu> _Menus;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public MenuService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Menus = _unitOfWork.Set<Menu>();
        }


        public async Task<Boolean> AddMenu(int parent,string name)
        {
            try
            {
                _Menus.Add(new Menu()
                { 
                    Name=name,
                    ParentId=parent
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Boolean> DeleteMenu(int menuid)
        {
            var find = await _Menus.FirstOrDefaultAsync(a => a.Id == menuid);
            if (find != null)
            {
                _Menus.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Menu>> GetAllMenu()
        {
            return await _Menus.ToListAsync();
        }
    }
}
