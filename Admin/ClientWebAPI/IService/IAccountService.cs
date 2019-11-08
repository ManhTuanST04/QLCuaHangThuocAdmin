using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.IService
{
    public interface IAccountService
    {
        List<AccountModel> GetListUser(string apiBaseAddress, string linkApi);
        int DeleteUser(string apiBaseAddress, string linkApi);
        AccountModel GetAccountById(string apiBaseAddress, string linkApi);

        AccountModel Login(string apiBaseAddress, string linkApi, AccountModel data);

        int AddOrUpdateUser(string apiBaseAddress, string linkApi, AccountModel data);

        int CheckDuplicateUser(string apiBaseAddress, string linkApi);

        List<PermissionModel> GetPerUser(string apiBaseAddress, string linkApi);

        List<ControlModel> GetControlUser(string apiBaseAddress, string linkApi);
    }
}