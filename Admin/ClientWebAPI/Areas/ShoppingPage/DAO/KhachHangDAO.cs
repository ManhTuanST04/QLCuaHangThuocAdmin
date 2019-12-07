using ClientWebAPI.Common;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Areas.ShoppingPage.DAO
{
    public static class KhachHangDAO
    {
        public static KhachHangModel KhachHangLogin(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<KhachHangModel>(apiBaseAddress, linkApi);
            return res;
        }
    }
}