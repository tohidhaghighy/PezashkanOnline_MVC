using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Menu;

namespace UrumiumMVC.ServiceLayer.Contract.MenuInterface
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllMenu();
        Task<Boolean> AddMenu(int parent,string name);
        Task<Boolean> DeleteMenu(int menuid);
    }
}
