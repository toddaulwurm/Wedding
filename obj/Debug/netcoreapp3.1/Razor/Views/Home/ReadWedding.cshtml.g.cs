#pragma checksum "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8c69f854aaeadb8c177b7ad1316368395fb52fb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ReadWedding), @"mvc.1.0.view", @"/Views/Home/ReadWedding.cshtml")]
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
#line 1 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\_ViewImports.cshtml"
using Wedding;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\_ViewImports.cshtml"
using Wedding.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8c69f854aaeadb8c177b7ad1316368395fb52fb", @"/Views/Home/ReadWedding.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a8ed3f45bb2d4924026e66eb79785b55f254b9ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ReadWedding : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WeddingModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"container\">\r\n    <a href=\"/logout\" class=\"btn btn-dark\">Logout</a>\r\n    <a href=\"/Dashboard\" class=\"btn btn-success\">Home</a>\r\n    <h1>Hey, ");
#nullable restore
#line 10 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
        Write(ViewBag.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("! <br>Here Are the details for ");
#nullable restore
#line 10 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
                                                              Write(ViewBag.OneModel.NameOne);

#line default
#line hidden
#nullable disable
            WriteLiteral(" & ");
#nullable restore
#line 10 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
                                                                                          Write(ViewBag.OneModel.NameTwo);

#line default
#line hidden
#nullable disable
            WriteLiteral("\'s Wedding.</h1>\r\n    <h2>Date: ");
#nullable restore
#line 11 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
         Write(ViewBag.OneModel.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h2>Address: ");
#nullable restore
#line 12 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
            Write(ViewBag.OneModel.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <h3>Guest List:</h3>\r\n    <ul>\r\n");
#nullable restore
#line 15 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
          
            foreach(RSVP rsvp in ViewBag.GuestList)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li>");
#nullable restore
#line 18 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
               Write(rsvp.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 18 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
                                    Write(rsvp.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 19 "C:\Users\todda\OneDrive\Documents\CodingDojo\C#\ORMs\Wedding\Views\Home\ReadWedding.cshtml"
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WeddingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591