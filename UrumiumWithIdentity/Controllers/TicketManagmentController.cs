using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.TicketInterface;

namespace UrumiumWithIdentity.Controllers
{
    public partial class TicketManagmentController : Controller
    {
        ITicketService _ticketservices;
        readonly IUnitOfWork _uow;

        public TicketManagmentController(ITicketService newticketservice, ITicketService newticketservice1,
            IUnitOfWork uow)
        {
            _ticketservices = newticketservice;
            _uow = uow;
        }
        // GET: Ticket
        public async virtual Task<ActionResult> Index()
        {
            return View(await _ticketservices.GetAllTicket());
        }

        public async virtual Task<ActionResult> Answer(string Text, string id)
        {
            return View(await _ticketservices.GetAllTicket());
        }


        public async virtual Task<ActionResult> TicketChatroom(int ticketid)
        {
            return View(await _ticketservices.GetTicketItems(ticketid));
        }

        [HttpPost]
        public async Task<Boolean> DeleteTicket(int id)
        {
            return await _ticketservices.DeleteTicket(id);
        }


        [HttpPost]
        public async Task<Boolean> SendTicket(int ticketid, string text, string userid, string username)
        {
            return await _ticketservices.AddTicket(ticketid, userid, username, "", text, "admin", "");
        }

    }
}