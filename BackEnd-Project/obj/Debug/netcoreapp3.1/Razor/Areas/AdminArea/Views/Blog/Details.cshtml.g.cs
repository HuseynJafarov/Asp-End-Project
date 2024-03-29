#pragma checksum "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\Blog\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b50ceb49f407999d33369ab2c9be8240eaeaed5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Blog_Details), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Blog/Details.cshtml")]
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
#line 1 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.Models.BlogPage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.Models.BlogDetail;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.Models.ContactUs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.ProductViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.BlogViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.ViewModels.ProductViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEnd_Project.Helpers;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b50ceb49f407999d33369ab2c9be8240eaeaed5c", @"/Areas/AdminArea/Views/Blog/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7596cf8ce6ee9e4e3bae0769c41be831533ecb7", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_AdminArea_Views_Blog_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BlogVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:200px; height:200px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Alternate Text"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\Blog\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/AdminArea/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container my-5"">
    <div class=""card"">
        <div class=""card-header"">
            Blog detail
        </div>
        <table class=""table table-bordered"">
            <thead>
                <tr>
                    <th>
                        Image
                    </th>
                    <th>
                        Description
                    </th>
                    <th>
                        Date
                    </th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b50ceb49f407999d33369ab2c9be8240eaeaed5c6742", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 754, "~/assets/img/blog/", 754, 18, true);
#nullable restore
#line 30 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\Blog\Details.cshtml"
AddHtmlAttributeValue("", 772, Model.Blogs.FirstOrDefault(m=> !m.IsDeleted)?.Image, 772, 52, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 33 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\Blog\Details.cshtml"
                   Write(Html.Raw(Model.Blogs.FirstOrDefault(m => !m.IsDeleted).Desc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 36 "C:\Users\HP\Desktop\CodeAcademy\ASP.NET Core\Backend-Project\BackEnd-Project\Areas\AdminArea\Views\Blog\Details.cshtml"
                   Write(Model.Date.ToString("dd.MM.yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n            </tbody>\r\n        </table>\r\n\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BlogVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
