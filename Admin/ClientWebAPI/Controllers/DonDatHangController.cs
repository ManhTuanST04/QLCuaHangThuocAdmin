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
    public class DonDatHangController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: DonDatHang
        public ActionResult DanhSachDonHang()
        {
            IDonDatHangService service = new DonDatHangService();
            List<DonDatHangModel> lst = service.DanhSachDonHang(baseAddress, "donhang/getalldonhang");
            return View(lst);
        }

        public ActionResult ChiTietDonHang(int idDDH)
        {
            IDonDatHangService serviceDDH = new DonDatHangService();
            List<ChiTietDonHangModel2> lst = serviceDDH.ChiTietDonHang(baseAddress, $"donhang/ctdh2?idDH={idDDH}");
            return Json(lst);
        }

        public ActionResult XacNhanDonHang(int idDDH)
        {
            IDonDatHangService serviceDDH = new DonDatHangService();
            serviceDDH.XacNhanDonHang(baseAddress, $"donhang/xacnhandonhang?idDH={idDDH}");
            return RedirectToAction("DanhSachDonHang");
        }

        public ActionResult HuyDonHang(int idDDH)
        {
            IDonDatHangService serviceDDH = new DonDatHangService();
            serviceDDH.HuyDonHang(baseAddress, $"donhang/huydon?idDH={idDDH}");
            return RedirectToAction("DanhSachDonHang");
        }


    }
}