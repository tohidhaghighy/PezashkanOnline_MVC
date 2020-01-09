using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;

namespace UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel
{
    public class ChatJudgeUser
    {
        public int Id { get; set; }
        public string Groupname { get; set; }
        public string Sendername { get; set; }
        public int illnessid { get; set; }
        public string Illnessname { get; set; }
        public int doctorid { get; set; }
        public int Type { get; set; }
        public string UserId { get; set; }
        public List<JudgeIllness> Allmassages { get; set; }
    }
}
