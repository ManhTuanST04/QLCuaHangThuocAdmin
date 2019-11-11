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


    }
}
