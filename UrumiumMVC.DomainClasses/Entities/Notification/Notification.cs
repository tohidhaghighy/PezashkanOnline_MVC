using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Notification
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        // Type==0 all ==1 Doctor ==2 judge ==3 illness ==4 pharmacy
        public int Type { get; set; }
    }
}
