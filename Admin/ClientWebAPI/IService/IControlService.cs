using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebAPI.IService
{
    public interface IControlService
    {
        List<ControlModel> GetAllControl(string apiBaseAddress, string linkApi);
        List<ControlModel> GetControlPer(string apiBaseAddress, string linkApi);

        int AddControlForPer(string apiBaseAddress, string linkApi, ControlModel data);
        int DeleteControlForPer(string apiBaseAddress, string linkApi, ControlModel data);

        //
        List<ControlModel> GetControlRole(string apiBaseAddress, string linkApi);
        int AssignControlForRole(string apiBaseAddress, string linkApi);
        int DeleteControlForRole(string apiBaseAddress, string linkApi);
    }
}
