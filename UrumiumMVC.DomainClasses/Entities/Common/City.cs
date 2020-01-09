using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Common
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }

        [ForeignKey(nameof(StateId))]
        public virtual State States { get; set; }

        public virtual ICollection<Pharmacy.Pharmacy> Pharmacies { get; set; }
        public virtual ICollection<Doctor.Doctor> Doctors { get; set; }
        public virtual ICollection<Illness.Illness> Illnesses { get; set; }
    }
}
