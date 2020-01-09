using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Ticket;
using UrumiumMVC.ServiceLayer.Contract.TicketInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.TicketService
{
    public class TicketService:ITicketService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Ticket> _Ticket;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public TicketService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Ticket = _unitOfWork.Set<Ticket>();
        }


        public async Task<bool> AddTicket(int ticketid,string userid, string name,string email,string text,string userroll,string file)
        {
            try
            {
                _Ticket.Add(new Ticket()
                {
                    Name = name,
                    Datetime=DateTime.Now,
                    Email=email,
                    File=file,
                    Text=text,
                    UserId=userid,
                    TicketId=ticketid,
                    UserRoll=userroll,
                    Seen=true,
                    FinishChat=false
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteTicket(int ticketid)
        {
            var find = await _Ticket.Where(a => a.Id == ticketid || a.TicketId==ticketid).ToListAsync();
            if (find != null)
            {
                foreach (var item in find)
                {
                    _Ticket.Remove(item);
                }
               
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //کل تیکت هایی که کاربران برای اولین بار فرستاده اند
        public async Task<List<Ticket>> GetAllTicket()
        {
            return await _Ticket.Where(a=>a.TicketId==0).OrderByDescending(a=>a.Id).ToListAsync();
        }

        //کل چت های مورد نظر کاربران و پاسخ ها که کاربران برای اولین بار فرستاده اند
        public async Task<List<Ticket>> GetTicketItems(int ticketid)
        {
            var findall= await _Ticket.Where(a => a.TicketId == ticketid || a.Id == ticketid).OrderByDescending(a => a.Id).ToListAsync();
            await SeenAllTicket(findall);
            return findall;
        }

        public async Task<List<Ticket>> GetOwnTicket(string userid)
        {
            return await _Ticket.Where(a=>a.UserId==userid).ToListAsync();
        }

        public async Task<Boolean> SeenAllTicket(List<Ticket> tickets)
        {
            foreach (var item in tickets)
            {
                item.Seen = true;

            }
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

    }
}
