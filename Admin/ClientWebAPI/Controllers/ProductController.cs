using ClientWebAPI.Areas.ShoppingPage.DAO;
using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
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

        [RBACAuthorizeAttribute(Control = "ViewProduct")]
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return View();
            }
        }

        public ActionResult PrepareAddProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(HttpPostedFileBase imgPro, ProductModel2 product)
        {
            if (imgPro.ContentLength > 0)
            {
                var path = Path.Combine(Server.MapPath("~/Areas/ShoppingPage/Content/Uploads/ImgProduct/"), Path.GetFileName(imgPro.FileName));
                imgPro.SaveAs(path);
                product.image = imgPro.FileName;
            }

            IProductService productService = new ProductService();
            string linkAPI = "product/addproduct";

            productService.AddProduct(baseAddress, linkAPI, product);

            return RedirectToAction("Index");
        }

        public ActionResult PrepareUpdateProduct(int idSP)
        {
            string linkAPI = $"product/productdetail?id={idSP}";
            ProductModel pro = ProductDAO.ProductDetail(baseAddress, linkAPI);
            return View(pro);
        }

        [HttpPost]
        public ActionResult UpdateProduct(HttpPostedFileBase imgPro, ProductModel2 product)
        {
            if(imgPro != null)
            {
                if (imgPro.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/Areas/ShoppingPage/Content/Uploads/ImgProduct/"), Path.GetFileName(imgPro.FileName));
                    imgPro.SaveAs(path);
                    product.image = imgPro.FileName;
                }
            }
            else
            {
                ProductModel pro = ProductDAO.ProductDetail(baseAddress, $"product/productdetail?id={product.id}");
                product.image = pro.Image;
            }

            IProductService productService = new ProductService();
            string linkAPI = "product/updateproduct";
            productService.UpdateProduct(baseAddress, linkAPI, product);

            return RedirectToAction("Index");
        }
    }
}