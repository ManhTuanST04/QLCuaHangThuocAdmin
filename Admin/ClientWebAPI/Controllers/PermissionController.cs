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
            //List<PermissionModel> lstPer = perService.GetAllPermission(baseAddress, "permission/getallper");
            //ViewBag.LST_ALL_PER = lstPer;

            return Json(lstPerRole);
        }

        public ActionResult GetPerNotOfRole(int roleId)
        {
            IPermissionService perService = new PermissionService();
            //Lấy các quyền của vai trò
            List<PermissionModel> lstPerRole = perService.GetPerRole(baseAddress, $"permission/getperrole?roleId={roleId}");

            //Lấy tất cả các quyền
            List<PermissionModel> lstPer = perService.GetAllPermission(baseAddress, "permission/getallper");

            //Lấy các quyền mà Nhóm quyền nay k có
            List<PermissionModel> lstPerNotOfRole = lstPer.Where(n => !lstPerRole.Select(n1 => n1.id).Contains(n.id)).ToList();
            return Json(lstPerNotOfRole);
        }

        public ActionResult AssignPermissionForRole(int roleId, int perId)
        {
            IPermissionService perService = new PermissionService();
            perService.AssignPerForRole(baseAddress, $"permission/assignperforrole?roleId={roleId}&&perId={perId}");

            //tra ve danh sach quyen cua Nhom quyen
            List<PermissionModel> lstPerRole = perService.GetPerRole(baseAddress, $"permission/getperrole?roleId={roleId}");
            return Json(lstPerRole);
        }

        public ActionResult RemovePermissionForRole(int roleId, int perId)
        {
            IPermissionService perService = new PermissionService();
            perService.RemovePerForRole(baseAddress, $"permission/removeperforrole?roleId={roleId}&&perId={perId}");

            //tra ve danh sach quyen cua Nhom quyen
            List<PermissionModel> lstPerRole = perService.GetPerRole(baseAddress, $"permission/getperrole?roleId={roleId}");
            return Json(lstPerRole);
        }

        public ActionResult ThemMoiQuyen()
        {
            return View();
        }

        //Thêm mới quyền
        [HttpPost]
        public ActionResult ThemMoiQuyen(PermissionModel perModel)
        {
            IPermissionService perService = new PermissionService();
            perService.AddNewPer(baseAddress, "permission/addnewper", perModel);
            return RedirectToAction("GetAllRole", "Role");
        }
    }
}