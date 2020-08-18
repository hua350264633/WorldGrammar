<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Regist.aspx.cs" Inherits="WorldGrammar.Pages.Manage.Regist" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>用户注册</title>
    <link href="/GL.ico" rel="shortcut icon" />
    <link href="../../Plaugs/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="../../Common/Jquery1.12.4.js"></script>
    <script src="../../Plaugs/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <script src="../../Common/Common.js"></script>
    <script src="../../Js/Manage/Regist.js"></script>
    <%--表单验证插件--%>
    <link href="../../Plaugs/bootstrap-validator/dist/css/bootstrapValidator.min.css" rel="stylesheet" />
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.min.js"></script>
    <%--日期插件--%>
    <link href="../../Plaugs/bootstrap-datetimepicker-master/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../../Plaugs/bootstrap-datetimepicker-master/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../../Plaugs/bootstrap-datetimepicker-master/js/bootstrap-datetimepicker.zh-CN.js"></script>
    <style type="text/css">
        * {
            margin: 0px;
            padding: 0px;
        }

        body {
            background: url('../../Imgs/Jpg/LoginBg1.jpg') no-repeat;
            font-size: 14px;
        }

        .form {
            width: 500px;
            height: 600px;
            margin:0px auto;
            margin-top:40px;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="form">
            <form id="form_User" class="form-horizontal" role="form">
                <h2 class="form-title">《天下语法》</h2>
                <div class="row">
                    <div class="col-md-offset-1 col-md-10">
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-10">
                                <a href="Login.aspx">登录</a>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="LoginName">登录名：</label>
                            <div class="col-md-9">
                                <input type="text" id="LoginName" name="LoginName" class="form-control" placeholder="5-20个字符之间" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="NickName">昵称：</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="NickName" name="NickName" placeholder="用户昵称" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="LoginPwd">密码：</label>
                            <div class="col-md-9">
                                <input type="password" class="form-control" id="LoginPwd" name="LoginPwd" placeholder="5-20个字符之间" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="ConfirmPassword">确认密码：</label>
                            <div class="col-md-9">
                                <input type="password" class="form-control" id="ConfirmPassword" name="ConfirmPassword" placeholder="确认密码" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="Birthday">出生日期：</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="datetimepicker" placeholder="出生日期" data-link-field="Birthday" value="1990-01-01" readonly />
                            <input type="hidden" id="Birthday" name="Birthday" value="1990-01-01" /><br />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="PlaceBirth">出生地点：</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="PlaceBirth" name="PlaceBirth" placeholder="出生地点" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="PhoneNumber">手机号：</label>
                            <div class="col-md-9">
                                <input type="text" class="form-control" id="PhoneNumber" name="PhoneNumber" placeholder="11位数字" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-md-3 control-label" for="Sex">性别：</label>
                            <div class="col-md-9">
                                <input type="radio" id="SexNan" name="Sex" value="1" checked="checked">男&nbsp;&nbsp;
                                    <input type="radio" id="SexNv" name="Sex" value="0">女
                            </div>
                        </div>
                        <button type="button" class="btn btn-primary col-md-offset-6" onclick="ResetForm()">重 置</button>
                        <button type="button" class="btn btn-success pull-right" onclick="SubmitForm()">注 册</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $('#datetimepicker').datetimepicker({
            format: 'yyyy-mm-dd',
            language: 'zh-CN',
            startView: "2",
            minView: 2,
            autoclose: true,
            initialDate: "1990-01-01"
        });

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
