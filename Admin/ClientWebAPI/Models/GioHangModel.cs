using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class GioHangModel
    {
        public ProductModel SanPham { set; get; }
        public int SoLuong { set; get; }
        public int TongTien { set; get; }
        public string Anh { set; get; }
    }
}