using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebAPI.IService
{
    interface IKhachHangService
    {
        List<KhachHangModel> DanhSachKhachHang(string apiBaseAddress, string linkApi);
        KhachHangModel GetKhachHangById(string apiBaseAddress, string linkApi);

        int ThemKhachHang(string apiBaseAddress, string linkApi, KhachHangModel2 kh);

        int SuaKhachHang(string apiBaseAddress, string linkApi, KhachHangModel2 kh);

        int XoaKhachHang(string apiBaseAddress, string linkApi);
    }
}
