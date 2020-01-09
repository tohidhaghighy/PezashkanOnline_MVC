using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Common;

namespace UrumiumMVC.ServiceLayer.Contract.SearchDayInterface
{
    public interface IDayService
    {
        Task<List<Day>> GetAllDay();
    }
}
