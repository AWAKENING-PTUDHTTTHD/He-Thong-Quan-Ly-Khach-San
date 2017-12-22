using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Pagination
{
    public static class PagingHelper
    {

        public static MvcHtmlString PageLink(PagingInfo pagingInfo, Func<int, string> pageUrl)
        {

            var result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages;i++)
            {
                var tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-warning");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());

        }

    }
}
