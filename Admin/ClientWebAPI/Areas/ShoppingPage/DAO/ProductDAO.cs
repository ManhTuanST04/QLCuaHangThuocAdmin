using ClientWebAPI.Common;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.Areas.ShoppingPage.DAO
{
    public static class ProductDAO
    {
        public static List<ProductModel> GetAllProduct(string apiBaseAddress, string linkApi)
        {
            List<ProductModel> lst;
            lst = APIHelper.GetDataFromAPI<List<ProductModel>>(apiBaseAddress, linkApi);
            return lst;
        }

        public static ProductModel ProductDetail(string apiBaseAddress, string linkApi)
        {
            ProductModel pro;
            pro = APIHelper.GetDataFromAPI<ProductModel>(apiBaseAddress, linkApi);
            return pro;
        }
    }
}