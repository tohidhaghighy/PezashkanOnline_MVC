using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Noskhe;
using UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.NoskheInterface
{
    public interface INoskheService
    {
        Task<bool> AddNoskhe(int visitid, int doctorid, int illnessid, string text, int count);
        Task<bool> DeleteNoskhe(int id);
        Task<List<Noskhe>> GetDoctorNoskhe(int doctorid);
        Task<List<Noskhe>> GetIllnessNoskhe(int illnessid);
        Task<List<Noskhe>> GetVisitNoskhe(int visitid);
        Task<List<Noskhe>> GetINoskheMedicins(int visitid);
        Task<List<Noskhe>> GetINoskheMedicinsFinaly(int visitid);
        Task<Boolean> FinalINoskheMedicins(int visitid);

        Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebServiceFinally(int visitid);
        Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebService(int visitid);
        Task<Boolean> ChangeFinallyMedicinWebService(int visitid);
        Task<Boolean> AdMedicineToNoskheWebService(int visitid, string text, int count);

        Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebServiceNotFinally(int visitid);
        Task<Boolean> CheckFinallyMedicinWebService(int visitid);
    }
}
