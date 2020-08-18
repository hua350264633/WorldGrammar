<%@ Page Title="我的语法管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyGMManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.MyGMManage" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div id="leftTree" class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">语法类型</h3>
                </div>
                <%--右键删除按钮--%>
                <div class="panel-body">
                    <ul id="contextGM" class="dropdown-menu">
                        <li>
                            <a href="javascript:;" onclick="DelGM()">删除</a>
                        </li>
                    </ul>
                    <div id="treeview" class=""></div>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">语法列表</h3>
                </div>
                <div class="panel-body">
                    <button type="button" class="btn btn-default glyphicon glyphicon-plus" onclick="Add()">新增语法</button>
                    <div style="min-height:380px;">
                        <table id="table"></table>
                    </div>
                    <%--分页插件--%>
                    <div>
                        <ul id='pagePlaug'></ul>
                    </div>                    
                </div>
            </div>
        </div>
    </div>
    <script src="../../Plaugs/bootstrap-treeview/js/bootstrap-treeview.js"></script>    
    <%--表格插件--%>
    <script src="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.js"></script>
    <script src="../../Plaugs/bootstrap-table-master/dist/locale/bootstrap-table-zh-CN.js"></script>
    <%--分页插件--%>
    <script src="../../Plaugs/bootstrap-paginator-master/src/bootstrap-paginator.js"></script>
    <script src="../../Js/Manage/MyGMManage.js"></script>
</asp:Content>
