<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WorldGrammar.Pages.Manage.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户登录</title>
    <link href="/GL.ico" rel="shortcut icon" />
    <link href="../../Plaugs/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Css/Manage/Login.css" rel="stylesheet" />
    <script src="../../Common/Jquery1.12.4.js"></script>
    <script src="../../Plaugs/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="../../Common/Common.js"></script>
    <script src="../../Common/jquery.cookie.js"></script>
    <script src="../../Common/rc4.js"></script>
    <script src="../../Js/Manage/Login.js"></script>
</head>
<body>
    <div class="form">
        <h2 class="form-title">《天下语法》</h2>
        <form id="loginForm" class="form-horizontal" method="post" onsubmit="return DoLogin()">
            <div class="col-md-12">
                <hr />
                <div class="form-group">
                    <i class="col-md-2 control-label glyphicon glyphicon-user"></i>
                    <div class="col-md-9">
                        <input class="form-control required" type="text" placeholder="登录名" id="LoginName" name="LoginName" autofocus="autofocus" maxlength="20" />
                    </div>
                </div>
                <div class="form-group">
                    <i class="col-md-2 control-label glyphicon glyphicon-lock"></i>
                    <div class="col-md-9">
                        <input class="form-control required" type="password" placeholder="登录密码" id="LoginPwd" name="LoginPwd" maxlength="20" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-4 col-md-offset-2">
                        <label class="checkbox">
                            <input type="checkbox" id="remember" />
                            记住密码  
                        </label>
                    </div>
                </div>
                <hr />
                <div class="form-group">
                    <div class="col-md-9 col-md-offset-2">
                        <a href="Regist.aspx" id="register_btn" class="">注册用户</a>
                    </div>
                </div>
                <div class="col-md-12 form-group">
                    <input type="submit" class="btn btn-success pull-right" value="登录" />
                </div>
            </div>
        </form>
    </div>
    <script type="text/javascript">
        var phoneWidth =  parseInt(window.screen.width);
        var phoneScale = phoneWidth/640;
        var ua = navigator.userAgent;
        if (/Android (\d+\.\d+)/.test(ua)){
            var version = parseFloat(RegExp.$1);
            if(version>2.3){
                document.write('<meta name="viewport" content="width=640, minimum-scale = '+phoneScale+', maximum-scale = '+phoneScale+', target-densitydpi=device-dpi">');
            }else{
                document.write('<meta name="viewport" content="width=640, target-densitydpi=device-dpi">');
            }
        } else {
            document.write('<meta name="viewport" content="width=640, user-scalable=no, target-densitydpi=device-dpi">');
        }
    </script>
</body>
</html>
