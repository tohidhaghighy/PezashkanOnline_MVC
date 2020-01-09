using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Illness
{
    public class IllnessMassage
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string OnlyUrlText { get; set; }
        //User=true  Doctor=false
        public Boolean UserDoctor { get; set; }
        public DateTime Date { get; set; }
        public int VisitId { get; set; }
        public string UserId { get; set; }
        public int TypeMassage { get; set; }
    }
}
