#pragma checksum "D:\code\实训项目\.Net_Core\PastryMS\UI\Areas\Admin\Views\WorkFlow_Instance\ListView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "41b0ffb2b51601fa5d57d99663ee0d6f2912879f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_WorkFlow_Instance_ListView), @"mvc.1.0.view", @"/Areas/Admin/Views/WorkFlow_Instance/ListView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"41b0ffb2b51601fa5d57d99663ee0d6f2912879f", @"/Areas/Admin/Views/WorkFlow_Instance/ListView.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_WorkFlow_Instance_ListView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
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
            WriteLiteral("<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41b0ffb2b51601fa5d57d99663ee0d6f2912879f5189", async() => {
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <title>layui</title>
    <meta name=""renderer"" content=""webkit"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge,chrome=1"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1, maximum-scale=1"">
    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "41b0ffb2b51601fa5d57d99663ee0d6f2912879f5722", async() => {
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
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "41b0ffb2b51601fa5d57d99663ee0d6f2912879f6988", async() => {
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
                WriteLiteral("\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41b0ffb2b51601fa5d57d99663ee0d6f2912879f8958", async() => {
                WriteLiteral(@"
    <div class=""layuimini-container"">
        <div class=""layuimini-main"">

            <fieldset class=""table-search-fieldset"">
                <legend>搜索信息</legend>
                <div style=""margin: 10px 10px 10px 10px"">
                    <form class=""layui-form layui-form-pane""");
                BeginWriteAttribute("action", " action=\"", 765, "\"", 774, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                        <div class=""layui-form-item"">

                            <div class=""layui-inline"">
                                <label class=""layui-form-label"">状态</label>
                                <div class=""layui-input-inline"">
                                    <input type=""text"" name=""status"" autocomplete=""off"" class=""layui-input"">
                                </div>
                            </div>
                            <div class=""layui-inline"">
                                <button type=""submit"" class=""layui-btn layui-btn-primary"" lay-submit lay-filter=""data-search-btn""><i class=""layui-icon""></i> 搜 索</button>
                            </div>
                        </div>
                    </form>
                </div>
            </fieldset>

            <script type=""text/html"" id=""toolbarDemo"">
                <div class=""layui-btn-container"">
                    <button class=""layui-btn layui-btn-normal layui-btn-sm data-add-btn"" lay-even");
                WriteLiteral("t=\"add\"> 耗材申领 </button>\r\n");
                WriteLiteral("\r\n                </div>\r\n            </script>\r\n\r\n            <table class=\"layui-hide\" id=\"currentTableId\" lay-filter=\"currentTableFilter\"></table>\r\n\r\n            <!--<script type=\"text/html\" id=\"currentTableBar\">-->\r\n");
                WriteLiteral(@"            <!--</script>-->

            <script type=""text/html"" id=""currentTableBar"">
                {{# if(d.status==1){}}
                <a class=""layui-btn layui-btn-normal layui-btn-xs data-count-edit"" lay-event=""edit"">作废</a>

                {{# }else{ }}
                <a class=""layui-font-red"">不可操作</a>
                
                {{# } }}
            </script>

            <script type=""text/html"" id=""StatusCell"">
                {{# if(d.status==1){}}
                <a class=""layui-font-orange"">审核中</a>
                {{# }else if(d.status==2){ }}
                <a class=""layui-font-green"">结束</a>
                {{# }else { }}
                <a class=""layui-font-red"">作废</a>
                {{# } }}
            </script>
        </div>
    </div>

    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "41b0ffb2b51601fa5d57d99663ee0d6f2912879f11935", async() => {
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
        layui.use(['form', 'table'], function () {
            var $ = layui.jquery,
                form = layui.form,
                table = layui.table;

            table.render({
                elem: '#currentTableId',
                url: '/Admin/WorkFlow_Instance/getWorkFlow_InstanceDTOs',
                //url: '~/layuimini/api/table.json',
                toolbar: '#toolbarDemo',
                defaultToolbar: ['filter', 'exports', 'print', {
                    title: '提示',
                    layEvent: 'LAYTABLE_TIPS',
                    icon: 'layui-icon-tips'
                }],
                cols: [[
                    { type: ""checkbox"" },
                    { field: 'id', title: 'ID', sort: true, hide: true },
                    { field: 'title', title: '工作流模板' },
                    { field: 'modelId', title: '工作流模板', hide: true },
                    { field: 'consumableName', title: '出库物资' },
                    { field: 'outNum', title: '出库数量' ");
                WriteLiteral(@"},
                    { field: 'outGoodsId', title: '出库物资', hide: true },
                    { field: 'userName', title: '申请加人' },
                    { field: 'reason', title: '申请理由' },
                    { field: 'status', title: '状态', templet: ""#StatusCell"" },
                    { field: 'creator', title: '添加人', hide: true },
                    { field: 'description', title: '描述', sort: true },
                    { field: 'createTime', title: '添加时间' },
                    { title: '操作', toolbar: '#currentTableBar', align: ""center"" }
                ]],
                limits: [10, 15, 20, 25, 50, 100],
                limit: 15,
                page: true,
                skin: 'line'
            });

            // 监听搜索操作
            form.on('submit(data-search-btn)', function (data) {
                //var result = JSON.stringify(data.field);
                //layer.alert(result, {
                //	title: '最终的搜索信息'
                //});

                执行搜索重载
            ");
                WriteLiteral(@"    table.reload('currentTableId', {
                    page: {
                        curr: 1
                    }
                    , where: {
                        /*searchParams: result*/
                        status: data.field.status
                    }
                }, 'data');

                return false;
            });

            /**
             * toolbar监听事件
             */
            table.on('toolbar(currentTableFilter)', function (obj) {
                if (obj.event === 'add') {  // 监听添加操作
                    var index = layer.open({
                        title: '发起耗材申领',
                        type: 2,
                        shade: 0.2,
                        maxmin: true,
                        shadeClose: true,
                        area: ['80%', '80%'],
                        content: '/Admin/WorkFlow_Instance/CreateWorkFlow_InstanceView',
                    });
                    $(window).on(""resize"", function () {
                ");
                WriteLiteral(@"        layer.full(index);
                    });
                }
            });

            //监听表格复选框选择
            table.on('checkbox(currentTableFilter)', function (obj) {
                console.log(obj)
            });

            table.on('tool(currentTableFilter)', function (obj) {
                var data = obj.data;
                if (obj.event === 'edit') {

                    $.ajax({
                        url: '/Admin/WorkFlow_Instance/UpdateWorkFlow_Instance',
                        type: 'post',
                        data: {
                            id: data.id
                        },
                        success: function myfunction(res) {

                            if (res.code == 200) {
                                table.reload('currentTableId', {
                                    page: {
                                        curr: 1
                                    }
                                   
                            ");
                WriteLiteral("    }, \'data\');\r\n                            }\r\n                            layer.msg(res.msg);\r\n                        }\r\n                    })\r\n                }\r\n                \r\n            });\r\n        });\r\n    </script>\r\n\r\n");
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
