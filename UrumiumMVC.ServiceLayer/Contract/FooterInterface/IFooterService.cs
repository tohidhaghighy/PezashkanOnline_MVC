using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;

namespace UrumiumMVC.ServiceLayer.Contract.FooterInterface
{
    public interface IFooterService
    {
        Task<bool> AddFooter(FooterItem footerItem);
        Task<bool> DeleteFooter(int id);
        Task<List<FooterItem>> GetFooter();
    }
}
