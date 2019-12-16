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
    public class DonDatHangController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: ShoppingPage/DonDatHang
        public ActionResult XemDonHangNguoiDung()
        {
            int idKH = 0;
            if(Session["KhachHang"] != null)
            {
                idKH = ((KhachHangModel)Session["KhachHang"]).id;
            }
            else
            {
                return RedirectToAction("DangNhap", "KhachHang");
            }
            
            List<DonDatHangModel> res = DonDatHangDAO.XemDonHangNguoiDung(baseAddress, $"donhang/dsdhuser?idUser={idKH}");
            return View(res);
        }

        public ActionResult XemChiTietDonHang(int idDH)
        {
            List<ChiTietDonHangModel2> res = DonDatHangDAO.ChiTietDonHangTheoDon(baseAddress, $"donhang/ctdh2?idDH={idDH}");
            return Json(res);
        }
    }
}