using ML.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ML.Common;
using ML.Accounts;
using System.IO;

namespace WorldGrammar.Ashx
{
    /// <summary>
    /// 文件上传处理程序
    /// </summary>
    public class FileUpLoad : ParentAshx,IHttpHandler
    {
        /// <summary>
        /// 允许上传文件的扩展类型
        /// </summary>
        private string extension = Common.GetAppSetting("extension");

        /// <summary>
        /// 文件上传根目录
        /// </summary>
        private string uploadFolder = Path.Combine(HttpContext.Current.Server.MapPath("~"), "Upload"); 

        /// <summary>
        /// 返回实体对象
        /// </summary>
        DatagridModel <FileUpLoadEntity> dataGridModel = new DatagridModel<FileUpLoadEntity>();

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            //设置相应内容类型
            context.Response.ContentType = "application/json";
            try
            {
                switch (typeClass)
                {
                    case "Upload":
                        JsonResult = Upload(context);
                        break;
                    case "DelFile":
                        JsonResult = DelFile(context);
                        break;
                    default:
                        break;
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

        /// <summary>
        /// 文件上传逻辑
        /// </summary>
        /// <param name="context">请求上下文对象</param>
        /// <returns></returns>
        public string Upload(HttpContext context)
        {
            try
            {
                FileUpLoadEntity fule = new FileUpLoadEntity();

                //这里只能用<input type="file" />才能有效果,因为服务器控件是HttpInputFile类型
                HttpFileCollection files = context.Request.Files;
                if (files.Count == 0)
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = "没有上传的文件";
                    return JsonData.GetResult(dataGridModel);
                }

                var Extension = Path.GetExtension(files[0].FileName).ToLower().Replace(".", "");  //获取扩展名
                if (!extension.ToLower().Contains(Extension))
                {
                    dataGridModel.Code = CodeEnum.Error;
                    dataGridModel.Msg = "上传的文件类型，服务器不允许";
                    return JsonData.GetResult(dataGridModel);
                }

                var tempFolder = Path.Combine(uploadFolder, Extension.ToUpper());
                if (!Directory.Exists(tempFolder))
                {
                    Directory.CreateDirectory(tempFolder);
                }
                fule.FileName = Extension.ToUpper() + "/" + DateTime.Now.ToString("yyyyMMddHHmmssff") + "_" + Path.GetFileName(files[0].FileName);
                files[0].SaveAs(Path.Combine(uploadFolder, fule.FileName));

                dataGridModel.Code = CodeEnum.Success;
                dataGridModel.Msg = "文件上传成功！";
                dataGridModel.Data = fule;

                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="context">请求上下文对象</param>
        /// <returns></returns>
        public string DelFile(HttpContext context)
        {
            try
            {
                var filePath = context.Request["FilePath"];  //相对路径
                if (string.IsNullOrEmpty(filePath))
                {
                    dataGridModel.Msg = "要删除的文件路径“FilePath”不能为空";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }
                var fileFullPath = Path.Combine(uploadFolder, filePath);
                if (!File.Exists(fileFullPath))
                {
                    dataGridModel.Msg = "服务器上，文件不存在！！！";
                    dataGridModel.Code = CodeEnum.Error;
                    return JsonData.GetResult(dataGridModel);
                }
                File.Delete(fileFullPath);
                dataGridModel.Msg = "删除成功√";
                dataGridModel.Code = CodeEnum.Success;
                return JsonData.GetResult(dataGridModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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