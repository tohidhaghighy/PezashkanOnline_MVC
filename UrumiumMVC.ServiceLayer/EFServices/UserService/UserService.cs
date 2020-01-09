using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.ServiceLayer.Contract.UserInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.UserService
{
    public class UserService:IUserService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<ApplicationUser> _ApplicationUser;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;
        #endregion
        public UserService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _ApplicationUser = _unitOfWork.Set<ApplicationUser>();
        }

        public void alllist()
        {
           // var find = _ApplicationUser.FirstOrDefault();
            //var info = _mapper.Map<CityViewModel>(find);
            //return _city.ToList();
        }
    }
}
