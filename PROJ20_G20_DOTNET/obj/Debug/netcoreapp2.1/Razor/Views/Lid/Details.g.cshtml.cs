#pragma checksum "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e951ae543716ae68520f9f683c6b4e5b9c592163"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Lid_Details), @"mvc.1.0.view", @"/Views/Lid/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Lid/Details.cshtml", typeof(AspNetCore.Views_Lid_Details))]
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
#line 1 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\_ViewImports.cshtml"
using PROJ20_G20_DOTNET;

#line default
#line hidden
#line 2 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\_ViewImports.cshtml"
using PROJ20_G20_DOTNET.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e951ae543716ae68520f9f683c6b4e5b9c592163", @"/Views/Lid/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa4bf064eb2072c38dcd85e682058b8c4b3ecf9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Lid_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PROJ20_G20_DOTNET.Models.Domain.Lid>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
            BeginContext(87, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(94, 14, false);
#line 6 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
Write(Model.Voornaam);

#line default
#line hidden
            EndContext();
            BeginContext(108, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(110, 16, false);
#line 6 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
               Write(Model.Achternaam);

#line default
#line hidden
            EndContext();
            BeginContext(126, 24, true);
            WriteLiteral("</h2>\r\n\r\n<div>\r\n    <h3>");
            EndContext();
            BeginContext(151, 13, false);
#line 9 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
   Write(Model.Functie);

#line default
#line hidden
            EndContext();
            BeginContext(164, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(168, 11, false);
#line 9 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                    Write(Model.Graad);

#line default
#line hidden
            EndContext();
            BeginContext(179, 3, true);
            WriteLiteral(" | ");
            EndContext();
            BeginContext(183, 18, false);
#line 9 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                                   Write(Model.PuntenAantal);

#line default
#line hidden
            EndContext();
            BeginContext(201, 55, true);
            WriteLiteral(" punten</h3>\r\n    <div>\r\n        <label>Geboortedatum: ");
            EndContext();
            BeginContext(257, 39, false);
#line 11 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                         Write(Model.GeboorteDatum.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(296, 47, true);
            WriteLiteral("</label><br />\r\n        <label>Geboorteplaats: ");
            EndContext();
            BeginContext(344, 20, false);
#line 12 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                          Write(Model.GeboortePlaats);

#line default
#line hidden
            EndContext();
            BeginContext(364, 41, true);
            WriteLiteral("</label><br />\r\n        <label>Geslacht: ");
            EndContext();
            BeginContext(406, 14, false);
#line 13 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                    Write(Model.Geslacht);

#line default
#line hidden
            EndContext();
            BeginContext(420, 46, true);
            WriteLiteral("</label><br />\r\n        <label>Nationaliteit: ");
            EndContext();
            BeginContext(467, 19, false);
#line 14 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                         Write(Model.Nationaliteit);

#line default
#line hidden
            EndContext();
            BeginContext(486, 47, true);
            WriteLiteral("</label><br />\r\n        <br />\r\n        <label>");
            EndContext();
            BeginContext(534, 12, false);
#line 16 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
          Write(Model.Straat);

#line default
#line hidden
            EndContext();
            BeginContext(546, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(548, 12, false);
#line 16 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                        Write(Model.HuisNr);

#line default
#line hidden
            EndContext();
            BeginContext(560, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(563, 34, false);
#line 16 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                                       Write(Model.Bus != null ? Model.Bus : "");

#line default
#line hidden
            EndContext();
            BeginContext(598, 31, true);
            WriteLiteral("</label><br />\r\n        <label>");
            EndContext();
            BeginContext(630, 14, false);
#line 17 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
          Write(Model.PostCode);

#line default
#line hidden
            EndContext();
            BeginContext(644, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(646, 20, false);
#line 17 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                          Write(Model.Stad.ToUpper());

#line default
#line hidden
            EndContext();
            BeginContext(666, 52, true);
            WriteLiteral("</label><br />\r\n        <br />\r\n        <label>GSM: ");
            EndContext();
            BeginContext(719, 11, false);
#line 19 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
               Write(Model.GsmNr);

#line default
#line hidden
            EndContext();
            BeginContext(730, 36, true);
            WriteLiteral("</label><br />\r\n        <label>TEL: ");
            EndContext();
            BeginContext(768, 59, false);
#line 20 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                Write(Model.VasteTelefoonNr != null ? Model.VasteTelefoonNr : "/");

#line default
#line hidden
            EndContext();
            BeginContext(828, 55, true);
            WriteLiteral("</label><br />\r\n        <br />\r\n        <label>E-mail: ");
            EndContext();
            BeginContext(884, 11, false);
#line 22 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                  Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(895, 45, true);
            WriteLiteral("</label><br />\r\n        <label>E-mail vader: ");
            EndContext();
            BeginContext(942, 49, false);
#line 23 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                         Write(Model.EmailVader != null ? Model.EmailVader : "/");

#line default
#line hidden
            EndContext();
            BeginContext(992, 46, true);
            WriteLiteral("</label><br />\r\n        <label>E-mail moeder: ");
            EndContext();
            BeginContext(1040, 52, false);
#line 24 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                          Write(Model.EmailMoeder != null ? @Model.EmailMoeder : "/");

#line default
#line hidden
            EndContext();
            BeginContext(1093, 55, true);
            WriteLiteral("</label><br />\r\n        <br />\r\n        <label>Beroep: ");
            EndContext();
            BeginContext(1150, 42, false);
#line 26 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                   Write(Model.Beroep != null ? @Model.Beroep : "/");

#line default
#line hidden
            EndContext();
            BeginContext(1193, 114, true);
            WriteLiteral("</label><br />\r\n        <div id=\"passwordDiv\">\r\n            <button id=\"btnToonWachtwoord\" class=\"btn btn-default\"");
            EndContext();
            BeginWriteAttribute("onclick", "\r\n                    onclick=\"", 1307, "\"", 1786, 17);
            WriteAttributeValue("\r\n                    ", 1338, "const", 1360, 27, true);
            WriteAttributeValue(" ", 1365, "passDiv", 1366, 8, true);
            WriteAttributeValue(" ", 1373, "=", 1374, 2, true);
            WriteAttributeValue(" ", 1375, "document.getElementById(\'passwordDiv\');", 1376, 40, true);
            WriteAttributeValue("\r\n                    ", 1415, "passDiv.removeChild(document.getElementById(\'btnToonWachtwoord\'));", 1437, 88, true);
            WriteAttributeValue("\r\n                    ", 1503, "const", 1525, 27, true);
            WriteAttributeValue(" ", 1530, "lblWachtwoord", 1531, 14, true);
            WriteAttributeValue(" ", 1544, "=", 1545, 2, true);
            WriteAttributeValue(" ", 1546, "document.createElement(\'label\');", 1547, 33, true);
            WriteAttributeValue("\r\n                    ", 1579, "const", 1601, 27, true);
            WriteAttributeValue(" ", 1606, "wwText", 1607, 7, true);
            WriteAttributeValue(" ", 1613, "=", 1614, 2, true);
            WriteAttributeValue(" ", 1615, "document.createTextNode(\'Wachtwoord:", 1616, 37, true);
#line 33 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
WriteAttributeValue(" ", 1652, Model.Wachtwoord, 1653, 17, false);

#line default
#line hidden
            WriteAttributeValue("", 1670, "\');", 1670, 3, true);
            WriteAttributeValue("\r\n                    ", 1673, "lblWachtwoord.appendChild(wwText);", 1695, 56, true);
            WriteAttributeValue("\r\n                    ", 1729, "passDiv.appendChild(lblWachtwoord);", 1751, 57, true);
            EndWriteAttribute();
            BeginContext(1787, 113, true);
            WriteLiteral(">\r\n                Toon wachtwoord\r\n            </button><br />\r\n        </div>\r\n        <br />\r\n    </div>\r\n    ");
            EndContext();
            BeginContext(1900, 299, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b4229a00aabb4f2481baa85012cc591b", async() => {
                BeginContext(1906, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(1916, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "635887e5a76c463bbec1791614ab62eb", async() => {
                    BeginContext(1991, 6, true);
                    WriteLiteral("Wijzig");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 42 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                                    WriteLiteral(Model.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2006, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2016, 95, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ea157a492d02438591776a77f383eab4", async() => {
                    BeginContext(2093, 9, true);
                    WriteLiteral("Verwijder");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues == null)
                {
                    throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper", "RouteValues"));
                }
                BeginWriteTagHelperAttribute();
#line 43 "E:\School\2YS2\Projecten2\PROJ2_G20_DOTNET\PROJ20_G20_DOTNET\Views\Lid\Details.cshtml"
                                      WriteLiteral(Model.Id);

#line default
#line hidden
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2111, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(2121, 65, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("button", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "56d4e6575ee5425dbce02d4ec418835d", async() => {
                    BeginContext(2172, 5, true);
                    WriteLiteral("Terug");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormActionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormActionTagHelper.Action = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(2186, 6, true);
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
            BeginContext(2199, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PROJ20_G20_DOTNET.Models.Domain.Lid> Html { get; private set; }
    }
}
#pragma warning restore 1591
