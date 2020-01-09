using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.judge
{
    public class judge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public Boolean Active { get; set; }
        public int CityId { get; set; }
        public int Cost { get; set; }
        public string Userid { get; set; }
        public string ScanMelliCode { get; set; }
        public string ScanMadrakTahsili { get; set; }
        public string ScanShenasname { get; set; }
        public string Mobile { get; set; }
        public string CodeActiveUse { get; set; }
        public Boolean Is_Use_CodeValue { get; set; }
        public string Password { get; set; }
        public string AccountNumber { get; set; }
    }
}
