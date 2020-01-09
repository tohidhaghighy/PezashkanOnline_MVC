using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Illness;

namespace UrumiumMVC.ServiceLayer.Contract.MassageIllnessInterface
{
    public interface IMassageIService
    {
        Task<bool> AddIllnessMassage(int visitid, string userid, string text, bool is_user, string onlytext,int typemassage);
        Task<List<IllnessMassage>> GetAllIllnessMassage(int visitid);
    }
}
