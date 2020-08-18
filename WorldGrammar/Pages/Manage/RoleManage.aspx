<%@ Page Title="角色管理" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RoleManage.aspx.cs" Inherits="WorldGrammar.Pages.Manage.RoleManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-icheck/skins/all.css" rel="stylesheet" />
    <link href="../../Plaugs/bootstrap-validator/dist/css/bootstrapValidator.min.css" rel="stylesheet" />
    <link href="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="row">
        <div class="col-md-3">
            <div id="leftTree" class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">角色列表</h3>
                </div>
                <%--右键删除按钮--%>
                <div class="panel-body">
                    <ul id="contextRole" class="dropdown-menu">
                        <li>
                            <a href="javascript:;" onclick="DelRole()">删除</a>
                        </li>
                    </ul>
                    <div id="roleTV" class=""></div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">角色详情</h3>
                </div>
                <div class="panel-body">
                    <ul id="RoleNav" class="nav nav-tabs">
                        <li class="active"><a data-toggle="tab" href="#menu1">角色基本信息</a></li>
                        <li><a data-toggle="tab" href="#menu2">可用菜单</a></li>
                    </ul>
                    <div class="tab-content">
                        <div id="menu1" class="tab-pane fade in active">
                            <div class="col-md-6 col-md-offset-3 tabPanel" style="margin-top: 20px;">
                                <form id="form_Role">
                                    <input type="hidden" id="ID" name="ID" />
                                    <div class="form-group">
                                        <%--下拉树--%>
                                        <div id="selectTV" style="display: none;"></div>
                                    </div>
                                    <div class="form-group">
                                        <label for="ParentName">父级角色</label>
                                        <input type="text" id="ParentName" name="ParentName" class="form-control" value="" onclick="$('#selectTV').show(); whoSelect = true;" />
                                        <input type="hidden" id="ParentCode" name="ParentCode" value="0">
                                    </div>
                                    <div class="form-group">
                                        <label for="RoleCodeTxt">角色编码</label>
                                        <input type="text" class="form-control" id="RoleCodeTxt" name="RoleCodeTxt" placeholder="选择父级角色自动生成编码" disabled />
                                        <input type="hidden" id="RoleCode" name="RoleCode" />
                                    </div>
                                    <div class="form-group">
                                        <label for="RoleName">角色名称</label>
                                        <input type="text" class="form-control" id="RoleName" name="RoleName" placeholder="角色名称" />
                                    </div>
                                    <div class="form-group">
                                        <label for="RoleSeq">排序码</label>
                                        <input type="number" class="form-control" id="RoleSeq" name="RoleSeq" placeholder="请输入数字" />
                                    </div>
                                    <div class="form-group">
                                        <label for="Description">角色描述</label>
                                        <textarea class="form-control" id="Description" name="Description" rows="2" placeholder="角色描述"></textarea>
                                    </div>
                                    <button type="button" class="btn btn-primary col-md-offset-2" onclick="ClearForm('form_Role')">重 置</button>
                                    <button type="button" class="btn btn-success col-md-offset-2" onclick="SubmitForm()">保 存</button>
                                </form>
                            </div>
                        </div>
                        <div id="menu2" class="tab-pane fade">
                            <div class="col-md-6 col-md-offset-3 tabPanel" style="margin-top: 20px;">
                                <div id="menuTV"></div>
                                <button type="button" class="btn btn-success pull-right" onclick="SaveRoleMenu()">保 存</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row col-md-3">
            <div class="panel panel-primary" style="border-color: #E3E3E3;">
                <div class="panel-heading">
                    <h3 class="panel-title">包含用户</h3>
                </div>
                <div class="panel-body">
                    <button type="button" onclick="ShowEdit()" class="btn btn-primary btn-sm green-meadow  col-sm-offset-1">
                        <i class="fa fa-plus"></i>
                        选择
                    </button>
                    <button type="button" onclick="SaveRoleUser()" class="btn btn-success btn-sm green-meadow  col-sm-offset-4">
                        <i class="fa fa-minus"></i>
                        保存
                    </button>
                    <div class="scroller" style="margin-top:10px;" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd">
                        <ul id="roleUsers" class="list-group"></ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--弹出框选择用户--%>
    <div class="modal fade" id="Modal_Select" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog" style="width: 1000px;">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
                    <h4 class="modal-title"><span class="glyphicon glyphicon-check"></span>&nbsp;选择用户</h4>
                </div>
                <div class="modal-body">
                    <%--具体内容--%>
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
                                    <span class="input-group-addon">手机号码</span>
                                    <input type="text" class="form-control" id="P_PhoneNumber" placeholder="手机号码">
                                </div>
                            </div>
                            <div class="col-md-1">
                                <button type="button" class="btn btn-primary" onclick="Search()">查 询</button>
                            </div>
                        </div>
                    </div>
                    <table id="table"></table>
                    <%--分页插件--%>
                    <div>
                        <ul id='pagePlaug'></ul>
                    </div>
                    <div id="oldRoleUsers" class="scroller" style="height: 100px;padding:10px;border:1px solid #337AB7;" data-rail-visible="1" data-rail-color="yellow" data-handle-color="#a1b2bd"></div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-primary" onclick="BringBack()">带回</button>
                </div>
            </div>
        </div>
    </div>

    <script src="../../Plaugs/bootstrap-treeview/js/bootstrap-treeview.js"></script>
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.js"></script>
    <script src="../../Plaugs/bootstrap-icheck/icheck.js"></script>
    <script src="../../Plaugs/bootstrap-paginator-master/src/bootstrap-paginator.js"></script>
    <script src="../../Plaugs/bootstrap-table-master/dist/bootstrap-table.min.js"></script>
    <script src="../../Js/Manage/RoleManage.js"></script>
</asp:Content>
