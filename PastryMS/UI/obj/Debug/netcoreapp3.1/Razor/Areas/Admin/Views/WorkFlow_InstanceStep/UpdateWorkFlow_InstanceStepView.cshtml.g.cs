#pragma checksum "D:\code\实训项目\.Net_Core\PastryMS\UI\Areas\Admin\Views\WorkFlow_InstanceStep\UpdateWorkFlow_InstanceStepView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b7cb019fda86077b0b0699e719dabd5c4eadae47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_WorkFlow_InstanceStep_UpdateWorkFlow_InstanceStepView), @"mvc.1.0.view", @"/Areas/Admin/Views/WorkFlow_InstanceStep/UpdateWorkFlow_InstanceStepView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b7cb019fda86077b0b0699e719dabd5c4eadae47", @"/Areas/Admin/Views/WorkFlow_InstanceStep/UpdateWorkFlow_InstanceStepView.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_WorkFlow_InstanceStep_UpdateWorkFlow_InstanceStepView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7cb019fda86077b0b0699e719dabd5c4eadae473015", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    <link rel=""stylesheet"" href=""../layuimini/lib/layui-v2.6.3/css/layui.css"" media=""all"">
    <link rel=""stylesheet"" href=""../layuimini/css/public.css"" media=""all"">
    <style>
        body {
            background-color: #ffffff;
        }
    </style>
");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b7cb019fda86077b0b0699e719dabd5c4eadae474526", async() => {
                WriteLiteral(@"
    <div class=""layui-form layuimini-form"" lay-filter=""formTest"">
        <div class=""layui-form-item"">
            <label class=""layui-form-label "">申请人</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""userName"" readonly");
                BeginWriteAttribute("value", " value=\"", 842, "\"", 850, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label "">申请物品</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""consumableName"" readonly");
                BeginWriteAttribute("value", " value=\"", 1118, "\"", 1126, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label "">申请数量</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""outNum"" readonly");
                BeginWriteAttribute("value", " value=\"", 1386, "\"", 1394, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <label class=""layui-form-label "">申请理由</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""reason"" readonly");
                BeginWriteAttribute("value", " value=\"", 1654, "\"", 1662, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>
        <div class=""layui-form-item reviewer"">
            <label class=""layui-form-label "">审核意见</label>
            <div class=""layui-input-block"">
                <input type=""text"" name=""reviewReason""");
                BeginWriteAttribute("value", " value=\"", 1928, "\"", 1936, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""layui-input"">
            </div>
        </div>

        <div class=""layui-form-item reviewer"">
            <label class=""layui-form-label "">审核状态</label>
            <div class=""layui-input-block"">
                <input type=""radio"" name=""reviewStatus"" value=""2"" title=""同意""");
                BeginWriteAttribute("checked", " checked=\"", 2226, "\"", 2236, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                <input type=""radio"" name=""reviewStatus"" value=""3"" title=""驳回"">
            </div>
        </div>
        <div class=""layui-form-item"">
            <div class=""layui-input-block"">
                <button class=""layui-btn layui-btn-normal"" lay-submit lay-filter=""saveBtn"">确认保存</button>
            </div>
        </div>
    </div>
    <script src=""../layuimini/lib/layui-v2.6.3/layui.js"" charset=""utf-8""></script>
    <script>
        var parentData;
        var form;
        var $;
        function getData(Data) {
            parentData = Data;

            form.val('formTest', {
                ""userName"": parentData.userName,
                ""outNum"": parentData.outNum,
                ""reason"": parentData.reason,
                ""reviewReason"": parentData.reviewReason,
                ""consumableName"": parentData.consumableName,
            })

            if (parentData.creatorId == getCookie('UserId')) {
                $('.reviewer').hide()
                $('inpu");
                WriteLiteral(@"t[name=outNum]').attr('readonly', false)
            }
        }


        layui.use(['form'], function () {
            var layer = layui.layer;
            $ = layui.$;
            form = layui.form;


            var id = window.location.search.substr(4);


            //监听提交
            form.on('submit(saveBtn)', function (data) {
                data.field.id = parentData.id;
                $.ajax({
                    url: ""/Admin/WorkFlow_InstanceStep/UpdateWorkFlow_InstanceStep"",
                    type: ""Post"",
                    data: data.field,
                    success: function (res) {
                        if (res.code == 200) {
                            var index = layer.alert(res.msg, {
                                title: '修改结果'
                            }, function () {
                                // 关闭弹出层
                                layer.close(index)
                                var iframeIndex = parent.layer.getFrameIndex(window.name);");
                WriteLiteral(@"
                                parent.layer.close(iframeIndex);
                                parent.location.reload();
                            });

                        }
                        else {
                            layer.alert(res.msg);
                        }
                    }
                })


                return false;
            });

        });
        function getCookie(cookieName) {
            const strCookie = document.cookie
            const cookieList = strCookie.split(';')
            for (let i = 0; i < cookieList.length; i++) {
                const arr = cookieList[i].split('=')
                if (cookieName === arr[0].trim()) {
                    return arr[1]
                }
            }
            return ''
        }
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
            WriteLiteral("\r\n</html>");
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
