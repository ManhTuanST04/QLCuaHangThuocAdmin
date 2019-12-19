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
    public class HomeController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: ShoppingPage/Home
        public ActionResult Index()
        {
            //Load danh sách sản phẩm
            try
            {
                //Lấy thông tin giỏ hàng để hiện số lượng lên trag chủ
                List<GioHangModel> cart = (List<GioHangModel>)Session["Cart"];
                Session["CartCount"] = cart != null ? cart.Count : 0;

                string linkAPI = "product/lstpro";
                List<ProductModel> lst = ProductDAO.GetAllProduct(baseAddress, linkAPI);
                return View(lst);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

    }
}