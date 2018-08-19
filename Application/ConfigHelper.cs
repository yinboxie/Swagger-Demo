using System;
using System.Configuration;
using System.Linq;
using System.Web;
namespace Application
{
    /// <summary>
    /// WebConfig AppSetting文件操作
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 根据Key取Value值
        /// </summary>
        /// <param name="key"></param>
        public static string GetValue(string key)
        {
            var r = ConfigurationManager.AppSettings[key];
            if (r == null)
            {
                return "";
            }
            else
            {
                return r.ToString().Trim();
            }
        }
        
    }
}
