#pragma checksum "C:\Users\Administrator\Downloads\PharmClient\Views\Order\CancelPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0f7171c813084a05da1382a4fd5ec18bce863b5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_CancelPage), @"mvc.1.0.view", @"/Views/Order/CancelPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0f7171c813084a05da1382a4fd5ec18bce863b5e", @"/Views/Order/CancelPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b75a74b606cc2d89b1789e457db5da70c822309d", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_CancelPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"jumbotron col-md-6\" style=\"background-image: linear-gradient(to right,#A2ECE6,#24B3A8,#1D8D84); margin-left: 350px;\">\r\n    <h4 style=\"color: #A2ECE6;text-align:center\">Hello ");
#nullable restore
#line 8 "C:\Users\Administrator\Downloads\PharmClient\Views\Order\CancelPage.cshtml"
                                                  Write(ViewBag.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("!!</h4>\r\n    <br />\r\n    <h6 style=\"color: white;text-align:center\" \"> Your cart is emptyy!!!</h6>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
