using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientWebAPI.ServiceImpl
{
    public class ControlService :IControlService
    {
        public List<ControlModel> GetAllControl(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<ControlModel>>(apiBaseAddress, linkApi);
        }
        public List<ControlModel> GetControlPer(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<ControlModel>>(apiBaseAddress, linkApi);
        }

        public int AddControlForPer(string apiBaseAddress, string linkApi, ControlModel data)
        {
            APIHelper.PostDataToAPIReturnDynamic<ControlModel>(apiBaseAddress, linkApi, data);
            return 1;
        }

        public int DeleteControlForPer(string apiBaseAddress, string linkApi, ControlModel data)
        {
            APIHelper.PostDataToAPIReturnDynamic<ControlModel>(apiBaseAddress, linkApi, data);
            return 1;
        }

        //Quyền và control
        public List<ControlModel> GetControlRole(string apiBaseAddress, string linkApi)
        {
            return APIHelper.GetDataFromAPI<List<ControlModel>>(apiBaseAddress, linkApi);
        }

        public int AssignControlForRole(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
            return Convert.ToInt32(res);
        }

        public int DeleteControlForRole(string apiBaseAddress, string linkApi)
        {
            var res = APIHelper.GetDataFromAPI<int>(apiBaseAddress, linkApi);
            return Convert.ToInt32(res);
        }
    }
}