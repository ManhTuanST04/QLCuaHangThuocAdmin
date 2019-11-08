using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class AccountService : IAccountService
    {

        public List<AccountModel> GetListUser(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<AccountModel>>(apiBaseAddress, linkApi);
        }

        public int DeleteUser(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDynamicFromAPI(apiBaseAddress, linkApi);
            return Convert.ToInt32(res);
        }

        public AccountModel GetAccountById(string apiBaseAddress, string linkApi)
        {
            //var acc = APIHelper.GetDynamicFromAPI(apiBaseAddress, linkApi);
            var acc = APIHelper.GetDataFromAPI<AccountModel>(apiBaseAddress, linkApi);

            //AccountModel res = JsonConvert.DeserializeObject<AccountModel>(Convert.ToString(acc));

            return (AccountModel) acc;
        }

        public AccountModel Login(string apiBaseAddress, string linkApi, AccountModel data)
        {
            var res = APIHelper.PostDataToAPI<AccountModel>(apiBaseAddress, linkApi, data);
            return res;
        }

        public int AddOrUpdateUser(string apiBaseAddress, string linkApi, AccountModel data)
        {
            var res = APIHelper.PostDataToAPIReturnDynamic<AccountModel>(apiBaseAddress, linkApi, data);
            return Convert.ToInt32(res);
        }

        public int CheckDuplicateUser(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDynamicFromAPI(apiBaseAddress, linkApi);
            return Convert.ToInt32(res);
        }

        public List<PermissionModel> GetPerUser(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<PermissionModel>>(apiBaseAddress, linkApi);
        }

        public List<ControlModel> GetControlUser(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<ControlModel>>(apiBaseAddress, linkApi);
        }

    }
}