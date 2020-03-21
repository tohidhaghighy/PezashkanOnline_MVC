using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Notification;
using UrumiumMVC.ServiceLayer.Contract;
using UrumiumMVC.ServiceLayer.Contract.NotificationInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.NotificationService
{
    public class NotificationService:INotificationService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Notification> _NotificationItems;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion


        public NotificationService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _NotificationItems = _unitOfWork.Set<Notification>();
        }

        public async Task<bool> AddNotification(Notification notificationItem)
        {
            try
            {
                _NotificationItems.Add(notificationItem);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteNotification(int id)
        {
            var find = await _NotificationItems.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                _NotificationItems.Remove(find);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Notification>> GetNotification()
        {
            return await _NotificationItems.OrderByDescending(a => a.Id).ToListAsync();
        }

        public async Task<List<Notification>> GetNotification(string userid,int type)
        {
            return await _NotificationItems.Where(a=> a.Type == 0 || (a.Type==type && a.UserId=="") || a.UserId.Contains(userid)).OrderByDescending(a=>a.Id).ToListAsync();
        }

        //type==0 all -type==1 doctor - type==2 judge - type==3 illness - type==4  pharmacy
        public async Task<int> GetNotificationCount(int type)
        {
            return await _NotificationItems.Where(a=>a.Type==type).CountAsync();
        }

        //type==0 all -type==1 doctor - type==2 judge - type==3 illness - type==4  pharmacy
        public async Task<IEnumerable<Notification>> GetNotificationList(int type)
        {
            return await _NotificationItems.Where(a => a.Type == type).OrderByDescending(a=>a.Id).ToListAsync();
        }

       

    }
}
