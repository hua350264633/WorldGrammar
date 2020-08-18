using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ML.Common
{
    public static class JsonData
    {

        /// <summary>
        /// 序列化成json数据,忽略为NULL的值
        /// </summary>
        /// <param name="parm">对象</param>
        /// <returns></returns>
        public static string GetResult(object parm)
        {
            JsonSerializerSettings jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            return Newtonsoft.Json.JsonConvert.SerializeObject(parm, jSetting);
        }
        /// <summary>
        /// 序列化成json数据,包含日期、时间转换
        /// </summary>
        /// <param name="parm">对象</param>
        /// <returns></returns>
        public static string GetResult2(object parm)
        {
            //IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //timeConverter.DateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss";
            JsonSerializerSettings jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            jSetting.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            return Newtonsoft.Json.JsonConvert.SerializeObject(parm, jSetting);
        }
        /// <summary>
        /// 序列化成json数据,包含日期转换
        /// </summary>
        /// <param name="parm">对象</param>
        /// <returns></returns>
        public static string GetResult3(object parm)
        {
            //IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //timeConverter.DateTimeFormat = "yyyy-MM-dd";
            JsonSerializerSettings jSetting = new JsonSerializerSettings();
            jSetting.NullValueHandling = NullValueHandling.Ignore;
            jSetting.DateFormatString = "yyyy-MM-dd";
            return Newtonsoft.Json.JsonConvert.SerializeObject(parm, jSetting);
        } 
        /// <summary>
        /// 序列化成json数据
        /// </summary>
        /// <param name="parm">对象,该对象是一张二维表</param>
        /// <returns></returns>
        public static string GetResult(System.Data.DataTable dt)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(dt, new DataTableConverter());
        }
        /// <summary>
        /// 将json数据反序列化成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T JsonToModel<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
        /// <summary>
        /// 将json数据反序列化成实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<T> JsonToList<T>(string json)
        {
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
