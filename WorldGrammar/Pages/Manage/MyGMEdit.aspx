<%@ Page Title="语法编辑" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyGMEdit.aspx.cs" Inherits="WorldGrammar.Pages.Manage.MyGMEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Plaugs/bootstrap-icheck/skins/all.css" rel="stylesheet" />
    <link href="../../Plaugs/summernote-0.8.8-dist/summernote.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div class="panel panel-primary" style="border-color: #E3E3E3;">
        <div class="panel-heading">
            <h3 class="panel-title">语法详情</h3>
        </div>
        <div class="panel-body">
            <form id="form_MyGM">
                <input type="hidden" id="ID" name="ID" />
                <div class="col-md-4">
                    <div id="selectTV" style="display: none;"></div>
                    <div class="form-group">
                        <label for="TypeName">所属分类</label>
                        <input type="text" id="TypeName" name="TypeName" class="form-control" value="" onclick="$('#selectTV').show(); whoSelect = true;" placeholder="所属分类" />
                        <input type="hidden" id="TypeID" name="TypeID" />
                    </div>
                </div>
                <div class="col-md-8">
                    <div class="form-group">
                        <label for="Title">语法标题</label>
                        <input type="text" class="form-control" id="Title" name="Title" placeholder="语法标题" />
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="Descript">语法描述</label>
                        <textarea class="form-control" id="Descript" name="Descript" rows="2"></textarea>
                    </div>
                </div>    
                <div class="col-md-12">
                    <div class="form-group">
                        <label for="Content">语法内容</label>
                        <div id="Content"></div>
                        <textarea id="ContentHTML" name="ContentHTML" style="display:none;"></textarea>
                    </div>
                </div>                
                <div class="col-md-6">                    
                    <div class="form-group">      
                        <label for="Title">附件：</label> 
                        <input id="DemoFile" class="form-control-static" name="DemoFile" type="text" style="width:300px;height:18px;" placeholder="附件必须时zip或rar 并且不能超过50mb"/>
                        <input id="btnfile" class="form-control-static" type="file" name="btnfile" style="display:inline-block" accept="application/x-zip-compressed" />
                        <button type="button" class="btn glyphicon glyphicon-trash btn-sm" onclick="DelFile()"></button>
                    </div>
                </div>
                <div class="col-md-6"> 
                     <div class="form-group">
                        <label for="Title">标签：</label>
                        <input type="text" class="form-control-static" id="Tags" name="Tags" style="width:300px;height:18px;" placeholder="Tag标签（英文","分隔多个标签）" />
                    </div>
                </div> 
                <div class="col-md-6"> 
                    <div class="form-group">
                        <label for="IsClassical">是否经典语法</label>
                        <input type="checkbox" class="form-control-static icheckbox_square-blue" id="IsClassical" name="IsClassical" />
                    </div>
                </div> 
                <div class="col-md-6"> 
                    <div class="form-group">
                        <input class="btn btn-primary" type="button" value="重 置" onclick="ClearForm('form_MyGM')">
                        <input class="btn btn-success col-md-offset-1" type="button" value="保 存" onclick="SubmitForm()">
                    </div>
                </div> 
            </form>
        </div>
    </div>
    <%--ajax上传插件--%>
    <script src="../../Plaugs/ajaxfileupload/ajaxfileupload.js"></script>
    <%--树形插件--%>
    <script src="../../Plaugs/bootstrap-treeview/js/bootstrap-treeview.js"></script>
    <%--富文本编辑插件--%>
    <script src="../../Plaugs/summernote-0.8.8-dist/summernote.js"></script>
    <script src="../../Plaugs/summernote-0.8.8-dist/lang/summernote-zh-CN.js"></script>
    <%--表单验证插件--%>
    <script src="../../Plaugs/bootstrap-validator/dist/js/bootstrapValidator.js"></script>
    <script src="../../Plaugs/bootstrap-icheck/icheck.js"></script>
    <script src="../../Js/Manage/MyGMEdit.js"></script>
</asp:Content>
