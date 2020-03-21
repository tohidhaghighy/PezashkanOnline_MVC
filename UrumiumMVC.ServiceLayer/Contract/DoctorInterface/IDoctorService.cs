using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.Contract.DoctorInterface
{
    public interface IDoctorService
    {
        Task<bool> AddDoctor(string Name, string Family, string Description, int CityId, string Image, int Cost, Boolean SpetialDoctor, string Userid, int Groupid);
        Task<int> AddDoctorMadrak(string Name, string Family, string Description, int CityId, string Image, int Cost, Boolean SpetialDoctor, string Userid, int Groupid, string Scanmelli, string Scanshenasname, string Scannezam);
        Task<int> AddDoctorMadrakWithMobile(string password, string Name,string Mobile, string Family, string Description, int CityId, string Image, int Cost, Boolean SpetialDoctor, string Userid, int Groupid, string Scanmelli, string Scanshenasname, string Scannezam);
        Task<bool> DeleteDoctor(int id);
        int GetAllDoctorCount();
        Task<List<Doctor>> GetAllDoctor();
        Task<List<NotificationUser>> GetDoctorNotifiList();
        Task<List<Doctor>> GetAllDoctorActive();
        Task<List<Doctor>> GetAllCityDoctor(int cityid,string text);
        Task<List<Doctor>> GetGroupCityDoctor(int groupid, int cityid,string text);
        Task<List<Doctor>> SearchDoctor(string text);
        Task<bool> GetDoctorWithMobile(string mobile);
        Task<bool> ChangeActive(int id);
        Task<bool> UpdateDoctor(int id, string accountnumber, string Name, string Description, int CityId, string Image, int GroupId, int Cost, Boolean SpetialDoctor, string NezampezeshkiCode);
        Task<Doctor> GetDoctor(int id);
        Task<DoctorDetailWebService> GetDoctorWebService(int id);
        Task<List<Doctor>> GetGroupDoctor(int groupid);
        Task<Doctor> GetDoctorwithguidid(string id);
        Task<bool> UpdateDoctorBusinessKey(int id, string key);
        Task<string> GetBussinessKey(int doctorid);

        //sms function mobile
        Task<string> GetSmsCode(string Mobile);
        Task<bool> ActiveSmsCode(string Mobile, string Code);
        Task<bool> UpdateDoctorMadarekwithSms(string Mobile, string Image, string ScanMelliCode, string ScanNezamPezeshki, string ScanShenasname);
        Task<bool> AddDoctorwithSms(string Name, int CityId, string Image, string Userid, int Groupid, string Mobile,string Password);


        // web service doctor listr
        Task<List<DoctorWebService>> GetCityDoctorForService(int cityid);
        Task<List<DoctorWebService>> GetTextDoctorForService(string text);
        Task<List<DoctorWebService>> GetGroupDoctorForService(int groupid);
        Task<List<DoctorWebService>> GetAllDoctorForService();
        Task<bool> CheckLogin(string mobile, string password);
        Task<Doctor> CheckLoginWithMobile(string mobile, string password);
        Task<bool> UpdateMadarekDoctorWithMobile(string mobile, string mellicartname, string shenasnamename, string nezampezeshkiname);

        Task<Doctor> GetDoctorValueWithMobile(string mobile);



        // code moaref zir majmoee

        Task<bool> AddDoctorMoarefWithCode(string Code, int ZirDoctorId);
        Task<int> ListDoctorMoaref(int doctorid);
        Task<List<Doctorlistmoaref>> ListStringDoctorMoaref(int doctorid);

        // web service managment
        Task<DoctorDetailWebService> GetDoctorWithMobileWebService(string mobile);
        Task<bool> UpdateDoctorWebservice(int id, string Name, string bankcode, int CityId, int groupid, string nezampezeshki, int cost, string description, string image);
        Task<List<DoctorWebService>> GetCityGroupDoctorForService(int cityid, int groupid);
        Task<Boolean> UpdateActiveDoctoruser(string mobile);
        Task<Boolean> Changepassword(string mobile, string pass, string newpassword);


        Task<List<Doctorlistmoaref>> ListStringDoctorMoarefWithSubsetinfo(int doctorid);


        //web service zirmajmoee
        Task<List<Doctorlistmoaref>> ListStringDoctorMoarefzirmajmoee(int doctorid, string code);


    }
}
