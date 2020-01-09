using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.DomainClasses.Entities.Medicine;

namespace UrumiumMVC.ViewModel.EntityViewModel.MedicineViewModel
{
    public class MedicineVM
    {
        public List<Medicine> medicines { get; set; }
        public List<Group> groups { get; set; }
        public int Doctorid { get; set; }
    }
}
