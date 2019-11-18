using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Controllers
{
    public class ControlController : Controller
    {
        ILog log = LogManager.GetLogger(typeof(AccountController));
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        // GET: Control
        public ActionResult GetControlPer(int perId)
        {
            IControlService controlService = new ControlService();

            List<ControlModel> lstControlPer = controlService.GetControlPer(baseAddress, $"control/getcontrolper?perId={perId}");
            //Lay tat ca cac control
            //List<ControlModel> lstControlAll = controlService.GetAllControl(baseAddress,$"control/getallcontrol");
            //ViewBag.LST_ALL_CONTROL = lstControlAll;

            return Json(lstControlPer);
        }

        //public ActionResult LoadDataForComboControl(int perId)
        //{
        //    IControlService controlService = new ControlService();

        //    List<ControlModel> lstControlPer = controlService.GetControlPer(baseAddress, $"control/getcontrolper?perId={perId}");
        //    //Lay tat ca cac control
        //    List<ControlModel> lstControlAll = controlService.GetAllControl(baseAddress, $"control/getallcontrol");

        //    List<ControlModel> lstControlNotOfPer = lstControlAll.Where(n => !lstControlPer.Select(n1 => n1.id).Contains(n.id)).ToList();

        //    return Json(lstControlNotOfPer);
        //}

        public ActionResult AddControlForPer(ControlModel controlModel)
        {
            IControlService controlService = new ControlService();
            controlService.AddControlForPer(baseAddress, "control/assigncontrolforper", controlModel);

            List<ControlModel> lstControlPer = controlService.GetControlPer(baseAddress, $"control/getcontrolper?perId={controlModel.permissionId}");
            return Json(lstControlPer);
        }

        public ActionResult DeleteControlForPer(ControlModel controlModel)
        {
            IControlService controlService = new ControlService();
            controlService.AddControlForPer(baseAddress, "control/deletecontrolforper", controlModel);

            List<ControlModel> lstControlPer = controlService.GetControlPer(baseAddress, $"control/getcontrolper?perId={controlModel.permissionId}");
            return Json(lstControlPer);
        }
    }
}