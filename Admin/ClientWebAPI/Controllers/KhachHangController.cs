using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Controllers
{
    public class KhachHangController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        [RBACAuthorizeAttribute(Control = "XemKhachHang")]
        public ActionResult DanhSachKhachHang()
        {
            IKhachHangService serviceKH = new KhachHangService();
            List<KhachHangModel> khModel = serviceKH.DanhSachKhachHang(baseAddress, "khachhang/getallKh");

            return View(khModel);
        }

        [RBACAuthorizeAttribute(Control = "XemKhachHang")]
        public ActionResult GetKhachHangById(int idKH)
        {
            IKhachHangService serviceKH = new KhachHangService();
            KhachHangModel khModel = serviceKH.GetKhachHangById(baseAddress, $"khachhang/getKhById?idKH={idKH}");

            return Json(khModel);
        }

        [RBACAuthorizeAttribute(Control = "ThemKhachHang")]
        public ActionResult ThemKhachHang()
        {
            return View();
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "ThemKhachHang")]
        public ActionResult ThemKhachHang(KhachHangModel2 model)
        {
            IKhachHangService serviceKH = new KhachHangService();
            serviceKH.ThemKhachHang(baseAddress, "khachhang/addkhachhang", model);
            return RedirectToAction("DanhSachKhachHang");
        }

        public ActionResult ChuanBiSuaKH(int idKH)
        {
            IKhachHangService serviceKH = new KhachHangService();
            KhachHangModel khModel = serviceKH.GetKhachHangById(baseAddress, $"khachhang/getKhById?idKH={idKH}");

            return View(khModel);
        }

        [RBACAuthorizeAttribute(Control = "SuaKhachHang")]
        public ActionResult SuaKhachHang(KhachHangModel2 model)
        {
            try
            {
                IKhachHangService serviceKH = new KhachHangService();
                serviceKH.SuaKhachHang(baseAddress, "khachhang/suakhachhang", model);

                return RedirectToAction("DanhSachKhachHang");
            }
            catch(Exception ex)
            {
                return RedirectToAction("DanhSachKhachHang");
            }
        }

        [RBACAuthorizeAttribute(Control = "XoaKhachHang")]
        public ActionResult XoaKhachHang(int idKH)
        {
            IKhachHangService serviceKH = new KhachHangService();
            serviceKH.XoaKhachHang(baseAddress, $"khachhang/xoakhachhang?idKH={idKH}");

            return RedirectToAction("DanhSachKhachHang");
        }
    }
}