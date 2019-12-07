using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class DonDatHangService : IDonDatHangService
    {
        public List<DonDatHangModel> DanhSachDonHang(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<DonDatHangModel>>(apiBaseAddress, linkApi);
        }

        public List<ChiTietDonHangModel2> ChiTietDonHang(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<ChiTietDonHangModel2>>(apiBaseAddress, linkApi);
        }

        public void XacNhanDonHang(string apiBaseAddress, string linkApi)
        {
            APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
        }

        public void HuyDonHang(string apiBaseAddress, string linkApi)
        {
            APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
        }
    }
}