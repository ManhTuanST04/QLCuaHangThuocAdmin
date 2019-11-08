using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Controllers
{
    public class ProductController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        ILog log = LogManager.GetLogger(typeof(ProductController));
        // GET: Product

        public ActionResult Index()
        {
            try
            {
                IProductService productService = new ProductService();
                string linkAPI = "product/lstpro";
                List<ProductModel> lst = productService.GetListProduct(baseAddress, linkAPI);
                log.Info("Lấy thông danh sách sản phẩm");
                return View(lst);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                return View();
            }
        }
    }
}