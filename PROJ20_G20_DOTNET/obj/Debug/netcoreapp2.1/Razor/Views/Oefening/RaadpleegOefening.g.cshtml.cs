#pragma checksum "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0c8a8dcbfbbd7655344b0d6f509f33bb81673399"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Oefening_RaadpleegOefening), @"mvc.1.0.view", @"/Views/Oefening/RaadpleegOefening.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Oefening/RaadpleegOefening.cshtml", typeof(AspNetCore.Views_Oefening_RaadpleegOefening))]
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
#line 1 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\_ViewImports.cshtml"
using PROJ20_G20_DOTNET;

#line default
#line hidden
#line 2 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\_ViewImports.cshtml"
using PROJ20_G20_DOTNET.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0c8a8dcbfbbd7655344b0d6f509f33bb81673399", @"/Views/Oefening/RaadpleegOefening.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4bf064eb2072c38dcd85e682058b8c4b3ecf9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Oefening_RaadpleegOefening : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PROJ20_G20_DOTNET.Models.Domain.Oefening>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ToonOefeningenLid", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
  
    ViewData["Title"] = Model.Titel;

#line default
#line hidden
            BeginContext(96, 17, true);
            WriteLiteral("\r\n<div>\r\n    <h2>");
            EndContext();
            BeginContext(114, 11, false);
#line 8 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
   Write(Model.Graad);

#line default
#line hidden
            EndContext();
            BeginContext(125, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(129, 16, false);
#line 8 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
                  Write(Model.Thema.Naam);

#line default
#line hidden
            EndContext();
            BeginContext(145, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(149, 11, false);
#line 8 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
                                      Write(Model.Titel);

#line default
#line hidden
            EndContext();
            BeginContext(160, 26, true);
            WriteLiteral("</h2>\r\n    <hr />\r\n    <p>");
            EndContext();
            BeginContext(187, 11, false);
#line 10 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
  Write(Model.Tekst);

#line default
#line hidden
            EndContext();
            BeginContext(198, 55, true);
            WriteLiteral("</p>\r\n    <iframe width=\"560\"\r\n            height=\"315\"");
            EndContext();
            BeginWriteAttribute("src", "\r\n            src=", 253, "", 286, 1);
#line 13 "E:\School\2YS2\Projecten2\dotnet-g20\PROJ20_G20_DOTNET\Views\Oefening\RaadpleegOefening.cshtml"
WriteAttributeValue("", 271, Model.UrlVideo, 271, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(286, 173, true);
            WriteLiteral("\r\n            frameborder=\"0\"\r\n            allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\"\r\n            allowfullscreen></iframe><br />\r\n    ");
            EndContext();
            BeginContext(459, 111, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "03c868e8b9a1414dbf0d686155285a86", async() => {
                BeginContext(465, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(475, 82, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "acdcec6c220843a981a275f7c7e1ee5b", async() => {
                    BeginContext(543, 5, true);
                    WriteLiteral("Terug");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("asp-", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(557, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(570, 10, true);
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PROJ20_G20_DOTNET.Models.Domain.Oefening> Html { get; private set; }
    }
}
#pragma warning restore 1591
