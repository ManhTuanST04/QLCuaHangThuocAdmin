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
    }
}
