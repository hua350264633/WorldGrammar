<%@ Page Title="类型管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GMTypeManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.GMTypeManage" %>

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
                    <h3 class="panel-title">语法类型</h3>
                </div>
                <%--右键删除按钮--%>
                <div class="panel-body">
                    <ul id="contextGMType" class="dropdown-menu">
                        <li>
                            <a href="javascript:;" onclick="DelGMType()">删除</a>
                        </li>
                    </ul>
                    <div id="treeview" class=""></div>
                </div>
            </div>
        </div>
        <div class="col-md-9">
            <div class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">类型详情</h3>
                </div>
                <div class="panel-body">
                    <div class="col-md-6 col-md-offset-3" style="margin-top: 20px;">
                        <form id="form_GMType">
                            <input type="hidden" id="ID" name="ID" />
                            <div class="form-group">                    
                                <%--下拉树--%>
                                <div id="selectTV" style="display: none;" />
                            </div>
                            <div class="form-group">
                                <label for="ParentName">父级类型</label>
                                <input type="text" id="ParentName" name="ParentName" class="form-control" value="" onclick="$('#selectTV').show(); whoSelect = true;">
                                <input type="hidden" id="ParentID" name="ParentID" value="0">
                            </div>
                            <div class="form-group">
                                <label for="TypeName">类型名称</label>
                                <input type="text" class="form-control" id="TypeName" name="TypeName" placeholder="TypeName">
                            </div>
                            <div class="form-group">
                                <label for="Seq">排序码</label>
                                <input type="number" class="form-control" id="Seq" name="Seq">
                            </div>
                            <div class="form-group">
                                <label for="Remark">类型描述</label>
                                <textarea class="form-control" id="Remark" name="Remark" placeholder="类型描述" rows="2"></textarea>
                            </div>
                            <button type="button" class="btn btn-primary col-md-offset-8" onclick="ClearForm('form_GMType')">重 置</button>
                            <button type="button" class="btn btn-success pull-right" onclick="SubmitForm()">保 存</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../../Plaugs/bootstrap-treeview/js/bootstrap-treeview.js"></script>
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.js"></script>
    <script src="../../Plaugs/bootstrap-icheck/icheck.js"></script>
    <script src="../../Js/Manage/GMTypeManage.js"></script>
</asp:Content>
