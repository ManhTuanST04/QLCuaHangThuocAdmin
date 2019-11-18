using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class PermissionService : IPermissionService
    {
        public List<PermissionModel> GetAllPermission(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<PermissionModel>>(apiBaseAddress, linkApi);
        }
        public List<PermissionModel> GetPerRole(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<PermissionModel>>(apiBaseAddress, linkApi);
        }
        public int AssignPerForRole(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
            
            return Convert.ToInt32(res);
        }

        public int RemovePerForRole(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);

            return Convert.ToInt32(res);
        }

    }
}