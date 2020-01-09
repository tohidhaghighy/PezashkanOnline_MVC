using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.DomainClasses.Entities.Language;
using UrumiumMVC.DomainClasses.Entities.Product;

namespace UrumiumMVC.ViewModel.EntityViewModel.ProductViewModel
{
    public class ProductPageModel
    {
        public List<Product> Products { get; set; }
        public List<Group> Groups { get; set; }
        public List<Language> Languages { get; set; }
    }
}
