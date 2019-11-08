using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using log4net;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];

        ILog log = LogManager.GetLogger(typeof(AccountController));

        [RBACAuthorizeAttribute(Control ="ViewUser,EditUser")]
        public ActionResult Index()
        {
            string username =((AccountModel) Session["user"]).userName;
            try
            {
                List<AccountModel> lst;

                IAccountService accountService = new AccountService();
                string linkApi = "account/lstuser";
                lst = accountService.GetListUser(baseAddress, linkApi);

                return View(lst);
            }
            catch(Exception ex)
            {
                log.Error("User:" + username + "-> " + ex.Message);
                return Redirect("/Error/Error500");
            }
        }

        public ActionResult CheckDuplicate(AccountModel model)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string linkApi = $"account/checkduplicateuser?userName={model.userName}";
                int res = accountService.CheckDuplicateUser(baseAddress, linkApi);
                model.mgs = "" + res;
                return Json(model);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                AccountModel modelRes = new AccountModel();
                modelRes.mgs = "-1";
                return Json(modelRes);
            }
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "AddUser,EditUser")]
        public ActionResult AddOrUpdateUser(AccountModel model)
        {
            string username = ((AccountModel)Session["user"]).userName;
            try
            {
                IAccountService accountService = new AccountService();
                string linkApi = "account/addorupdateuser";
                int res = accountService.AddOrUpdateUser(baseAddress, linkApi, model);
                if (res > 0)
                {
                    if (model.id == 0)
                    {
                        model.mgs = "Thêm mới thành công!";
                        log.Info("Thêm mới User thành công");
                    }
                    else
                    {
                        model.mgs = "Cập nhật User thành công!";
                        log.Info("Cập nhật User thành công!");
                    }
                    return Json(model);
                }
                else
                {
                    if (model.id == 0)
                        model.mgs = "Không thêm được :(";
                    else
                        model.mgs = "Không sửa được :(";
                    return Json(model);
                }
            }
            catch (Exception ex)
            {
                log.Error("User:" + username + "-> " + ex.Message);
                AccountModel modelRes = new AccountModel();
                modelRes.mgs = "-1";
                return Json(modelRes);
            }
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "EditUser")]
        public ActionResult PrepareUpdateUser(int id)
        {
            try
            {
                AccountService accountService = new AccountService();
                string linkApi = $"account/getuserbyid?id={id}";
                var acc = accountService.GetAccountById(baseAddress, linkApi);
                if(acc == null)
                {
                    throw new Exception();
                }
                return Json(acc);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
                AccountModel model = new AccountModel();
                model.mgs = "Không thể kết nối đến API";
                return Json(model);
            }
        }

        [HttpPost]
        [RBACAuthorizeAttribute(Control = "DeleteXXX")]
        public ActionResult DeleteUser(int id)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string linkApi = $"account/deleteuser?id={id}";
                var res = accountService.DeleteUser(baseAddress, linkApi);
                log.Info("Xóa thành công User: id = " + id);
                return Json(res);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return Json("-1");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Login", "Prepare");
        }

    }
}