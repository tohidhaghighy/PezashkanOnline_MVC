using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.DomainClasses.Entities.Insurance;

namespace UrumiumMVC.ViewModel.EntityViewModel.IllnessViewModel
{
    public class IllnessViewModel
    {
        public Illness Illness { get; set; }
        public List<State> States { get; set; }
        public List<Insurance> Insurances { get; set; }
    }
}
