#pragma checksum "D:\code\实训项目\.Net_Core\PastryMS\UI\Areas\Admin\Views\StaffInfo\UpdateStaffInfoView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_StaffInfo_UpdateStaffInfoView), @"mvc.1.0.view", @"/Areas/Admin/Views/StaffInfo/UpdateStaffInfoView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d24c59aeab1fb34b502b1bb572c7f4a9a6fddee8", @"/Areas/Admin/Views/StaffInfo/UpdateStaffInfoView.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_StaffInfo_UpdateStaffInfoView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/lib/layui-v2.6.3/css/layui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("media", new global::Microsoft.AspNetCore.Html.HtmlString("all"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/css/public.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/layuimini/lib/layui-v2.6.3/layui.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("charset", new global::Microsoft.AspNetCore.Html.HtmlString("utf-8"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\code\实训项目\.Net_Core\PastryMS\UI\Areas\Admin\Views\StaffInfo\UpdateStaffInfoView.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee85437", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee85970", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee87236", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <style>\r\n        body {\r\n            background-color: #ffffff;\r\n        }\r\n    </style>\r\n");
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
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee89310", async() => {
                WriteLiteral("\r\n    <div class=\"layui-form layuimini-form\" lay-filter=\"formTest\">\r\n\t\t<div class=\"layui-form-item\">\r\n\t\t\t<label class=\"layui-form-label \">用户账号</label>\r\n\t\t\t<div class=\"layui-input-block\">\r\n\t\t\t\t<input type=\"text\" readonly name=\"account\"");
                BeginWriteAttribute("value", " value=\"", 831, "\"", 839, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
			</div>
		</div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label required"">员工姓名</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""staffName"" lay-verify=""required"" lay-reqtext=""姓名不能为空"" placeholder=""请输入姓名""");
                BeginWriteAttribute("value", " value=\"", 1149, "\"", 1157, 0);
                EndWriteAttribute();
                WriteLiteral(" class=\"layui-input\">\r\n            </div>\r\n        </div>\r\n\t\t<div class=\"layui-form-item\">\r\n\t\t\t<label class=\"layui-form-label \">用户密码</label>\r\n\t\t\t<div class=\"layui-input-block\">\r\n\t\t\t\t<input type=\"text\" name=\"pwd\"");
                BeginWriteAttribute("value", " value=\"", 1369, "\"", 1377, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
			</div>
		</div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label "">描述</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""description"" placeholder=""请输入描述""");
                BeginWriteAttribute("value", " value=\"", 1636, "\"", 1644, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label"">主管Id</label>
            <div class=""layui-input-block"">
                <select name=""leaderId"" id=""parentSelect"">
                    <option");
                BeginWriteAttribute("value", " value=\"", 1933, "\"", 1941, 0);
                EndWriteAttribute();
                WriteLiteral(@"></option>
                </select>
            </div>
        </div>
        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">确认保存</button>
            </div>
        </div>
    </div>
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d24c59aeab1fb34b502b1bb572c7f4a9a6fddee812077", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
		//
		var parentData;
		let form;
		//获取父级页面的回调方法
		function getData(data) {
			parentData = data;
			console.log(""父级传递的数据"", parentData);
			//使用form表单模块赋值
			form.val(""formTest"", {
				""account"": parentData.account,
				""pwd"": """",
				""staffName"": parentData.staffName,
				""leaderId"": parentData.leaderId,
				""description"": parentData.description,
				""sex"": parentData.sex,
			});
		}

		layui.use(['form'], function () {
			var layer = layui.layer,
				$ = layui.$;

			form = layui.form;

			//获取列表页面传递的Id
			var id = window.location.search.substr(4);
			//console.log(id);


			//通过Ajax去获取下拉列表数据进行渲染
			$.ajax({
                url: '/Admin/StaffInfo/GetSelectOptions',
				type: ""get"",
				success: function (res) {
					console.log(""接口返回的结果"", res);
					//父级部门数据
					var parentSelect = res.data.parentSelect;
					for (var i = 0; i < parentSelect.length; i++) {
						$(""#parentSelect"").append('<option value=""' + parentSelect[i].value + '"">' + parentSelect[i");
                WriteLiteral(@"].title + '</option>');
					}
					//调用form重写渲染select
					form.render('select');

					//绑定编辑的表单信息
					form.val(""formTest"", {
						""departmentId"": parentData.departmentId,

					});
				}
			});

			//监听提交
			form.on('submit(saveBtn)', function (data) {
				data.field.id = parentData.id;//赋值id

				//$.ajax
				$.ajax({
                    url: '/Admin/StaffInfo/UpdateStaffInfo',
					type: 'Post',
					data: data.field,
					success: function (res) {
						if (res.code == 200) {
							var index = layer.alert(res.msg, {
								title: '修改结果',
							}, function () {

								// 关闭弹出层
								layer.close(index);

								var iframeIndex = parent.layer.getFrameIndex(window.name);
								parent.layer.close(iframeIndex);
								parent.location.reload();//重载
							});

						} else {
							layer.alert(res.msg);
						}
					}
				});

				return false;
			});

		});
    </script>
");
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
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
