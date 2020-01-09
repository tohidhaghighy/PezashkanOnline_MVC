using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.judge;

namespace UrumiumMVC.ServiceLayer.Contract.MassageJudgeInterface
{
    public interface IMassageJService
    {
        Task<bool> AddJudgeIllness(int visitid, string userid, string text, bool is_user,string onlytext,int typemassage);
        Task<List<JudgeIllness>> GetAllJudgeIllness(int visitid);
    }
}
