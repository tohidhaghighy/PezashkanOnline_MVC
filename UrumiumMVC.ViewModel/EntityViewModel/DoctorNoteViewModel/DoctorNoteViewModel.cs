using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;

namespace UrumiumMVC.ViewModel.EntityViewModel.DoctorNoteViewModel
{
    public class DoctorNoteViewModel
    {
        public List<DoctorSubsetPassage> DoctorSubsetPassages { get; set; }
        public int Id { get; set; }
    }
}
