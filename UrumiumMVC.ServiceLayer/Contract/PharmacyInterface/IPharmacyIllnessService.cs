using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;

namespace UrumiumMVC.ServiceLayer.Contract.PharmacyInterface
{
    public interface IPharmacyIllnessService
    {
        Task<Boolean> AddPharmacyIllness(Illness_Pharmacy_Massage item);
        Task<IEnumerable<Illness_Pharmacy_Massage>> GetAllIllness(int illnessid);
        Task<IEnumerable<Illness_Pharmacy_Massage>> GetAll();
        Task<Boolean> AddAnswer(string text,int id);
    }
}
