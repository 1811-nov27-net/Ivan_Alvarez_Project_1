#pragma checksum "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6772dc42a60e6ab4b1b073462253b8726cc3f026"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pizzastore_Details), @"mvc.1.0.view", @"/Views/Pizzastore/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pizzastore/Details.cshtml", typeof(AspNetCore.Views_Pizzastore_Details))]
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
#line 1 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\_ViewImports.cshtml"
using PizzaWebApp;

#line default
#line hidden
#line 2 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\_ViewImports.cshtml"
using PizzaWebApp.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6772dc42a60e6ab4b1b073462253b8726cc3f026", @"/Views/Pizzastore/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ecafee7b281a8aa538eeabe8240a060d1702a2d7", @"/Views/_ViewImports.cshtml")]
    public class Views_Pizzastore_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PizzaWebApp.Models.Orderdetails>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(98, 31, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(129, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6772dc42a60e6ab4b1b073462253b8726cc3f0263881", async() => {
                BeginContext(152, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(166, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(259, 43, false);
#line 16 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Orderid));

#line default
#line hidden
            EndContext();
            BeginContext(302, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(358, 46, false);
#line 19 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Customerid));

#line default
#line hidden
            EndContext();
            BeginContext(404, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(460, 43, false);
#line 22 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Storeid));

#line default
#line hidden
            EndContext();
            BeginContext(503, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(559, 46, false);
#line 25 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Locationid));

#line default
#line hidden
            EndContext();
            BeginContext(605, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(661, 45, false);
#line 28 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Totalcost));

#line default
#line hidden
            EndContext();
            BeginContext(706, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(762, 46, false);
#line 31 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Dateplaced));

#line default
#line hidden
            EndContext();
            BeginContext(808, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 37 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(926, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(975, 42, false);
#line 40 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Orderid));

#line default
#line hidden
            EndContext();
            BeginContext(1017, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1073, 45, false);
#line 43 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Customerid));

#line default
#line hidden
            EndContext();
            BeginContext(1118, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1174, 42, false);
#line 46 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Storeid));

#line default
#line hidden
            EndContext();
            BeginContext(1216, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1272, 45, false);
#line 49 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Locationid));

#line default
#line hidden
            EndContext();
            BeginContext(1317, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1373, 44, false);
#line 52 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Totalcost));

#line default
#line hidden
            EndContext();
            BeginContext(1417, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1473, 45, false);
#line 55 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.DisplayFor(modelItem => item.Dateplaced));

#line default
#line hidden
            EndContext();
            BeginContext(1518, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1574, 65, false);
#line 58 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1639, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1660, 71, false);
#line 59 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1731, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(1752, 69, false);
#line 60 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1821, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 63 "C:\revature\alvarez-practice\PizzaWebApp\WebApplication1\Views\Pizzastore\Details.cshtml"
}

#line default
#line hidden
            BeginContext(1860, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PizzaWebApp.Models.Orderdetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
