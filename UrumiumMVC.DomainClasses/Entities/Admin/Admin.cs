using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Admin
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean DoctorManagment { get; set; }
        public Boolean IllnessManagment { get; set; }
        public Boolean JudgeManagment { get; set; }
        public Boolean AdminManagment { get; set; }
        public Boolean PharmacyManagment { get; set; }
        //City State Group
        public Boolean CommonManagment { get; set; }
        //user rolluser
        public Boolean UserManagment { get; set; }
        public Boolean MedicineManagment { get; set; }
        public Boolean AccountManagment { get; set; }
        public string UserId { get; set; }
    }
}
