using AutoMapper;
using DataLayer.Context;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.Cryptography;
using UrumiumMVC.Common.Massage;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.ServiceLayer.Contract.PharmacyInterface;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.EFServices.PharmacyService
{
    public class PharmacyService:IPharmacyService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Pharmacy> _Pharmacy;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        private InCrypt _md5 = new InCrypt();

        #endregion
        public PharmacyService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Pharmacy = _unitOfWork.Set<Pharmacy>();
        }

        public async Task<bool> AddPharmacy(string Name, string Description, int CityId, string Image,string UserId,string address)
        {
            try
            {
                _Pharmacy.Add(new Pharmacy()
                {
                    Description = Description,
                    Image=Image,
                    Name = Name,
                    CityId = CityId,
                    Userid=UserId,
                    Active=true,
                    Address=address
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> AddPharmacywithsms(string Name, int CityId, string Image, string UserId, string Mobile,string Password)
        {
            try
            {
                string code = GetRandomString(6);
                _Pharmacy.Add(new Pharmacy()
                {
                    Description = "",
                    Image = Image,
                    Name = Name,
                    CityId = CityId,
                    Userid = UserId,
                    Active = false,
                    Address = "",
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

        public async Task<bool> AddPharmacyMadrakwithmobile(string Password,string Name,string Mobile, string Description, int CityId, string Image, string UserId, string address, string Scanmelli, string Scanshenasname, string Scanparvane, string Scannezam)
        {
            try
            {
                string code = GetRandomString(6);
                _Pharmacy.Add(new Pharmacy()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name,
                    CityId = CityId,
                    Userid = UserId,
                    Active = false,
                    Address = address,
                    Mobile=Mobile,
                    Is_Use_CodeValue=false,
                    CodeActiveUse=code,
                    ScanMelliCode = Scanmelli,
                    ScanNezamPezeshki = Scannezam,
                    ScanParvane = Scanparvane,
                    ScanShenasname = Scanshenasname,
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

        public async Task<bool> AddPharmacyMadrak(string Name, string Description, int CityId, string Image, string UserId, string address,string Scanmelli,string Scanshenasname,string Scanparvane,string Scannezam)
        {
            try
            {
                _Pharmacy.Add(new Pharmacy()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name,
                    CityId = CityId,
                    Userid = UserId,
                    Active = false,
                    Address = address,
                    ScanMelliCode=Scanmelli,
                    ScanNezamPezeshki=Scannezam,
                    ScanParvane=Scanparvane,
                    ScanShenasname=Scanshenasname
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CheckLogin(string mobile, string password)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<Pharmacy> CheckLoginwithmobile(string mobile, string password)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return find;
            }
            return null;
        }

        public async Task<Boolean> Changepassword(string mobile, string pass, string newpassword)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == pass);
            if (find != null)
            {
                find.Password = newpassword;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> GetPharmacyWithMobile(string mobile)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePharmacyMadrakWithMobile(string mobile,string mellicart,string shenasname,string parvane,string nezampezeshki)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.ScanMelliCode = mellicart;
                find.ScanShenasname = shenasname;
                find.ScanParvane = parvane;
                find.ScanNezamPezeshki = nezampezeshki;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeletePharmacy(int id)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _Pharmacy.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Pharmacy>> GetAllPharmacy()
        {
            return await _Pharmacy.OrderByDescending(a=>a.Id).ToListAsync();
        }

        public async Task<List<Pharmacy>> GetAllPharmacyActive()
        {
            return await _Pharmacy.Where(b=>b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
        }

        public int GetAllPharmacyCount()
        {
            return _Pharmacy.OrderByDescending(a => a.Id).Count();
        }

        public async Task<Pharmacy> GetPharmacy(string id)
        {
            return await _Pharmacy.FirstOrDefaultAsync(a=>a.Userid==id);
        }

        public async Task<Pharmacy> GetPharmacyClient(int id)
        {
            return await _Pharmacy.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Pharmacy>> SearchPharmacy(string text)
        {
            return await _Pharmacy.Where(a=>a.Name.Contains(text) || a.Description.Contains(text)).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<bool> UpdatePharmacy(int id, string Name, string Description, int CityId, string Image,string address)
        {
            var findpharmacy = await _Pharmacy.FirstOrDefaultAsync(a => a.Id == id);
            if (findpharmacy!=null)
            {
                
                findpharmacy.Name = Name;
                findpharmacy.Description = Description;
                findpharmacy.CityId = CityId;
                findpharmacy.Address = address;
                if (Image != "" && Image != null)
                {
                    findpharmacy.Image = Image;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdatePharmacyInfoWithMobile(string mobile, string Name, string Description, int CityId, string Image, string address)
        {
            var findpharmacy = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (findpharmacy != null)
            {
                findpharmacy.Name = Name;
                findpharmacy.Description = Description;
                findpharmacy.CityId = CityId;
                findpharmacy.Address = address;
                if (Image != "" && Image != null)
                {
                    findpharmacy.Image = Image;
                }
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeActive(int id)
        {
            var find= await _Pharmacy.FirstOrDefaultAsync(a => a.Id == id);
            if (find!=null)
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



        //web service for android
        public async Task<List<PharmacyWebService>> GetAllPharmacyForService()
        {
            List<PharmacyWebService> _pharmacyservice = new List<PharmacyWebService>();
            var find= await _Pharmacy.Where(b => b.Active == true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                PharmacyWebService _pharmacyitem = new PharmacyWebService();
                _pharmacyitem.Id = item.Id;
                _pharmacyitem.Name = item.Name;
                _pharmacyitem.Address = item.Address;
                _pharmacyitem.City = item.Cities.Name;
                if (item.Image == null || item.Image == "")
                {
                    _pharmacyitem.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    _pharmacyitem.Image = ImgSrc.MainUrl + ImgSrc.PharmacyUrl + item.Image;
                }
                _pharmacyservice.Add(_pharmacyitem);
            }
            return _pharmacyservice;
        }

        Random rand = new Random();
        public string GetRandomString(int length)
        {
            string s = "";
            for (int i = 0; i < length; i++)
                s += rand.Next(0, 10);
            return s;
        }

         public async Task<PharmacyWebService> GetPharmacyInfoWithMobile(string mobile)
        {
            PharmacyWebService newpharm = new PharmacyWebService();
            var find= await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find!=null)
            {
                newpharm.Id = find.Id;
                newpharm.Name = find.Name;
                newpharm.Description = find.Description;
                newpharm.Address = find.Address;
                newpharm.CityId = find.CityId;
                newpharm.ActiveCode = find.CodeActiveUse;
            }
            return newpharm;

        }


        public async Task<Boolean> UpdateActivePharmacyuser(string mobile)
        {
            var find = await _Pharmacy.FirstOrDefaultAsync(a => a.Mobile == mobile);
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
