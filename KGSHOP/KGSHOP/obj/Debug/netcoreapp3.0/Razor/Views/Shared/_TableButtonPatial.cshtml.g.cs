#pragma checksum "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\Shared\_TableButtonPatial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95ef2224447a12a428882b7a7a51962729c3e105"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__TableButtonPatial), @"mvc.1.0.view", @"/Views/Shared/_TableButtonPatial.cshtml")]
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
#line 1 "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\_ViewImports.cshtml"
using KGSHOP;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\_ViewImports.cshtml"
using KGSHOP.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95ef2224447a12a428882b7a7a51962729c3e105", @"/Views/Shared/_TableButtonPatial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8bf69867beea75bca00a1b666fefc9de3995f4f0", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__TableButtonPatial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<int>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<td style=\"width:150px\">\r\n    <div class=\"btn-group\" role=\"group\">\r\n        <a type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 142, "\"", 184, 1);
#nullable restore
#line 7 "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\Shared\_TableButtonPatial.cshtml"
WriteAttributeValue("", 149, Url.Action("Edit") + $"/{Model}", 149, 35, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-edit\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-success\"");
            BeginWriteAttribute("href", " href=\"", 290, "\"", 334, 1);
#nullable restore
#line 10 "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\Shared\_TableButtonPatial.cshtml"
WriteAttributeValue("", 297, Url.Action("Details")+ $"/{Model}", 297, 37, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-info-circle\"></i>\r\n        </a>\r\n        <a type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("href", " href=\"", 446, "\"", 489, 1);
#nullable restore
#line 13 "C:\Users\Admin\Desktop\KGSHOP\KGSHOP\Views\Shared\_TableButtonPatial.cshtml"
WriteAttributeValue("", 453, Url.Action("Delete")+ $"/{Model}", 453, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <i class=\"fa fa-minus-circle\"></i>      \r\n        </a>\r\n    </div>\r\n</td>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<int> Html { get; private set; }
    }
}
#pragma warning restore 1591
