using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Gallery
{
    public class ProductGallery
    {
        public int Id { get; set; }
        public string Src { get; set; }
        public int ProductId { get; set; }
        public Boolean IsMain { get; set; }
    }
}
