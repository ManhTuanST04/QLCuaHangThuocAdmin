using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientWebAPI.Models;

namespace ClientWebAPI.IService
{
    public interface IPermissionService
    {
        List<PermissionModel> GetAllPermission(string apiBaseAddress, string linkApi);
        List<PermissionModel> GetPerRole(string apiBaseAddress, string linkApi);

        int AssignPerForRole(string apiBaseAddress, string linkApi);
        int RemovePerForRole(string apiBaseAddress, string linkApi);

        int AddNewPer(string apiBaseAddress, string linkApi, PermissionModel perModel);
    }
}
