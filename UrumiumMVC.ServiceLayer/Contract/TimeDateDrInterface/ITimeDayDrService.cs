using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;

namespace UrumiumMVC.ServiceLayer.Contract.TimeDateDrInterface
{
    public interface ITimeDayDrService
    {
        Task<bool> AddDoctorDays(int doctorid, int dayid, string description, int countvisit);
        Task<bool> DeleteDoctorDays(int id);
        Task<List<DoctorDays>> GetAllDoctorDays();
        Task<List<DoctorDays>> GetAllDoctorSelectDays(int doctorid);
    }
}
