using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.Massage;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.ServiceLayer.Contract.JudgeInterface;
using UrumiumMVC.ViewModel.EntityViewModel.NotificationViewModel;
using UrumiumMVC.ViewModel.EntityViewModel.WebServiceClasses;

namespace UrumiumMVC.ServiceLayer.EFServices.JudgeService
{
    public class JudgeService:IJudgeService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<judge> _judge;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public JudgeService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _judge = _unitOfWork.Set<judge>();
        }

        public async Task<bool> Addjudge(string Name,string Family, string Description, int CityId, string Image,string UserId)
        {
            try
            {
                _judge.Add(new judge()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name,
                    Family=Family,
                    Cost=0,
                    Active=false,
                    Userid= UserId,
                    CityId = CityId
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
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return true;
            }
            return false;
        }
        public async Task<judge> CheckLoginwithmobile(string mobile, string password)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == password);
            if (find != null)
            {
                return find;
            }
            return null;
        }

        public async Task<Boolean> Changepassword(string mobile, string pass, string newpassword)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile && a.Password == pass);
            if (find != null)
            {
                find.Password = newpassword;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> GetJudgewithmobile(string mobile)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<NotificationUser>> GetJudgeNotifi()
        {
            var find = from db in _judge
                       select new NotificationUser { Id = db.Id, Name = db.Name, Userid = db.Userid };
            
            return find.ToList();
        }

        public async Task<judge> GetJudgeInfowithmobile(string mobile)
        {
            return await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile);
        }

        public async Task<bool> UpdateJudgeMadarekwithmobile(string mobile,string mellicart,string shenasname,string madrak)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.ScanMelliCode = mellicart;
                find.ScanShenasname = shenasname;
                find.ScanMadrakTahsili = madrak;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Addjudgewithsms(string Name, int CityId, string Image, string UserId,string Mobile,string Password)
        {
            try
            {
                string code = GetRandomString(6);
                _judge.Add(new judge()
                {
                    Description = "",
                    Image = Image,
                    Name = Name,
                    Family = "",
                    Cost = 0,
                    Active = false,
                    Userid = UserId,
                    CityId = CityId,
                    Mobile=Mobile,
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


        public async Task<bool> AddjudgeMadrakWithMobile(string Password,string Name,string Mobile, string Family, string Description, int CityId, string Image, string UserId, string Scanmelli, string Scanshenasname, string Scanmadrak)
        {
            try
            {
                string code = GetRandomString(6);
                _judge.Add(new judge()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name,
                    Family = Family,
                    Cost = 0,
                    Active = false,
                    Userid = UserId,
                    CityId = CityId,
                    ScanMadrakTahsili = Scanmadrak,
                    ScanMelliCode = Scanmelli,
                    ScanShenasname = Scanshenasname,
                    Password=Password,
                    Mobile=Mobile,
                    Is_Use_CodeValue=false,
                    CodeActiveUse=code
            });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> AddjudgeMadrak(string Name, string Family, string Description, int CityId, string Image, string UserId,string Scanmelli,string Scanshenasname,string Scanmadrak)
        {
            try
            {
                _judge.Add(new judge()
                {
                    Description = Description,
                    Image = Image,
                    Name = Name,
                    Family = Family,
                    Cost = 0,
                    Active = false,
                    Userid = UserId,
                    CityId = CityId,
                    ScanMadrakTahsili=Scanmadrak,
                    ScanMelliCode=Scanmelli,
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

        public async Task<bool> Deletejudge(int id)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _judge.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<judge>> GetAlljudge()
        {
            return await _judge.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<judge>> GetAlljudgeActive()
        {
            return await _judge.Where(b=>b.Active==true).OrderByDescending(a => a.Id).ToListAsync();
        }

        public int GetAlljudgeCount()
        {
            return _judge.OrderByDescending(a => a.Id).Count();
        }

        public async Task<judge> Getjudge(string id)
        {
            return await _judge.FirstOrDefaultAsync(a=>a.Userid==id);
        }

        public async Task<judge> GetjudgeClient(int id)
        {
            return await _judge.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<judge>> Searchjudge(string text)
        {
            return await _judge.Where(a => a.Name.Contains(text) || a.Description.Contains(text)).OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<bool> Updatejudge(int id,string accountnumber, string Name, string Description, int CityId, string Image)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                find.Name = Name;
                find.Description = Description;
                find.CityId = CityId;
                if (Image != "" && Image != null)
                {
                    find.Image = Image;
                }
                find.AccountNumber = accountnumber;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> Updatejudgewithmobile(string mobile, string Name,string bankcode, string Description, int CityId, string Image)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile);
            if (find != null)
            {
                find.Name = Name;
                find.Description = Description;
                find.CityId = CityId;
                if (Image != "" && Image != null)
                {
                    find.Image = Image;
                }
                find.AccountNumber = bankcode;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> ChangeActive(int id)
        {
            var find= await _judge.FirstOrDefaultAsync(a => a.Id == id);
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



        //web service list item
        public async Task<List<JudgeWebService>> GetAllJudgeForService()
        {
            List<JudgeWebService> _alljudge = new List<JudgeWebService>();
            var find= await _judge.Where(b => b.Active == true).OrderByDescending(a => a.Id).ToListAsync();
            foreach (var item in find)
            {
                JudgeWebService newjudge = new JudgeWebService();
                newjudge.Id = item.Id;
                if (item.Image == null || item.Image == "")
                {
                    newjudge.Image = ImgSrc.MainUrl + ImgSrc.ImgeDefaultUrl;
                }
                else
                {
                    newjudge.Image = ImgSrc.MainUrl + ImgSrc.JudgeUrl + item.Image;
                }
                newjudge.Description = item.Description;
                newjudge.Name = item.Name;
                _alljudge.Add(newjudge);
            }
            return _alljudge;
        }


        Random rand = new Random();
        public string GetRandomString(int length)
        {
            string s = "";
            for (int i = 0; i < length; i++)
                s += rand.Next(0, 10);
            return s;
        }


        public async Task<Boolean> UpdateActiveJudgeuser(string mobile)
        {
            var find = await _judge.FirstOrDefaultAsync(a => a.Mobile == mobile);
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
