using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Language
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Icon { get; set; }
    }
}
