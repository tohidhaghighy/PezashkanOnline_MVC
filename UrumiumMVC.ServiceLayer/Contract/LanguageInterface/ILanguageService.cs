using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Language;

namespace UrumiumMVC.ServiceLayer.Contract.LanguageInterface
{
    public interface ILanguageService
    {
        Task<List<Language>> GetAllLanguage();
    }
}
