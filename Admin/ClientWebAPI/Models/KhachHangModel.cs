using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Models
{
    public class KhachHangModel
    {
        public int id { set; get; }

        public String DienThoai { set; get; }

        public String MatKhau { set; get; }

        public String Ten { set; get; }

        public String Email { set; get; }

        public String DiaChi { set; get; }
    }
}