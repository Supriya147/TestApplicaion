#pragma checksum "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "09fc88d9253b1eabff2d2d2d49461b90f1aef1b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Test_EmployeeList), @"mvc.1.0.view", @"/Views/Test/EmployeeList.cshtml")]
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
#line 1 "D:\Test\TestApplication\TestApplication\Views\_ViewImports.cshtml"
using TestApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Test\TestApplication\TestApplication\Views\_ViewImports.cshtml"
using TestApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"09fc88d9253b1eabff2d2d2d49461b90f1aef1b1", @"/Views/Test/EmployeeList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c18df14659d9ffcf730f540f4c694666d270b7cb", @"/Views/_ViewImports.cshtml")]
    public class Views_Test_EmployeeList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestApplication.ViewModel.EmployeeViewModelList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
Write(Html.Hidden("DeleteEmployee", Url.Action("DeleteEmployee", "Test")));

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""app-main__inner"">
    <div class=""app-page-title"">
        <div class=""page-title-wrapper"">
            <div class=""page-title-heading"">
                <div class=""page-title-icon"">
                    <i class=""pe-7s-note2 icon-gradient bg-ripe-malin"">
                    </i>
                </div>
                <div>
");
            WriteLiteral("                    EmployeeList\r\n");
            WriteLiteral(@"

                </div>
            </div>

        </div>
    </div>

    <div class=""main-card mb-3 card"">
        <div class=""card-body"">
            <div id=""Employeesdiv"">
                <div id=""Employeesa"">

                    <table id=""Employees"" class=""table"" width=""100%"">
                        <thead>
                            <tr>
                                <th>Name/Edit</th>
                                <th>Email</th>
                                <th>Designation</th>
                                <th>Action</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 42 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
                             foreach (var item in Model.EmployeeList)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("data", " data=\"", 1520, "\"", 1549, 2);
            WriteAttributeValue("", 1527, "testpara=2&Id=", 1527, 14, true);
#nullable restore
#line 46 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
WriteAttributeValue("", 1541, item.Id, 1541, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"mb-2 mr-2 btn btn-info active btnEditEmp\">\r\n                                        <span class=\"glyphicon glyphicon-edit\"></span> ");
#nullable restore
#line 47 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
                                                                                  Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </a>\r\n                                </td>\r\n                                <td>");
#nullable restore
#line 50 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
                               Write(item.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 51 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
                               Write(item.Designation);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n                                    <a");
            BeginWriteAttribute("data", " data=\"", 1986, "\"", 2015, 2);
            WriteAttributeValue("", 1993, "testpara=2&Id=", 1993, 14, true);
#nullable restore
#line 53 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
WriteAttributeValue("", 2007, item.Id, 2007, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" type=\"button\" class=\"btngrid btnDeleteEmp\">\r\n                                        <i class=\"pe-7s-trash\"></i>\r\n                                    </a>\r\n                                </td>\r\n                            </tr>\r\n");
#nullable restore
#line 58 "D:\Test\TestApplication\TestApplication\Views\Test\EmployeeList.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        </tbody>
                    </table>


                </div>
            </div>
        </div>
    </div>

</div>

<script>

    $(document).ready(function () {

        var table = $('#Employees').DataTable({
            responsive: true,
            orderCellsTop: true,
            fixedHeader: true,

            dom: 'Bfrtip',
            lengthMenu: [
                [10, 25, 50, -1],
                ['10', '25', '50', 'all']
            ],
            dom: 'lBfrtip',
            buttons: [
                'copy', 'csv', 'excel', 'pdf', 'print'
            ]
        });

        function getUrlParameter(name, uri) {
            name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
            var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
            var results = regex.exec(uri);
            return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
        }

        var EditEmpObj;
        var uriEditE");
            WriteLiteral(@"mpObj;
        $('#Employees tbody').on('click', '.btnEditEmp', function () {
            EditEmpObj = $(this);
            uriEditEmpObj = EditEmpObj[0].attributes['1'].textContent;
            uriEditEmpObj = $(this).attr('data');
            var Id = getUrlParameter(""Id"", uriEditEmpObj);
            $(""#myPartialViewContainer"").load($(""#ModifyEmp"").val() + ""?Id="" + Id);
            $(""#displayquick"").load($(""#DefaultQuick"").val());
            $('#RightSlidingWindow').removeAttr('class');
            $('#RightSlidingWindow').attr('class', 'ui-theme-settings');
            return false;
        });

        
        var DeleteClientsObj;
        var uriDeleteClientsObj;
        $('#Employees tbody').on('click', '.btnDeleteEmp', function () {
            DeleteClientsObj = $(this);  //for future use
            uriDeleteClientsObj = DeleteClientsObj[0].attributes['1'].textContent;
            uriDeleteClientsObj = $(this).attr('data');
            var Id = getUrlParameter(""Id"", uriDeleteC");
            WriteLiteral(@"lientsObj);
            var EmpViewModel = {
                ""Id"": parseInt(Id)
            };
            $.ajax({
                url: $(""#DeleteEmployee"").val(),
                type: ""Post"",
                dataType: ""json"",
                contentType: ""application/json; charset=utf-8"",
                headers: {
                    RequestVerificationToken:
                        $('input:hidden[name=""__RequestVerificationToken""]').val()
                },
                data: JSON.stringify(EmpViewModel),
                cache: false,
                success: function (result) {
                    var resultdata = JSON.parse(result);
                    if (resultdata == ""success"") {
                        showToolTip('Employee Deleted Successfully')
                        $(""#myPartialViewContainer"").load($(""#EmployeeList"").val() + ""?MenuID=1"");
                    }
                    else {
                        showToolTip(resultdata);
                        $(""#myPa");
            WriteLiteral(@"rtialViewContainer"").load($(""#EmployeeList"").val() + ""?MenuID=1"");
                    }
                },
                fail: function (response) {
                    showToolTip(""JSON Error, Document cannot be Deleted"");
                }
            });


        });

        $.ajaxSetup({
            beforeSend: function (xhr) {
                xhr.setRequestHeader(""XSRF-TOKEN"",
                    $('input:hidden[name=""__RequestVerificationToken""]').val());
            },
        });

    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestApplication.ViewModel.EmployeeViewModelList> Html { get; private set; }
    }
}
#pragma warning restore 1591
