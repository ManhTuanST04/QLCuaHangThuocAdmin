using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class ChiTietDonHangModel
    {
        public int idDH { set; get; }
        public int idSP { set; get; }
        public int soLuong { set; get; }
        public int tongTien { set; get; }
    }
}