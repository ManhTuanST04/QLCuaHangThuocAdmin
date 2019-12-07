using ClientWebAPI.Areas.ShoppingPage.DAO;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Areas.ShoppingPage.Controllers
{
    public class ProductController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        public ActionResult ProductDetail(int id)
        {
            string linkAPI = $"product/productdetail?id={id}";
            ProductModel pro = ProductDAO.ProductDetail(baseAddress, linkAPI);

            return View(pro);
        }
    }
}