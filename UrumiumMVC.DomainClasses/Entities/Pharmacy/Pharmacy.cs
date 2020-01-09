using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;

namespace UrumiumMVC.DomainClasses.Entities.Pharmacy
{
    public class Pharmacy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
        public string Userid { get; set; }
        public string Address { get; set; }
        public Boolean Active { get; set; }
        public string ScanMelliCode { get; set; }
        public string ScanNezamPezeshki { get; set; }
        public string ScanShenasname { get; set; }
        public string ScanParvane { get; set; }
        public string Mobile { get; set; }
        public string CodeActiveUse { get; set; }
        public Boolean Is_Use_CodeValue { get; set; }
        public string Password { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City Cities { get; set; }

        public virtual ICollection<Pharmacy_Massage> Pharmacy_Massage { get; set; }
    }
}
