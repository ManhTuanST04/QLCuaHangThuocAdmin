using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class RoleService : IRoleSevice
    {

        public List<RoleModel> GetAllRole(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<RoleModel>>(apiBaseAddress, linkApi);
        }

        public List<RoleModel> GetRoleUser(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<RoleModel>>(apiBaseAddress, linkApi);
        }

        public int AssignRoleForUser(string apiBaseAddress, string linkApi, UserRoleModel userRoleModel)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, userRoleModel);
            if(res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        public int AddRole(string apiBaseAddress, string linkApi, RoleModel roleModel)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, roleModel);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }

        public RoleModel GetRoleById(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<RoleModel>(apiBaseAddress, linkApi);
        }

        public int UpdateRole(string apiBaseAddress, string linkApi, RoleModel roleModel)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic(apiBaseAddress, linkApi, roleModel);
            if (res == null)
            {
                res = 0;
            }
            return Convert.ToInt32(res);
        }
    }
}