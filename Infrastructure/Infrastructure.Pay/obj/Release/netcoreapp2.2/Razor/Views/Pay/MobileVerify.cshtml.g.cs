#pragma checksum "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\Pay\MobileVerify.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71ecd2d4cd2063fc1d2be3004735b2850d05174b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Pay_MobileVerify), @"mvc.1.0.view", @"/Views/Pay/MobileVerify.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Pay/MobileVerify.cshtml", typeof(AspNetCore.Views_Pay_MobileVerify))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71ecd2d4cd2063fc1d2be3004735b2850d05174b", @"/Views/Pay/MobileVerify.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9bbb5ad271925157608714c133df7031a49ab500", @"/Views/_ViewImports.cshtml")]
    public class Views_Pay_MobileVerify : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pay.Models.PaymentModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(32, 210, true);
            WriteLiteral("<link href=\"/css/bootstrap.css\" rel=\"stylesheet\" />\r\n\r\n\r\n\r\n<div class=\"card bg-white\" style=\"margin:auto auto;\">\r\n\r\n\r\n\r\n\r\n    <center class=\"p-5 bg-danger\">\r\n\r\n        <label id=\"Message\" class=\"h4 text-white\">");
            EndContext();
            BeginContext(243, 13, false);
#line 13 "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\Pay\MobileVerify.cshtml"
                                             Write(Model.Message);

#line default
#line hidden
            EndContext();
            BeginContext(256, 146, true);
            WriteLiteral("</label>\r\n    </center>\r\n\r\n\r\n\r\n\r\n    <table class=\"table table-bordered table-striped\" style=\"align-content:center;margin:auto auto 32px auto;\">\r\n");
            EndContext();
            BeginContext(756, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(1131, 330, true);
            WriteLiteral(@"        <tr>
            <td style=""width:50%; align-content:center;text-align:center;"">
                <label id=""lbl4"" class=""text-dark bg-info"">میزان پرداخت</label>

            </td>
            <td style=""width:50%;align-content:center;text-align:center;"">
                <label id=""Amount"" class=""text-dark bg-info"">");
            EndContext();
            BeginContext(1462, 12, false);
#line 48 "C:\Projects\Zigorat\Amlak\Infrastructure\Infrastructure.Pay\Views\Pay\MobileVerify.cshtml"
                                                        Write(Model.Amount);

#line default
#line hidden
            EndContext();
            BeginContext(1474, 923, true);
            WriteLiteral(@"</label>
            </td>

        </tr>
    </table>

    <table class=""table"" style=""width:100%;align-content:center;"">
        <tr>
            <td style=""align-content:center;text-align:center;"">
                <button id=""back-btn"" class=""btn btn-success bg-info"" onclick=""backToKargozar()"">بازگشت به موبایل</button>
            </td>
        </tr>
    </table>

</div>


<script>
    var loc;
    

    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        loc = ""intent:#Intent;action=schemas.org.nicode.arzyabi_nam.MainActivity;end"";
    } else {
        loc = ""http://37.255.249.175:60002/Profile#my-products""
        //loc = ""http://localhost:5001/Profile#my-products""
        document.getElementById(""back-btn"").innerHTML='بازگشت به سایت';
    }
    backToKargozar = function () {
        window.location = loc;
    }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pay.Models.PaymentModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
