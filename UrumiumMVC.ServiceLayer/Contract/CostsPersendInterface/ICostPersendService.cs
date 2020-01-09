using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Setting;

namespace UrumiumMVC.ServiceLayer.Contract.CostsPersendInterface
{
    public interface ICostPersendService
    {
        Task<bool> AddCostPersend(int VisitPesend, int ZirmajmoePersend,int CostJudgeVisit);
        Task<CostsPersend> GetCostPersend();
    }
}
