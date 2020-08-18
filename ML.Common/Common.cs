using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;
using System.Configuration; 

namespace ML.Common
{
    public static class Common
    {
        /// <summary>
        /// 将一个DataTable转换成实体类List
        /// </summary>
        /// <param name="dt">要转换的DataTable</param>
        /// <returns>返回一个实体类列表</returns>
        public static List<T> DT2EntityList<T>(DataTable dt)
        {
            List<T> entityList = new List<T>();
            if (dt == null || dt.Rows.Count == 0)
            {
                return entityList;
            }
            T entity = default(T);
            foreach (DataRow dr in dt.Rows)
            {
                entity = Activator.CreateInstance<T>();
                PropertyInfo[] pis = entity.GetType().GetProperties();
                foreach (PropertyInfo pi in pis)
                {
                    if (dt.Columns.Contains(pi.Name))
                    {
                        if (!pi.CanWrite)
                        {
                            continue;
                        }
                        if (dr[pi.Name] != DBNull.Value)
                        {
                            pi.SetValue(entity, dr[pi.Name], null);
                        }
                    }
                }
                entityList.Add(entity);
            }
            return entityList;
        }

        /// <summary>
        /// 判断是是否是数字
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool isNumber(string text)
        {
            int tmp = 0;
            if (int.TryParse(text, out tmp))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断是是否是数字
        /// </summary>
        /// <param name="text"></param>
        /// <param name="number">返回转换后数字</param>
        /// <returns></returns>
        public static bool isNumber(string text,out int number)
        {
            int tmp = 0;
            number = -1;
            if (int.TryParse(text, out tmp))
            {
                number = tmp;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 返回随机名称字符串
        /// </summary>
        /// <returns></returns>
        public static string GetDate()
        {
            string strName = DateTime.Now.Date.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            return strName;
        }

        /// <summary>
        /// 获取一个随机数(r值以内)
        /// </summary>
        /// <param name="r"></param>
        /// <returns></returns>
        public static string GetRnd(int r)
        {
            Random rd = new Random();
            return rd.Next(r).ToString();
        }

        /// <summary>
        /// 取得汉字拼音首字母
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetGbkX(string str)
        {
            string py = "";
            if (str.Length > 0)
            {

                for (int i = 0; i < str.Length; i++)
                {
                    py += GetGbk(str.Substring(i, 1));
                }
            }
            return py;
        }

        public static string GetGbk(string str)
        {
            if (str.CompareTo("吖") < 0)
            {
                return str;
            }
            if (str.CompareTo("八") < 0)
            {
                return "a";
            }

            if (str.CompareTo("嚓") < 0)
            {
                return "b";
            }

            if (str.CompareTo("咑") < 0)
            {
                return "c";
            }
            if (str.CompareTo("妸") < 0)
            {
                return "d";
            }
            if (str.CompareTo("发") < 0)
            {
                return "e";
            }
            if (str.CompareTo("旮") < 0)
            {
                return "f";
            }
            if (str.CompareTo("铪") < 0)
            {
                return "g";
            }
            if (str.CompareTo("讥") < 0)
            {
                return "h";
            }
            if (str.CompareTo("咔") < 0)
            {
                return "j";
            }
            if (str.CompareTo("垃") < 0)
            {
                return "k";
            }
            if (str.CompareTo("嘸") < 0)
            {
                return "l";
            }
            if (str.CompareTo("拏") < 0)
            {
                return "m";
            }
            if (str.CompareTo("噢") < 0)
            {
                return "n";
            }
            if (str.CompareTo("妑") < 0)
            {
                return "o";
            }
            if (str.CompareTo("七") < 0)
            {
                return "p";
            }
            if (str.CompareTo("亽") < 0)
            {
                return "q";
            }
            if (str.CompareTo("仨") < 0)
            {
                return "r";
            }
            if (str.CompareTo("他") < 0)
            {
                return "s";
            }
            if (str.CompareTo("哇") < 0)
            {
                return "t";
            }
            if (str.CompareTo("夕") < 0)
            {
                return "w";
            }
            if (str.CompareTo("丫") < 0)
            {
                return "x";
            }
            if (str.CompareTo("帀") < 0)
            {
                return "y";
            }
            if (str.CompareTo("咗") < 0)
            {
                return "z";
            }             
          
            return str;
        }

        /// <summary>
        /// 获取config中AppSettings数据
        /// </summary>
        /// <returns></returns>
        public static string GetAppSetting(string key)
        {
           return  ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 计算两个日期的时间间隔
        /// </summary>
        /// <param name="DateTime1">第一个日期和时间</param>
        /// <param name="DateTime2">第二个日期和时间</param>
        /// <returns></returns>
        public static TimeSpan DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }

    }
                                                                
}
