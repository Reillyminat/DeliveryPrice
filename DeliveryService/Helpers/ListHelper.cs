using DeliveryServiceModel;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace DeliveryService.API.Helpers
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, IEnumerable<Product> products)
        {
            string result = "<ul>";
            ((List<Product>)products).Sort(new AppliancesComparer());

            foreach (var item in products)
            {
                result = $"{result}<li><a href=\"Product/{item.Id}\">{item.Name}</a></li>";
            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }
    }
}
