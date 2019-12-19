using ClientWebAPI.Areas.ShoppingPage.DAO;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
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
            var res = KhachHangDAO.KhachHangLogin(baseAddress, $"khachhang/khachhanglogin?dienthoai={dienThoai}&&matkhau={matKhau}");
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

        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHangModel2 model)
        {
            try
            {
                IKhachHangService serviceKH = new KhachHangService();
                serviceKH.ThemKhachHang(baseAddress, "khachhang/addkhachhang", model);
                return RedirectToAction("DangNhap");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Đã có lỗi xảy ra");
                return View();
            }
        }


        //16/12/2019
        public ActionResult ChuanBiSuaKhachHang()
        {
            int idKH = 0;
            if (Session["KhachHang"] != null)
            {
                idKH = ((KhachHangModel)Session["KhachHang"]).id;
            }
            else
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            IKhachHangService serviceKH = new KhachHangService();
            KhachHangModel khModel = serviceKH.GetKhachHangById(baseAddress, $"khachhang/getKhById?idKH={idKH}");

            return Json(khModel);
        }

        public ActionResult SuaKhachHang(KhachHangModel2 model)
        {
            try
            {
                IKhachHangService serviceKH = new KhachHangService();
                serviceKH.SuaKhachHang(baseAddress, "khachhang/suakhachhang", model);
                KhachHangModel khModel = serviceKH.GetKhachHangById(baseAddress, $"khachhang/getKhById?idKH={model.id}");
                Session["KhachHang"] = khModel;

                return Json(1);
            }
            catch (Exception ex)
            {
                return Json(0);
            }
        }

    }
}