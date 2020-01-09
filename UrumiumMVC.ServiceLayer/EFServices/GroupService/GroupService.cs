using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.EFServices.GroupService
{
    public class GroupService : IGroupService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Group> _Group;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public GroupService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Group = _unitOfWork.Set<Group>();
        }
        public async Task<bool> AddGroup(int parent, string name, string src)
        {
            try
            {
                _Group.Add(new Group()
                {
                    Name = name,
                    GroupId = parent,
                    Icon=src
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteGroup(int groupid)
        {
            var find = await _Group.FirstOrDefaultAsync(a => a.Id == groupid);
            if (find != null)
            {
                _Group.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Group>> GetAllGroup()
        {
            return await _Group.ToListAsync();
        }

        public async Task<Group> GetFirstGroup()
        {
            return await _Group.FirstOrDefaultAsync();
        }

        public async Task<List<GroupWebService>> GetAllGroupForService()
        {
            List<GroupWebService> allwebservice = new List<GroupWebService>();
            var find= await _Group.ToListAsync();
            foreach (var item in find)
            {
                GroupWebService newgroup = new GroupWebService();
                newgroup.Id = item.Id;
                newgroup.Name = item.Name;
                allwebservice.Add(newgroup);
            }
            return allwebservice;
        }
    }
}
