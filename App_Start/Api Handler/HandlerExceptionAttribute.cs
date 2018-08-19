using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net;
using System.Web;

namespace Swagger.Demo.Api
{
    /// <summary>
    /// Api Action异常过滤器
    /// </summary>
    public class HandlerExceptionAttribute : ExceptionFilterAttribute
    {
        /// <summary>
        /// 控制器方法中出现异常，会调用该方法捕获异常
        /// </summary>
        /// <param name="context">提供使用</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            WriteLog(context);
            //TODO : 异常处理逻辑
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError); ;
            context.Response.Content = new StringContent(context.Exception.Message);
        }

        /// <summary>
        /// 写入日志（log4net）
        /// </summary>
        /// <param name="context">提供使用</param>
        private void WriteLog(HttpActionExecutedContext context)
        {
            if (context == null)
                return;
            //TODO : 异常记录至文件          
        }
    }
}
