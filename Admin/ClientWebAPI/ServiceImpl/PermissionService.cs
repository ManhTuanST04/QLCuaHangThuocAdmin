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

    }
}