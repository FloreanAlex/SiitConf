#pragma checksum "C:\Users\User\source\repos\Siit-Conference\Siit-Conference\Areas\Admin\Views\Workshop\Create.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42501eb54246ce56ccc156a4a06f8bcbf615a9a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Workshop_Create), @"mvc.1.0.view", @"/Areas/Admin/Views/Workshop/Create.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42501eb54246ce56ccc156a4a06f8bcbf615a9a7", @"/Areas/Admin/Views/Workshop/Create.cshtml")]
    public class Areas_Admin_Views_Workshop_Create : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Siit_Conference.Models.WorkshopDto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\User\source\repos\Siit-Conference\Siit-Conference\Areas\Admin\Views\Workshop\Create.cshtml"
  
    ViewData["Title"] = "Create";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Create</h1>\r\n\r\n<h4>WorkshopDto</h4>\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-4\">\r\n        <form asp-action=\"Create\">\r\n            <div asp-validation-summary=\"ModelOnly\" class=\"text-danger\"></div>\r\n");
            WriteLiteral(@"            <div class=""form-group"">
                <label asp-for=""Name"" class=""control-label""></label>
                <input asp-for=""Name"" class=""form-control"" />
                <span asp-validation-for=""Name"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""Description"" class=""control-label""></label>
                <input asp-for=""Description"" class=""form-control"" />
                <span asp-validation-for=""Description"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""PlacesAvailable"" class=""control-label""></label>
                <input asp-for=""PlacesAvailable"" class=""form-control"" />
                <span asp-validation-for=""PlacesAvailable"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""RegistrationLink"" class=""control-label""></label>
                <input asp-for=""RegistrationLi");
            WriteLiteral(@"nk"" class=""form-control"" />
                <span asp-validation-for=""RegistrationLink"" class=""text-danger""></span>
            </div>
            <div class=""form-group form-check"">
                <label class=""form-check-label"">
                    <input class=""form-check-input"" asp-for=""Active"" /> ");
#nullable restore
#line 42 "C:\Users\User\source\repos\Siit-Conference\Siit-Conference\Areas\Admin\Views\Workshop\Create.cshtml"
                                                                   Write(Html.DisplayNameFor(model => model.Active));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </label>\r\n            </div>\r\n            <div class=\"form-group form-check\">\r\n                <label class=\"form-check-label\">\r\n                    <input class=\"form-check-input\" asp-for=\"RegistrationOpened\" /> ");
#nullable restore
#line 47 "C:\Users\User\source\repos\Siit-Conference\Siit-Conference\Areas\Admin\Views\Workshop\Create.cshtml"
                                                                               Write(Html.DisplayNameFor(model => model.RegistrationOpened));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </label>
            </div>
            <div class=""form-group"">
                <label asp-for=""Prerequisites"" class=""control-label""></label>
                <input asp-for=""Prerequisites"" class=""form-control"" />
                <span asp-validation-for=""Prerequisites"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <label asp-for=""ShortDescription"" class=""control-label""></label>
                <input asp-for=""ShortDescription"" class=""form-control"" />
                <span asp-validation-for=""ShortDescription"" class=""text-danger""></span>
            </div>
            <div class=""form-group"">
                <input type=""submit"" value=""Create"" class=""btn btn-primary"" />
            </div>
        </form>
    </div>
</div>

<div>
    <a asp-action=""Index"">Back to List</a>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 72 "C:\Users\User\source\repos\Siit-Conference\Siit-Conference\Areas\Admin\Views\Workshop\Create.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Siit_Conference.Models.WorkshopDto> Html { get; private set; }
    }
}
#pragma warning restore 1591
