using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class KhachHangService : IKhachHangService
    {
        //Danh sách khách hàng
        public List<KhachHangModel> DanhSachKhachHang(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<KhachHangModel>>(apiBaseAddress, linkApi);
        }

        //Lấy khách hàng theo ID
        public KhachHangModel GetKhachHangById(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<KhachHangModel>(apiBaseAddress, linkApi);
        }

        //Thêm khách hàng
        public int ThemKhachHang(string apiBaseAddress, string linkApi, KhachHangModel2 kh)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, kh);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        //Sửa khách hàng
        public int SuaKhachHang(string apiBaseAddress, string linkApi, KhachHangModel2 kh)
        {
            var res =  APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, kh);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        public int XoaKhachHang(string apiBaseAddress, string linkApi)
        {
            int res =  APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

    }
}