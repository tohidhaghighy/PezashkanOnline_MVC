using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel
{
    public class IllnessMassageViewModel
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
        public string Time { get; set; }
    }
}
