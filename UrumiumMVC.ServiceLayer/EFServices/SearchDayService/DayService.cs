using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.ServiceLayer.Contract.SearchDayInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.SearchDayService
{
    public class DayService : IDayService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Day> _Day;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public DayService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Day = _unitOfWork.Set<Day>();
        }
        
        public async Task<List<Day>> GetAllDay()
        {
            return await _Day.OrderByDescending(a => a.Id).ToListAsync();
        }
        
    }
}
