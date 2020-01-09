using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Nurse
{
    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Userid { get; set; }
        public Boolean Active { get; set; }
        public int CityId { get; set; }
        public string Mobile { get; set; }
        public string CodeActiveUse { get; set; }
        public Boolean Is_Use_CodeValue { get; set; }
        public string Password { get; set; }
    }
}
