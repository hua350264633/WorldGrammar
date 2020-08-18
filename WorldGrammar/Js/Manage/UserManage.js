//*********************全局变量——开始***********************
var CurrentPage = 1;  //默认第几页
var PageSize = 5;     //默认一页显示多少条数据
var TotalRecord = 0;  //返回数据总数
var TotalPage = 0;    //总共页码
var Where = "";       //条件
var $table =  $('#table');  //表格对象
//*********************全局变量——结束***********************
$(document).ready(function () {
    InitTable(CurrentPage, PageSize, Where);
});

/*
*初始化分页插件
*/
function InitPage() {
    var element = $('#pagePlaug');
    var options = {
        bootstrapMajorVersion: 3,
        currentPage: CurrentPage,
        numberOfPages: 5,
        totalPages: TotalPage,
        onPageClicked: function (event, originalEvent, type, page) {
            CurrentPage = page;
            InitTable(CurrentPage, PageSize, Where);
        }
    }

    element.bootstrapPaginator(options);
}

var loaded = false;
/*
*初始化表格
*CurrentPage：当前页码
*PageSize：每页数据条数
*Where:查询条件
*/
function InitTable(CurrentPage, PageSize, Where)
{   
    PostData("../../Ashx/User.ashx", { typeClass: "GetPageData", CurrentPage: CurrentPage, PageSize: PageSize, Where: Where }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        TotalRecord = returnData.Total;
        TotalPage = parseInt(TotalRecord / PageSize) + (TotalRecord % PageSize > 0 ? 1 : 0);

        if (!loaded) {
            loaded = true;
            $table.bootstrapTable({
                height: 380,
                pagination: true,
                cache: false,
                pageList: [30, 50, 100],
                search: true,
                data: returnData.Rows,
                uniqueId: "LoginName",
                columns: [{
                    field: 'LoginName',
                    title: '登录名',
                    valign: "middle",
                    align: "center",
                    width: "150"
                }, {
                    field: 'NickName',
                    title: '昵称',
                    valign: "middle",
                    align: "center",
                    width: "150"
                }, {
                    field: 'Sex',
                    title: '性别',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        if (value) {
                            return "男";
                        } else {
                            return "女";
                        }
                    },
                    align: "center",
                    width: "80"
                }, {
                    field: 'Birthday',
                    title: '出生日期',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        return FormatDate(new Date(value), "1");
                    },
                    align: "center",
                    width: "120"
                }, {
                    field: 'PlaceBirth',
                    title: '出生地',
                    valign: "middle",
                    align: "center",
                    width: "200"
                }, {
                    field: 'PhoneNumber',
                    title: '手机号码',
                    valign: "middle",
                    align: "center",
                    width: "100"
                }, {
                    field: 'IsEnabled',
                    title: '是否启用',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        if (value) {
                            return '<span class="label label-success">启用</span>';
                        } else {
                            return '<span class="label label-danger">禁用</span>';
                        }
                    },
                    align: "center",
                    width: "100"
                }, {
                    title: '操作',
                    formatter: function (value, row, index) {
                        return '<button type="button" class="btn btn-primary" onclick="ShowEdit(\'' + row.LoginName + '\')"><span class="glyphicon glyphicon-edit"></span></button>&nbsp;' +
                               '<button type="button" class="btn btn-danger" onclick="DelUser(\'' + row.LoginName + '\')"><span class="glyphicon glyphicon-remove"></span></button>&nbsp;' +
                               '<button type="button" class="btn btn-warning" onclick="ResetPwd(\'' + row.LoginName + '\')"><span class="glyphicon glyphicon-lock"></span></button>';
                    },
                    align: "center",
                    width: "200"
                }]
            });
        } else {
            $table.bootstrapTable('load', returnData.Rows);
        }
        
        if (TotalPage > 0) {
            InitPage();
        }
    });
}

/*
*拼接查询条件
*/
function Search()
{
    Where = " 1 = 1 ";
    var NickName = $("#P_NickName").val();
    var PhoneNumber = $("#P_PhoneNumber").val();
    if (NickName !== "") {
        Where += " and NickName like '%" + NickName + "%'";
    }
    if (PhoneNumber !== "") {
        Where += " and PhoneNumber like '%" + PhoneNumber + "%'";
    }
    InitTable(CurrentPage, PageSize, Where);
}

/*
*删除
*loginName：用户登录名
*/
function DelUser(loginName) {
    if (loginName === undefined) {
        return;
    }
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/User.ashx", { typeClass: "DelUser", LoginName: loginName }, function (returnData) {
                if (returnData.Code != 200) {
                    AlertMsg(returnData.Msg, "err");
                    return;
                }
                AlertMsg(returnData.Msg, "info");
                InitTable(CurrentPage, PageSize, Where);
            });
        }
    })
}

/*
*修改用户
*loginName：用户登录名
*/
function ShowEdit(loginName) {
    var row = $table.bootstrapTable('getRowByUniqueId', loginName)
    if (row === undefined) {
        AlertMsg(loginName + "对应的数据为undefined", "info");
        return;
    }

    //给输入框赋值
    $("#LoginName").val(row.LoginName);
    $("#NickName").val(row.NickName);
    $("#Birthday").val(row.Birthday);
    $('#datetimepicker').val(FormatDate(new Date(row.Birthday), "1"));
    $("#PlaceBirth").val(row.PlaceBirth);
    $("#PhoneNumber").val(row.PhoneNumber);
    if (row.Sex) {
        $("#SexNan").attr("checked", "checked");
    } else {
        $("#SexNv").attr("checked", "checked");
    }
    $("#IsEnabled").attr("checked",row.IsEnabled);
    //弹出面板
    $('#Modal_Edit').modal({
        keyboard: true
    });
}

/*
*提交修改内容
*/
function EditUser()
{
    //获取输入框的值
    var row = new Object();
    row.typeClass = "EditUser";
    row.LoginName = $("#LoginName").val();
    row.NickName = $("#NickName").val();
    row.Birthday = $("#Birthday").val();
    row.PlaceBirth = $("#PlaceBirth").val();
    row.PhoneNumber = $("#PhoneNumber").val();
    row.Sex = $("input[name='Sex']:checked").val() === "1" ? true : false;
    row.IsEnabled = $("input[type='checkbox']:checked").val() === "on" ? true : false;
    //验证输入内容
    if (row.NickName === "") {
        AlertMsg("昵称不能为空,请输入后重试", "err");
        $("#NickName").focus();
        return;
    }
    if (row.Birthday === "") {
        AlertMsg("出生日期不能为空,请输入后重试", "err");
        $("#Birthday").focus();
        return;
    }
    if (row.PlaceBirth === "") {
        AlertMsg("出生地不能为空,请输入后重试", "err");
        $("#PlaceBirth").focus();
        return;
    }
    if (row.PhoneNumber === "") {
        AlertMsg("手机号码不能为空,请输入后重试", "err");
        $("#PhoneNumber").focus();
        return;
    }
    //提交数据到后台
    PostData("../../Ashx/User.ashx", row, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        InitTable(CurrentPage, PageSize, Where);
        $('#Modal_Edit').modal('hide')
    });
}

/*
*重置密码
loginName：登录名
*/
function ResetPwd(loginName) {
    if (loginName === undefined) {
        return;
    }
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/User.ashx", { typeClass: "ResetPwd", LoginName: loginName }, function (returnData) {
                if (returnData.Code != 200) {
                    AlertMsg(returnData.Msg, "err");
                    return;
                }
                AlertMsg(returnData.Msg, "info");
            });
        }
    }, "郑重提示", "确定要重置《" + loginName + "》的密码吗？")
}