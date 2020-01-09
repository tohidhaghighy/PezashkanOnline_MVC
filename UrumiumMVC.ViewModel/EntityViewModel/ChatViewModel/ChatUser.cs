using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Illness;

namespace UrumiumMVC.ViewModel.EntityViewModel.ChatViewModel
{
    public class ChatUser
    {
        public int Id { get; set; }
        public string Groupname { get; set; }
        public string Sendername { get; set; }
        public int illnessid { get; set; }
        public string illnessname { get; set; }
        public int doctorid { get; set; }
        public string doctorname { get; set; }
        public int Type { get; set; }
        public string UserId { get; set; }
        public List<IllnessMassage> Allmassages { get; set; }
    }
}
