using DataLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UrumiumMVC.ServiceLayer.Contract.GroupInterface;
using UrumiumMVC.ServiceLayer.Contract.LanguageInterface;
using UrumiumMVC.ServiceLayer.Contract.ProductInterface;
using UrumiumMVC.ViewModel.EntityViewModel.ProductViewModel;

namespace UrumiumWithIdentity.Controllers
{
    public partial class ProductManagmentController : Controller
    {
        IProductService _productservices;
        IGroupService _groupservices;
        ILanguageService _languageservices;
        ProductPageModel _productpm;
        readonly IUnitOfWork _uow;

        public ProductManagmentController(IProductService newproductservice, IGroupService newgroupservice, ILanguageService newlanguageservice,
            IUnitOfWork uow)
        {
            _productservices = newproductservice;
            _groupservices = newgroupservice;
            _languageservices = newlanguageservice;
            _uow = uow;
        }
        // GET: Product
        public async virtual Task<ActionResult> Index()
        {
            _productpm = new ProductPageModel();
            _productpm.Products = await _productservices.GetAllProduct();
            _productpm.Groups = await _groupservices.GetAllGroup();
            _productpm.Languages = await _languageservices.GetAllLanguage();
            return View(_productpm);
        }

        [HttpPost]
        public virtual ActionResult Create()
        {
            return View();
        }
    }
}