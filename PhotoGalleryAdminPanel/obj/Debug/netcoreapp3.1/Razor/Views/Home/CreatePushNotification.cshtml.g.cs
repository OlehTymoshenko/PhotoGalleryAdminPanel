#pragma checksum "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c5d43a8f9cc4a39361c2ce4f670e9a7a4ff4b35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_CreatePushNotification), @"mvc.1.0.view", @"/Views/Home/CreatePushNotification.cshtml")]
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
#line 1 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\_ViewImports.cshtml"
using PhotoGalleryAdminPanel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\_ViewImports.cshtml"
using PhotoGalleryAdminPanel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c5d43a8f9cc4a39361c2ce4f670e9a7a4ff4b35", @"/Views/Home/CreatePushNotification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03564be3e333e5e24911ef5eedcd31aee95a6979", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_CreatePushNotification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PhotoGalleryAdminPanel.Models.PushNotificationViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml"
  
    ViewData["Title"] = "CreatePushNotification";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"text-center\">\r\n    <h1 class=\"display-4\"> Create a new push notification </h1>\r\n    <br>\r\n");
#nullable restore
#line 8 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml"
     using(Html.BeginForm("CreatePushNotification", "Home", FormMethod.Post))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml"
   Write(Html.EditorForModel());

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml"
                              ;

#line default
#line hidden
#nullable disable
            WriteLiteral("        <br>\r\n        <input type=\"submit\" class=\"btn-secondary\" value=\"Send notification\">\r\n");
#nullable restore
#line 13 "C:\Users\user\source\repos\PhotoGallery\PhotoGalleryAdminPanel\Views\Home\CreatePushNotification.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PhotoGalleryAdminPanel.Models.PushNotificationViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
