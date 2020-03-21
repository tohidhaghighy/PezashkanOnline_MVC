using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.Massage;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ServiceLayer.Contract.DoctorInterface;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.EFServices.DoctorService
{
    public class DoctorService:IDoctorService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Doctor> _Doctor;
        private readonly IDbSet<VisitTime> _VisitTime;
        private readonly IDbSet<DoctorMoarefCode> _DoctorMoarefCode;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public DoctorService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Doctor = _unitOfWork.Set<Doctor>();
            _VisitTime = _unitOfWork.Set<VisitTime>();
            _DoctorMoarefCode = _unitOfWork.Set<DoctorMoarefCode>();
        }

        public async Task<bool> AddDoctor(string Name,string Family, string Description, int CityId, string Image,int Cost,Boolean SpetialDoctor,string Userid,int Groupid)
        {
            try
            {
                string code=GetRandomString(6);
                _Doctor.Add(new Doctor()
                {
                    Active=false,
                    Cost=Cost,
                    IllnessCountVisit=0,
                    SpecialDoctor=SpetialDoctor,
                    Userid= Userid,
                    StartTime=DateTime.Now,
                    Description = Description,
                    GroupId=Groupid,
                    ViewerCount=0,
                    Image = Image,
                    Name = Name,
                    Family= Family,
                    CityId = CityId,
                    NezamPezeshkiCode="",
                    BusinessKey=code,
                    Mobile="",
                    CodeActiveUse="",
                    Is_Use_CodeValue=false
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddDoctorwithSms(string Name, int CityId, string Image, string Userid, int Groupid,string Mobile,string Password)
        {
            try
            {
                var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == Mobile);
                if ( finddoc==null)
                {
                    string code = GetRandomString(6);
                    string codesms = GetRandomString(6);
                    _Doctor.Add(new Doctor()
                    {
                        Active = false,
                        Cost = 0,
                        IllnessCountVisit = 0,
                        SpecialDoctor = false,
                        Userid = Userid,
                        StartTime = DateTime.Now,
                        Description = "",
                        GroupId = Groupid,
                        ViewerCount = 0,
                        Image = Image,
                        Name = Name,
                        Family = "",
                        CityId = CityId,
                        NezamPezeshkiCode = "",
                        Mobile=Mobile,
                        BusinessKey = code,
                        CodeActiveUse = codesms,
                        Is_Use_CodeValue = false,
                        Password=Password
                    });
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
               
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CheckLogin(string mobile,string password)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find!=null)
            {
                return true;
            }
            return false;
        }

        public async Task<Doctor> CheckLoginWithMobile(string mobile, string password)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return find;
            }
            return null;
        }
        public async Task<Boolean> Changepassword(string mobile ,string pass, string newpassword)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == pass);
            if (find != null)
            {
                find.Password = newpassword;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> GetDoctorWithMobile(string mobile)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<NotificationUser>> GetDoctorNotifiList()
        {
            var find = from db in _Doctor
                       select new NotificationUser { Id = db.Id, Name = db.Name, Userid = db.Userid };
            return find.ToList();
        }

        public async Task<Doctor> GetDoctorValueWithMobile(string mobile)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return find;
            }
            return null;
        }
        public async Task<bool> UpdateMadarekDoctorWithMobile(string mobile,string mellicartname,string shenasnamename,string nezampezeshkiname)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.ScanMelliCode = mellicartname;
                find.ScanShenasname = shenasnamename;
                find.ScanNezamPezeshki = nezampezeshkiname;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDoctorMadarekwithSms(string Mobile,string Image,string ScanMelliCode,string ScanNezamPezeshki,string ScanShenasname)
        {
            try
            {
                var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == Mobile);
                if (finddoc != null)
                {
                    finddoc.Image = Image;
                    finddoc.ScanMelliCode = ScanMelliCode;
                    finddoc.ScanNezamPezeshki = ScanNezamPezeshki;
                    finddoc.ScanShenasname = ScanShenasname;
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<string> GetSmsCode(string Mobile)
        {
                var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == Mobile);
                if (finddoc != null)
                {
                finddoc.Is_Use_CodeValue = true;
                await _unitOfWork.SaveChangesAsync();
                    return finddoc.CodeActiveUse;
                }
            return "";
        }

        public async Task<bool> ActiveSmsCode(string Mobile,string Code)
        {
            var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == Mobile);
            if (finddoc != null)
             {
                 if (finddoc.CodeActiveUse==Code)
                  {
                        return true;
                  }
              }
            return false;
        }

        public async Task<int> AddDoctorMadrakWithMobile(string password,string Name,string Mobile, string Family, string Description, int CityId, string Image, int Cost, Boolean SpetialDoctor, string Userid, int Groupid, string Scanmelli, string Scanshenasname, string Scannezam)
        {
            try
            {
                string code = GetRandomString(6);
                var find = _Doctor.Add(new Doctor()
                {
                    Active = false,
                    Cost = Cost,
                    IllnessCountVisit = 0,
                    SpecialDoctor = SpetialDoctor,
                    Userid = Userid,
                    StartTime = DateTime.Now,
                    Description = Description,
                    GroupId = Groupid,
                    ViewerCount = 0,
                    Image = Image,
                    Name = Name,
                    Family = Family,
                    CityId = CityId,
                    NezamPezeshkiCode = "",
                    BusinessKey = code,
                    ScanMelliCode = Scanmelli,
                    ScanNezamPezeshki = Scannezam,
                    ScanShenasname = Scanshenasname,
                    Mobile = Mobile,
                    Is_Use_CodeValue = false,
                    CodeActiveUse = "",
                    Password=password
                });
                await _unitOfWork.SaveChangesAsync();
                return find.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<int> AddDoctorMadrak(string Name, string Family, string Description, int CityId, string Image, int Cost, Boolean SpetialDoctor, string Userid, int Groupid,string Scanmelli,string Scanshenasname,string Scannezam)
        {
            try
            {
                string code = GetRandomString(6);
                var find=_Doctor.Add(new Doctor()
                {
                    Active = false,
                    Cost = Cost,
                    IllnessCountVisit = 0,
                    SpecialDoctor = SpetialDoctor,
                    Userid = Userid,
                    StartTime = DateTime.Now,
                    Description = Description,
                    GroupId = Groupid,
                    ViewerCount = 0,
                    Image = Image,
                    Name = Name,
                    Family = Family,
                    CityId = CityId,
                    NezamPezeshkiCode = "",
                    BusinessKey = code,
                    ScanMelliCode=Scanmelli,
                    ScanNezamPezeshki=Scannezam,
                    ScanShenasname=Scanshenasname,
                    Mobile="",
                    Is_Use_CodeValue=false,
                    CodeActiveUse=""
                });
                await _unitOfWork.SaveChangesAsync();
                return find.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Doctor.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Doctor>> GetAllDoctor()
        {
            return await _Doctor.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<Doctor>> GetAllDoctorActive()
        {
            return await _Doctor.Where(b=>b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<Doctor>> GetAllCityDoctor(int cityid,string text)
        {
            return await _Doctor.Where(a =>a.Active==true && a.CityId==cityid && (a.Name.Contains(text) || a.Description.Contains(text))).OrderByDescending(a => a.Id).ToListAsync();
        }

        public int GetAllDoctorCount()
        {
            return _Doctor.OrderByDescending(a => a.Id).Count();
        }

        public async Task<List<Doctor>> GetGroupDoctor(int groupid)
        {
            return await _Doctor.OrderByDescending(a => a.Id).Where(a=>a.GroupId==groupid && a.Active==true).ToListAsync();
        }

        public async Task<List<Doctor>> GetGroupCityDoctor(int groupid,int cityid,string text)
        {
            return await _Doctor.Where(a => a.GroupId == groupid && a.CityId==cityid && (a.Name.Contains(text) || a.Description.Contains(text))).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _Doctor.FirstOrDefaultAsync(a=>a.Id==id);
        }

        public async Task<DoctorDetailWebService> GetDoctorWebService(int id)
        {
            DoctorDetailWebService _doctor = new DoctorDetailWebService();
            var find= await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find!=null)
            {
                _doctor.Id = find.Id;
                _doctor.Name = find.Name;
                _doctor.Description = find.Description;
                _doctor.Cost = find.Cost.ToString();
                _doctor.Image = find.Image;
                _doctor.Takhasos = find.Groups.Name;
                _doctor.Address = find.Cities.Name;
                _doctor.City = find.Cities.Name;
            }
            return _doctor;
        }

        public async Task<DoctorDetailWebService> GetDoctorWithMobileWebService(string mobile)
        {
            DoctorDetailWebService _doctor = new DoctorDetailWebService();
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                _doctor.Id = find.Id;
                _doctor.Name = find.Name;
                _doctor.Description = find.Description;
                _doctor.Cost = find.Cost.ToString();
                _doctor.Image = find.Image;
                _doctor.NezamPezeshki = find.NezamPezeshkiCode;
                _doctor.Bankcode = find.AccountNumber;
            }
            return _doctor;
        }



        public async Task<Doctor> GetDoctorwithguidid(string id)
        {
            return await _Doctor.FirstOrDefaultAsync(a => a.Userid == id);
        }

        public async Task<List<Doctor>> SearchDoctor(string text)
        {
            return await _Doctor.Where(a => a.Name.Contains(text) || a.Description.Contains(text) || a.Groups.Name.Contains(text)).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<bool> UpdateDoctor(int id, string accountnumber, string Name, string Description, int CityId, string Image,int GroupId,int Cost,Boolean SpetialDoctor, string NezampezeshkiCode)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                find.Name = Name;
                find.Description = Description;
                if(CityId!=0)
                find.CityId = CityId;
                if (Image != "" && Image != null)
                {
                    find.Image = Image;
                }
                find.GroupId = GroupId;
                find.Cost = Cost;
                find.AccountNumber = accountnumber;
                find.NezamPezeshkiCode = NezampezeshkiCode;
                find.SpecialDoctor = SpetialDoctor;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDoctorWebservice(int id, string Name,string bankcode, int CityId,int groupid, string nezampezeshki, int cost, string description, string image)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                find.Name = Name;
                find.Description = description;
                if (CityId != 0)
                    find.CityId = CityId;
                if (image != "" && image != null)
                {
                    find.Image = image;
                }
                find.GroupId = groupid;
                find.Cost = cost;
                find.AccountNumber = bankcode;
                find.NezamPezeshkiCode = nezampezeshki;
                find.SpecialDoctor = false;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateDoctorBusinessKey(int id,string key)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                find.BusinessKey = key;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }


        public async Task<bool> ChangeActive(int id)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                if (find.Active==true)
                {
                    find.Active = false;
                }
                else
                {
                    find.Active = true;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> GetBussinessKey(int doctorid)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Id == doctorid);
            if (find != null)
            {
                return find.BusinessKey;
            }
            return "";
        }

        Random rand = new Random();
        public string GetRandomString(int length)
        {
            string s = "";
            for (int i = 0; i < length; i++)
                s += rand.Next(0, 10);
            return s;
        }




        //web service functions
        public async Task<List<DoctorWebService>> GetAllDoctorForService()
        {
            List<DoctorWebService> _doctorlist = new List<DoctorWebService>();
            var find= await _Doctor.Where(b=>b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                DoctorWebService newdoctor = new DoctorWebService();
                newdoctor.Id = item.Id;
                if (item.Image == null || item.Image == "")
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.DoctorUrl + item.Image;
                }

                newdoctor.Name = item.Name;
                newdoctor.Takhasos = item.Groups.Name;
                newdoctor.City = item.Cities.Name;
                newdoctor.Cost = item.Cost.ToString();
                newdoctor.Description = item.Description;
                _doctorlist.Add(newdoctor);
            }
            return _doctorlist;
        }

        public async Task<List<DoctorWebService>> GetGroupDoctorForService(int groupid)
        {
            List<DoctorWebService> _doctorlist = new List<DoctorWebService>();
            var find = await _Doctor.Where(b=>b.GroupId==groupid && b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                DoctorWebService newdoctor = new DoctorWebService();
                newdoctor.Id = item.Id;
                if (item.Image == null || item.Image == "")
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.DoctorUrl + item.Image;
                }

                newdoctor.Name = item.Name;
                newdoctor.Takhasos = item.Groups.Name;
                newdoctor.City = item.Cities.Name;
                newdoctor.Cost = item.Cost.ToString();
                newdoctor.Description = item.Description;
                _doctorlist.Add(newdoctor);
            }
            return _doctorlist;
        }

        public async Task<List<DoctorWebService>> GetTextDoctorForService(string text)
        {
            List<DoctorWebService> _doctorlist = new List<DoctorWebService>();
            var find = await _Doctor.Where(b =>( b.Name.Contains(text) || b.Description.Contains(text)) && b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                DoctorWebService newdoctor = new DoctorWebService();
                newdoctor.Id = item.Id;
                if (item.Image == null || item.Image == "")
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.DoctorUrl + item.Image;
                }

                newdoctor.Name = item.Name;
                newdoctor.Takhasos = item.Groups.Name;
                newdoctor.City = item.Cities.Name;
                newdoctor.Cost = item.Cost.ToString();
                newdoctor.Description = item.Description;
                _doctorlist.Add(newdoctor);
            }
            return _doctorlist;
        }

        public async Task<List<DoctorWebService>> GetCityDoctorForService(int cityid)
        {
            List<DoctorWebService> _doctorlist = new List<DoctorWebService>();
            var find = await _Doctor.Where(b => b.CityId==cityid && b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                DoctorWebService newdoctor = new DoctorWebService();
                newdoctor.Id = item.Id;
                if (item.Image == null || item.Image == "")
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.DoctorUrl + item.Image;
                }

                newdoctor.Name = item.Name;
                newdoctor.Takhasos = item.Groups.Name;
                newdoctor.City = item.Cities.Name;
                newdoctor.Cost = item.Cost.ToString();
                newdoctor.Description = item.Description;
                _doctorlist.Add(newdoctor);
            }
            return _doctorlist;
        }

        public async Task<List<DoctorWebService>> GetCityGroupDoctorForService(int cityid,int groupid)
        {
            List<DoctorWebService> _doctorlist = new List<DoctorWebService>();
            var find = await _Doctor.Where(b => b.CityId == cityid && b.GroupId==groupid && b.Active == true).OrderByDescending(a => a.Id).ToListAsync();
            
            foreach (var item in find)
            {
                DoctorWebService newdoctor = new DoctorWebService();
                newdoctor.Id = item.Id;
                if (item.Image==null || item.Image=="")
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newdoctor.Image = ImgSrc.MainUrl + ImgSrc.DoctorUrl + item.Image;
                }
                
                newdoctor.Name = item.Name;
                newdoctor.Takhasos = item.Groups.Name;
                newdoctor.City = item.Cities.Name;
                newdoctor.Cost = item.Cost.ToString();
                newdoctor.Description = item.Description;
                _doctorlist.Add(newdoctor);
            }
            return _doctorlist;
        }


        // doctor moaref code  
        public async Task<bool> AddDoctorMoaref(int MainDoctorId,int ZirDoctorId)
        {
            try
            {
                _DoctorMoarefCode.Add(new DoctorMoarefCode()
                {
                    Id_Doctor_Main=MainDoctorId,
                    Id_Doctor_Zir=ZirDoctorId
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> AddDoctorMoarefWithCode(string Code, int ZirDoctorId)
        {
            try
            {
                var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.BusinessKey == Code);
                if (finddoc!=null)
                {
                    _DoctorMoarefCode.Add(new DoctorMoarefCode()
                    {
                        Id_Doctor_Main = finddoc.Id,
                        Id_Doctor_Zir = ZirDoctorId
                    });
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
               
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<int> ListDoctorMoaref(int doctorid)
        {
            try
            {
                int counter = 0;
                List<DoctorMoarefCode> poshelist = new List<DoctorMoarefCode>();
                var findlist = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == doctorid).ToListAsync();
                if (findlist.Count > 0)
                {
                    foreach (var item in findlist)
                    {
                        poshelist.Add(new DoctorMoarefCode()
                        {
                            Id_Doctor_Main = doctorid,
                            Id_Doctor_Zir = item.Id_Doctor_Zir
                        });
                    }

                    while (poshelist.Count > 0)
                    {
                        var findfirst = poshelist.FirstOrDefault();
                        var findpo = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == findfirst.Id_Doctor_Zir).ToListAsync();
                        foreach (var item in findpo)
                        {
                            poshelist.Add(new DoctorMoarefCode()
                            {
                                Id_Doctor_Main = findfirst.Id_Doctor_Main,
                                Id_Doctor_Zir = item.Id_Doctor_Zir
                            });
                        }
                        poshelist.Remove(findfirst);
                        counter++;
                    }
                    return counter;
                }

                return findlist.Count;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<List<Doctorlistmoaref>> ListStringDoctorMoaref(int doctorid)
        {
            List<Doctorlistmoaref> allmoareflist = new List<Doctorlistmoaref>();
            try
            {
                int counter = 0;
                List<DoctorMoarefCode> poshelist = new List<DoctorMoarefCode>();
                var findlist = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == doctorid).ToListAsync();
                if (findlist.Count > 0)
                {
                    foreach (var item in findlist)
                    {
                        poshelist.Add(new DoctorMoarefCode()
                        {
                            Id_Doctor_Main = doctorid,
                            Id_Doctor_Zir = item.Id_Doctor_Zir
                        });
                        var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                        if (finddoc != null)
                        {
                            allmoareflist.Add(new Doctorlistmoaref()
                            {
                                Id = item.Id,
                                Userid = finddoc.Name
                            });
                        }
                    }

                    while (poshelist.Count > 0)
                    {
                        var findfirst = poshelist.FirstOrDefault();
                        var findpo = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == findfirst.Id_Doctor_Zir).ToListAsync();
                        foreach (var item in findpo)
                        {
                            poshelist.Add(new DoctorMoarefCode()
                            {
                                Id_Doctor_Main = findfirst.Id_Doctor_Main,
                                Id_Doctor_Zir = item.Id_Doctor_Zir
                            });
                            var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                            if (finddoc != null)
                            {
                                allmoareflist.Add(new Doctorlistmoaref()
                                {
                                    Id = item.Id_Doctor_Zir,
                                    Userid = finddoc.Name
                                });
                            }
                        }
                        poshelist.Remove(findfirst);
                        counter++;
                    }
                    return allmoareflist;
                }

                return allmoareflist;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Doctorlistmoaref>> ListStringDoctorMoarefWithSubsetinfo(int doctorid)
        {
            List<Doctorlistmoaref> allmoareflist = new List<Doctorlistmoaref>();
            try
            {
                int counter = 0;
                List<DoctorMoarefCode> poshelist = new List<DoctorMoarefCode>();
                var findlist = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == doctorid).ToListAsync();
                if (findlist.Count > 0)
                {
                    foreach (var item in findlist)
                    {
                        poshelist.Add(new DoctorMoarefCode()
                        {
                            Id_Doctor_Main = doctorid,
                            Id_Doctor_Zir = item.Id_Doctor_Zir
                        });
                        var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                        if (finddoc != null)
                        {
                            Doctorlistmoaref newmoaref = new Doctorlistmoaref();
                            newmoaref.Id = item.Id_Doctor_Zir;
                            newmoaref.Userid = finddoc.Name;
                            var findcost = await _VisitTime.Where(a => a.DoctorId == item.Id).ToListAsync();
                            if (findcost != null)
                            {
                                newmoaref.CountVisit = findcost.Count();
                                int cost = 0;
                                foreach (var listcost in findcost)
                                {
                                    cost += listcost.Cost;
                                }
                                newmoaref.CostVisit = cost;
                            }
                            else
                            {
                                newmoaref.CostVisit = 0;
                                newmoaref.CountVisit = 0;
                            }
                            allmoareflist.Add(newmoaref);
                        }
                    }

                    while (poshelist.Count > 0)
                    {
                        var findfirst = poshelist.FirstOrDefault();
                        var findpo = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == findfirst.Id_Doctor_Zir).ToListAsync();
                        foreach (var item in findpo)
                        {
                            poshelist.Add(new DoctorMoarefCode()
                            {
                                Id_Doctor_Main = findfirst.Id_Doctor_Main,
                                Id_Doctor_Zir = item.Id_Doctor_Zir
                            });
                            var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                            if (finddoc != null)
                            {
                                Doctorlistmoaref newmoaref = new Doctorlistmoaref();
                                newmoaref.Id = item.Id_Doctor_Zir;
                                newmoaref.Userid = finddoc.Name;
                                var findcost = await _VisitTime.Where(a => a.DoctorId == item.Id_Doctor_Zir).ToListAsync();
                                if (findcost!=null)
                                {
                                    newmoaref.CountVisit = findcost.Count();
                                    int cost = 0;
                                    foreach (var listcost in findcost)
                                    {
                                        cost += listcost.Cost;
                                    }
                                    newmoaref.CostVisit = cost;
                                }
                                else
                                {
                                    newmoaref.CostVisit = 0;
                                    newmoaref.CountVisit = 0;
                                }
                                allmoareflist.Add(newmoaref);
                            }
                        }
                        poshelist.Remove(findfirst);
                        counter++;
                    }
                    return allmoareflist;
                }

                return allmoareflist;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Boolean> UpdateActiveDoctoruser(string mobile)
        {
            var find = await _Doctor.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.Is_Use_CodeValue = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;

        }



        //web service zirmajmoee

        public async Task<List<Doctorlistmoaref>> ListStringDoctorMoarefzirmajmoee(int doctorid,string code)
        {
            List<Doctorlistmoaref> allmoareflist = new List<Doctorlistmoaref>();
            allmoareflist.Add(new Doctorlistmoaref()
            {
                Id = 0,
                Userid = code
            });
            try
            {
                int counter = 0;
                List<DoctorMoarefCode> poshelist = new List<DoctorMoarefCode>();
                var findlist = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == doctorid).ToListAsync();
                if (findlist.Count > 0)
                {
                    foreach (var item in findlist)
                    {
                        poshelist.Add(new DoctorMoarefCode()
                        {
                            Id_Doctor_Main = doctorid,
                            Id_Doctor_Zir = item.Id_Doctor_Zir
                        });
                        var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                        if (finddoc != null)
                        {
                            allmoareflist.Add(new Doctorlistmoaref()
                            {
                                Id = item.Id,
                                Userid = finddoc.Name
                            });
                        }
                    }

                    while (poshelist.Count > 0)
                    {
                        var findfirst = poshelist.FirstOrDefault();
                        var findpo = await _DoctorMoarefCode.Where(a => a.Id_Doctor_Main == findfirst.Id_Doctor_Zir).ToListAsync();
                        foreach (var item in findpo)
                        {
                            poshelist.Add(new DoctorMoarefCode()
                            {
                                Id_Doctor_Main = findfirst.Id_Doctor_Main,
                                Id_Doctor_Zir = item.Id_Doctor_Zir
                            });
                            var finddoc = await _Doctor.FirstOrDefaultAsync(a => a.Id == item.Id_Doctor_Zir);
                            if (finddoc != null)
                            {
                                allmoareflist.Add(new Doctorlistmoaref()
                                {
                                    Id = item.Id_Doctor_Zir,
                                    Userid = finddoc.Name
                                });
                            }
                        }
                        poshelist.Remove(findfirst);
                        counter++;
                    }
                    return allmoareflist;
                }

                return allmoareflist;
            }
            catch (Exception)
            {
                return null;
            }
        }




    }
}
