using System.Web.Mvc;

namespace WebDeveloper.Areas.Internal
{
    public class InternalAreaRegistration : AreaRegistration 
    {
        public override string AreaName => "Internal";

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Internal_default",
                "Intranet/{action}/{id}",
                new { controller= "Internal", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}