using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class ChiTietDonHangModel2
    {
        public int id { set; get; }

        public string Name { set; get; }

        public int Price { set; get; }

        public string Image { set; get; }

        public int SoLuong { set; get; }

        public int ThanhTien { set; get; }
    }
}