using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.Contract.GroupInterface
{
    public interface IGroupService
    {
        Task<List<Group>> GetAllGroup();
        Task<Boolean> AddGroup(int parent, string name,string src);
        Task<Boolean> DeleteGroup(int groupid);
        Task<Group> GetFirstGroup();


        //group web service

        Task<List<GroupWebService>> GetAllGroupForService();
    }
}
