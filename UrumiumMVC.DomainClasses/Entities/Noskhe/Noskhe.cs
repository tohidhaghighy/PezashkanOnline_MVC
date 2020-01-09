using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Noskhe
{
    public class Noskhe
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int IllnessId { get; set; }
        public int VisitId { get; set; }
        public string MedicineName { get; set; }
        public int MedicineCount { get; set; }
        public DateTime NoskheTime { get; set; }
        public Boolean Is_Finaly { get; set; }

        

    }
}
