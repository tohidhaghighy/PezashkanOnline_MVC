using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.DomainClasses.Entities.Ticket
{
    public class Ticket
    {
        public int Id { get; set; }
        [DisplayName("نام کاربری")]
        public string Name { get; set; }
        public string UserId { get; set; }
        [DisplayName("ایمیل")]
        public string Email { get; set; }
        public string Text { get; set; }
        public Boolean Seen { get; set; }
        public int TicketId { get; set; }
        public string File { get; set; }
        public string UserRoll { get; set; }
        public DateTime Datetime { get; set; }
        public Boolean FinishChat { get; set; }

    }
}
