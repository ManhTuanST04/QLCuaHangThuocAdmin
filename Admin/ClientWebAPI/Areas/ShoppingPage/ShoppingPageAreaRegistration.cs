using System.Web.Mvc;

namespace ClientWebAPI.Areas.ShoppingPage
{
    public class ShoppingPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ShoppingPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ShoppingPage_default",
                "ShoppingPage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "ClientWebAPI.Areas.ShoppingPage.Controllers" }
            );
        }
    }
}