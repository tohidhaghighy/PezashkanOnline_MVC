using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Setting
{
    public class CostsPersend
    {
        public int Id { get; set; }
        public int PersendPerVisit { get; set; }
        public int ZirMajmoeVisitDoctor { get; set; }
        public int CostJudgeVisit { get; set; }
    }
}
