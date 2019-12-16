using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class ProductService : IProductService
    {
        public List<ProductModel> GetListProduct(string apiBaseAddress, string linkApi)
        {
            List<ProductModel> lst;
            lst = APIHelper.GetDataFromAPI<List<ProductModel>>(apiBaseAddress, linkApi);
            return lst;
        }

        public int AddProduct(string apiBaseAddress, string linkApi, ProductModel2 pro)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, pro);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        public int UpdateProduct(string apiBaseAddress, string linkApi, ProductModel2 pro)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, pro);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }
    }
}