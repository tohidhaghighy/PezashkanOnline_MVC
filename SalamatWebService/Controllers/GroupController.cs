using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;

namespace SalamatWebService.Controllers
{
    public class GroupController : ApiController
    {
        ApplicationDbContext _dbcontext;
        IGroupService _groupservice;

        public GroupController(IGroupService groupservice)
        {
            _groupservice = groupservice;
        }
        public async Task<List<Group>> Get()
        {
            return await _groupservice.GetAllGroup();
        }
    }
}
