using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebAPI.IService
{
    public interface IRoleSevice
    {
        List<RoleModel> GetAllRole(string apiBaseAddress, string linkApi);
        List<RoleModel> GetRoleUser(string apiBaseAddress, string linkApi);
        int AssignRoleForUser(string apiBaseAddress, string linkApi, UserRoleModel userRoleModel);
    }
}
