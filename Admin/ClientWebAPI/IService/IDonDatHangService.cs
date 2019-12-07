using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.IService
{
    public interface IDonDatHangService
    {
        List<DonDatHangModel> DanhSachDonHang(string apiBaseAddress, string linkApi);

        List<ChiTietDonHangModel2> ChiTietDonHang(string apiBaseAddress, string linkApi);

        void XacNhanDonHang(string apiBaseAddress, string linkApi);
        void HuyDonHang(string apiBaseAddress, string linkApi);
    }
}