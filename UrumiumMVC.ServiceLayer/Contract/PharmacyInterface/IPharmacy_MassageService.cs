using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;

namespace UrumiumMVC.ServiceLayer.Contract.PharmacyInterface
{
    public interface IPharmacy_MassageService
    {
        Task<bool> AddPharmacy(string description, int illnessid, int doctorid, int pharmacyid, int visitid);
        Task<List<Pharmacy_Massage>> GetIllnessPharmacyMassage(int Illnessid);
        Task<List<Pharmacy_Massage>> GetVisitPharmacyMassage(int visitid);
    }
}
