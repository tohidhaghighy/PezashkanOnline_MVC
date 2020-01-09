using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.Contract.JudgeInterface
{
    public interface IJudgeService
    {
        Task<bool> Addjudge(string Name, string Family, string Description, int CityId, string Image, string UserId);
        Task<bool> AddjudgeMadrak(string Name, string Family, string Description, int CityId, string Image, string UserId, string Scanmelli, string Scanshenasname, string Scanmadrak);
        Task<bool> AddjudgeMadrakWithMobile(string Password, string Name,string Mobile, string Family, string Description, int CityId, string Image, string UserId, string Scanmelli, string Scanshenasname, string Scanmadrak);
        Task<bool> Deletejudge(int id);
        int GetAlljudgeCount();
        Task<List<judge>> GetAlljudge();
        Task<List<judge>> GetAlljudgeActive();
        Task<List<judge>> Searchjudge(string text);
        Task<bool> Updatejudge(int id, string accountnumber, string Name, string Description, int CityId, string Image);
        Task<judge> Getjudge(string id);
        Task<judge> GetjudgeClient(int id);
        Task<bool> ChangeActive(int id);
        Task<bool> Addjudgewithsms(string Name, int CityId, string Image, string UserId, string Mobile,string Password);

        //web service list
        Task<List<JudgeWebService>> GetAllJudgeForService();
        Task<bool> CheckLogin(string mobile, string password);
        Task<judge> CheckLoginwithmobile(string mobile, string password);
        Task<bool> GetJudgewithmobile(string mobile);
        Task<bool> UpdateJudgeMadarekwithmobile(string mobile, string mellicart, string shenasname, string madrak);

        //web service
        Task<judge> GetJudgeInfowithmobile(string mobile);
        Task<bool> Updatejudgewithmobile(string mobile, string Name, string Description, int CityId, string Image);
        Task<Boolean> UpdateActiveJudgeuser(string mobile);
        Task<Boolean> Changepassword(string mobile, string pass, string newpassword);
    }
}
