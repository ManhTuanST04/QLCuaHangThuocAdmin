using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class DonDatHangModel
    {
        public int id { set; get; } 
        public int idKH { set; get; }
        public DateTime ngayDat { set; get; }
        public DateTime ngayXuat { set; get; }
        public int tinhTrangDon { set; get; }
        public int tongTien { set; get; }

        //public string idSanPham { set; get; }
    }
}