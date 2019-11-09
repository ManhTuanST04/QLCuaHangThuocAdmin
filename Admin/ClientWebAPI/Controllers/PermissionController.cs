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
    public class PermissionController : Controller
    {
        ILog log = LogManager.GetLogger(typeof(AccountController));
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        // GET: Permission
        public ActionResult GetPerOfRole(int roleId)
        {
            IPermissionService perService = new PermissionService();
            //Lấy các quyền của vai trò
            List<PermissionModel> lstPerRole = perService.GetPerRole(baseAddress, $"permission/getperrole?roleId={roleId}");

            //Lấy tất cả các quyền
            List<PermissionModel> lstPer = perService.GetAllPermission(baseAddress, "permission/getallper");
            ViewBag.LST_ALL_PER = lstPer;

            return View(lstPerRole);
        }
    }
}