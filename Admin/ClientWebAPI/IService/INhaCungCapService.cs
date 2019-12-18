using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebAPI.IService
{
    public interface INhaCungCapService
    {
        List<NhaCungCapModel> DanhSachNCC(string apiBaseAddress, string linkApi);
        NhaCungCapModel GetNCCById(string apiBaseAddress, string linkApi);
        int ThemNCC(string apiBaseAddress, string linkApi, NhaCungCapModel model);
        int SuaNCC(string apiBaseAddress, string linkApi, NhaCungCapModel model);
        int XoaNCC(string apiBaseAddress, string linkApi);
    }
}
