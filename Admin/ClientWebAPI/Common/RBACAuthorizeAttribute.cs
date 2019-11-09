using ClientWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientWebAPI.Common
{
    public class RBACAuthorizeAttribute : AuthorizeAttribute
    {
        public string Control { set; get; }
        public string ReturnUrl { set; get; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Lấy danh sách các quyền điều khiển của User
            List<ControlModel> lstUserControl = (List<ControlModel>)HttpContext.Current.Session["CONTROL_USER"];
            List<string> sLstUserControl = new List<string>();
            if(lstUserControl.Count > 0)
            {
                foreach (ControlModel x in lstUserControl)
                {
                    string control = x.code.ToUpper().ToString().Trim();
                    sLstUserControl.Add(control);
                }
            }

            if (sLstUserControl.Count <= 0)
            {
                return false;
            }

            //List này chứa các quyền có thể truy cập vào Action trong Controller
            List<string> lstActionControl = new List<string>(Control.Split(",".ToCharArray()));
            lstActionControl = lstActionControl.Select(x => x.ToUpper().ToString()).ToList();

            //Kiểm tra các quyền User được cấp và quyền truy cập Acction
            //Nếu có thì mới được truy cập
            List<string> per = sLstUserControl.Intersect(lstActionControl).ToList<String>();
            if (per.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Session["RETURN_URL"] = ReturnUrl;
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/401.cshtml"
            };
        }
    }
}