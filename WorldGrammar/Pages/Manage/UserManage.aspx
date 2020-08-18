<%@ Page Title="用户管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.UserManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.css" rel="stylesheet" />
    <%--日期插件--%>
    <link href="../../Plaugs/bootstrap-datetimepicker-master/css/bootstrap-datetimepicker.min.css" rel="stylesheet" />
    <script src="../../Plaugs/bootstrap-datetimepicker-master/js/bootstrap-datetimepicker.min.js"></script>
    <script src="../../Plaugs/bootstrap-datetimepicker-master/js/bootstrap-datetimepicker.zh-CN.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">条件筛选</h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-3">
                        <div class="input-group">
                            <span class="input-group-addon">昵称</span>
                            <input type="text" class="form-control" id="P_NickName" placeholder="用户昵称">
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group ">
                            <span class="input-group-addon">手机</span>
                            <input type="text" class="form-control" id="P_PhoneNumber" placeholder="手机号码">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <button type="button" class="btn btn-primary" onclick="Search()">查 询</button>
                    </div>
                </div>
            </div>
            <div style="min-height:380px;">
                <table id="table"></table>
            </div>
            <%--分页插件--%>
            <div>
                <ul id='pagePlaug'></ul>
            </div>
        </div>
        <%--修改面板--%>
        <div class="modal fade" id="Modal_Edit" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                        <h4 class="modal-title"><span class="glyphicon glyphicon-edit"></span>&nbsp;编辑用户</h4>
                    </div>
                    <div class="modal-body">
                        <%--具体内容--%>
                        <div class="row">
                            <div class="form-group col-md-6">
                                <label>登录名：</label>
                                <input type="text" class="form-control" id="LoginName" placeholder="登录名" disabled>
                            </div>
                            <div class="form-group col-md-6">
                                <label>昵称：</label>
                                <input type="text" class="form-control" id="NickName" placeholder="用户昵称">
                            </div>
                            <div class="form-group col-md-6">
                                <label>出生日期：</label>
                                <input type="text" class="form-control" id="datetimepicker" placeholder="出生日期" data-link-field="Birthday" value="1990-01-01" readonly />
                                <input type="hidden" id="Birthday" name="Birthday" value="" />
                            </div>
                            <div class="form-group col-md-6">
                                <label>出生地点：</label>
                                <input type="text" class="form-control" id="PlaceBirth" placeholder="出生地点">
                            </div>
                            <div class="form-group col-md-6">
                                <label>手机号：</label>
                                <input type="text" class="form-control" id="PhoneNumber" placeholder="手机号">
                            </div>
                            <div class="form-group col-md-6">
                                <label>性别：</label><br />
                                <input type="radio" id="SexNan" name="Sex" value="1">男&nbsp;&nbsp;
                                    <input type="radio" id="SexNv" name="Sex" value="0">女
                            </div>
                            <div class="form-group col-md-12">
                                <label>是否启用：</label>
                                <input type="checkbox" id="IsEnabled">
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                        <button type="button" class="btn btn-primary" onclick="EditUser()">提交更改</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--表格插件--%>
    <script src="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.js"></script>
    <script src="../../Plaugs/bootstrap-table-master/dist/locale/bootstrap-table-zh-CN.js"></script>
    <%--分页插件--%>
    <script src="../../Plaugs/bootstrap-paginator-master/src/bootstrap-paginator.js"></script>
    <script src="../../Js/Manage/UserManage.js"></script>
    <script type="text/javascript">
        $('#datetimepicker').datetimepicker({
            format: 'yyyy-mm-dd',
            language: 'zh-CN',
            startView: "2",
            minView: 2,
            autoclose: true,
            initialDate: "1990-01-01"
        });
    </script>
</asp:Content>
