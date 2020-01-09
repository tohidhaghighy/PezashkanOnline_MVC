using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Medicine;

namespace UrumiumMVC.ServiceLayer.Contract.MedicineInterface
{
    public interface IMedicineService
    {
        Task<bool> AddMedicine(int id, string Name, string Description);
        Task<bool> DeleteMedicine(int id);
        Task<List<Medicine>> GetAllMedicine(int doctorid);
        Task<bool> UpdateMedicine(int MedicineId, string Name, string Description, Boolean PublicMedicine);
        Task<List<Medicine>> SearchMedicine(int id,string text);


        Task<List<Medicine>> SearchMedicineWebService(string text, int doctorid);
    }
}
