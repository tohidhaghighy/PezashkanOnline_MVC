using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;
using UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.CostPersendService
{
    public class CostPersendService:ICostPersendService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<CostsPersend> _CostsPersend;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion
        public CostPersendService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _CostsPersend = _unitOfWork.Set<CostsPersend>();
        }

        public async Task<bool> AddCostPersend(int VisitPesend,int ZirmajmoePersend,int CostJudgeVisit)
        {
            var findfirst = await _CostsPersend.FirstOrDefaultAsync();
            if (findfirst!=null)
            {
                findfirst.PersendPerVisit = VisitPesend;
                findfirst.ZirMajmoeVisitDoctor = ZirmajmoePersend;
                findfirst.CostJudgeVisit = CostJudgeVisit;
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
            {
                _CostsPersend.Add(new CostsPersend()
                {
                    PersendPerVisit = VisitPesend,
                    ZirMajmoeVisitDoctor = ZirmajmoePersend,
                    CostJudgeVisit= CostJudgeVisit
                });
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }

        public async Task<CostsPersend> GetCostPersend()
        {
            return await _CostsPersend.FirstOrDefaultAsync();
        }
    }
}
