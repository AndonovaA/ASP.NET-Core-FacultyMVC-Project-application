#pragma checksum "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "542495e0625d30239e96dc36702f4377fc52bf55"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Enrollments_CourseStudents), @"mvc.1.0.view", @"/Views/Enrollments/CourseStudents.cshtml")]
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
#line 1 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\_ViewImports.cshtml"
using FacultyMVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\_ViewImports.cshtml"
using FacultyMVC.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"542495e0625d30239e96dc36702f4377fc52bf55", @"/Views/Enrollments/CourseStudents.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"83529dd1b7828f75eed5737eb15b3d8dedc63092", @"/Views/_ViewImports.cshtml")]
    public class Views_Enrollments_CourseStudents : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<FacultyMVC.ViewModels.EnrollmentFilterViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Enrollments", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CourseStudents", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<h2>Enrolled students for ");
#nullable restore
#line 4 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                     Write(ViewData["CourseName"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "542495e0625d30239e96dc36702f4377fc52bf555011", async() => {
                WriteLiteral("\r\n    <p>\r\n        ");
#nullable restore
#line 9 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
   Write(Html.DropDownListFor(m => m.EnrollmentYear, Enumerable.Range(2010, DateTime.Now.Year - 2010 + 1).Reverse().Select(i => new SelectListItem { Text = i.ToString(), Value = i.ToString()})));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n        <input type=\"submit\" value=\"Filter\" />\r\n    </p>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].Student.Index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].Student.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 25 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].Semester));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 28 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 31 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].Grade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 34 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].SeminalUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 37 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].ProjectUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 40 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].ExamPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 43 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].SeminalPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 46 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].ProjectPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 49 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].AdditionalPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 52 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
           Write(Html.DisplayNameFor(model => model.Enrollments[0].FinishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 58 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
         foreach (var item in Model.Enrollments)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 62 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.Student.Index));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.Student.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.Semester));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 71 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.Year));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 74 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.Grade));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 77 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                     if (item.SeminalUrl != null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a");
            BeginWriteAttribute("href", " href=\"", 2769, "\"", 2825, 1);
#nullable restore
#line 79 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
WriteAttributeValue("", 2776, Url.Content("~/seminalFiles/" + item.SeminalUrl), 2776, 49, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">View</a>\r\n");
#nullable restore
#line 80 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                   Write(Html.ActionLink("Download", "DownloadFile", new { filename = item.SeminalUrl }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 80 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                                                                                                        
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 84 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProjectUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 87 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.ExamPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 90 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.SeminalPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 93 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.ProjectPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 96 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.AdditionalPoints));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 99 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
               Write(Html.DisplayFor(modelItem => item.FinishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
#nullable restore
#line 102 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                     if (item.FinishDate == null)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "542495e0625d30239e96dc36702f4377fc52bf5517719", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 104 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                                               WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 105 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 109 "C:\Users\ANE\Documents\Visual Studio 2019\source\FacultyMVC\Views\Enrollments\CourseStudents.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>


<!-- Teachers/GetCourses/TeacherId no za eden enrollment ima dva profesori pa ne moze da se znae koe kje e TeacherId
<div>
    <a asp-controller=""Teachers"" asp-action=""GetCourses"" asp-route-id="" "">Back to Courses</a>
</div>
-->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<FacultyMVC.ViewModels.EnrollmentFilterViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
