using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Product
{
    public class Detail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DetailId { get; set; }
        public int ProductId { get; set; }
        public int Order { get; set; }
    }
}
