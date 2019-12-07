using ClientWebAPI.Areas.ShoppingPage.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Areas.ShoppingPage.Controllers
{
    public class KhachHangController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: ShoppingPage/KhachHang
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string dienThoai, string matKhau)
        {
            var res = KhachHangDAO.KhachHangLogin(baseAddress, $"account/khachhanglogin?dienthoai={dienThoai}&&matkhau={matKhau}");
            if(res == null)
            {
                ModelState.AddModelError("", "Sai điện thoại hoặc mật khẩu");
                return View();
            }
            else
            {
                Session["KhachHang"] = res;
                return RedirectToAction("Index", "Home");
            }
            
        }
    }
}