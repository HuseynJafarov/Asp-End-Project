#pragma checksum "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "832481f6c9a2d69c4acc79174e2eb537a95d7847"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Comment_Default), @"mvc.1.0.view", @"/Views/Shared/Components/Comment/Default.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.LayoutViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.BasketViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\_ViewImports.cshtml"
using BackEnd_Project.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"832481f6c9a2d69c4acc79174e2eb537a95d7847", @"/Views/Shared/Components/Comment/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a829211378d353518788851832925a7a8237e2b", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared_Components_Comment_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Comment>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"total-reviews\">\r\n        <div class=\"rev-avatar\">\r\n            <img src=\"`/assets/img/about/avatar.jpg\"");
            BeginWriteAttribute("alt", " alt=\"", 183, "\"", 189, 0);
            EndWriteAttribute();
            WriteLiteral(@">
        </div>
        <div class=""review-box"">
            <div class=""ratings"">
                <span class=""good""><i class=""fa fa-star""></i></span>
                <span class=""good""><i class=""fa fa-star""></i></span>
                <span class=""good""><i class=""fa fa-star""></i></span>
                <span class=""good""><i class=""fa fa-star""></i></span>
                <span><i class=""fa fa-star""></i></span>
            </div>
            <div class=""post-author"">
                <p><span>");
#nullable restore
#line 18 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml"
                    Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -</span>");
#nullable restore
#line 18 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml"
                                           Write(item.AddingTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            </div>\r\n            <p>");
#nullable restore
#line 20 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml"
          Write(item.CommentDetail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 23 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Views\Shared\Components\Comment\Default.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Comment>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
