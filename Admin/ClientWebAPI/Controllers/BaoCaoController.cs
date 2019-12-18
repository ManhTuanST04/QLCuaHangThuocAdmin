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
    public class BaoCaoController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: BaoCao
        [RBACAuthorizeAttribute(Control = "BCDH")]
        public ActionResult BaoCaoDonHang()
        {
            ViewBag.tuNgay = DateTime.Now.ToString("dd-MM-yyyy");
            ViewBag.denNgay = DateTime.Now.ToString("dd-MM-yyyy");
            return View();
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "BCDH")]
        public ActionResult BaoCaoDonHang(string sTuNgay, string sDenNgay, int tinhTrangDon)
        {
            DateTime tuNgay = Convert.ToDateTime(sTuNgay);
            DateTime denNgay = Convert.ToDateTime(sDenNgay);

            ViewBag.tuNgay = tuNgay.ToString("dd-MM-yyyy");
            ViewBag.denNgay = denNgay.ToString("dd-MM-yyyy");
            ViewBag.tinhTrangDon = tinhTrangDon;

            IDonDatHangService service = new DonDatHangService();
            List<DonDatHangModel> lst = service.DanhSachDonHang(baseAddress, "donhang/getalldonhang");

            if(tinhTrangDon == 0)
            {
                lst = lst.Where(x => x.ngayDat >= tuNgay && x.ngayDat <= denNgay).Where(x=>x.tinhTrangDon == 0).ToList();
            }
            else if(tinhTrangDon == 1)
            {
                lst = lst.Where(x => x.ngayXuat >= tuNgay && x.ngayXuat <= denNgay).Where(x=>x.tinhTrangDon == 1).ToList();
                
            }
            else if (tinhTrangDon == -1)
            {
                lst = lst.Where(x => x.ngayXuat >= tuNgay && x.ngayXuat <= denNgay).Where(x => x.tinhTrangDon == -1).ToList();

            }
            return View(lst);
        }
    }
}