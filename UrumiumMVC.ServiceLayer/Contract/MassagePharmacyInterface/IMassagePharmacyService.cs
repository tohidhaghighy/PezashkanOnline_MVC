using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.ViewModel.EntityViewModel.PharmacyViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.MassagePharmacyInterface
{
    public interface IMassagePharmacyService
    {
        Task<List<Pharmacy_Massage>> GetPharmacyNoskheMassageToIllness(int illnessid);
        Task<List<Pharmacy_Massage>> GetPharmacyNoskheMassageToPharmacy(int pharmacyid);
        Task<List<PharmacyWebService>> GetPharmacyWebSeriveListVisit(int illnessid);

        // web service   
        Task<Boolean> AddPharmacyMassage(int visitid, int pharmacyid, int doctorid, int illnessid, string massage);
    }
}
