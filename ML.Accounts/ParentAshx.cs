using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using ML.Model;
using System.Web.SessionState;
using ML.Accounts.Control;
using ML.Common;
using System.Web.Security;

namespace ML.Accounts
{
    public class ParentAshx : GlobleConfig, IHttpHandler, IRequiresSessionState
    {
        #region 字段
        
        private AccountsPrincipal _account;        
        private User _userInfo;

        #endregion

        #region 属性

        /// <summary>
        /// 数据上下文
        /// </summary>
        public HttpContext context { get; set; }

        /// <summary>
        /// 请求过来的处理函数名
        /// </summary>
        public string typeClass { get; set; }

        /// <summary>
        /// 返回的json字符串
        /// </summary>
        public string JsonResult { get; set; }
        
        /// <summary>
        ///  数据上下文对象
        /// </summary>
        public AccountsPrincipal Account
        {
            get { return _account; }
            set { _account = value; }
        }

        /// <summary>
        ///  用户信息
        /// </summary>
        public User UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        #endregion

        /// <summary>
        /// 加载时处理
        /// </summary>
        /// <param name="context"></param>
        public virtual void ProcessRequest(HttpContext context)
        {
            this.context = context;
            this.typeClass = context.Request["typeClass"];
        }

        /// <summary>
        /// 判断是否登陆
        /// </summary>
        public bool IsLogin()
        {
            if (context.User.Identity.IsAuthenticated)
            {
                _account = (AccountsPrincipal)context.Session["Accounts"];
                if (_account == null)
                {
                    _account = new AccountsPrincipal(context.User.Identity.Name);
                    _userInfo = _account.CurrUser;
                    context.Session["Accounts"] = _account;
                }
                if (context.Session["LoginName"] == null)
                {
                    context.Session["LoginName"] = _account.CurrUser.LoginName;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 菜单列表
        /// </summary>
        public string Menu
        {
            get
            {
                var dataGridModel = new DatagridModel<S_Menu>();
                dataGridModel.Rows = Account.MenuList;
                dataGridModel.Msg = "菜单加载成功！";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
        }

        public virtual bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
