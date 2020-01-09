using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.judge;

namespace UrumiumMVC.ViewModel.EntityViewModel.JudgeManagmentViewModel
{
    public class JudgeViewModel
    {

        public judge judges { get; set; }
        public List<State> States { get; set; }

    }
}
