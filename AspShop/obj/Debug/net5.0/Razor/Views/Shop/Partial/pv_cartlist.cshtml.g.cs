#pragma checksum "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2987172910fe2844c9de51c1c031ae954548cbede697bfe4d27d8c1a73bd4f40"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Partial_pv_cartlist), @"mvc.1.0.view", @"/Views/Shop/Partial/pv_cartlist.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
using ShopWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
using ShopWebApp.Core.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
using ShopWebApp.Infrastrcuture.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"2987172910fe2844c9de51c1c031ae954548cbede697bfe4d27d8c1a73bd4f40", @"/Views/Shop/Partial/pv_cartlist.cshtml")]
    #nullable restore
    public class Views_Shop_Partial_pv_cartlist : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BaseViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<script>
    function addProduct(code, count = 1) {
        $.post(""/cart/add/"" + code + ""/"" + count);
        setTimeout(updateCart, 10)
    }
    function removeProduct(code) {
        $.post(""/cart/remove/"" + code);
        setTimeout(updateCart, 10)
    }
</script>

");
#nullable restore
#line 17 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
 if (ViewBag.Cart.Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<table class=""table table-hover"" style=""font-size: large"">
    <thead>
        <tr>
            <th scope=""col""></th>
            <th scope=""col"">Product</th>
            <th scope=""col"">Price</th>
            <th scope=""col"">Quanity</th>
            <th scope=""col"">Delete</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 30 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
          
            int totalCost = 0, totalDiscount = 0;
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
         foreach (KeyValuePair<string, int> kvp in ViewBag.Cart)
        {
            Product product = new Product();
            using (var db = new ShopContext())
            {
                product = db.Products.Where(p => p.Code == kvp.Key).FirstOrDefault();
                if (product == null)
                    continue;
            }
            int count = kvp.Value;
            totalCost += product.Price * count;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td style=\"max-width: 5vw; max-height: 5vh\"><a");
            BeginWriteAttribute("href", " href=\"", 1313, "\"", 1336, 2);
            WriteAttributeValue("", 1320, "/p/", 1320, 3, true);
#nullable restore
#line 45 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 1323, product.Code, 1323, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img class=\"img-fluid\"");
            BeginWriteAttribute("src", " src=\"", 1360, "\"", 1388, 2);
            WriteAttributeValue("", 1366, "/images/", 1366, 8, true);
#nullable restore
#line 45 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 1374, product.Photo, 1374, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></a></td>\n                <td><a");
            BeginWriteAttribute("href", " href=\"", 1422, "\"", 1445, 2);
            WriteAttributeValue("", 1429, "/p/", 1429, 3, true);
#nullable restore
#line 46 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 1432, product.Code, 1432, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"nounderline text-dark\">");
#nullable restore
#line 46 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                        Write(product.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 46 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                                       Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\n                <td>\n                    ");
#nullable restore
#line 48 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                Write(((double)product.Price*count / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 48 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                          if (product.OldPrice > product.Price)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <p style=\"text-decoration: line-through; color:red\">");
#nullable restore
#line 50 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                        Write(((double)product.OldPrice*count / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <p style=\"color: forestgreen\">Taniej o ");
#nullable restore
#line 51 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                           Write(((double)(product.OldPrice - product.Price)*count / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("!</p>\n");
#nullable restore
#line 52 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                        totalDiscount += (product.OldPrice - product.Price)*count;
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\n                <td><i class=\"bi-arrow-left\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2119, "\"", 2160, 4);
            WriteAttributeValue("", 2129, "addProduct(\'", 2129, 12, true);
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 2141, product.Code, 2141, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2154, "\',", 2154, 2, true);
            WriteAttributeValue(" ", 2156, "-1)", 2157, 4, true);
            EndWriteAttribute();
            WriteLiteral("></i> ");
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                                       Write(kvp.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <i class=\"bi-arrow-right\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2203, "\"", 2243, 4);
            WriteAttributeValue("", 2213, "addProduct(\'", 2213, 12, true);
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 2225, product.Code, 2225, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2238, "\',", 2238, 2, true);
            WriteAttributeValue(" ", 2240, "1)", 2241, 3, true);
            EndWriteAttribute();
            WriteLiteral("></i></td>\n                <td><i class=\"bi-trash-fill\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2299, "\"", 2339, 3);
            WriteAttributeValue("", 2309, "removeProduct(\'", 2309, 15, true);
#nullable restore
#line 56 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
WriteAttributeValue("", 2324, product.Code, 2324, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2337, "\')", 2337, 2, true);
            EndWriteAttribute();
            WriteLiteral("></i></td>\n            </tr>\n");
#nullable restore
#line 58 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\n        <td></td>\n        <td>Suma:</td>\n        <td style=\"font-weight: bold\">");
#nullable restore
#line 62 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                  Write(((double)totalCost / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        <td>\n");
#nullable restore
#line 64 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
             if (totalDiscount > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            WriteLiteral("<p style=\"color: forestgreen; font-weight: bold\">");
#nullable restore
#line 66 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
                                                                       Write(((double)totalDiscount / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" discount</p>\n");
#nullable restore
#line 67 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </td>\n        <td></td>\n    </tr>\n    </tbody>\n</table>\n");
#nullable restore
#line 73 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"text-info\" style=\"text-align:center; margin-top: 20vh; margin-bottom: 25vh\">\n        basket is empty\n    </h2>\n");
#nullable restore
#line 79 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Partial\pv_cartlist.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BaseViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
