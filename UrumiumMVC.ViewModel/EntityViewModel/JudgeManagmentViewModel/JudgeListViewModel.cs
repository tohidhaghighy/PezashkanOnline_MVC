using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.DomainClasses.Entities.judge;

namespace UrumiumMVC.ViewModel.EntityViewModel.JudgeManagmentViewModel
{
    public class JudgeListViewModel
    {
        public List<State> States { get; set; }
        public List<judge> judges { get; set; }
    }
}
