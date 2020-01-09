using AutoMapper;
using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Product;
using UrumiumMVC.ServiceLayer.Contract.ProductInterface;

namespace UrumiumMVC.ServiceLayer.EFServices.ProductService
{
    public class ProductService:IProductService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbSet<Product> _Product;
        private readonly MapperConfiguration _configuration;
        private readonly IMapper _mapper;

        #endregion
        public ProductService(IUnitOfWork unitofwork, MapperConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitofwork;
            _configuration = configuration;
            _mapper = mapper;
            _Product = _unitOfWork.Set<Product>();
        }

        public async Task<bool> DeleteProduct(int productid)
        {
            var find = await _Product.Where(a => a.Id == productid).ToListAsync();
            if (find != null)
            {
                foreach (var item in find)
                {
                    _Product.Remove(item);
                }

                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            return false;
        }

       
        public async Task<List<Product>> GetAllProduct()
        {
            return await _Product.OrderByDescending(a => a.Id).ToListAsync();
        }


    }
}
