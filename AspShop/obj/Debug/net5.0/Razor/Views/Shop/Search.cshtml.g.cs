#pragma checksum "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "b16b70480de0abe67d75d519cf718c59f7e0c3371ebc649bab51c97d089e4857"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shop_Search), @"mvc.1.0.view", @"/Views/Shop/Search.cshtml")]
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
#line 2 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
using ShopWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
using ShopWebApp.Core.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"b16b70480de0abe67d75d519cf718c59f7e0c3371ebc649bab51c97d089e4857", @"/Views/Shop/Search.cshtml")]
    #nullable restore
    public class Views_Shop_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SearchModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\n");
#nullable restore
#line 5 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
      
        Layout = "_Layout";
        int c = 0;
        int count = Model.Count;
        string result = count.ToString() + " ";
        if (count == 1)
            result += "wynik";
        else if (count > 1 && count <= 4)
            result += "wyniki";
        else
            result += "wyników";
    

#line default
#line hidden
#nullable disable
            DefineSection("top", async() => {
                WriteLiteral("\n        <div class=\"jumbotron jumbotron-fluid\" style=\"margin-top: 5vh; margin-bottom: -30px\">\n            <h3 class=\"text-center display-4 align-bottom\">");
#nullable restore
#line 19 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                      Write(Model.SearchFor);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\n            <p class=\"text-center\">");
#nullable restore
#line 20 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                              Write(result);

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\n        </div>\n    ");
            }
            );
            DefineSection("left", async() => {
                WriteLiteral(@"
        <button class=""btn btn-outline-secondary d-md-none btn-block btn-block"" type=""button"" data-toggle=""collapse"" data-target=""#sort"" aria-expanded=""false"" aria-controls=""sort"">
            Sortowanie
        </button>
        <div class=""sticky-top flex-column"" style=""top: 65px"">
            <div class=""collapse dont-collapse-sm list-group"" id=""sort"">
                <span class=""list-group-item font-weight-bold text-muted"">Sortowanie</span>
                <button type=""button"" onclick=""changeQuery('sort', 'name')"" class=""list-group-item list-group-item-action"">Nazwa od A do Z</button>
                <button type=""button"" onclick=""changeQuery('sort', '-name')"" class=""list-group-item list-group-item-action"">Nazwa od Z do A</button>
                <button type=""button"" onclick=""changeQuery('sort', 'price')"" class=""list-group-item list-group-item-action"">Cena od najniższej</button>
                <button type=""button"" onclick=""changeQuery('sort', '-price')"" class=""list-group-item list-group-item-action""");
                WriteLiteral(@">Cena od najwyższej</button>
                <button type=""button"" onclick=""changeQuery('sort', 'rating')"" class=""list-group-item list-group-item-action"">Po ocenie użytkowników</button>
                <button type=""button"" onclick=""changeQuery('sort', 'popularity')"" class=""list-group-item list-group-item-action"">Po popularności</button>
            </div>
        </div>
    ");
            }
            );
            WriteLiteral("    <div style=\"text-align:center\">\n        <h4 class=\"text-info\">");
#nullable restore
#line 40 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                         Write(ViewData["message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\n    </div>\n\n    <div class=\"row\">\n");
#nullable restore
#line 44 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
         foreach (Product prod in Model.Products)
        {
            if (c == 3)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("            ");
            WriteLiteral("</div>\n            ");
            WriteLiteral("<div class=\"row\">\n");
#nullable restore
#line 50 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                c = 0;
            }
            c++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-lg-4 d-flex align-items-stretch\" style=\"padding-left: 5px; padding-right: 5px\">\n                <div class=\"card\" style=\"margin-top: 10px;\">\n                    <a");
            BeginWriteAttribute("href", " href=\"", 2606, "\"", 2626, 2);
            WriteAttributeValue("", 2613, "/p/", 2613, 3, true);
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
WriteAttributeValue("", 2616, prod.Code, 2616, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><img class=\"card-img-top\"");
            BeginWriteAttribute("src", " src=\"", 2653, "\"", 2678, 2);
            WriteAttributeValue("", 2659, "/images/", 2659, 8, true);
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
WriteAttributeValue("", 2667, prod.Photo, 2667, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2679, "\"", 2695, 1);
#nullable restore
#line 55 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
WriteAttributeValue("", 2685, prod.Code, 2685, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"margin-top: 10px; padding-left:5px; padding-right:5px\"></a>\n                    <div class=\"card-body d-flex flex-column\">\n");
#nullable restore
#line 57 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                          
                            double price = prod.Price / 100.0;
                            double rate = -1;
                            int stars = 0, halfStars = 0;
                            if (prod.RatingVotes > 0)
                            {
                                rate = Math.Round(prod.RatingSum / (double)prod.RatingVotes, 2);
                                halfStars = Convert.ToInt32(rate / 0.5);
                                double rest = rate - halfStars * 0.5;
                                if (rest >= 0.5)
                                    halfStars++;
                                stars = halfStars / 2;
                                if (halfStars % 2 == 1)
                                    halfStars = 1;
                                else
                                    halfStars = 0;
                            }
                        

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 3775, "\"", 3795, 2);
            WriteAttributeValue("", 3782, "/p/", 3782, 3, true);
#nullable restore
#line 75 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
WriteAttributeValue("", 3785, prod.Code, 3785, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"text-dark nounderline\"><h5 class=\"card-title\">");
#nullable restore
#line 75 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                                                Write(prod.Brand);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 75 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                                                            Write(prod.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5></a>\n                        <p class=\"card-text\">");
#nullable restore
#line 76 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                        Write(prod.About);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n                        <p class=\"text-warning mt-auto\">\n");
#nullable restore
#line 78 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                             if (rate != -1)
                            {
                                

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                 for (int i = 0; i < stars; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            WriteLiteral("<i class=\"bi-star-fill\"></i>\n");
#nullable restore
#line 83 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                 if (halfStars == 1)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            WriteLiteral("<i class=\"bi-star-half\"></i>\n");
#nullable restore
#line 87 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 88 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                 for (int i = stars + halfStars; i < 5; i++)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    ");
            WriteLiteral("<i class=\"bi-star\"></i>\n");
#nullable restore
#line 91 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                ");
            WriteLiteral("(");
#nullable restore
#line 92 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                              Write(prod.RatingVotes);

#line default
#line hidden
#nullable disable
            WriteLiteral(")\n");
#nullable restore
#line 93 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </p>\n\n");
#nullable restore
#line 96 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                         if (prod.Stock != 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"btn-group mt-auto\">\n                                <a");
            BeginWriteAttribute("href", " href=\"", 4950, "\"", 4970, 2);
            WriteAttributeValue("", 4957, "/p/", 4957, 3, true);
#nullable restore
#line 99 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
WriteAttributeValue("", 4960, prod.Code, 4960, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-outline-primary\">");
#nullable restore
#line 99 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                                   Write(price);

#line default
#line hidden
#nullable disable
            WriteLiteral(" zł</a>\n                                <a href=\"#\" class=\"btn btn-outline-success\"><i class=\"bi-cart-plus-fill\"></i></a>\n                            </div>\n");
#nullable restore
#line 102 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#\" class=\"btn btn-outline-warning mt-auto\">Niedostępny</a>\n");
#nullable restore
#line 106 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\n                </div>\n            </div>\n");
#nullable restore
#line 110 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\n");
#nullable restore
#line 112 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
      
        int prev = Model.Page - 1, next = Model.Page + 1;
    

#line default
#line hidden
#nullable disable
            WriteLiteral("    <br />\n");
#nullable restore
#line 116 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
     if (Model.Page > 1)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("<a class=\"float-left text-dark\" href=\"?name=");
#nullable restore
#line 118 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                 Write(Model.SearchFor);

#line default
#line hidden
#nullable disable
            WriteLiteral("&page=");
#nullable restore
#line 118 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                       Write(prev);

#line default
#line hidden
#nullable disable
            WriteLiteral("&sort=");
#nullable restore
#line 118 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                                  Write(ViewData["sort"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\"><i class=\"bi-arrow-left\"></i> Poprzednia</a>\n");
#nullable restore
#line 119 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 120 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
     if (Model.Page < Model.LastPage)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        ");
            WriteLiteral("<a class=\"float-right text-dark\" href=\"?name=");
#nullable restore
#line 122 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                  Write(Model.SearchFor);

#line default
#line hidden
#nullable disable
            WriteLiteral("&page=");
#nullable restore
#line 122 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                        Write(next);

#line default
#line hidden
#nullable disable
            WriteLiteral("&sort=");
#nullable restore
#line 122 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
                                                                                   Write(ViewData["sort"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">Następna <i class=\"bi-arrow-right\"></i></a>\n");
#nullable restore
#line 123 "E:\interview-tasks\Exceed\AspShop\Views\Shop\Search.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SearchModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
