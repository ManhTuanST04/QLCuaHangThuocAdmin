using ClientWebAPI.Common;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Areas.ShoppingPage.DAO
{
    public static class DonDatHangDAO
    {
        public static int ThemDonHang(string apiBaseAddress, string linkApi, DonDatHangModel ddhModel)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic<DonDatHangModel>(apiBaseAddress, linkApi, ddhModel);
            
            return Convert.ToInt32(res);
        }

        public static int ThemChiTietDonHang(string apiBaseAddress, string linkApi, ChiTietDonHangModel ctdh)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, ctdh);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        public static List<DonDatHangModel> XemDonHangNguoiDung(string apiBaseAddress, string linkApi)
        {
            List<DonDatHangModel> res = APIHelper.GetDataFromAPI<List<DonDatHangModel>>(apiBaseAddress, linkApi);
            return res;
        }

        public static List<ChiTietDonHangModel2> ChiTietDonHangTheoDon(string apiBaseAddress, string linkApi)
        {
            List<ChiTietDonHangModel2> res = APIHelper.GetDataFromAPI<List<ChiTietDonHangModel2>>(apiBaseAddress, linkApi);
            return res;
        }



    }
}