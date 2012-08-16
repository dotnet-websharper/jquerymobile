using System.Web.UI;
using IntelliFactory.WebSharper;

namespace IntelliFactory.WebSharper.JQuery.Mobile.Resources
{
    [IntelliFactory.WebSharper.Core.Attributes.Require(typeof(IntelliFactory.WebSharper.JQuery.Resources.JQuery))]
    public class JQueryMobile : IntelliFactory.WebSharper.Core.Resources.BaseResource
    {
        public JQueryMobile() : base("http://code.jquery.com/mobile/1.1.1",
            "/jquery.mobile-1.1.1.min.js",
            "/jquery.mobile-1.1.1.min.css") {}
    }
}
