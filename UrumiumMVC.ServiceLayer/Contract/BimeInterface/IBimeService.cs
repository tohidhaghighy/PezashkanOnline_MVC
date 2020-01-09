using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Insurance;
using UrumiumMVC.ViewModel.EntityViewModel.InsuranceViewModel;

namespace UrumiumMVC.ServiceLayer.Contract.BimeInterface
{
    public interface IBimeService
    {
        Task<bool> AddInsurance(string Name, string Description, string Image);
        Task<bool> DeleteInsurance(int id);
        Task<List<Insurance>> GetAllInsurance();
        Task<List<Insurance>> SearchInsurance(string text);
        Task<Insurance> GetFirstInsurance();
        Task<bool> UpdateInsurance(int id, string Name, string Description, string Image);


        // web service 

        Task<List<InsuranceWithOutForegnkey>> GetAllInsuranceWebservice();
    }
}
