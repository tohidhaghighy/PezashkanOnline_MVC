using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.QuestionViewModel
{
    public class QuestionListInfoViewModel
    {
        public int Id { get; set; }
        public int IllnessId { get; set; }
        public int DoctorId { get; set; }
        public int VisitId { get; set; }
        public List<QuestionViewModel> QuestionViewModelList { get; set; }
    }
}
