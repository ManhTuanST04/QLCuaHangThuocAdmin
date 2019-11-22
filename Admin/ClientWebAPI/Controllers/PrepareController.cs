using ClientWebAPI.Common;
using ClientWebAPI.IService;
using ClientWebAPI.Models;
using ClientWebAPI.ServiceImpl;
using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Controllers
{
    public class PrepareController : Controller
    {
        ILog log = LogManager.GetLogger(typeof(PrepareController));
        public string baseAddress = ConfigurationManager.AppSettings["APIBaseAddress"];
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string linkAPI = "account/login";
                AccountModel acc = accountService.Login(baseAddress, linkAPI, model);
                if (acc != null)
                {
                    Session["user"] = acc;
                    //Lấy các quền của user và lưu vào Session
                    List<PermissionModel> lstPer = accountService.GetPerUser(baseAddress, $"account/getperuser?userId={acc.id}");
                    Session["PERMISSION_USER"] = lstPer;
                    //Lấy các control của user và lưu vào Session
                    List<ControlModel> lstControl = accountService.GetControlUser(baseAddress, $"account/getcontroluser?userId={acc.id}");

                    Session["CONTROL_USER"] = lstControl;

                    log.Info("Đăng nhập thành công! user:" + acc.userName);
                    log4net.GlobalContext.Properties["currentUser"] = acc.userName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sai tài khoản hoặc mật khẩu");
                }
            }
            catch (Exception  ex)
            {
                log.Error(ex.Message);
                return Redirect("/Error/Error500");
            }
            return View();
        }

        public ActionResult CheckDuplicate(AccountModel model)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string linkApi = $"account/checkduplicte?userName={model.userName}";
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


        public ActionResult CreateAccount(AccountModel model)
        {
            try
            {
                IAccountService accountService = new AccountService();
                string linkApi = "account/addorupdateuser";
                int res = accountService.AddOrUpdateUser(baseAddress, linkApi, model);
                if (res > 0)
                {
                    if (model.id == 0)
                        model.mgs = "Thêm mới thành công!";
                    else
                        model.mgs = "Cập nhật thành công!";
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
                log.Error(ex.Message);
                AccountModel modelRes = new AccountModel();
                modelRes.mgs = "-1";
                return Json(modelRes);
            }
        }

    }
}