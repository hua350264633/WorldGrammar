//*********************全局变量——开始***********************
var whoSelect = true;   //谁选择的下拉框（1：直接点击，2：左边树形改变）
//*********************全局变量——结束***********************
$(document).ready(function () {
    DisabledContextMenu();
    InitTree();
});

/*
*禁用右键菜单
*/
function DisabledContextMenu(){
    $(document).on("contextmenu", function (event) {
        event.preventDefault();//阻止浏览器与事件相关的默认行为；此处就是弹出右键菜单
    });
    $("#contextMenu").on("click", function (event) {
        event.preventDefault();//阻止浏览器与事件相关的默认行为；此处就是弹出右键菜单
        $("#contextMenu").hide();
    });
    $("#leftTree").on("click", function (event) {        
        $("#contextMenu").hide();
    }); 
}

/*
*删除菜单（树形选中的）
*/
function DelMenu() {
    var selectNode = $('#treeview').treeview('getSelected');
    var menuCode = selectNode[0].id;
    if (menuCode === undefined) {
        return;
    }
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/Menu.ashx", { typeClass: "DelMenu", MenuCode: menuCode }, function (returnData) {
                if (returnData.Code != 200) {
                    AlertMsg(returnData.Msg, "err");
                    return;
                }
                AlertMsg(returnData.Msg, "info");
                InitTree();
            });
        }
    })
}

/*
*初始化树形
*/
function InitTree() {
    PostData("../../Ashx/Menu.ashx", { typeClass: "GetTreeMenu" }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        var menuTree = JSON.parse(returnData.Data);  //将菜单字符串数据转换成Json数据
        //初始化左边树形
        $('#treeview').treeview({
            levels: 3,
            color: "#428bca",
            showBorder: false,
            data: menuTree,
            onNodeSelected: function (event, data) {
                whoSelect = false;
                //设置顶级菜单
                var selectNode = $('#selectTV').treeview('searchByVal', [data.tags.ParentCode, { ignoreCase: false, exactMatch: false }]);
                $('#selectTV').treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
                $("#ID").val(data.tags.ID);
                $("#MenuCodeTxt").val(data.tags.MenuCode);
                $("#MenuCode").val(data.tags.MenuCode);
                $("#MenuName").val(data.tags.MenuName);
                $("#MenuSeq").val(data.tags.MenuSeq);
                $("#MenuIcon").val(data.tags.MenuIcon);
                $("#URL").val(data.tags.URL);
                $("#IsEnable").attr("checked",data.tags.IsEnable);
            },
            onMouseDown: function (event)
            {
                if (event.buttons === 2) {   //1：鼠标左键，2：鼠标右键
                    var left = event.offsetX + 50;
                    var top = event.toElement.offsetTop;
                    //获取菜单并设置菜单的位置
                    $("#contextMenu").css({
                        left: left + "px",//设置菜单离页面左边距离，left等效于x坐标 
                        top: top + "px"//设置菜单离页面上边距离，top等效于y坐标
                    }).stop().show();//显示使用淡入效果,比如不需要动画可以使用show()替换;


                    //获取点击的节点
                    var target = $(event.toElement);
                    var node = $('#treeview').treeview('findNode', target);
                    //设置节点选中状态
                    var selectNode = $('#treeview').treeview('searchByVal', [node.tags.MenuCode, { ignoreCase: false, exactMatch: false }]);
                    $('#treeview').treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
                }
            }
        });
        //初始化下拉树
        var top = new Object();
        top.id = "0";
        top.text = "顶级菜单";
        menuTree.push(top);  //插入元素
        menuTree.reverse();  //反转数组
        var options = {
            bootstrap2: false,
            showTags: false,
            levels: 5,
            showCheckbox: false,
            checkedIcon: "glyphicon glyphicon-check",
            data: menuTree,
            onNodeSelected: function (event, data) {
                //选中节点后处理逻辑
                if (whoSelect) {
                    PostData("../../Ashx/Menu.ashx", { typeClass: "GenerateMenuCode", SelfCode: $("#MenuCode").val(), ParentMenuCode: data.id }, function (returnData) {
                        if (returnData.Code === 200) {
                            $("#MenuCode").val(returnData.Data);
                            $("#MenuCodeTxt").val(returnData.Data);
                        }
                    });
                }

                //设置相应值
                $("#ParentCode").val(data.id);
                $("#ParentName").val(data.text);
                $("#selectTV").hide();
            }
        };
        $('#selectTV').treeview(options);
        //设置默认选中顶级菜单
        var selectNode = $('#selectTV').treeview('searchByVal', ["0", { ignoreCase: false, exactMatch: false }]);
        $('#selectTV').treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
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
            MenuCode: {
                message: '菜单编码无效',
                validators: {
                    notEmpty: {
                        message: '菜单编码不能为空'
                    }
                }
            },
            MenuName: {
                validators: {
                    notEmpty: {
                        message: '菜单名不能为空'
                    }
                }
            },
            MenuSeq: {
                validators: {
                    notEmpty: {
                        message: '排序码不能为空'
                    }
                }
            }
        }
    };
    $("#form_menu").bootstrapValidator(options).bootstrapValidator('validate');
    var valided = $("#form_menu").data('bootstrapValidator').isValid();  //验证表单必须调用上面一行代码
    if (valided) {
        CommitForm("form_menu", "../../Ashx/Menu.ashx?typeClass=SaveMenu", "post", function (data) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            if (data.Code === 200) {
                //重置表单
                $("#form_menu").bootstrapValidator(options).data('bootstrapValidator').resetForm();
                AlertMsg(data.Msg, "info");
                InitTree();
            }
        });
    }
}

