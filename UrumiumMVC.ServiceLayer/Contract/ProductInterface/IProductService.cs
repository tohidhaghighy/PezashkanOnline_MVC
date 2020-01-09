using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrumiumMVC.DomainClasses.Entities.Product;

namespace UrumiumMVC.ServiceLayer.Contract.ProductInterface
{
    public interface IProductService
    {
        Task<bool> DeleteProduct(int productid);
        Task<List<Product>> GetAllProduct();
    }
}
