#pragma checksum "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fe7e526d37e47d9333ec079e98f8c2b2afa2192e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Footer_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Footer/Default.cshtml")]
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
#line 1 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.Models.Home;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\_ViewImports.cshtml"
using WebApplication.ViewModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fe7e526d37e47d9333ec079e98f8c2b2afa2192e", @"/Views/Shared/Components/Footer/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"01d4cb1a2bd1016b5d949e72488133aed0d2ded8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Footer_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FooterViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<div class=\"col-md-6 col-lg-3\">\r\n    <div class=\"item\">\r\n        <h6>CUSTOMER SERVICE</h6>\r\n        <ul class=\"list-unstyled mt-4\">\r\n");
#nullable restore
#line 8 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
             foreach (var service in Model.Services)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a class=\"text-black-50\"");
            BeginWriteAttribute("href", " href=\"", 274, "\"", 281, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 10 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
                                                Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 11 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n<div class=\"col-md-6 col-lg-3\">\r\n    <div class=\"item\">\r\n        <h6>COMPANY</h6>\r\n        <ul class=\"list-unstyled mt-4\">\r\n");
#nullable restore
#line 19 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
             foreach (var service in Model.Companies)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a class=\"text-black-50\"");
            BeginWriteAttribute("href", " href=\"", 595, "\"", 602, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 21 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
                                                Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 22 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>\r\n<div class=\"col-md-6 col-lg-3\">\r\n    <div class=\"item\">\r\n        <h6>SOCIAL MEDIA</h6>\r\n        <ul class=\"list-unstyled mt-4\">\r\n");
#nullable restore
#line 30 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
             foreach (var service in Model.SocialMedias)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li><a class=\"text-black-50\"");
            BeginWriteAttribute("href", " href=\"", 924, "\"", 931, 0);
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 32 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
                                                Write(service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></li>\r\n");
#nullable restore
#line 33 "C:\Users\Nigar\Desktop\12.17.2021\FrontToBack\WebApplication\WebApplication\Views\Shared\Components\Footer\Default.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FooterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
