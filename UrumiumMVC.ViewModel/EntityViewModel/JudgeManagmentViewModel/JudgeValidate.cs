using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.ViewModel.EntityViewModel.JudgeManagmentViewModel
{
    public class JudgeValidate
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public int cityid { get; set; }

        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
