﻿using ClientWebAPI.Common;
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

    }
}