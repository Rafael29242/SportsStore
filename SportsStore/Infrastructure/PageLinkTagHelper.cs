using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SportsStore.Models.ViewModels;

namespace SportsStore.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]  //<div page-model="___" page-action=" "....
    public class PageLinkTagHelper
       : TagHelper
    {
        //   F i e l d s   &   P r o p e r t i e s

        private IUrlHelperFactory _urlHelperFactory;

        public string PageAction { get; set; }

        public PagingInfo PageModel { get; set; }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        //   C o n s t r u c t o r s

        public PageLinkTagHelper
           (IUrlHelperFactory helperFactory)
        {
            _urlHelperFactory = helperFactory;
        }

        //   M e t h o d s

        public override void Process
           (TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper =
               _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder result = new TagBuilder("div");
            for (int i = 1; i <= PageModel.TotalPages(); i++)
            {
                TagBuilder anchorTag = new TagBuilder("a");
                anchorTag.Attributes["href"] = urlHelper.Action(PageAction, new { productPage = i });
                anchorTag.InnerHtml.Append(i.ToString());
                result.InnerHtml.AppendHtml(anchorTag);
            }
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
