using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;

namespace UrumiumMVC.ViewModel.EntityViewModel.JudgeViewModel
{
    public class CostJudgeList
    {
        public int CostJudge { get; set; }
        public List<judge> Judges { get; set; }
    }
}
