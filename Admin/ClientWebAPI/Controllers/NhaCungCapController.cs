using ClientWebAPI.Common;
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
    public class NhaCungCapController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        ILog log = LogManager.GetLogger(typeof(ProductController));
        // GET: NhaCungCap
        [RBACAuthorizeAttribute(Control = "XemNCC")]
        public ActionResult DanhSachNhaCungCap()
        {
            INhaCungCapService service = new NhaCungCapService();
            List<NhaCungCapModel> lst = service.DanhSachNCC(baseAddress, "nhacungcap/dsncc");
            return View(lst);
        }

        [RBACAuthorizeAttribute(Control = "ThemNCC")]
        public ActionResult ThemNhaCungCap()
        {
            return View();
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "ThemNCC")]
        public ActionResult ThemNhaCungCap(NhaCungCapModel model)
        {
            try
            {
                INhaCungCapService service = new NhaCungCapService();
                service.ThemNCC(baseAddress, "nhacungcap/add", model);
                return RedirectToAction("DanhSachNhaCungCap");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Đã có lỗi xảy ra");
                return RedirectToAction("ThemNhaCungCap");
            }
        }

        //chuan bi sua
        [RBACAuthorizeAttribute(Control = "SuaNCC")]
        public ActionResult ChuanBiSuaNhaCungCap(int idNCC)
        {
            INhaCungCapService service = new NhaCungCapService();
            NhaCungCapModel model = service.GetNCCById(baseAddress, $"nhacungcap/getById?idNCC={idNCC}");
            return View(model);
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "SuaNCC")]
        public ActionResult SuaNhaCungCap(NhaCungCapModel model)
        {
            try
            {
                INhaCungCapService service = new NhaCungCapService();
                service.SuaNCC(baseAddress, "nhacungcap/edit", model);
                return RedirectToAction("DanhSachNhaCungCap");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã có lỗi xảy ra");
                return RedirectToAction("ThemNhaCungCap");
            }
        }

        [RBACAuthorizeAttribute(Control = "XoaNCC")]
        public ActionResult XoaNhaCungCap(int idNCC)
        {
            INhaCungCapService service = new NhaCungCapService();
            service.XoaNCC(baseAddress, $"nhacungcap/delete?idNCC={idNCC}");
            return RedirectToAction("DanhSachNhaCungCap");
        }
    }
}