//*********************全局变量——开始***********************
var CurrentPage = 1;  //默认第几页
var PageSize = 5;     //默认一页显示多少条数据
var TotalRecord = 0;  //返回数据总数
var TotalPage = 0;    //总共页码
var Where = "";       //条件
var $table = $('#table');  //表格对象
//*********************全局变量——结束***********************

/*
*窗体加载完成事件
*/
$(document).ready(function () {
    InitTree();
    InitTable(CurrentPage, PageSize, Where);
});

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

var loaded = false;
/*
*初始化表格
*CurrentPage：当前页码
*PageSize：每页数据条数
*Where:查询条件
*/
function InitTable(CurrentPage, PageSize, Where) {
    PostData("../../Ashx/GM.ashx", { typeClass: "GetPageData", CurrentPage: CurrentPage, PageSize: PageSize, Where: Where }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        TotalRecord = returnData.Total;
        TotalPage = parseInt(TotalRecord / PageSize) + (TotalRecord % PageSize > 0 ? 1 : 0);

        if (!loaded) {
            loaded = true;
            $table.bootstrapTable({
                height: 380,
                pagination: true,
                cache: false,
                pageList: [30, 50, 100],
                search: true,
                data: returnData.Rows,
                uniqueId: "ID",
                columns: [{
                    field: 'ID',
                    title: '主键ID',
                    valign: "middle",
                    align: "center",
                    width: "100",
                    visible:false
                }, {
                    field: 'TypeID',
                    title: '类型ID',
                    valign: "middle",
                    align: "center",
                    width: "150",
                    visible: false
                }, {
                    field: 'Title',
                    title: '标题',
                    valign: "middle",
                    align: "center",
                    width: "120"
                }, {
                    field: 'Descript',
                    title: '描述',
                    valign: "middle",
                    align: "center",
                    width: "200"
                }, {
                    field: 'IsClassical',
                    title: '是否经典',
                    valign: "middle",
                    formatter: function (value, row, index) {
                        if (value) {
                            return '<span class="glyphicon glyphicon-thumbs-up" aria-hidden="true"></span>&nbsp;&nbsp;经典';
                        } else {
                            return '<span class="glyphicon glyphicon-star-empty" aria-hidden="true"></span>&nbsp;&nbsp;普通';
                        }
                    },
                    align: "center",
                    width: "60"
                }, {
                    field: 'DemoFile',
                    title: '示例文件',
                    valign: "middle",
                    align: "center",
                    width: "100"
                }, {
                    field: 'Tags',
                    title: '标签',
                    valign: "middle",
                    align: "center",
                    width: "100"
                },{
                    title: '操作',
                    formatter: function (value, row, index) {
                        return '<button type="button" class="btn btn-primary" onclick="ShowEdit(\'' + row.ID + '\')"><span class="glyphicon glyphicon-edit"></span></button>&nbsp;&nbsp;' +
                               '<button type="button" class="btn btn-danger" onclick="DelGM(\'' + row.ID + '\')"><span class="glyphicon glyphicon-remove"></span></button>';
                    },
                    align: "center",
                    width: "80"
                }]
            });
        } else {
            $table.bootstrapTable('load', returnData.Rows);
        }

        if (TotalPage > 0) {
            InitPage();
        }
    });
}

/*
*修改
*id：语法ID
*/
function ShowEdit(id) {
    location.href = "MyGMEdit.aspx?id=" + id;
}

/*
*新增
*/
function Add() {
    location.href = "MyGMEdit.aspx";
}

/*
*删除
*id：语法ID
*/
function DelGM(id) {
    Confirm(function (r) {
        if (r) {
            PostData("../../Ashx/GM.ashx", { typeClass: "DelGM", ID: id }, function (returnData) {
                if (returnData.Code != 200) {
                    AlertMsg(returnData.Msg, "err");
                    return;
                }
                AlertMsg(returnData.Msg, "info");
                InitTable(CurrentPage, PageSize, Where);
            });
        }
    })
}

/*
*初始化树形
*/
function InitTree() {
    //初始化左边树形
    PostData("../../Ashx/GM.ashx", { typeClass: "GetTreeGM" }, function (returnData) {
        if (returnData.Code != 200) {
            AlertMsg(returnData.Msg, "err");
            return;
        }
        var menuTree = JSON.parse(returnData.Data);  //将语法字符串数据转换成Json数据
        //初始化左边树形
        $('#treeview').treeview({
            levels: 3,
            color: "#428bca",
            showBorder: false,
            data: menuTree,
            onNodeSelected: function (event, data) {
                Where = "TypeID = '" + data.id + "'";
                InitTable(CurrentPage, PageSize, Where);
            }            
        });        
    });
}
