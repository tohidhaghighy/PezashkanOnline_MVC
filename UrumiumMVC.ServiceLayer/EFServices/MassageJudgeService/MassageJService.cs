using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.MassageJudgeService
{
    public class MassageJService: IMassageJService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<JudgeIllness> _JudgeIllness;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public MassageJService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _JudgeIllness = _unitOfWork.Set<JudgeIllness>();
        }

        public async Task<bool> AddJudgeIllness(int visitid, string userid, string text, bool is_user, string onlytext,int typemassage)
        {
            try
            {
                _JudgeIllness.Add(new JudgeIllness()
                {
                    AnswerDatetime=DateTime.Now,
                    AnswerUserId=userid,
                    JudgeIllnessPaymentId=visitid,
                    Text=text,
                    UserJudge=is_user,
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

        public async Task<List<JudgeIllness>> GetAllJudgeIllness(int visitid)
        {
            return await _JudgeIllness.Where(b => b.JudgeIllnessPaymentId == visitid).OrderByDescending(a => a.Id).ToListAsync();
        }
    }
}
