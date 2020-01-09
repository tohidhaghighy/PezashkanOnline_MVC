using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Doctor;

namespace UrumiumMVC.ServiceLayer.Contract.DoctorInterface
{
    public interface IDoctorNoteService
    {
        Task<bool> AddDoctorSubsetPassage(string text, int doctorid);
        Task<bool> DeleteDoctorSubsetPassage(int id);
        Task<List<DoctorSubsetPassage>> GetAllDoctorSubsetPassage(int doctorid);
    }
}
