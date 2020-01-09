using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Insurance
{
    public class Insurance
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public virtual ICollection<InsuranceDoctor> InsuranceDoctors { get; set; }
        public virtual ICollection<Illness.Illness> Illnesses { get; set; }
    }
}
