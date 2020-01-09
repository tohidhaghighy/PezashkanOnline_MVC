using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Doctor
{
    public class DoctorSubsetPassage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int DoctorId { get; set; }
    }
}
