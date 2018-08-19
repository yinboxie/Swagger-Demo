using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Swagger.Demo.Api
{
    /// <summary>
    /// （权限认证+安全）拦截组件
    /// </summary>
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// 权限认证
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            //权限认证忽略
            if (filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
               || filterContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }

            //从http请求的头里面获取身份验证信息，验证是否是请求发起方的ticket
            var request = filterContext.Request; var token = "";
            if (request.Headers.Contains("token"))
            {
                token = request.Headers.GetValues("token").SingleOrDefault();
            }
            //因为IE浏览器，token传空值时，请求不需要授权的函数会报跨域错误，所以前端给了固定值token
            if (!string.IsNullOrEmpty(token) && token != "token")
            {
                //TODO: 验证token是否有效,并形成唯一登录值
                
            }
            else
            {
                //要求身份认证
                filterContext.Response = new HttpResponseMessage(HttpStatusCode.NotAcceptable);
            }
        }
    }
}