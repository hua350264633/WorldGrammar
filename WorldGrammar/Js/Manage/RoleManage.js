//*********************全局变量——开始***********************
var whoSelect = true;
var $menuTV = $('#menuTV');     //菜单树
var $roleTV = $('#roleTV');     //角色树
var $selectTV = $('#selectTV'); //选择树
//*********************全局变量——结束***********************
$(document).ready(function () {
    Init();
});

/*
*删除角色（树形选中的）
*/
function DelRole() {
    var selectNode = $roleTV.treeview('getSelected');
    var menuCode = selectNode[0].id;
    if (menuCode === undefined) {
        return;
    }
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/Role.ashx", { typeClass: "DelRole", RoleCode: menuCode }, function (returnData) {
                if (returnData.Code != 200) {
                    AlertMsg(returnData.Msg, "err");
                    return;
                }
                AlertMsg(returnData.Msg, "info");
                Init();
            });
        }
    })
}

/*
*初始化树形
*/
function Init() {
    PostData("../../Ashx/Role.ashx", { typeClass: "GetTreeRole" }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        var menuTree = JSON.parse(returnData.Data);  //将角色字符串数据转换成Json数据
        //初始化左边树形
        $roleTV.treeview({
            levels: 3,
            color: "#428bca",
            showBorder: false,
            data: menuTree,
            selectedBackColor: "#5CB85C",
            onNodeSelected: function (event, data) {
                whoSelect = false;
                SetRoleVal(data);                
                GetRoleMenu();
                GetRoleUser();
            },
            onMouseDown: function (event)
            {
                if (event.buttons === 2) {   //1：鼠标左键，2：鼠标右键
                    var left = event.offsetX + 50;
                    var top = event.toElement.offsetTop;
                    //获取角色并设置角色的位置
                    $("#contextRole").css({
                        left: left + "px",//设置角色离页面左边距离，left等效于x坐标 
                        top: top + "px"//设置角色离页面上边距离，top等效于y坐标
                    }).stop().show();//显示使用淡入效果,比如不需要动画可以使用show()替换;


                    //获取点击的节点
                    var target = $(event.toElement);
                    var node = $roleTV.treeview('findNode', target);
                    //设置节点选中状态
                    var selectNode = $roleTV.treeview('searchByVal', [node.tags.RoleCode, { ignoreCase: false, exactMatch: false }]);
                    $roleTV.treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
                }
            }
        });
        //初始化下拉树
        var top = new Object();
        top.id = "0";
        top.text = "顶级角色";
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
                    PostData("../../Ashx/Role.ashx", { typeClass: "GenerateRoleCode", SelfCode: $("#RoleCode").val(), ParentRoleCode: data.id }, function (returnData) {
                        if (returnData.Code === 200) {
                            $("#RoleCode").val(returnData.Data);
                            $("#RoleCodeTxt").val(returnData.Data);
                        }
                    });
                }

                //设置相应值
                $("#ParentCode").val(data.id);
                $("#ParentName").val(data.text);
                $("#selectTV").hide();
            }
        };        
        $selectTV.treeview(options);
        //设置默认选中顶级角色
        var selectNode = $selectTV.treeview('searchByVal', ["0", { ignoreCase: false, exactMatch: false }]);
        $selectTV.treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
        //设置默认选中第一个角色
        //var firstRole = $roleTV.find("li").eq(0);
        //if (firstRole) {
        //    firstRole.click();
        //}
    });
    PostData("../../Ashx/Menu.ashx", { typeClass: "GetTreeMenu" }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        var menuTree = JSON.parse(returnData.Data);  //将角色字符串数据转换成Json数据
        //初始化左边树形
        $menuTV.treeview({
            levels: 5,
            selectable: true,
            color: "#428bca",
            showBorder: false,
            showCheckbox: true,
            multiSelect: true,
            highlightSelected:false,
            data: menuTree,
            onNodeChecked: function (event, node)
            {
                DGCheck(node, true);
            },
            onNodeUnchecked: function (event, node) {
                DGCheck(node, false);
            }
        });
    });
}

/*
*设置觉得信息到控件中
*/
function SetRoleVal(data)
{
    //设置顶级角色
    var selectNode = $selectTV.treeview('searchByVal', [data.tags.ParentCode, { ignoreCase: false, exactMatch: false }]);
    $selectTV.treeview('selectNode', [selectNode, { silent: $('#chk-select-silent').is(':checked') }]);
    $("#ID").val(data.tags.ID);
    $("#RoleCodeTxt").val(data.tags.RoleCode);
    $("#RoleCode").val(data.tags.RoleCode);
    $("#RoleName").val(data.tags.RoleName);
    $("#RoleSeq").val(data.tags.RoleSeq);
    $("#Description").val(data.tags.Description);
}

/*
*递归修改节点及子节点状态
*rootNode：根节点
*state：要设置的状态
*/
function DGCheck(rootNode,State) {
    var childs = rootNode.nodes;
    if (!childs) {
        return;
    }
    for (var i = 0; i < childs.length; i++) {
        if (State) {
            $menuTV.treeview('checkNode', [childs[i].nodeId, { silent: true }]);
        } else {
            $menuTV.treeview('uncheckNode', [childs[i].nodeId, { silent: true }]);
        }
        DGCheck(childs[i], State);
    }
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
            RoleCode: {
                message: '角色编码无效',
                validators: {
                    notEmpty: {
                        message: '角色编码不能为空'
                    }
                }
            },
            RoleName: {
                validators: {
                    notEmpty: {
                        message: '角色名不能为空'
                    }
                }
            },
            RoleSeq: {
                validators: {
                    notEmpty: {
                        message: '排序码不能为空'
                    }
                }
            }
        }
    };
    $("#form_Role").bootstrapValidator(options).bootstrapValidator('validate');
    var valided = $("#form_Role").data('bootstrapValidator').isValid();  //验证表单必须调用上面一行代码
    if (valided) {
        CommitForm("form_Role", "../../Ashx/Role.ashx?typeClass=SaveRole", "post", function (data) {
            if (data.Code !== 200) {
                AlertMsg(data.Msg, "err");
                return;
            }
            if (data.Code === 200) {
                //重置表单
                $("#form_Role").bootstrapValidator(options).data('bootstrapValidator').resetForm();
                AlertMsg(data.Msg, "info");
                Init();
            }
        });
    }
}

/*
*保存角色菜单
*/
function SaveRoleMenu()
{
    var selectNode = $roleTV.treeview('getSelected');
    if (selectNode.length === 0) {
        AlertMsg("请在角色列表中选择一个角色", "err");
        return;
    }
    var roleCode = selectNode[0].id;    
   
    //获取角色选中菜单
    var nodes = $('#menuTV > ul > li');
    var menuCodes = new Array();
    for (var i = 0; i < nodes.length; i++) {
        if ($(nodes[i]).hasClass("node-checked")) {
            var muenCode = $menuTV.treeview('getNode', $(nodes[i]).attr("data-nodeid")).id;
            menuCodes.push(muenCode);
        }
    }
    //提交到数据库
    PostData("../../Ashx/Role.ashx", { typeClass: "SaveRoleMenu", RoleCode: roleCode,MenuCodes: menuCodes.join(",")}, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        } else {
            AlertMsg(returnData.Msg, "suc");
        }
    });
}

/*
*获取角色菜单
*/
function GetRoleMenu()
{
    var selectNode = $roleTV.treeview('getSelected');
    if (selectNode.length === 0) {
        AlertMsg("请在角色列表中选择一个角色", "err");
        return;
    }
    var roleCode = selectNode[0].id;
    //提交到数据库
    PostData("../../Ashx/Role.ashx", { typeClass: "GetRoleMenu", RoleCode: roleCode }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        } else {
            $menuTV.treeview('uncheckAll', { silent: true });
            for (var i = 0; i < returnData.Data.length; i++) {
                var nodeId = $("#menuTV > ul > li[data-nodecode='" + returnData.Data[i].MenuCode + "']").attr("data-nodeid");
                $menuTV.treeview('checkNode', [parseInt(nodeId), { silent: true }]);
            }
        }
    });
}

/****************************************************选择用户面板相关**********************************************************/
/*
*显示编辑面板
*/
function ShowEdit()
{
    var selectNode = $roleTV.treeview('getSelected');
    if (selectNode.length === 0) {
        AlertMsg("请在角色列表中选择一个角色", "err");
        return;
    }
    InitTable(CurrentPage, PageSize, Where);
    //弹出面板
    $('#Modal_Select').modal({
        keyboard: true
    });
}

//*********************全局变量——开始***********************
var CurrentPage = 1;  //默认第几页
var PageSize = 30;    //默认一页显示多少条数据
var TotalRecord = 0;  //返回数据总数
var TotalPage = 0;    //总共页码
var Where = " [IsEnabled] = 1 ";       //条件
var loaded = false;   //页面是否加载完
var $table = $('#table');  //表格对象
//*********************全局变量——结束***********************

/*
*拼接查询条件
*/
function Search() {    
    var NickName = $("#P_NickName").val();
    var PhoneNumber = $("#P_PhoneNumber").val();
    if (NickName !== "") {
        Where += " and NickName like '%" + NickName + "%'";
    }
    if (PhoneNumber !== "") {
        Where += " and PhoneNumber like '%" + PhoneNumber + "%'";
    }
    InitTable(CurrentPage, PageSize, Where);
}

/*
*初始化分页插件
*/
function InitPage() {
    var element = $('#pagePlaug');
    var options = {
        bootstrapMajorVersion: 3,
        currentPage: CurrentPage,
        numberOfPages: 5,
        totalPages: TotalPage,
        onPageClicked: function (event, originalEvent, type, page) {
            CurrentPage = page;
            InitTable(CurrentPage, PageSize, Where);
        }
    }

    element.bootstrapPaginator(options);
}

/*
*初始化表格
*CurrentPage：当前页码
*PageSize：每页数据条数
*Where:查询条件
*/
function InitTable(CurrentPage, PageSize, Where) {
    PostData("../../Ashx/User.ashx", { typeClass: "GetPageData", CurrentPage: CurrentPage, PageSize: PageSize, Where: Where }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        TotalRecord = returnData.Total;
        TotalPage = parseInt(TotalRecord / PageSize) + (TotalRecord % PageSize > 0 ? 1 : 0);

        if (!loaded) {
            loaded = true;
            $table.bootstrapTable({
                height: 350,
                cache: false,
                pageList: [30, 50, 100],
                data: returnData.Rows,
                uniqueId: "LoginName",
                columns: [{
                    field: 'LoginName',
                    title: '登录名',
                    valign: "middle",
                    align: "center",
                    width: "80"
                }, {
                    field: 'NickName',
                    title: '昵称',
                    valign: "middle",
                    align: "center",
                    width: "80"
                }, {
                    field: 'Sex',
                    title: '性别',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        if (value) {
                            return "男";
                        } else {
                            return "女";
                        }
                    },
                    align: "center",
                    width: "50"
                }, {
                    field: 'Birthday',
                    title: '出生日期',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        return FormatDate(new Date(value), "1");
                    },
                    align: "center",
                    width: "120"
                }, {
                    field: 'PlaceBirth',
                    title: '出生地',
                    valign: "middle",
                    align: "center",
                    width: "120"
                }, {
                    field: 'PhoneNumber',
                    title: '手机号码',
                    valign: "middle",
                    align: "center",
                    width: "100"
                }, {
                    title: '操作',
                    formatter: function (value, row, index) {
                        return '<button type="button" class="btn btn-primary" onclick="AddLoginName(\'' + row.LoginName + '\')"><span class="glyphicon glyphicon-add"></span>添加</button>';
                    },
                    align: "center",
                    width: "50"
                }]
            });
        } else {
            $table.bootstrapTable('load', returnData.Rows);
        }

        if (TotalPage > 0) {
            InitPage();
        }

        //加载选中用户信息
        $("#oldRoleUsers").empty();
        var lis = $("#roleUsers > li");
        var tempLoginName;
        var tempHTML;
        for (var i = 0; i < lis.length; i++) {
            tempLoginName = $(lis[i]).attr("data-value");
            tempHTML = "<a style=\"margin:0px 5px;\" class=\"label label-info\" onclick=\"RemoveOld(this)\">" + tempLoginName + "</a>";
            $("#oldRoleUsers").append(tempHTML);
        }   
    });
}

/*
*带回选中的用户
*/
function BringBack()
{
    $("#roleUsers").empty();    
    var getSelection = $("#oldRoleUsers > a");
    var tempLoginName;
    for (var i = 0; i < getSelection.length; i++) {
        tempLoginName = getSelection[i].innerHTML;
        var user = "<li class=\"list-group-item\" data-value=\"" + tempLoginName + "\">" +
                        "<a class=\"badge\" onclick=\"RemoveUser(this)\">移除</a>" + tempLoginName +
                    "</li>";
        $("#roleUsers").append(user);
    }
    //隐藏面板
    $('#Modal_Select').modal("hide");
}

/*
*获取角色用户
*/
function GetRoleUser() {
    var selectNode = $roleTV.treeview('getSelected');
    if (selectNode.length === 0) {
        AlertMsg("请在角色列表中选择一个角色", "err");
        return;
    }
    var roleCode = selectNode[0].id;
    //提交到数据库
    PostData("../../Ashx/Role.ashx", { typeClass: "GetRoleUser", RoleCode: roleCode }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        } else {
            $("#roleUsers").empty();
            for (var i = 0; i < returnData.Data.length; i++) {
                var user = "<li class=\"list-group-item\" data-value=\"" + returnData.Data[i].LoginName + "\">" +
                       "<a class=\"badge\" onclick=\"RemoveUser(this)\">移除</a>" + returnData.Data[i].LoginName +
                   "</li>";
                $("#roleUsers").append(user);
            }
        }
    });
}

/*
*保存角色用户
*/
function SaveRoleUser()
{
    var selectNode = $roleTV.treeview('getSelected');
    if (selectNode.length === 0) {
        AlertMsg("请在角色列表中选择一个角色", "err");
        return;
    }
    var roleCode = selectNode[0].id;
    //获取选中的用户
    var loginNames = new Array();    
    var lis = $("#roleUsers > li");
    var tempLoginName;
    for (var i = 0; i < lis.length; i++) {
        loginNames.push($(lis[i]).attr("data-value"));
    }
    //提交到数据库
    PostData("../../Ashx/Role.ashx", { typeClass: "SaveRoleUser", RoleCode: roleCode, LoginNames: loginNames.join(",") }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        } else {
            AlertMsg(returnData.Msg, "suc");
        }
    });
}

/*
*移除本条记录
*/
function RemoveUser(obj) {
    $(obj).parent("li").remove();
}

/*
*移除本用户
*/
function RemoveOld(obj)
{
    $(obj).remove();
}

/*
*添加到选择的用户集合中
*/
function AddLoginName(loginName)
{
    var haved = false;  //改用户是否已存在
    var getSelection = $("#oldRoleUsers > a");
    for (var i = 0; i < getSelection.length; i++) {
        if (getSelection[i].innerHTML === loginName) {
            haved = true;
            break;
        }
    }
    if (haved) {
        AlertMsg("该用户已经添加过了，不允许重复添加", "err");
        return;
    }
    var tempHTML = "<a style=\"margin:0px 5px;\" class=\"label label-info\" onclick=\"RemoveOld(this)\">" + loginName + "</a>";
    $("#oldRoleUsers").append(tempHTML);
}