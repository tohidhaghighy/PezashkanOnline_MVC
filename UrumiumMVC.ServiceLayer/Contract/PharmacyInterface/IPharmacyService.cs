using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.Contract.PharmacyInterface
{
    public interface IPharmacyService
    {
        Task<bool> AddPharmacy(string Name, string Description, int CityId, string Image, string UserId, string address);
        Task<bool> AddPharmacywithsms(string Name, int CityId, string Image, string UserId, string Mobile,string Password);
        Task<bool> AddPharmacyMadrak(string Name, string Description, int CityId, string Image, string UserId, string address, string Scanmelli, string Scanshenasname, string Scanparvane, string Scannezam);
        Task<bool> AddPharmacyMadrakwithmobile(string Password, string Name, string Mobile, string Description, int CityId, string Image, string UserId, string address, string Scanmelli, string Scanshenasname, string Scanparvane, string Scannezam);
        Task<bool> UpdatePharmacy(int id, string Name, string Description, int CityId, string Image,string address);
        Task<bool> DeletePharmacy(int id);
        int GetAllPharmacyCount();
        Task<List<Pharmacy>> GetAllPharmacy();
        Task<List<NotificationUser>> GetPharmacyNotifi();
        Task<List<Pharmacy>> GetAllPharmacyActive();
        Task<List<Pharmacy>> SearchPharmacy(string text);
        Task<Pharmacy> GetPharmacy(string id);
        Task<Pharmacy> GetPharmacyClient(int id);
        Task<bool> ChangeActive(int id);


        //wen servic item list

        Task<List<PharmacyWebService>> GetAllPharmacyForService();
        Task<bool> CheckLogin(string mobile, string password);
        Task<Pharmacy> CheckLoginwithmobile(string mobile, string password);
        Task<bool> GetPharmacyWithMobile(string mobile);
        Task<bool> UpdatePharmacyMadrakWithMobile(string mobile, string mellicart, string shenasname, string parvane, string nezampezeshki);
        Task<PharmacyWebService> GetPharmacyInfoWithMobile(string mobile);
        Task<bool> UpdatePharmacyInfoWithMobile(string mobile, string Name, string Description, int CityId, string Image, string address);
        Task<Boolean> UpdateActivePharmacyuser(string mobile);
        Task<Boolean> Changepassword(string mobile, string pass, string newpassword);

    }
}
