using DeliveryServiceModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Text;

namespace DeliveryService.API.Helpers
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, IEnumerable<Product> products)
        {
            var result = new StringBuilder("<ul>");
            ((List<Product>)products).Sort(new AppliancesComparer());

            foreach (var item in products)
            {
                result.Append($"<li><a href=\"Product/{item.Id}\">{item.Name}</a></li>");
            }
            result.Append($"</ul>");
            return new HtmlString(result.ToString());
        }
    }
}
