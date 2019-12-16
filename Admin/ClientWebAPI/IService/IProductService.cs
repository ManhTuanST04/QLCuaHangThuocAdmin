using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebAPI.IService
{
    interface IProductService
    {
        List<ProductModel> GetListProduct(string apiBaseAddress, string linkApi);

        int AddProduct(string apiBaseAddress, string linkApi, ProductModel2 pro);
        int UpdateProduct(string apiBaseAddress, string linkApi, ProductModel2 pro);
    }
}
