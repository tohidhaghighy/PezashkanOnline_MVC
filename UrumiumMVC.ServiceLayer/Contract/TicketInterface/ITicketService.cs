using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Ticket;

namespace UrumiumMVC.ServiceLayer.Contract.TicketInterface
{
    public interface ITicketService
    {
        Task<bool> AddTicket(int ticketid, string userid, string name, string email, string text, string userroll, string file);
        Task<bool> DeleteTicket(int ticketid);
        Task<List<Ticket>> GetAllTicket();
        Task<List<Ticket>> GetTicketItems(int ticketid);
        Task<List<Ticket>> GetOwnTicket(string userid);
        Task<Boolean> SeenAllTicket(List<Ticket> tickets);
    }
}
