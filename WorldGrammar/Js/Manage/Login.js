//窗体加载完成事件
window.onload = function () {
    var LoginName = $.cookie('LoginName');
    var encrypted = $.cookie('LoginPwd');
    if (LoginName && encrypted) {
        //设置复选框为选中状态
        document.getElementById("remember").checked = true;
        var decrypted = CryptoJS.RC4.decrypt(encrypted, LoginName).toString(CryptoJS.enc.Utf8);
        $("#LoginName").val(LoginName)
        $("#LoginPwd").val(decrypted);
    }
};

/*
*登录验证
*/
function DoLogin() {
    var LoginName = $("input[name='LoginName']").val();
    if (LoginName === undefined || LoginName === "") {
        alert("用户名不能为空!");
        return false;
    }
    var LoginPwd = $("input[name='LoginPwd']").val();
    if (LoginPwd === undefined || LoginPwd === "") {
        alert("密码不能为空!");
        return false;
    }

    //记住密码
    if (document.getElementById("remember").checked) {
        var encrypted = CryptoJS.RC4.encrypt(LoginPwd, LoginName);
        $.cookie('LoginName', LoginName, { expires: 1, path: '/' });
        $.cookie('LoginPwd', encrypted, { expires: 1, path: '/' });
    } else {
        $.removeCookie("LoginName",{ path: '/' });
        $.removeCookie("LoginPwd", { path: '/' });
    }

    //提交请求
    var param = { LoginName: LoginName, LoginPwd: LoginPwd };
    PostData("../../Ashx/Login.ashx?typeClass=LoginIn",param, function (data) {
        if (data.Code == 200) {
            window.location.href = data.Data;
        } else {
            alert(data.Msg);
        }
    });
    return false;
}