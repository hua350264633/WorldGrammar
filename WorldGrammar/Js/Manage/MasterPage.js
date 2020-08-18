//窗体加载完成事件
window.onload = function () {
    //当前用户
    $("#curUser").text($.cookie('NickName'));
    //窗体加载
    PostData("/Ashx/MasterPage.ashx", { typeClass: "LoadMenu" }, function (data) {
        if (data.Code == 400) {
            alert(data.Msg);
            window.location.href = data.Data;
            return;
        }
        if (data.Code == 200) {
            //加载菜单处理
            LoadMenu(data.Rows);
        } else {
            AlertMsg(data.Msg, "err");
        }
    });
};

/*
*退出系统
*/
function LoginOut()
{
    PostData("/Ashx/Login.ashx?typeClass=LoginOut", null, function (data) {
        if (data.Code == 200) {
            window.location.href = data.Data;
        } else {
            AlertMsg(data.Msg, "err");
        }
    });
}

/*
*显示修改密码面板
*/
function ShowChangePwd() {
    //弹出面板
    $('#Modal_ChangePwd').modal({
        keyboard: true
    });
}

/*
*修改密码
*/
function ChangePwd() {
    var options = {
        message: '值验证未通过',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            LoginPwd: {
                validators: {
                    notEmpty: {
                        message: '密码不能为空'
                    },
                    stringLength: {
                        min: 5,
                        max: 20,
                        message: '密码长度在5-20个字符之间'
                    },
                    identical: {
                        field: 'ConfirmPassword',
                        message: '两次输入的密码不一致'
                    }
                }
            },
            ConfirmPassword: {
                validators: {
                    notEmpty: {
                        message: '重复密码不能为空'
                    },
                    identical: {
                        field: 'LoginPwd',
                        message: '两次输入的密码不一致'
                    }
                }
            }
        }
    };
    $("#form_ChangePwd").bootstrapValidator(options).bootstrapValidator('validate');
    var valided = $("#form_ChangePwd").data('bootstrapValidator').isValid();  //验证表单必须调用上面一行代码
    if (valided) {
        CommitForm("form_ChangePwd", "../../Ashx/User.ashx?typeClass=ChangePwd", "post", function (data) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            if (data.Code === 200) {                
                AlertMsg(data.Msg, "info");
                $("#form_ChangePwd").bootstrapValidator(options).data('bootstrapValidator').resetForm();
                $('#Modal_ChangePwd').modal('hide')
            }
        });
    }
}

/*
*加载菜单
*data：菜单数据
*/
function LoadMenu(data)
{
    if (!data) {
        return;
    }
    for (var i = 0; i < data.length; i++)
    {
        if (data[i].ParentCode === "0")
        {
            var filterarray = $.grep(data, function (value,index) {
                return value.ParentCode === data[i].MenuCode;
            });

            var rootHTML;
            if (filterarray.length > 0)
            {
                rootHTML = "<li data-menuCode=\"" + data[i].MenuCode + "\"><span><i class=\"glyphicon glyphicon-folder-open\"></i>" + data[i].MenuName + "</span><ul></ul></li>";
            }
            else
            {
                rootHTML = "<li data-menuCode=\"" + data[i].MenuCode + "\"><span><i class=\"glyphicon glyphicon-leaf\"></i><a href=\"" + data[i].URL + "\">" + data[i].MenuName + "</a></span></li>";
            }

            $("#treeBox > ul").append(rootHTML);
            DG(data[i], data);
        }
    }
    BindMenu();
}

/*
*递归创建菜单
*/
function DG(root, data)
{
    var filterarray;
    var childHTML;
    for (var i = 0; i < data.length; i++)
    {
        if (data[i].ParentCode === root.MenuCode)
        {
            var filterarray = $.grep(data, function (value, index) {
                return value.ParentCode === data[i].MenuCode;
            });
            if (filterarray.length > 0) {
                childHTML = "<li data-menuCode=\"" + data[i].MenuCode + "\"><span><i class=\"glyphicon glyphicon-folder-open\"></i>" + data[i].MenuName + "</span><ul></ul></li>";
            }
            else {
                childHTML = "<li data-menuCode=\"" + data[i].MenuCode + "\"><span><i class=\"glyphicon glyphicon-leaf\"></i><a href=\""+data[i].URL+"\">" + data[i].MenuName + "</a></span></li>";
            }
            $("#treeBox").find("li[data-menuCode='" + root.MenuCode + "'] > ul").append(childHTML);
            DG(data[i], data);
        }
    }
}