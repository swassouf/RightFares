using System.Web.Mvc;

namespace Organization.Application.MVC.Areas.Services
{
    public class ServicesAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Services";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Services_default",
                 "Services/{controller}/{action}/{id}",
                new { area = AreaName, controller = "Common", action = "index", id = UrlParameter.Optional }
            );

            context.MapRoute(
               "Services_default_2",
                "Portal/Services/{controller}/{action}/{id}",
               new { area = AreaName, controller = "Common", action = "index", id = UrlParameter.Optional }
           );
        }
    }
}