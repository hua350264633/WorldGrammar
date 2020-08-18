using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ML.Accounts;
using ML.Common;
using System.Web.Security;

namespace WorldGrammar.Ashx
{
    /// <summary>
    /// Site.Master 母版页后台处理类
    /// </summary>
    public class MasterPage : ParentAshx,IHttpHandler
    {
        DatagridModel<object> dataGridModel = new DatagridModel<object>();
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                base.ProcessRequest(context);
                //验证用户是否登录
                if (!IsLogin())
                {
                    var dataGridModel = new DatagridModel<object>();
                    dataGridModel.Msg = "登录超时,请重新登录";
                    dataGridModel.Code = CodeEnum.LoginOutTime;
                    dataGridModel.Data = base.LoginUrl;
                    JsonResult = JsonData.GetResult(dataGridModel);
                }
                else
                {
                    switch (typeClass)
                    {
                        case "LoadMenu":
                            JsonResult = Menu;
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                dataGridModel.Msg = ex.Message;
                dataGridModel.Code = CodeEnum.Exception;
                JsonResult = JsonData.GetResult(dataGridModel);
            }
            context.Response.Write(JsonResult);
            context.Response.End();
        }

        public override bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}