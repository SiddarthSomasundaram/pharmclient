#pragma checksum "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6ec41c825592bc5cbd290bcbab75bf49355d4d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prod_Productdetails), @"mvc.1.0.view", @"/Views/Prod/Productdetails.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Administrator\Downloads\PharmClient\Views\_ViewImports.cshtml"
using PharmClient;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator\Downloads\PharmClient\Views\_ViewImports.cshtml"
using PharmClient.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6ec41c825592bc5cbd290bcbab75bf49355d4d9", @"/Views/Prod/Productdetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b75a74b606cc2d89b1789e457db5da70c822309d", @"/Views/_ViewImports.cshtml")]
    public class Views_Prod_Productdetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PharmClient.Models.Product>>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<style>
    #divprofile {
        border: solid;
    }
    input:hover[type=""submit""] {
        border-radius: 20%;
        border: none;
        border-color: bisque;
        background-color: antiquewhite;
    }

    input.slide-hover-left-1 {
        background-image: linear-gradient(0, #156760, #156760);
        background-size: 0;
        transition: .8s;
        background-repeat: no-repeat;
    }

        input.slide-hover-left-1:hover {
            background-size: 100%;
            color: #fff;
        }

    button:hover[type=""submit""] {
        border-radius: 20%;
        border: none;
        border-color: bisque;
        background-color: antiquewhite;
    }

    button.slide-hover-left-1 {
        background-image: linear-gradient(0, #156760, #156760);
        background-size: 0;
        transition: .8s;
        background-repeat: no-repeat;
    }

        button.slide-hover-left-1:hover {
            background-size: 100%;
            color: #fff;
       ");
            WriteLiteral(" }\r\n    #itemdiv {\r\n        position: relative;\r\n        margin-bottom: 25px;\r\n    }\r\n\r\n    #div1 {\r\n        text-align: center;\r\n    }\r\n\r\n    h6 {\r\n        color: #156760;\r\n    }\r\n</style>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f6ec41c825592bc5cbd290bcbab75bf49355d4d94396", async() => {
                WriteLiteral("\r\n\r\n    <div class=\"container\">\r\n        <div class=\"row\">\r\n            <div class=\"col\">\r\n                <div class=\"row\">\r\n");
#nullable restore
#line 67 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
                     foreach (var pro in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <div class=\"col-lg-4\">\r\n                            <div class=\"card\" id=\"itemdiv\" style=\" background-image: linear-gradient(to bottom,white,white,#A2ECE6);\">\r\n                                <div class=\"card-body\" id=\"div1\">\r\n");
                WriteLiteral("                                    <img");
                BeginWriteAttribute("src", " src=\"", 1953, "\"", 1989, 1);
#nullable restore
#line 73 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
WriteAttributeValue("", 1959, Url.Content(pro.ProductImage), 1959, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"no data\" height=\"100\" width=\"100\" />\r\n                                    <h4 style=\"color: #156760\">");
#nullable restore
#line 74 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
                                                          Write(pro.Productname);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n                                    <h6>");
#nullable restore
#line 75 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
                                   Write(pro.ProductDesc);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h6>\r\n                                    <h4 style=\"color: #2F4F4F\">Rs.");
#nullable restore
#line 76 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
                                                             Write(pro.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n\r\n                                </div>\r\n                                <input type=\"button\" value=\"Addtocart\" class=\"btn btn-primary slide-hover-left-1\"");
                BeginWriteAttribute("onclick", " onclick=\"", 2421, "\"", 2519, 8);
                WriteAttributeValue("", 2431, "location.href", 2431, 13, true);
                WriteAttributeValue(" ", 2444, "=", 2445, 2, true);
                WriteAttributeValue(" ", 2446, "\'", 2447, 2, true);
#nullable restore
#line 79 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
WriteAttributeValue("", 2448, Url.Action("AddtoCart", "Prod",pro), 2448, 36, false);

#line default
#line hidden
#nullable disable
                WriteAttributeValue("", 2484, "\';return", 2484, 8, true);
                WriteAttributeValue(" ", 2492, "confirm", 2493, 8, true);
                WriteAttributeValue(" ", 2500, "(\'Product", 2501, 10, true);
                WriteAttributeValue(" ", 2510, "Added\');", 2511, 9, true);
                EndWriteAttribute();
                WriteLiteral(" style=\"background-color: #1D8D84; border: none; \" />\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 82 "C:\Users\Administrator\Downloads\PharmClient\Views\Prod\Productdetails.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n            </div>\r\n");
                WriteLiteral("        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PharmClient.Models.Product>> Html { get; private set; }
    }
}
#pragma warning restore 1591
