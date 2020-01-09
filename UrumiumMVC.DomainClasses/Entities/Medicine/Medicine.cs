using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Medicine
{
    //Group id=1   عمومی
    // Medicine with groupId==1 is Public
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DoctorId { get; set; }
        public string Description { get; set; }
        //public Medicine=true
        public Boolean PublicMedicine { get; set; }
        

    }
}
