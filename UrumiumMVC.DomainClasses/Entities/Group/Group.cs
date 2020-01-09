using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Group
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        //if groupid = 0 this is parent
        public int GroupId { get; set; }
        
        public virtual ICollection<Doctor.Doctor> Doctors { get; set; }
    }
}
