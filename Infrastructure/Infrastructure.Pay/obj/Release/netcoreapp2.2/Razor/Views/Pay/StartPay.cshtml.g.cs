#pragma checksum "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\Pay\StartPay.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c250c9ea516c653f5b5f036207cba471069ba3bc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_StartPay), @"mvc.1.0.view", @"/Views/Pay/StartPay.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pay/StartPay.cshtml", typeof(AspNetCore.Views_Pay_StartPay))]
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
#line 1 "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\_ViewImports.cshtml"
using Core.Entities.GlobalSettings;

#line default
#line hidden
#line 2 "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\_ViewImports.cshtml"
using Pay.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c250c9ea516c653f5b5f036207cba471069ba3bc", @"/Views/Pay/StartPay.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bbb5ad271925157608714c133df7031a49ab500", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_StartPay : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Image1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height:80px; width:80px;align-content:center;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/ic_logo.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 7, true);
            WriteLiteral("<html>\n");
            EndContext();
            BeginContext(7, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c250c9ea516c653f5b5f036207cba471069ba3bc5309", async() => {
                BeginContext(13, 5, true);
                WriteLiteral("\n    ");
                EndContext();
                BeginContext(18, 52, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c250c9ea516c653f5b5f036207cba471069ba3bc5690", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(70, 1, true);
                WriteLiteral("\n");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(78, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(79, 4988, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c250c9ea516c653f5b5f036207cba471069ba3bc7812", async() => {
                BeginContext(85, 3494, true);
                WriteLiteral(@"
    <style>
        body {
            background-color: white;
        }

        h1 {
            color: red;
            margin-left: 150px;
        }

        .auto-style1 {
            color: #0000FF;
            text-align: right;
        }
    </style>

    <style>
        .Error {
            background-color: burlywood;
        }



        .Error {
            font-size: xx-large;
            color: #ff0000;
        }
    </style>

    <meta name=""viewport"" content=""width=1024"">

    <style>
        .btn-Hiwa {
            color: #fff;
            background-color: #28a745;
            border-color: #28a745;
            font-size: xx-large;
            font-family: 'B Yekan';
            direction: rtl;
            align-items: center;
            text-align: center;
        }

            .btn-Hiwa:hover {
                color: #fff;
                background-color: #218838;
                border-color: #1e7e34;
                font-size: xx-large;
            }

            .btn-Hiwa:focus, .b");
                WriteLiteral(@"tn-success.focus {
                box-shadow: 0 0 0 0.2rem rgba(40, 167, 69, 0.5);
                font-size: xx-large;
            }

            .btn-Hiwa.disabled, .btn-Hiwa:disabled {
                color: #fff;
                background-color: #28a745;
                border-color: #28a745;
                font-size: xx-large;
            }

            .btn-Hiwa:not(:disabled):not(.disabled):active, .btn-Hiwa:not(:disabled):not(.disabled).active,
            .show > .btn-Hiwa.dropdown-toggle {
                color: #fff;
                background-color: #1e7e34;
                border-color: #1c7430;
                font-size: xx-large;
            }

                .btn-Hiwa:not(:disabled):not(.disabled):active:focus, .btn-Hiwa:not(:disabled):not(.disabled).active:focus,
                .show > .btn-Hiwa.dropdown-toggle:focus {
                    box-shadow: 0 0 0 0.2rem rgba(40, 167, 69, 0.5);
                    font-size: xx-large;
                }
    </style>

    <style>
        .table-bo");
                WriteLiteral(@"rdered {
            border: 1px solid #dee2e6;
        }

            .table-bordered th,
            .table-bordered td {
                border: 1px solid #dee2e6;
            }

            .table-bordered thead th,
            .table-bordered thead td {
                border-bottom-width: 2px;
            }
    </style>

    <style>
        .table-success,
        .table-success > th,
        .table-success > td {
            background-color: #c3e6cb;
        }

        .table-hover .table-success:hover {
            background-color: #b1dfbb;
        }

            .table-hover .table-success:hover > td,
            .table-hover .table-success:hover > th {
                background-color: #b1dfbb;
            }
    </style>

    <style>
        .table-primary,
        .table-primary > th,
        .table-primary > td {
            background-color: #b8daff;
        }

        .table-hover .table-primary:hover {
            background-color: #9fcdff;
        }

            .table-hover .table-primary:h");
                WriteLiteral(@"over > td,
            .table-hover .table-primary:hover > th {
                background-color: #9fcdff;
            }
    </style>

    <style>
        div {
            width: 100%;
            margin: 0px auto;
            align-content: center;
            font-size: xx-large;
        }
    </style>
    <style>
        .main {
            color: blue;
            font-family: 'B Yekan';
        }
    </style>



");
                EndContext();
                BeginContext(3757, 233, true);
                WriteLiteral("\n    <div style=\"margin:0px auto;\">\n\n\n\n        <table class=\"table\" style=\"width:100%;align-content:center;text-align:center;\">\n            <tr>\n                <td style=\"align-content:center;text-align:center\">\n                    ");
                EndContext();
                BeginContext(3990, 100, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c250c9ea516c653f5b5f036207cba471069ba3bc12163", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4090, 970, true);
                WriteLiteral(@"

                </td>
            </tr>

            <tr>
                <td style=""align-content:center;text-align:center;font-family:B Yekan;"">
                    <p> سیستم بررسی ویزای آلمان </p>

                </td>
            </tr>

        </table>



        <table class=""table"" style=""width:100%;align-content:center;text-align:center;"">
            <tr>
                <td style=""align-content:center;text-align:center;"">
                    <label id=""Message"" class=""Error"" style=""font-family:B Yekan;"">سامانه قادر به اتصال به درگاه نیست</label>

                </td>
            </tr>
        </table>

        <br /><br />
        <table class=""table"" style=""width:100%;align-content:center;"">
            <tr>
                <td style=""align-content:center;text-align:center;"">
                    <button class=""btn-Hiwa"" onclick=""backToKargozar()"">بازگشت به موبایل </button>
                </td>
            </tr>
        </table>

    </div>
");
                EndContext();
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
            EndContext();
            BeginContext(5067, 173, true);
            WriteLiteral("\n</html>\n<script>\n\n    function backToKargozar() {\n        window.location = \"intent:#Intent;action=schemas.ir.erenco.germany.PassportServicesActivity;end\";\n    }\n</script>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
