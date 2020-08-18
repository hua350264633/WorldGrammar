//*********************全局变量——开始***********************
var formOptions = undefined;   //表单验证项
//*********************全局变量——结束***********************

/*
*验证并提交表单
*/
function SubmitForm() {
    formOptions = {
        message: '值验证未通过',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            LoginName: {
                message: '用户名无效',
                validators: {
                    notEmpty: {
                        message: '用户名不能为空'
                    },
                    stringLength: {
                        min: 5,
                        max: 20,
                        message: '用户名长度在5-20个字符之间'
                    },
                    regexp: {
                        regexp: /^[a-zA-Z0-9_\.]+$/,
                        message: '用户名只能有字母和数字组成'
                    }
                }
            },
            NickName: {
                validators: {
                    notEmpty: {
                        message: '昵称不能为空'
                    }
                }
            },
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
            },
            Birthday: {
                validators: {
                    notEmpty: {
                        message: '出生日期不能为空'
                    },
                    date: {
                        format: 'YYYY-MM-DD',
                        separator: '-'
                    }
                }
            },
            PlaceBirth: {
                validators: {
                    notEmpty: {
                        message: '出生地不能为空'
                    }
                }
            },
            PhoneNumber: {
                validators: {
                    notEmpty: {
                        message: '手机号码不能为空'
                    },
                    regexp: {
                        regexp: /^1(3|4|5|7|8)\d{9}$/,
                        message: '手机号格式不正确'
                    }
                }
            }
        }
    };
    $("#form_User").bootstrapValidator(formOptions).bootstrapValidator('validate');
    var valided = $("#form_User").data('bootstrapValidator').isValid();  //验证表单必须调用上面一行代码
    if (valided) {
        CommitForm("form_User", "../../Ashx/Login.ashx?typeClass=Regist", "post", function (data) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            if (data.Code === 200) {
                $("#form_User").bootstrapValidator(formOptions).data('bootstrapValidator').resetForm();
                window.location.href = data.Data;
            }
        });
    }
}

function ResetForm() {
    ClearForm("form_User");
    $("#form_User").bootstrapValidator(formOptions).data('bootstrapValidator').resetForm();
}
