using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tittle { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public Boolean IsImportant { get; set; }
        public double Cost { get; set; }
        public int Off { get; set; }
        public DateTime DatetimeNow { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public int ViewerCount { get; set; }
        public int LanguageId { get; set; }
        public string Tags { get; set; }
    }
}
