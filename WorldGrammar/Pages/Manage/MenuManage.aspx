<%@ Page Title="菜单管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MenuManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.MenuManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-icheck/skins/all.css" rel="stylesheet" />
    <link href="../../Plaugs/bootstrap-validator/dist/css/bootstrapValidator.min.css" rel="stylesheet" />
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div id="leftTree" class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">菜单列表</h3>
                </div>
                <%--右键删除按钮--%>
                <div class="panel-body">
                    <ul id="contextMenu" class="dropdown-menu">
                        <li>
                            <a href="javascript:;" onclick="DelMenu()">删除</a>
                        </li>
                    </ul>
                    <div id="treeview" class=""></div>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">菜单详情</h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-6 col-md-offset-3" style="margin-top: 20px;">
                        <form id="form_menu">
                            <input type="hidden" id="ID" name="ID" />
                            <div class="form-group">                    
                                <%--下拉树--%>
                                <div id="selectTV" style="display: none;" />
                            </div>
                            <div class="form-group">
                                <label for="ParentName">父级菜单</label>
                                <input type="text" id="ParentName" name="ParentName" class="form-control" value="" onclick="$('#selectTV').show(); whoSelect = true;">
                                <input type="hidden" id="ParentCode" name="ParentCode" value="36">
                            </div>
                            <div class="form-group">
                                <label for="MenuCodeTxt">菜单编码</label>
                                <input type="text" class="form-control" id="MenuCodeTxt" name="MenuCodeTxt" placeholder="选择父级菜单自动生成编码" disabled>
                                <input type="hidden" id="MenuCode" name="MenuCode" />
                            </div>
                            <div class="form-group">
                                <label for="MenuName">菜单名称</label>
                                <input type="text" class="form-control" id="MenuName" name="MenuName" placeholder="MenuName">
                            </div>
                            <div class="form-group">
                                <label for="MenuSeq">排序码</label>
                                <input type="number" class="form-control" id="MenuSeq" name="MenuSeq">
                            </div>
                            <div class="form-group">
                                <label for="MenuIcon">菜单图标</label>
                                <input type="text" class="form-control" id="MenuIcon" name="MenuIcon" placeholder="相对路径">
                            </div>
                            <div class="form-group">
                                <label for="URL">菜单路径</label>
                                <input type="text" class="form-control" id="URL" name="URL" placeholder="相对路径">
                            </div>
                            <div class="form-group">
                                <label>
                                    <input id="IsEnable" name="IsEnable" type="checkbox" class="icheckbox_square-blue checked" checked="checked" />是否启用
                                </label>
                            </div>
                            <button type="button" class="btn btn-primary col-md-offset-4" onclick="ClearForm('form_menu')">重 置</button>
                            <button type="button" class="btn btn-success col-md-offset-2" onclick="SubmitForm()">保 存</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../../Plaugs/bootstrap-treeview/js/bootstrap-treeview.js"></script>
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.js"></script>
    <script src="../../Plaugs/bootstrap-icheck/icheck.js"></script>
    <script src="../../Js/Manage/MenuManage.js"></script>
</asp:Content>
