//*********************全局变量——开始***********************
var id = undefined;
//*********************全局变量——结束***********************
/*
*窗体加载完成事件
*/
$(document).ready(function () {
    InitPage();
    InitGMType();
});

/*
*初始化页面
*/
function InitPage() {
    //渲染富文本编辑器
    $('#Content').summernote({
        lang: 'zh-CN',
        tabsize: 2,
        height: 250
    });
}

/*
*执行上传
*callBack：上传成功后回调函数
*/
function UpLoad(callBack) {
    //判断要上传的文件是否为空
    var filePath = $("#btnfile").val();
    if (filePath === "") {
        if (callBack !== null && typeof (callBack) === "function") {
            callBack();
        }
        return;
    }

    //删除之前的文件
    var oldFile = $("#DemoFile").val();
    if (oldFile !== "") {
        PostData("../../Ashx/FileUpLoad.ashx", { typeClass: "DelFile", FilePath: oldFile }, null);
    }

    //判断上传文件类型
    if (filePath.indexOf("zip") == -1 && filePath.indexOf("rar") == -1) {
        AlertMsg("目前仅支持：zip|rar 格式的附件", "err");
        //清空上传路径
        $("#DemoFile").val("");
        return false;
    }

    //上传文件
    $.ajaxFileUpload({
        url: '../../Ashx/FileUpLoad.ashx?typeClass=Upload',//处理程序路径
        secureuri: false,
        fileElementId: 'btnfile',
        dataType: 'json',
        success: function (data, status) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            //获取上传文件路径
            $("#DemoFile").val(data.Data.FileName);

            //上传成功后回调函数
            if (callBack !== null && typeof (callBack) === "function") {
                callBack();
            }
        },
        error: function (data, status, e) {
            AlertMsg("文件上传异常原因是：" + e, "err");
        }
    });
}

/*
*删除附件
*/
function DelFile() {
    var oldFile = $("#DemoFile").val();
    if (oldFile === "") {
        $("#DemoFile").val("")
        return;
    }
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/FileUpLoad.ashx", { typeClass: "DelFile", FilePath: oldFile }, function (returnData) {
                if (returnData.Code === 200) {
                    AlertMsg(returnData.Msg, "suc");
                } else {
                    AlertMsg(returnData.Msg, "err");
                }
                $("#DemoFile").val("")
            });
        }
    });
}
/*
*初始化语法类型结构
*/
function InitGMType() {
    PostData("../../Ashx/GMType.ashx", { typeClass: "GetTreeGMType" }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        var treeData = JSON.parse(returnData.Data);  //将语法字符串数据转换成Json数据
        //初始化下拉树
        var options = {
            bootstrap2: false,
            showTags: false,
            levels: 5,
            showCheckbox: false,
            checkedIcon: "glyphicon glyphicon-check",
            data: treeData,
            onNodeSelected: function (event, data) {
                //设置相应值
                $("#TypeID").val(data.id);
                $("#TypeName").val(data.text);
                $("#selectTV").hide();
            }
        };
        $('#selectTV').treeview(options);
        //设置默认选中顶级语法
        var selectNode = $('#selectTV').treeview('searchByVal', ["0", { ignoreCase: false, exactMatch: false }]);
        $('#selectTV').treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);

        //树形加载完成后再调用加载数据的方法
        LoadData();
    });
}

/*
*加载语法内容
*/
function LoadData() {
    id = Request("id");
    if (id == "") {
        return;
    }
    PostData("../../Ashx/GM.ashx", { typeClass: "GetGMById", ID: id }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        $("#ID").val(returnData.Data.ID);
        var selectNode = $('#selectTV').treeview('searchByVal', [returnData.Data.TypeID, { ignoreCase: false, exactMatch: false }]);
        $('#selectTV').treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
        $("#Title").val(returnData.Data.Title);
        $('#Content').summernote('code', returnData.Data.Content);
        $("#Descript").val(returnData.Data.Descript);
        $("#Tags").val(returnData.Data.Tags);
        $("#DemoFile").val(returnData.Data.DemoFile); 
        $("#IsClassical").attr("checked", returnData.Data.IsClassical);
    });
}

/*
*验证并提交表单
*/
function SubmitForm()
{
    var options = {
        message: '值验证未通过',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            Title: {
                validators: {
                    notEmpty: {
                        message: '语法标题不能为空'
                    }
                }
            }
        }
    };
    var TypeID = $("#TypeID").val();
    if (TypeID === "") {
        AlertMsg("所属分类不能为空", "err");
        return;
    }
    $("#form_MyGM").bootstrapValidator(options).bootstrapValidator('validate');
    var valided = $("#form_MyGM").data('bootstrapValidator').isValid();  //验证表单必须调用上面一行代码
    if (!valided) {
        return;
    }

    var ContentHTML = $('#Content').summernote('code');
    if (ContentHTML === undefined || ContentHTML === "" || ContentHTML === "<p><br></p>") {
        $('#Content').summernote('focus');
        AlertMsg("语法内容不能为空","err");
        return;
    }
    $("#ContentHTML").html(ContentHTML);

    //先执行上传，再执行提交
    UpLoad(function () {
        CommitForm("form_MyGM", "../../Ashx/GM.ashx?typeClass=SaveGM", "post", function (data) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            if (data.Code === 200) {
                //重置表单
                $("#form_MyGM").bootstrapValidator(options).data('bootstrapValidator').resetForm();
                AlertMsg(data.Msg, "info");
            }
        });
    })
}

