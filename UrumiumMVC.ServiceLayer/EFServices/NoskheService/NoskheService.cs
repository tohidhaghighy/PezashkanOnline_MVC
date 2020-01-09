using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Noskhe;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.ServiceLayer.Contract.NoskheInterface;
using UrumiumMVC.ViewModel.EntityViewModel.VisitViewModel;

namespace UrumiumMVC.ServiceLayer.EFServices.NoskheService
{
    public class NoskheService:INoskheService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Noskhe> _Noskhe;
        private readonly IDbSet<VisitTime> _VisitTime;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion
        public NoskheService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Noskhe = _unitOfWork.Set<Noskhe>();
            _VisitTime = _unitOfWork.Set<VisitTime>();
        }

        public async Task<bool> AddNoskhe(int visitid,int doctorid,int illnessid,string text,int count)
        {
            try
            {

                _Noskhe.Add(new Noskhe()
                {
                    DoctorId=doctorid,
                    IllnessId=illnessid,
                    VisitId=visitid,
                    MedicineCount=count,
                    MedicineName=text,
                    NoskheTime=DateTime.Now
                });
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteNoskhe(int id)
        {
            var find = await _Noskhe.FirstOrDefaultAsync(a => a.Id == id);
            if (find != null)
            {
                if (find.Is_Finaly!=true)
                {
                    _Noskhe.Remove(find);
                    await _unitOfWork.SaveChangesAsync();
                    return true;
                }
                
            }
            return false;
        }

        public async Task<List<Noskhe>> GetDoctorNoskhe(int doctorid)
        {
            return await _Noskhe.Where(a => a.DoctorId == doctorid).ToListAsync();
        }

        public async Task<List<Noskhe>> GetIllnessNoskhe(int illnessid)
        {
            return await _Noskhe.Where(a => a.IllnessId == illnessid).ToListAsync();
        }

        public async Task<List<Noskhe>> GetINoskheMedicins(int visitid)
        {
            return await _Noskhe.Where(a => a.VisitId==visitid).ToListAsync();
        }

        public async Task<List<Noskhe>> GetINoskheMedicinsFinaly(int visitid)
        {
            return await _Noskhe.Where(a => a.VisitId == visitid && a.Is_Finaly==true).ToListAsync();
        }

        public async Task<Boolean> FinalINoskheMedicins(int visitid)
        {
            var listnoskhe= await _Noskhe.OrderByDescending(a => a.VisitId == visitid).ToListAsync();
            foreach (var item in listnoskhe)
            {
                item.Is_Finaly = true;
            }
            await _unitOfWork.SaveAllChangesAsync();
            return true;
        }

        public async Task<List<Noskhe>> GetVisitNoskhe(int visitid)
        {
            return await _Noskhe.Where(a => a.VisitId == visitid).ToListAsync();
        }

        public async Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebServiceFinally(int visitid)
        {
            List<NoskheMedicineWebService> noskhemed = new List<NoskheMedicineWebService>();
            var find= await _Noskhe.Where(a => a.VisitId == visitid && a.Is_Finaly==true).ToListAsync();
            foreach (var item in find)
            {
                NoskheMedicineWebService newnoskhe = new NoskheMedicineWebService();
                newnoskhe.Id = item.Id;
                newnoskhe.Name = item.MedicineName;
                newnoskhe.Count = item.MedicineCount;
                noskhemed.Add(newnoskhe);
            }
            return noskhemed;
        }

        public async Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebServiceNotFinally(int visitid)
        {
            List<NoskheMedicineWebService> noskhemed = new List<NoskheMedicineWebService>();
            var find = await _Noskhe.Where(a => a.VisitId == visitid && a.Is_Finaly ==false).ToListAsync();
            foreach (var item in find)
            {
                NoskheMedicineWebService newnoskhe = new NoskheMedicineWebService();
                newnoskhe.Id = item.Id;
                newnoskhe.Name = item.MedicineName;
                newnoskhe.Count = item.MedicineCount;
                noskhemed.Add(newnoskhe);
            }
            return noskhemed;
        }

        public async Task<List<NoskheMedicineWebService>> GetNoskheMedicinWebService(int visitid)
        {
            List<NoskheMedicineWebService> noskhemed = new List<NoskheMedicineWebService>();
            var find = await _Noskhe.Where(a => a.VisitId == visitid).ToListAsync();
            foreach (var item in find)
            {
                NoskheMedicineWebService newnoskhe = new NoskheMedicineWebService();
                newnoskhe.Id = item.Id;
                newnoskhe.Name = item.MedicineName;
                newnoskhe.Count = item.MedicineCount;
                noskhemed.Add(newnoskhe);
            }
            return noskhemed;
        }

        public async Task<Boolean> ChangeFinallyMedicinWebService(int visitid)
        {
            var find = await _Noskhe.Where(a => a.VisitId == visitid).ToListAsync();
            foreach (var item in find)
            {
                item.Is_Finaly = true;
                await _unitOfWork.SaveChangesAsync();
            }
            return true;
        }

        public async Task<Boolean> CheckFinallyMedicinWebService(int visitid)
        {
            var find = await _Noskhe.Where(a => a.VisitId == visitid).ToListAsync();
            if (find!=null)
            {
                var findfirst = await _Noskhe.Where(a=>a.VisitId==visitid && a.Is_Finaly==true).FirstOrDefaultAsync();
                if (findfirst!=null)
                {
                    return true;
                }
             
            }
            return false;
        }

        public async Task<Boolean> AdMedicineToNoskheWebService(int visitid,string text,int count)
        {
            var find = await _VisitTime.FirstOrDefaultAsync(a => a.Id==visitid);
            if (find!=null)
            {
                if (await AddNoskhe(visitid, find.DoctorId, find.UserId, text, count)==true)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
