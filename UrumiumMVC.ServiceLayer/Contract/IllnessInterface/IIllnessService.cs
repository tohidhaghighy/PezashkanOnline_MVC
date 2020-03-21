using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.IllnessInterface
{
    public interface IIllnessService
    {
        Task<bool> AddIllness(string Name, string Family, int CityId, string Image, string UserId, int age, int weight, int suger, int pressure, string serialbime, int bimeid);
        Task<bool> AddIllnesswithmobile(string Password, string Name,string Mobile, string Family, int CityId, string Image, string UserId, int age, int weight, int suger, int pressure, string serialbime, int bimeid);
        Task<bool> Deleteillness(int id);
        int GetAllillnessCount();
        Task<List<Illness>> GetAllillness();
        Task<List<NotificationUser>> GetIllnessNotifi();
        Task<List<Illness>> Searchillness(string text);
        Task<bool> Updateillness(int id, string Name, int CityId, string Image, int age, int weight, int suger, int pressure, string serialbime, int bimeid);
        Task<bool> UpdateillnessWithDate(int id, string Name, int CityId, string Image, string imagebimefirstpage, int age, int weight, int suger, int pressure, string serialbime, int bimeid, string date);
        Task<Illness> Getillness(string id);

        //mobile functions 
        Task<Boolean> Checksmscode(string code, string userid);
        Task<bool> AddIllnessWithSms(string Name, int CityId, string Image, string UserId, string Mobile, int insuranceid,string Password);
        Task<string> GetSmsCode(string userid);


        Task<Illness> GetillnessClient(int id);
        Task<bool> CheckLogin(string mobile, string password);
        Task<Illness> CheckLoginwithmobile(string mobile, string password);
        Task<Illness> GetIllnessWithMobile(string mobile);
        Task<IllnessWebService> GetIllnessWithMobileWebService(string mobile);
        Task<Boolean> Changepassword(string mobile, string pass, string newpassword);

        Task<Boolean> UpdateActiveIllnessuser(string mobile);

    }
}
