using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpers
{
       public static class Helpers
    {
        public static IHtmlContent SubmitButton(this IHtmlHelper htmlHelper, string text, string cssClass)
        {
            return new HtmlString($"<button type='submit' class='{cssClass}'>{text}</button>");
        }

    }
}


