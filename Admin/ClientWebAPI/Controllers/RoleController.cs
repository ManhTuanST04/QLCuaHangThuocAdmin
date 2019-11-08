using ClientWebAPI.Common;
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
    public class RoleController : Controller
    {
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        public string CUR_USER_SET_ROLE = "CUR_USER_SET_ROLE";

        ILog log = LogManager.GetLogger(typeof(AccountController));
        // GET: Role
        public ActionResult PhanQuyenUser(int userId)
        {
            IRoleSevice roleService = new RoleService();
            IAccountService accountService = new AccountService();
            string linkApi = $"role/getroleuser?userId={userId}";
            List<RoleModel> lstRole = roleService.GetRoleUser(baseAddress, linkApi);

            List<RoleModel> lstAllRole = roleService.GetAllRole(baseAddress, "role/getallrole");

            AccountModel acc = accountService.GetAccountById(baseAddress, $"account/getuserbyid?id={userId}");
            if(acc.name == "" || acc.name == null)
            {
                ViewBag.CUR_NANE_USER_SET_ROLE = "Danh sách vai trò của User: " + acc.userName;
            }
            else
            {
                ViewBag.CUR_NANE_USER_SET_ROLE = "Danh sách vai trò của User: " + acc.name;
            }

            Session["ALL_ROLE"] = lstAllRole;
            ViewData[CUR_USER_SET_ROLE] = userId;
            return View(lstRole);
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "ViewUser")]
        public ActionResult PhanQuyenUser(int userId, string sRole)
        {
            UserRoleModel model = new UserRoleModel(userId, sRole);
            string linkApi = "role/assignroleuser";
            IRoleSevice roleService = new RoleService();
            int res = roleService.AssignRoleForUser(baseAddress, linkApi, model);
            if(res > 0) //Nếu thực hiện được thì trả về userId
            {
                res = userId;
            }
            return Json(res);
        }



    }
}