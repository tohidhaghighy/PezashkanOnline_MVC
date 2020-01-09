using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Violation;
using UrumiumMVC.ViewModel.EntityViewModel.ViolationViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.ViolationInterface
{
    public interface IViolationService
    {
        Task<bool> AddViolation(string number, string userid, string description, int type, string doctorid);
        Task<List<Violation>> ListViolation();
        Task<List<Violation>> GetViolation(string number);
        Task<bool> CheckViolationByAdmin(int Id, string des, bool check);
        Task<List<ViolationViewModel>> ListViolationOnlyNotCheck();
        Task<List<ViolationViewModel>> GetViolationsearch(string number);
        Task<bool> ChangeChecktoOk(int id, string text);

        Task<List<ViolationViewModel>> GetViolationuserwithanswer(string userid);
    }
}
