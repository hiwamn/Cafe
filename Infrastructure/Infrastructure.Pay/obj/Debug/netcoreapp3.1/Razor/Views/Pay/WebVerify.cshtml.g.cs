#pragma checksum "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\Pay\WebVerify.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ecc17079bd8229ba73b7876968092c3ac174d8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_WebVerify), @"mvc.1.0.view", @"/Views/Pay/WebVerify.cshtml")]
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
#line 1 "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\_ViewImports.cshtml"
using Core.Entities.GlobalSettings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\_ViewImports.cshtml"
using Pay.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ecc17079bd8229ba73b7876968092c3ac174d8b", @"/Views/Pay/WebVerify.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"94a3235ebdfaa218c77f5f339fd4371ad3b71766", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_WebVerify : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pay.Models.PaymentModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<link href=\"/css/bootstrap.css\" rel=\"stylesheet\" />\r\n\r\n\r\n\r\n<div class=\"card bg-white\" style=\"margin:auto auto;\">\r\n\r\n\r\n\r\n\r\n    <center class=\"p-5 bg-danger\">\r\n\r\n        <label id=\"Message\" class=\"h4 text-white\">");
#nullable restore
#line 13 "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\Pay\WebVerify.cshtml"
                                             Write(Model.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n    </center>\r\n\r\n\r\n\r\n\r\n    <table class=\"table table-bordered table-striped\" style=\"align-content:center;margin:auto auto 32px auto;\">\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"        <tr>
            <td style=""width:50%; align-content:center;text-align:center;"">
                <label id=""lbl4"" class=""text-dark bg-info"">میزان پرداخت</label>

            </td>
            <td style=""width:50%;align-content:center;text-align:center;"">
                <label id=""Amount"" class=""text-dark bg-info"">");
#nullable restore
#line 48 "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\Pay\WebVerify.cshtml"
                                                        Write(Model.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
            </td>

        </tr>
    </table>

    <table class=""table"" style=""width:100%;align-content:center;"">
        <tr>
            <td style=""align-content:center;text-align:center;"">
                <button id=""back-btn"" class=""btn btn-success bg-info"" onclick=""backToKargozar()"">بازگشت به سایت  نام ساز</button>
            </td>
        </tr>
    </table>

</div>


<script>
    var loc;    
    loc = '");
#nullable restore
#line 67 "C:\Users\Hirad\Desktop\cafelanda-backend\Infrastructure\Infrastructure.Pay\Views\Pay\WebVerify.cshtml"
      Write(PaymentData.SiteAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\';\r\n    document.getElementById(\"back-btn\").innerHTML=\'بازگشت به سایت\';\r\n    \r\n    function backToKargozar()  {\r\n        window.location = loc;\r\n    }\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pay.Models.PaymentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
