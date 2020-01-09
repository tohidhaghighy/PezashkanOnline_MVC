using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public Boolean Have_Answer { get; set; }
        public string Text { get; set; }
        public string Answer { get; set; }
        public int AnswerId { get; set; }
    }
}
