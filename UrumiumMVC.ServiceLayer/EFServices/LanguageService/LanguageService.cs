using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Language;
using UrumiumMVC.ServiceLayer.Contract.LanguageInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.LanguageService
{
    public class LanguageService:ILanguageService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Language> _Language;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public LanguageService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Language = _unitOfWork.Set<Language>();
        }

        public async Task<List<Language>> GetAllLanguage()
        {
            return await _Language.ToListAsync();
        }
    }
}
