using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.ViewModel.EntityViewModel.DoctorViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.DayTimeDoctorInterface
{
    public interface IDayDoctorService
    {
        Task<bool> AddDayDoctor(int doctorid = 0, string date = "", string timevisit = "", int countuser = 0);
        Task<bool> DeleteDoctorDays(int id);
        Task<List<DoctorDays>> GetAllDoctorDays(int doctorid);
        Task<List<DoctorDays>> GetAllDoctorDaysFromToday(int doctorid);
        Task<List<TimeVisitDoctorWebService>> GetAllTimeForWebService(int doctorid);


        //we b service

        Task<bool> AddDayDoctorWebService(int doctorid = 0, string date = "", string timevisit = "", int countuser = 0);
    }
}
