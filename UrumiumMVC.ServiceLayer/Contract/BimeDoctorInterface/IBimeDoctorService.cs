using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Insurance;

namespace UrumiumMVC.ServiceLayer.Contract.BimeDoctorInterface
{
    public interface IBimeDoctorService
    {
        Task<bool> AddInsuranceDoctor(int doctorid, int bimeid);
        Task<bool> DeleteInsuranceDoctor(int id);
        Task<List<InsuranceDoctor>> GetAllInsuranceDoctor(int doctorid);
    }
}
