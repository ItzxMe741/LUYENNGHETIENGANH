#pragma checksum "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tracks_Index), @"mvc.1.0.view", @"/Views/Tracks/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\LWEnglishPractice\LWEnglishPractice\Views\_ViewImports.cshtml"
using LWEnglishPractice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\LWEnglishPractice\LWEnglishPractice\Views\_ViewImports.cshtml"
using LWEnglishPractice.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
using LWEnglishPractice.Entities;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b2", @"/Views/Tracks/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA256", @"802a8fccb9d5ac5e1446aac7f1af72ae5d8961a9e0f0f4ebc1d7c4ddb81dd93c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Tracks_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<LWEnglishPractice.Entities.Track>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateOrEdit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tracks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return onSubmitForm()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("SourceEdit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(" "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-append-version", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("formDelete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Js/AudioList.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
  
    ListenAndWriteContext context = new ListenAndWriteContext();
    List<Lesson> lesson = context.Lesson.Where(a => a.Active == 1).ToList();

#line default
#line hidden
#nullable disable
            WriteLiteral("<style>\r\n    audio::-webkit-media-controls-play-button {\r\n        display: block;\r\n    }\r\n</style>\r\n<div");
            BeginWriteAttribute("class", " class=\"", 345, "\"", 353, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b28116", async() => {
                WriteLiteral(@"
        <input id=""action"" type=""hidden"" name=""action"" />
        <input id=""Idtrack"" type=""hidden"" name=""Idtrack"" />
        <div class=""bg-light p-1 border border-secondary rounded"">
            <h2>Tracks Management</h2>

            <div class=""row"">
                <div class=""col-md-6 col-sm-12"">
                    <div class=""row d-flex align-items-center"">
                        <div class=""col-md-2 col-sm-12"">
                            Lesson
                        </div>
                        <div class=""col-md-10 col-sm-12"">
                            <select id=""multipleSelect"" name=""Idlesson"" class=""Idlesson"" data-search=""true""
                                    data-silent-initial-value-set=""true"">
");
#nullable restore
#line 29 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                 foreach (var item in lesson)
                                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b29491", async() => {
#nullable restore
#line 31 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                                              Write(item.Lessonanme);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 31 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                       WriteLiteral(item.Idlesson);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 32 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                            </select>

                        </div>
                    </div>
                </div>
                <div class=""col-md-6 col-sm-12"">
                    <div class=""row d-flex align-items-center"">
                        <div class=""col-md-2 col-sm-12"">
                            Track Name
                        </div>
                        <div class=""col-md-10 col-sm-12"">
                            <input name=""Trackname"" id=""Trackname"" maxlength=""255""  onfocus=""this.value=''""  type=""number"" class=""form-control""/>
                            <span id=""checkTrackname"" class=""text-danger""></span>

                        </div>
                    </div>
                </div>


            </div>
            <div class=""row mt-2"">
                <div class=""col-md-6 col-sm-12"">
                    <div class=""row d-flex align-items-center"">

                        <div class=""col-md-2 col-sm-12"">
                            Audio
       ");
                WriteLiteral(@"                 </div>
                        <div class=""col-md-10 col-sm-12"">
                            <audio controls class=""w-100 p-2"" id=""audio"">
                                <source id=""ShowSource"" src=""#"" class="" "" asp-append-version=""true"" />
                            </audio>

                        </div>
                    </div>
                </div>
                <div class=""col-md-6 col-sm-12"">
                    <div class=""row d-flex align-items-center"">
                        <div class=""col-md-2 col-sm-12"">
                            Describe
                        </div>
                        <div class=""col-md-10 col-sm-12"">
                            <textarea name=""Describe"" id=""Describe""  type=""text"" style=""height:14px"" class=""form-control""></textarea>
                            <span id=""checkDescribe"" class=""text-danger""></span>
                        </div>
                    </div>
                </div>



            </div>
        ");
                WriteLiteral(@"    <div class=""row"">
                <div class=""col-md-4 col-sm-12"">
                    <div class=""row d-flex align-items-center"">

                        <div class=""col-md-3 col-sm-12"">
                            Source
                        </div>
                        <div class=""col-md-9 col-sm-12"">
                            <input name=""Source"" id=""Source"" type='file' class=""form-control"" />

                            <span id=""checkSource"" class=""text-danger""></span>
                        </div>

                    </div>
                </div>
                <div class=""col-md-2 col-sm-12 "">
                    <div class=""row d-flex align-items-center"">

                        <div class=""col-md-4 col-sm-12"">
                            Duration(s)
                        </div>
                        <div class=""col-md-8 col-sm-12"">
                            <input name=""Duration"" id=""Duration"" onfocus=""this.value=''""  maxlength=""255"" type=""text"" class=""fo");
                WriteLiteral(@"rm-control"">
                           
                            <span id=""checkDuration"" class=""text-danger""></span>
                        </div>
                    </div>
                </div>
                <div class=""col-md-3 col-sm-12"">
                    <div class=""row d-flex align-items-center"">


                        <div class=""col-md-4 col-sm-12"">
                            Date Upload
                        </div>
                        <div class=""col-md-8 col-sm-12"">
                            <input type=""date"" id=""Dateupload"" disabled name=""Dateupload"" maxlength=""255""
                                   class=""form-control"">
                            <span class=""text-danger""></span>

                        </div>
                    </div>
                </div>

                <div class=""col-md-3 col-sm-12 "">
                    <button type=""submit"" style=""float: right;"" class=""btn btn-primary w-100"" id=""btnAdd"">Thêm</button>
                   ");
                WriteLiteral(@" <div class=""d-flex"">
                        <button type=""button"" style=""display:none;"" class=""btn btn-light w-50"" id=""btnCancel"">Hủy</button>
                        <button type=""submit"" class=""btn btn-primary w-50"" onclick=""onEdit()"" id=""btnUpdate"" style=""display:none; float: right;"">
                            Cập
                            nhật
                        </button>
                    </div>
                </div>
            </div>

        </div>

    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

</div>
<div class=""x_content"">
    <div class=""row"">
        <div class=""col-sm-12"" style=""height:60vh;overflow-y:scroll"">
            <div class=""card-box table-responsive"">


                <table id=""datatable-responsive"" class=""table table-striped table-bordered dt-responsive nowrap""
                       cellspacing=""0"" width=""100%"">
                    <thead>
                        <tr class=""text-center"">
                            <th>Lesson Name</th>
                            <th>Track Name</th>
                            <th>Describe</th>
                            <th>Source</th>
                            <th>Duration</th>
                            <th>Date Upload</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr class=""d-none"">
                            <td>.</td>
                            <td>.</td>
                            <td>.</td>
       ");
            WriteLiteral("                     <td>.</td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 172 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                         foreach (var item in Model)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 175 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                               Write(item.IdlessonNavigation.Lessonanme);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 176 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                               Write(item.Trackname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 177 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                               Write(item.Describe);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td style=\"width:200px\">\r\n\r\n                                    <audio controls class=\"w-100 p-2\">\r\n                                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("source", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b220720", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 7664, "~/Images/", 7664, 9, true);
#nullable restore
#line 181 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
AddHtmlAttributeValue("", 7673, item.Source, 7673, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    </audio>\r\n                                </td>\r\n");
#nullable restore
#line 184 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                  
                                    string minutes = (@item.Duration / 60)+"m"; // minute
                                    string remainingSeconds = (@item.Duration % 60)+"s"; //second
                                

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-center\">");
#nullable restore
#line 188 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                                   Write(minutes);

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 188 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                                              Write(remainingSeconds);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 189 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                               Write(item.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 190 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                 if (item.Dateupload != null)
                                {
                                    DateTime Dateupload = (DateTime)item.Dateupload;

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>");
#nullable restore
#line 193 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                   Write(Dateupload.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    <td class=\"d-none\">");
#nullable restore
#line 194 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                                  Write(Dateupload.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 195 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td></td>\r\n                                    <td></td>\r\n");
#nullable restore
#line 200 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"d-none\">");
#nullable restore
#line 201 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                              Write(item.Idlesson);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td class=\"d-none\">");
#nullable restore
#line 202 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                              Write(item.Idtrack);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n\r\n                                <td class=\"table-td-center d-flex\">\r\n                                    <a class=\"btn  btn-sm btn-warning \" onclick=\"onEdit(this)\"><i class=\"fas fa-edit text-white\"></i></a>\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b226433", async() => {
                WriteLiteral("\r\n                                        <button type=\"submit\" class=\"btn  btn-sm btn-danger \"><i class=\"fas fa-trash text-white\"></i></button>\r\n                                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 207 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                                                                                   WriteLiteral(item.Idtrack);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 213 "D:\LWEnglishPractice\LWEnglishPractice\Views\Tracks\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </tbody>
                </table>

            </div>
        </div>
    </div>

</div>

<script>
    let deleteBtns = document.querySelectorAll('.formDelete');
    deleteBtns.forEach(function (deleteBtn) {
        deleteBtn.addEventListener('submit', function (e) {

            var form = this;

            e.preventDefault();

            swal({
                title: 'Bạn có chắc chắn muốn xóa?',

                icon: 'warning',
                buttons: ['Hủy bỏ!', 'Xác nhận'],
                dangerMode: true,
            }).then(function (isConfirm) {
                if (isConfirm) {

                    form.submit();
                    swal({
                        title: 'Đã xóa!',
                        icon: 'success',
                        timer: 1500,
                        button: false,
                    });

                } else {
                    swal({
                        title: 'Đã hủy!',
                        bu");
            WriteLiteral(@"tton: false,
                        icon: 'error',
                        timer: 500,
                    });
                }
            });
        });
    })



    function onSubmitForm() {
        let isSubmit = false;
        let checkDescribe = document.getElementById(""checkDescribe"");
        let checkTrackname = document.getElementById(""checkTrackname"");
        let checkDuration = document.getElementById(""checkDuration"");
        let checkSource = document.getElementById(""checkSource"");
        let Trackname = document.getElementById(""Trackname"").value;
        let Describe = document.getElementById(""Describe"").value;
        let Source = document.getElementById(""Source"").value;
        let Duration = document.getElementById(""Duration"").value;

        let errorMessage = ""Vui lòng cung cấp thông tin!"";

        if (Duration.length == 0 && Duration <= 0) {
            checkDuration.innerText = errorMessage;

        }
        if (Source.length == 0) {
            chec");
            WriteLiteral(@"kSource.innerText = errorMessage;

        }
        if (Describe.length == 0) {
            checkDescribe.innerText = errorMessage;

        }
        if (Trackname.length == 0) {
            checkTrackname.innerText = errorMessage;

        }
        else {
            isSubmit = true;
        }
        return isSubmit;
    }


    let btnAdd = document.getElementById(""btnAdd"");
    let btnUpdate = document.getElementById(""btnUpdate"");
    let btnCancel = document.getElementById(""btnCancel"");
    let action = document.getElementById(""action"");

    btnCancel.addEventListener(""click"", function () {
        btnUpdate.style.display = ""none"";
        btnCancel.style.display = ""none"";
        btnAdd.style.display = ""block"";
        document.getElementById(""Dateupload"").disabled = true;
    })


    btnAdd.addEventListener(""click"", function () {
        action.value = ""addItem"";
    })
    btnUpdate.addEventListener(""click"", function () {
        action.value = ""editItem"";

  ");
            WriteLiteral(@"  })


    
</script>
<script>
    const audioInput = document.getElementById('Source');
    const audioSource = document.getElementById('ShowSource');
    const audio = document.getElementById('audio');
    let timeout;
    audioInput.addEventListener('change', function () {
        const file = this.files[0];
        const objectURL = URL.createObjectURL(file);
        audioSource.src = objectURL;
        audio.load();
        clearTimeout(timeout);
        timeout = setTimeout(() => {
            document.getElementById(""Duration"").value = Math.round(document.getElementById('audio').duration);

        }, 500);
    });

</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "77fc96ede9a1b224f56e79ed070921bab153e9e186c002a6f885f8977c8f41b233551", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<LWEnglishPractice.Entities.Track>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
