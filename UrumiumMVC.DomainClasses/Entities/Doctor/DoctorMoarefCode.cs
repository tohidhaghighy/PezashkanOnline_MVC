using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Doctor
{
    public class DoctorMoarefCode
    {
        public int Id { get; set; }
        public int Id_Doctor_Main { get; set; }
        public int Id_Doctor_Zir { get; set; }
        public Nullable<int> type { get; set; }
    }
}
