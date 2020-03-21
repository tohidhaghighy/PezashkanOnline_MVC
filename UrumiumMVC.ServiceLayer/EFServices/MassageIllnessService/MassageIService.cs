using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.Common.TimeConverter;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.MassageIllnessService
{
    public class MassageIService:IMassageIService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<IllnessMassage> _IllnessMassage;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public MassageIService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _IllnessMassage = _unitOfWork.Set<IllnessMassage>();
        }

        public async Task<bool> AddIllnessMassage(int visitid,string userid, string text,bool is_user,string onlytext,int typemassage)
        {
            try
            {
                _IllnessMassage.Add(new IllnessMassage()
                {
                    Date=DateTime.Now,
                    Text=text,
                    UserId=userid,
                    VisitId=visitid,
                    UserDoctor=is_user,
                    OnlyUrlText=onlytext,
                    TypeMassage=typemassage
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<IllnessMassage>> GetAllIllnessMassage(int visitid)
        {
            Converter convert = new Converter();
            var findallmassage = from db in _IllnessMassage
                                 where db.VisitId == visitid
                                 select db;

            return await findallmassage.OrderByDescending(a => a.Id).ToListAsync();
        }
    }
}
