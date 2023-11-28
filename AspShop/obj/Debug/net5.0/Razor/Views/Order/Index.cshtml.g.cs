#pragma checksum "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "da976ff9e91ac331b844bd5288b45bd35c8c4d13ce9f55d4c084e04d7b45f27d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
using ShopWebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"da976ff9e91ac331b844bd5288b45bd35c8c4d13ce9f55d4c084e04d7b45f27d", @"/Views/Order/Index.cshtml")]
    #nullable restore
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<OrderModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
  
    Layout = "_OrderLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function OnShippingUpdate() {
        if (document.getElementById('ShippingType').value == ""2"") {
            document.getElementById('info').style.display = ""block"";
        }
        else {
            document.getElementById('info').style.display = ""none"";
        }
    }
</script>
");
            DefineSection("top", async() => {
                WriteLiteral("\n    <div class=\"jumbotron\">\n        <h1 class=\"display-3 text-center\">Zamówienie</h1>\n    </div>\n");
            }
            );
            WriteLiteral("\n");
#nullable restore
#line 23 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
 if (Model.Cart.Count < 1)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2 class=\"text-info\">Koszyk jest pusty</h2>\n    <br />\n    <a");
            BeginWriteAttribute("href", " href=\"", 613, "\"", 647, 1);
#nullable restore
#line 27 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 620, Url.Action("cart", "shop"), 620, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary btn-block btn-lg margin-mobile\">Powrót do sklepu</a>\n");
#nullable restore
#line 28 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
}
else
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
     if (Context.User.Identity.IsAuthenticated)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\n            Jesteś zalogowany jako ");
#nullable restore
#line 34 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                              Write(Model.User.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 34 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                               Write(Model.User.Surname);

#line default
#line hidden
#nullable disable
            WriteLiteral("! Twoje zamówienie zostanie zapisane na Twoim koncie.\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\n                <span aria-hidden=\"true\">&times;</span>\n            </button>\n        </div>\n");
#nullable restore
#line 39 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
    }
    else
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-warning alert-dismissible fade show\" role=\"alert\">\n            <a");
            BeginWriteAttribute("href", " href=\"", 1305, "\"", 1360, 2);
#nullable restore
#line 44 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 1312, Url.Action("login", "account"), 1312, 31, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1343, "?ReturnUrl=/order", 1343, 17, true);
            EndWriteAttribute();
            WriteLiteral(@" class=""nounderline text-dark"">
                Zaloguj się, aby zapisać zamówienie na swoim koncie.
            </a>
            <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                <span aria-hidden=""true"">&times;</span>
            </button>
        </div>
");
#nullable restore
#line 51 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
     if (Model.Message != null && Model.Message != string.Empty)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"alert alert-danger alert-dismissible fade show\" role=\"alert\">\n            <span style=\"white-space: pre-line\">");
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                           Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\n            <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\n                <span aria-hidden=\"true\">&times;</span>\n            </button>\n        </div>\n");
#nullable restore
#line 60 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("<form method=\"post\" id=\"orderForm\">\n    <div class=\"form-row\">\n        <div class=\"form-group col-md-6\">\n            <label for=\"ClientName\">Imię</label>\n            <input type=\"text\" class=\"form-control\" name=\"Order.ClientName\" id=\"ClientName\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 2323, "\"", 2356, 1);
#nullable restore
#line 65 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 2333, Model.Order.ClientName, 2333, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2357, "\"", 2388, 1);
#nullable restore
#line 65 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 2365, Model.Order.ClientName, 2365, 23, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" pattern=\".{3,64}\" required>\n        </div>\n        <div class=\"form-group col-md-6\">\n            <label for=\"ClientSurname\">Nazwisko</label>\n            <input type=\"text\" class=\"form-control\" name=\"Order.ClientSurname\" id=\"ClientSurname\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 2628, "\"", 2664, 1);
#nullable restore
#line 69 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 2638, Model.Order.ClientSurname, 2638, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 2665, "\"", 2699, 1);
#nullable restore
#line 69 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 2673, Model.Order.ClientSurname, 2673, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" pattern="".{3,64}"" required>
        </div>
    </div>
    <div class=""form-row"">
        <div class=""form-group col-md-6"">
            <label for=""Email"">Kontaktowy adres email</label>
            <input type=""email"" class=""form-control"" name=""Order.ClientEmail"" id=""Email""");
            BeginWriteAttribute("asp-for", " asp-for=\"", 2974, "\"", 3008, 1);
#nullable restore
#line 75 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 2984, Model.Order.ClientEmail, 2984, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3009, "\"", 3041, 1);
#nullable restore
#line 75 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3017, Model.Order.ClientEmail, 3017, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" pattern=\".{5,128}\" required>\n        </div>\n        <div class=\"form-group col-md-6\">\n            <label for=\"Phone\">Numer telefonu</label>\n            <input type=\"text\" class=\"form-control\" name=\"Order.ClientPhone\" id=\"Phone\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 3270, "\"", 3304, 1);
#nullable restore
#line 79 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3280, Model.Order.ClientPhone, 3280, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3305, "\"", 3337, 1);
#nullable restore
#line 79 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3313, Model.Order.ClientPhone, 3313, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" pattern=\".{7,16}\" required>\n        </div>\n    </div>\n    <div class=\"form-group\">\n        <label for=\"Address\">Adres</label>\n        <input type=\"text\" class=\"form-control\" name=\"Order.Address\" id=\"Address\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 3546, "\"", 3576, 1);
#nullable restore
#line 84 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3556, Model.Order.Address, 3556, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 3577, "\"", 3605, 1);
#nullable restore
#line 84 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3585, Model.Order.Address, 3585, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" pattern=\".{,256}\">\n    </div>\n    <div class=\"row form-group\">\n        <div class=\"col-6\">\n            <select class=\"custom-select\" onchange=\"OnShippingUpdate()\" name=\"Order.ShippingType\" id=\"ShippingType\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 3813, "\"", 3848, 1);
#nullable restore
#line 88 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 3823, Model.Order.ShippingType, 3823, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <option ");
#nullable restore
#line 89 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                         if (Model.Order.ShippingType == 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 90 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Dostawa\n                </option>\n                <option value=\"1\" ");
#nullable restore
#line 93 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.ShippingType == 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 94 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Kurier (+20 zł)\n                </option>\n                <option value=\"2\" ");
#nullable restore
#line 97 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.ShippingType == 2) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 98 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Paczkomat (+8,99 zł)\n                </option>\n                <option value=\"3\" ");
#nullable restore
#line 101 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.ShippingType == 3) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 102 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Odbiór osobisty\n                </option>\n            </select>\n        </div>\n        <div class=\"col-6\">\n            <select class=\"custom-select\" name=\"Order.PaymentMethod\" id=\"PaymentMethod\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 4682, "\"", 4718, 1);
#nullable restore
#line 108 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 4692, Model.Order.PaymentMethod, 4692, 26, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\n                <option ");
#nullable restore
#line 109 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                         if (Model.Order.PaymentMethod == 0) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 110 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Metoda płatności\n                </option>\n                <option value=\"1\" ");
#nullable restore
#line 113 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.PaymentMethod == 1) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 114 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Przelew\n                </option>\n                <option value=\"2\" ");
#nullable restore
#line 117 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.PaymentMethod == 2) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 118 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(">\n                    Płatność przy odbiorze\n                </option>\n                <option value=\"3\" ");
#nullable restore
#line 121 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                                   if (Model.Order.PaymentMethod == 3) {

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
            WriteLiteral(" selected\n");
#nullable restore
#line 122 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@">
                    Przelewy24
                </option>
            </select>
        </div>
    </div>
    <div class=""form-group"" id=""info"" style=""display: none"">
        <input type=""text"" class=""form-control"" name=""Order.ShippingInfo"" id=""ShippingInfo""");
            BeginWriteAttribute("asp-for", " asp-for=\"", 5602, "\"", 5637, 1);
#nullable restore
#line 129 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 5612, Model.Order.ShippingInfo, 5612, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5638, "\"", 5671, 1);
#nullable restore
#line 129 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 5646, Model.Order.ShippingInfo, 5646, 25, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Kod paczkomatu\" pattern=\".{,64}\" />\n    </div>\n    <div class=\"form-group\">\n        <input type=\"text\" class=\"form-control\" name=\"Order.Comments\" id=\"Comments\"");
            BeginWriteAttribute("asp-for", " asp-for=\"", 5845, "\"", 5876, 1);
#nullable restore
#line 132 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 5855, Model.Order.Comments, 5855, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 5877, "\"", 5906, 1);
#nullable restore
#line 132 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 5885, Model.Order.Comments, 5885, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" placeholder=\"Uwagi do zamówienia\" pattern=\".{,2048}\" />\n    </div>\n\n    <div class=\"row\" style=\"margin-top: 30px\">\n        <div class=\"col-sm-4\">\n            <a");
            BeginWriteAttribute("href", " href=\"", 6068, "\"", 6102, 1);
#nullable restore
#line 137 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
WriteAttributeValue("", 6075, Url.Action("cart", "shop"), 6075, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""btn btn-outline-primary btn-block btn-lg margin-mobile"">Powrót do koszyka</a>
        </div>
        <div class=""col-sm-8"">
            <button type=""submit"" class=""btn btn-success btn-block btn-lg margin-mobile"">Zamów produkty</button>
        </div>
    </div>
</form>
");
#nullable restore
#line 144 "E:\interview-tasks\Exceed\AspShop\Views\Order\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<OrderModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
