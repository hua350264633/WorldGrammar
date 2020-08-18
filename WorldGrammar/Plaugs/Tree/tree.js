/*
*绑定菜单点击事件
*/
function BindMenu()
{
    //加载时设置样式
    $('.tree li:has(ul)').addClass('parent_li').find(' > span').attr('title', 'Collapse this branch');
    $(".tree").find("i").css("margin-right", "5px");
    //顶级节点绑定点击事件
    $('.tree>ul>li>span').on('click', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            //隐藏节点
            children.hide('fast');
            $(this).attr('title', 'Collapse this branch').find(' > i').addClass('glyphicon-folder-close').removeClass('glyphicon-folder-open');
        } else {
            //显示节点
            children.show('fast');
            $(this).attr('title', 'Expand this branch').find(' > i').addClass('glyphicon-folder-open').removeClass('glyphicon-folder-close');
        }
        e.stopPropagation();
    });

    //子节点绑定点击事件
    $('.tree>ul>li').find(".parent_li > span").on('click', function (e) {
        var children = $(this).parent('li.parent_li').find(' > ul > li');
        if (children.is(":visible")) {
            //隐藏节点
            children.hide('fast');
            $(this).attr('title', 'Collapse this branch').find(' > i').addClass('glyphicon-plus-sign').removeClass('glyphicon-minus-sign');
        } else {
            //显示节点
            children.show('fast');
            $(this).attr('title', 'Expand this branch').find(' > i').addClass('glyphicon-minus-sign').removeClass('glyphicon-plus-sign');
        }
        e.stopPropagation();
    });
}

/*
*折叠/显示所有可点击的节点
*/
function foldAll() {
    $(".tree li.parent_li > span").each(function (i, o) {
        $(o).click();
    });
}