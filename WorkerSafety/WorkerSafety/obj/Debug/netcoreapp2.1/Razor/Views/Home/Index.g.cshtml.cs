#pragma checksum "D:\WorkerSafety\WorkerSafety\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16b49798a84c96ba28c03d5dc3fe0fdd6b7d27fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
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
#line 1 "D:\WorkerSafety\WorkerSafety\Views\_ViewImports.cshtml"
using WorkerSafety;

#line default
#line hidden
#line 2 "D:\WorkerSafety\WorkerSafety\Views\_ViewImports.cshtml"
using WorkerSafety.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16b49798a84c96ba28c03d5dc3fe0fdd6b7d27fd", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"af71a27ff72a89d1708d317a66ec564b10bec5ef", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\WorkerSafety\WorkerSafety\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(45, 4328, true);
            WriteLiteral(@"
    <div class=""container-fluid"">
        <!-- Page Heading -->
        <div class=""row"">
            <div class=""col-lg-12"">
                <h1 class=""page-header"">
                    Dashboard
                </h1>
            </div>
        </div>
        <!-- /.row -->
        <div class=""row"">
            <div class=""col-lg-4 col-md-6"">
                <div class=""panel panel-primary"">
                    <a href=""#"">
                        <div class=""panel-footer"">
                            <span class=""pull-left"">Productivity Ratio</span>
                            <div class=""clearfix""></div>
                        </div>
                    </a>
                    <div class=""panel-heading"">
                        <div class=""row"">
                            <div class=""col-xs-9"">
                                <div class=""huge"">9126</div>
                                <div class=""medium"">Last Hour Increase</div><div class=""green""><i class=""fa fa-arrow-up""></i> ");
            WriteLiteral(@"13.8%</div>
                            </div>
                            <div class=""col-xs-3 active "">
                                <i class=""fa fa-comments fa-5x""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""panel panel-green"">
                    <a href=""#"">
                        <div class=""panel-footer"">
                            <span class=""pull-left"">Number of incident</span>
                            <div class=""clearfix""></div>
                        </div>
                    </a>
                    <div class=""panel-heading"">
                        <div class=""row"">
                            <div class=""col-xs-9"">
                                <div class=""huge"">26</div>
                                <div class=""medium"">Compare to Last Month</div><div class=""green""><i class=""fa fa-arrow-down"">");
            WriteLiteral(@"</i> 10.8%</div>
                            </div>
                            <div class=""col-xs-3 active "">
                                <i class=""fa fa-comments fa-5x""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4 col-md-6"">
                <div class=""panel panel-red"">
                    <a href=""#"">
                        <div class=""panel-footer"">
                            <span class=""pull-left"">Departmental Occupancy</span>
                            <div class=""clearfix""></div>
                        </div>
                    </a>
                    <div class=""panel-heading"">
                        <div class=""row"">
                            <div class=""col-xs-9"">
                                <div class=""huge"">26</div>
                                <div class=""green""><i class=""fa fa-arrow-up""></i> 20.8%</div>
                        ");
            WriteLiteral(@"    </div>
                            <div class=""col-xs-3 active "">
                                <i class=""fa fa-comments fa-5x""></i>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- /.row -->
        <div class=""row"">
            <div class=""col-lg-8"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"">
                        <h3 class=""panel-title"">Productivity Ratio Aspects</h3>
                    </div>
                    <div class=""panel-body"">
                        <div id=""morris-area-chart""></div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""panel panel-default"">
                    <div class=""panel-heading"">
                        <h3 class=""panel-title"">Departmental Incidents</h3>
                    </div>
           ");
            WriteLiteral("         <div class=\"panel-body\">\r\n                        <div id=\"morris-donut-chart\"></div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <!-- /.container-fluid -->\r\n\r\n\r\n");
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