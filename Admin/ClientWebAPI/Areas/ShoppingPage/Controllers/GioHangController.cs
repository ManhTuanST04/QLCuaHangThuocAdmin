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
    public class GioHangController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: ShoppingPage/GioHang
        public ActionResult XemGioHang()
        {
            var cart = Session["Cart"];
            var list = new List<GioHangModel>();
            if (cart != null)
            {
                list = (List<GioHangModel>)cart;
                Session["CartCount"] = list.Count;
            }
            
            return View(list);
        }

        public ActionResult ThemVaoGioHang(int idSP, int soLuong)
        {
            //Lấy sản phẩm
            string linkAPI = $"product/productdetail?id={idSP}";
            ProductModel product = ProductDAO.ProductDetail(baseAddress, linkAPI);

            //nếu đã có giỏ hàng
            if (Session["Cart"] != null)
            {
                //Lấy ra giỏ hàng
                List<GioHangModel> cart = (List<GioHangModel>)Session["Cart"];
                if (cart.Exists(x => x.SanPham.id == idSP)) //Nếu tìm thấy sản phẩm trong giỏ thì tăng số lượng sản phẩm thêm 1
                {
                    foreach (var item in cart)
                    {
                        if (item.SanPham.id == idSP)
                        {
                            item.SoLuong += soLuong;
                            item.TongTien = item.SanPham.Price * item.SoLuong;
                        }
                    }
                }
                else //Nếu chưa có sản phẩm trong giỏ thì thêm sản phẩm vào giỏ
                {
                    var item = new GioHangModel();
                    item.SanPham = product;
                    item.SoLuong = soLuong;
                    item.TongTien = item.SanPham.Price * item.SoLuong;
                    cart.Add(item);
                }
                Session["Cart"] = cart;
            }
            else
            {
                var item = new GioHangModel();
                item.SanPham = product;
                item.SoLuong = soLuong;
                item.TongTien = item.SanPham.Price * item.SoLuong;
                var list = new List<GioHangModel>();
                list.Add(item);
                Session["Cart"] = list;
            }

            
            List<GioHangModel> cart1 = (List<GioHangModel>)Session["Cart"];
            @ViewBag.CartCount = cart1.Count;
            return Json(cart1.Count());
        }

        public ActionResult CapNhatSoLuongSanPham(int idSP, int soLuong)
        {
            List<GioHangModel> cart = (List<GioHangModel>)Session["Cart"];
            if (cart.Exists(x => x.SanPham.id == idSP)) //Nếu tìm thấy sản phẩm trong giỏ thì gans laij so luong
            {
                foreach (var item in cart)
                {
                    if (item.SanPham.id == idSP)
                    {
                        item.SoLuong = soLuong;
                        item.TongTien = item.SanPham.Price * item.SoLuong;
                    }
                }
            }
            Session["Cart"] = cart;
            return Json(cart.Count);
        }

        public ActionResult DeleteProductFromCart(int idSP)
        {
            var cart = Session["Cart"];
            var list = (List<GioHangModel>)cart;
            if (cart != null)
            {
                var item = list.Single(x => x.SanPham.id == idSP);
                list.Remove(item);
                return RedirectToAction("XemGioHang", "GioHang");
            }
            return View();
        }


        public ActionResult DeleteAll()
        {
            var cart = Session["Cart"];
            var list = (List<GioHangModel>)cart;
            if (cart != null)
            {
                list.Clear();
                return RedirectToAction("XemGioHang", "GioHang");
            }
            return View();
        }


        public ActionResult DatHang()
        {
            KhachHangModel kh = (KhachHangModel)Session["KhachHang"];
            return View(kh);
        }


        public ActionResult XacNhanDatHang()
        {
            KhachHangModel kh = (KhachHangModel)Session["KhachHang"];
            //Lay thong tin gio hang de them chi tiet don hang
            List<GioHangModel> cart = (List<GioHangModel>)Session["Cart"];

            //Thêm vào bảng đơn hàng
            DonDatHangModel ddhModel = new DonDatHangModel();
            ddhModel.idKH = kh.id;
            ddhModel.ngayDat = DateTime.Now;
            //ddhModel.ngayXuat = "";
            ddhModel.tinhTrangDon = 0;
            ddhModel.tongTien = cart.Sum(x => x.TongTien);

            //Thêm đơn hàng và lấy ra id của đơn để thêm chi tiết
            int idDH = DonDatHangDAO.ThemDonHang(baseAddress, $"donhang/themdonhang", ddhModel);

            List<ChiTietDonHangModel> ctdh = new List<ChiTietDonHangModel>();
            foreach(GioHangModel item in cart)
            {
                ChiTietDonHangModel ctdhItem = new ChiTietDonHangModel();
                ctdhItem.idDH = idDH;
                ctdhItem.idSP = item.SanPham.id;
                ctdhItem.soLuong = item.SoLuong;
                ctdhItem.tongTien = item.TongTien;
                DonDatHangDAO.ThemChiTietDonHang(baseAddress, $"donhang/themchitietdonhang", ctdhItem);
            }

            return RedirectToAction("XemDonHangNguoiDung", "DonDatHang");
        }

        /// <summary>
        /// Nếu đăng nhập rồi thì mới cho xác nhận mua hàng
        /// </summary>
        /// <returns></returns>
        public ActionResult KiemTraDangNhap()
        {
            KhachHangModel kh = (KhachHangModel)Session["KhachHang"];
            if (kh == null)
            {
                return Json(0);
            }
            else
            {
                return Json(1);
            }
        }






    }
}