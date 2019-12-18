using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class NhaCungCapService : INhaCungCapService
    {
        public List<NhaCungCapModel> DanhSachNCC(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<NhaCungCapModel>>(apiBaseAddress, linkApi);
        }
        public NhaCungCapModel GetNCCById(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<NhaCungCapModel>(apiBaseAddress, linkApi);
        }
        public int ThemNCC(string apiBaseAddress, string linkApi, NhaCungCapModel model)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, model);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }
        public int SuaNCC(string apiBaseAddress, string linkApi, NhaCungCapModel model)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, model);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }
        public int XoaNCC(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
            return Convert.ToInt32(res);
        }
    }
}