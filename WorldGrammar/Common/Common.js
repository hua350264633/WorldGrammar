/*
*Post方式请求数据
*url：请求路径，必须携带typeClass(处理方法)
*param:请求参数，格式为：{ width:1680, height:1050 };
*callBack：请求成功后回调函数
*/
function PostData(url, param, callBack) {
    var data = "";
    if (param != null) {
        data = $.param(param);
    }
    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        cache: false,
        data: data,
        success: function (data) {
            if (callBack !== null && typeof(callBack) === "function") {
                callBack(data);
            }            
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("错误代码：" + XMLHttpRequest.status + ",错误信息：" + errorThrown);
        }
    });
}

/*
*在页面顶部创建一个提示框
*msg:提示文本
*type：提示框类型：info(默认)，suc,err,wor
*/
function AlertMsg(msg, type) {
    //处理已经存在提示框的问题
    var timeOutHandle = $("#tipsID").attr("timeOutHandle");
    if (timeOutHandle) {
        clearTimeout(timeOutHandle);
        $("#tipsID").remove();   //移除原有提示框
    }
    if (msg === "" || msg === undefined || msg === null) {
        alert("请输入要提示的msg");
        return;
    }
    var tipBox = "<div id='tipsID' class='alert alert-info' style='min-width:300px;position:fixed;top:0px;z-index:999;'>提示！" + msg + "</div>";
    switch (type) {
        case "suc":
            tipBox = "<div id='tipsID' class='alert alert-success' style='min-width:300px;position:fixed;top:0px;z-index:999;'>成功！" + msg + "</div>";
            break;
        case "err":
            tipBox = "<div id='tipsID' class='alert alert-danger' style='min-width:300px;position:fixed;top:0px;z-index:999;'>错误！" + msg + "</div>";
            break;
        case "wor":
            tipBox = "<div id='tipsID' class='alert alert-warning' style='min-width:300px;position:fixed;top:0px;z-index:999;'>异常！" + msg + "</div>";
            break;
    }
    //将文本放在页面的正上方
    $("body").append(tipBox);
    var tipBoxWidth = $("#tipsID").width();
    var windowWidth = document.body.offsetWidth;
    var leftVal = ((windowWidth - tipBoxWidth) / 2)+"px";
    $("#tipsID").css("left", leftVal);
    //三秒后删除提示框对象
    var handle = setTimeout(function () {
        $("#tipsID").remove();
    }, 3000);
    $("#tipsID").attr("timeOutHandle", handle);
}

/**
 * 重写确认框
 *title:提示标题
 *tips：提示文本
 */
function Confirm(Callback,title, tips) {
    if (title === undefined || title === "") {
        title = "温馨提示";
    }
    if (tips === undefined || tips === "") {
        tips = "是否确定要删除";
    }
    if ($("#myConfirm").length > 0) {
        $("#myConfirm").remove();
    }
    var html = "<div class='modal fade' id='myConfirm' >"
            + "<div class='modal-backdrop in' style='opacity:0; '></div>"
            + "<div class='modal-dialog' style='z-index:2901; margin-top:60px; width:400px; '>"
            + "<div class='modal-content'>"
            + "<div class='modal-header'  style='font-size:16px; '>"
            + "<span class='glyphicon glyphicon-envelope'>&nbsp;</span>" + title + "<button type='button' class='close' data-dismiss='modal'>"
            + "<span style='font-size:20px;  ' class='glyphicon glyphicon-remove'></span><tton></div>"
            + "<div class='modal-body text-center' id='myConfirmContent' style='font-size:18px; '>"
            + tips
            + "？"
            + "</div>"
            + "<div class='modal-footer ' style=''>"
            + "<button class='btn btn-danger ' id='confirmOk' >确定<tton>"
            + "<button class='btn btn-info ' data-dismiss='modal' id='confirmCancel'>取消<tton>"
            + "</div>" + "</div></div></div>";
    $("body").append(html);
    $("#myConfirm").modal("show");
    $("#confirmOk").on("click", function () {
        $("#myConfirm").modal("hide");
        if (typeof (Callback) === "function") {
            Callback(true);
        }
    });
    $("#confirmCancel").on("click", function () {
        $("#myConfirm").modal("hide");        
        if (typeof (Callback) === "function") {
            Callback(false);
        }
    });
}

/*
*表单提交
*@fromid： 表单ID
*@url： 提交地址
*@type： 提交类型：post/get(默认post)
*Callback:回调函数
**/
CommitForm = function (fromid, url, type, callBack) {
    if (type == undefined || type === '') {
        type = 'post';
    }
    var postData = $("#" + fromid).serialize();
    $.ajax({
        url: url,
        data: postData,
        dataType: 'json',
        type: type,
        async: false,
        success: function (data) {
            if (callBack !== null && typeof (callBack) === "function") {
                callBack(data);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("错误代码：" + XMLHttpRequest.status + ",错误信息：" + errorThrown);
        }
    });
}

/*
*清空表单
*formID:要清空的表单ID
*/
function ClearForm(formID) {
    $(':input', '#' + formID)
      .not(':button,:submit,:reset,:checkbox,:radio')   //将表单中input元素type为button、submit、reset、checkbox排除
      .val('')  //将input元素的value设为空值
      .removeAttr('checked')
      .removeAttr('checked')
}

/*
*格局化日期：
*date:日期对象
*type:格式类型：1：年月日，2：年月日时分秒
*/
function FormatDate(date,type) {
    var myyear = date.getFullYear();       //年
    var mymonth = date.getMonth() + 1;     //月
    var myday = date.getDate();            //日
    var myhours = date.getHours();         //时
    var myminutes = date.getMinutes();     //分
    var myseconds = date.getSeconds();     //秒

    if (mymonth < 10) {
        mymonth = "0" + mymonth;
    }
    if (myday < 10) {
        myday = "0" + myday;
    }

    if (myhours < 10) {
        myhours = "0" + myhours;
    }

    if (myminutes < 10) {
        myminutes = "0" + myminutes;
    }

    if (myseconds < 10) {
        myseconds = "0" + myseconds;
    }
    var returnStr = "";
    switch (type) {
        case "1":
            returnStr = (myyear + "-" + mymonth + "-" + myday);
            break;
        case "2":
            returnStr = (myyear + "-" + mymonth + "-" + myday + " " + myhours + ":" + myminutes + ":" + myseconds);
            break;

    }
    return returnStr;
}

//获取URL参数
function Request(requestName) {
    var Url = window.location.search;
    var requestValue = "";
    if (Url.indexOf("?") != -1) {
        var str = Url;
        var ParamCount = "";
        var name = new Array();
        var value = new Array();
        var ToTalParam = str.substring(str.indexOf("?") + 1); //
        ParamCount = ToTalParam.split("&").length; //
        for (var i = 0; i < ParamCount; i++) {
            name[name.length] = ToTalParam.split("&")[i].split("=")[0];
            value[value.length] = ToTalParam.split("&")[i].split("=")[1];
        }
        for (var i = 0; i < name.length; i++) {
            if (name[i] == requestName) {
                requestValue = value[i];
                break;
            }
        }

    }
    return requestValue;
}