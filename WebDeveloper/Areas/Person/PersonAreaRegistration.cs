using System.Web.Mvc;

namespace WebDeveloper.Areas.Person
{
    public class PersonAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Person";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Person_default",
                "Personal/{action}/{id}",
                new { controller="Person", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}