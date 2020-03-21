using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.ServiceLayer.Contract.IllnessInterface;
using UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.IllnessService
{
    public class IllnessService:IIllnessService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Illness> _illness;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public IllnessService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _illness = _unitOfWork.Set<Illness>();
        }

        public async Task<bool> AddIllnesswithmobile(string Password,string Name,string Mobile, string Family, int CityId, string Image, string UserId, int age, int weight, int suger, int pressure, string serialbime, int bimeid)
        {
            try
            {
                string code = GetRandomString(6);
                _illness.Add(new Illness()
                {
                    Image = Image,
                    Name = Name,
                    Family = Family,
                    Active = true,
                    Age = age,
                    InsuranceFinishDate = "",
                    Userid = UserId,
                    Sugar = suger,
                    Weight = weight,
                    InsuranceId = bimeid,
                    InsuranceSerial = serialbime,
                    PressureBlood = pressure,
                    CityId = CityId,
                    Mobile = Mobile,
                    CodeActiveUse = code,
                    Is_Use_CodeValue = false,
                    Password=Password
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> AddIllness(string Name,string Family, int CityId, string Image,string UserId,int age,int weight,int suger,int pressure,string serialbime,int bimeid)
        {
            try
            {
                _illness.Add(new Illness()
                {
                    Image = Image,
                    Name = Name,
                    Family=Family,
                    Active=true,
                    Age=age,
                    InsuranceFinishDate="",
                    Userid= UserId,
                    Sugar=suger,
                    Weight=weight,
                    InsuranceId=bimeid,
                    InsuranceSerial=serialbime,
                    PressureBlood=pressure,
                    CityId = CityId,
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

        public async Task<bool> AddIllnessWithSms(string Name, int CityId, string Image, string UserId,string Mobile,int insuranceid,string password)
        {
                var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == Mobile);
                if (find==null)
                {
                    string code = GetRandomString(6);
                    _illness.Add(new Illness()
                    {
                        Image = Image,
                        Name = Name,
                        Family = "",
                        Active = true,
                        Age = 0,
                        InsuranceFinishDate = "",
                        Userid = UserId,
                        Sugar = 0,
                        Weight = 0,
                        InsuranceId = insuranceid,
                        InsuranceSerial = "",
                        PressureBlood = 0,
                        CityId = CityId,
                        Mobile = Mobile,
                        CodeActiveUse = code,
                        Is_Use_CodeValue = false,
                        Password = password
                    });
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
            else
            {
                return false;
            }
            return false;
        }

        public async Task<Boolean> Changepassword(string mobile, string pass, string newpassword)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == pass);
            if (find != null)
            {
                find.Password = newpassword;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> CheckLogin(string mobile, string password)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Illness> CheckLoginwithmobile(string mobile, string password)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return find;
            }
            return null;
        }

        public async Task<Illness> GetIllnessWithMobile(string mobile)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return find;
            }
            return null;
        }

        public async Task<List<NotificationUser>> GetIllnessNotifi()
        {
            var find = from db in _illness
                       select new NotificationUser { Id = db.Id, Name = db.Name, Userid = db.Userid };
            
            return find.ToList();
        }

        public async Task<IllnessWebService> GetIllnessWithMobileWebService(string mobile)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                IllnessWebService newillness = new IllnessWebService()
                {
                    Age=find.Age,
                    Id=find.Id,
                    Image=find.Image,
                    InsuranceFinishDate=find.InsuranceFinishDate,
                    InsuranceId=find.InsuranceId,
                    InsuranceSerial=find.InsuranceSerial,
                    Name=find.Name,
                    PressureBlood=find.PressureBlood,
                    Sugar=find.Sugar,
                    Weight=find.Weight
                };
                return newillness;
            }
            return null;
        }


        public async Task<bool> Deleteillness(int id)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _illness.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Illness>> GetAllillness()
        {
            return await _illness.OrderByDescending(a => a.Id).ToListAsync();
        }

        public int GetAllillnessCount()
        {
            return _illness.OrderByDescending(a => a.Id).Count();
        }

        public async Task<Illness> Getillness(string id)
        {
            return await _illness.Where(a=>a.Userid==id).FirstOrDefaultAsync();
        }

        public async Task<Illness> GetillnessClient(int id)
        {
            return await _illness.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Illness>> Searchillness(string text)
        {
            return await _illness.Where(a => a.Name.Contains(text)).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<bool> Updateillness(int id, string Name, int CityId, string Image, int age, int weight, int suger, int pressure, string serialbime, int bimeid)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                if (Name!="")
                find.Name = Name;
                if (CityId != 0)
                find.CityId = CityId;
                if (age != 0)
                find.Age = age;
                if (bimeid != 0)
                find.InsuranceId = bimeid;
                if (serialbime != "")
                find.InsuranceSerial = serialbime;
                if (pressure != 0)
                find.PressureBlood = pressure;
                if (suger != 0)
                find.Sugar = suger;
                if (weight != 0)
                find.Weight = weight;
                if (Image != "" && Image != null)
                {
                    find.Image = Image;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateillnessWithDate(int id, string Name, int CityId, string Image,string imagebimefirstpage, int age, int weight, int suger, int pressure, string serialbime, int bimeid,string date)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                if (Name != "")
                    find.Name = Name;
                if (CityId != 0)
                    find.CityId = CityId;
                if (age != 0)
                    find.Age = age;
                if (bimeid != 0)
                    find.InsuranceId = bimeid;
                if (serialbime != "")
                    find.InsuranceSerial = serialbime;
                if (pressure != 0)
                    find.PressureBlood = pressure;
                if (suger != 0)
                    find.Sugar = suger;
                if (weight != 0)
                    find.Weight = weight;
                if (Image != "" && Image != null)
                {
                    find.Image = Image;
                }
                if (imagebimefirstpage != "" && imagebimefirstpage != null)
                {
                    find.ImageBimeFirstPage = imagebimefirstpage;
                }
                find.InsuranceFinishDate = date;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Boolean> Checksmscode(string code,string userid)
        {
            var finduser = await _illness.FirstOrDefaultAsync(a => a.CodeActiveUse == code && a.Userid == userid);
            if (finduser!=null)
            {
                finduser.Is_Use_CodeValue = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<string> GetSmsCode(string userid)
        {
            var finddoc = await _illness.FirstOrDefaultAsync(a => a.Userid == userid);
            if (finddoc != null)
            {
                if (finddoc.Is_Use_CodeValue == true)
                {
                    finddoc.CodeActiveUse = GetRandomString(4);
                    finddoc.Is_Use_CodeValue = false;
                    await _unitOfWork.SaveChangesAsync();
                    return finddoc.CodeActiveUse;
                }
                else
                {
                    return finddoc.CodeActiveUse;
                }
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

        public async Task<Boolean> UpdateActiveIllnessuser(string mobile)
        {
            var find = await _illness.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.Is_Use_CodeValue = true;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;

        }
    }
}
