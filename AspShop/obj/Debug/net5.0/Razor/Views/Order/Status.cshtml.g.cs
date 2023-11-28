#pragma checksum "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a3fa707b54dab6a8663fe1d09e4e6aa5b3cf3edb9dda97a7214a58b6c5e32cf9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Status), @"mvc.1.0.view", @"/Views/Order/Status.cshtml")]
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
#line 1 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
using ShopWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
using ShopWebApp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"a3fa707b54dab6a8663fe1d09e4e6aa5b3cf3edb9dda97a7214a58b6c5e32cf9", @"/Views/Order/Status.cshtml")]
    #nullable restore
    public class Views_Order_Status : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("top", async() => {
                WriteLiteral("\n    <div class=\"jumbotron jumbotron-fluid\" style=\"margin-top: 5vh; margin-bottom: -30px\">\n        <h1 class=\"text-center display-4 align-bottom\">Zamówienie ");
#nullable restore
#line 10 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                                                             Write(Model.Order.Code);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h1>\n    </div>\n");
            }
            );
            WriteLiteral("<div class=\"row\">\n    <ul class=\"list-group col-sm-8\">\n        <li class=\"list-group-item list-group-item-primary\">Produkty</li>\n");
#nullable restore
#line 16 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
         foreach (KeyValuePair<Product, int> kvp in ViewBag.products)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item d-flex justify-content-between align-items-center\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 623, "\"", 646, 2);
            WriteAttributeValue("", 630, "/p/", 630, 3, true);
#nullable restore
#line 19 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
WriteAttributeValue("", 633, kvp.Key.Code, 633, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-dark nounderline\">");
#nullable restore
#line 19 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                                                                    Write(kvp.Key.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 19 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                                                                                   Write(kvp.Key.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n");
#nullable restore
#line 20 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                 if (kvp.Value > 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"badge badge-primary badge-pill\">");
#nullable restore
#line 22 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                                                            Write(kvp.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral(" szt.</span>\n");
#nullable restore
#line 23 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </li>\n");
#nullable restore
#line 25 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n    <ul class=\"list-group col-sm-4\">\n        <li class=\"list-group-item list-group-item-primary\">Status zamówienia</li>\n");
#nullable restore
#line 29 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
         if (Model.Order.Paid)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item list-group-item-success d-flex\">\n                Opłacone  -  ");
#nullable restore
#line 32 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                         Write((Model.Order.Amount / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </li>\n");
#nullable restore
#line 34 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"list-group-item list-group-item-danger d-flex\">\n                Nieopłacone  -  ");
#nullable restore
#line 38 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
                            Write((Model.Order.Amount / 100).ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n            </li>\n");
#nullable restore
#line 40 "E:\interview-tasks\Exceed\AspShop\Views\Order\Status.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591