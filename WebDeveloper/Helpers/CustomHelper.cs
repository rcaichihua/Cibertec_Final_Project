using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebDeveloper.Helpers
{
    public static class CustomHelper
    {   
        public static IHtmlString GetModal(this HtmlHelper helper, string htmlId)
        {
            var htmlOfModal = new StringBuilder();
            htmlOfModal.AppendLine("<div id='gameModal' class='modal hide fade in' data-url='@Url.Action('GetGameListing')'>");
            htmlOfModal.AppendLine("<div id='gameContainer'>");
            htmlOfModal.AppendLine("</div>");
            htmlOfModal.AppendLine("</div>");
            return new HtmlString(htmlOfModal.ToString());
        }
    }
}
