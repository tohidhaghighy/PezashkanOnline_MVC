using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Violation
{
    public class Violation
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string UserId { get; set; }
        public string Description { get; set; }

        //if Type==0 General  Type==1  ChatRoom
        public int Type { get; set; }
        public string DoctorId { get; set; }
        public string DesAdmin { get; set; }
        public bool CheckIsOk { get; set; }
    }
}
