<%@ Page Title="字典管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DicManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.DicManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">字典树形</h3>
                </div>
                <div class="panel-body">
                    字典树形
                   <div id="dicTV"></div>  
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">条件筛选</h3>
                </div>
                <div class="panel-body">
                    <table id="table"></table>
                    <%--分页插件--%>
                    <div>
                        <ul id='pagePlaug'></ul>
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
    <script src="../../Js/Manage/DicManage.js"></script>
</asp:Content>
