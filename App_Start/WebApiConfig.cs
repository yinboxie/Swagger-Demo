using Application;
using Newtonsoft.Json;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;

namespace Swagger.Demo.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            var allowedOrigins = ConfigHelper.GetValue("CORS:AllowedOrigins");//允许的请求域名
            var allowedHeaders = ConfigHelper.GetValue("CORS:AllowedHeaders");//允许的请求头部
            var allowedMethods = ConfigHelper.GetValue("CORS:AllowedMethods");//允许的请求方法
            config.EnableCors(new EnableCorsAttribute(allowedOrigins, allowedHeaders, allowedMethods));

            //配置Action权限过滤器
            config.Filters.Add(new HandlerAuthorizeAttribute());

            //配置异常处理过滤器
            config.Filters.Add(new HandlerExceptionAttribute());

            //配置Action动作结束过滤器
            config.Filters.Add(new ApiResultAttribute());

            //命名空间支持
            config.Services.Replace(typeof(IHttpControllerSelector), new NamespaceHttpControllerSelector(config));

            // Web API 路由

            config.Routes.MapHttpRoute(
               name: "BmsApi",
               routeTemplate: "api/Bms/{controller}/{action}/{id}",
               defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional, namespaces = new string[] { "Swagger.Demo.Api.Areas.Bms.Controllers" } });

            config.Routes.MapHttpRoute(
               name: "MesApi",
               routeTemplate: "api/Mes/{controller}/{action}/{id}",
               defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional, namespaces = new string[] { "Swagger.Demo.Api.Areas.Mes.Controllers" } });

            config.Routes.MapHttpRoute(
                name: "CommonApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { action = RouteParameter.Optional, id = RouteParameter.Optional, namespaces = new string[] { "Swagger.Demo.Api.ApiControllers" } }
            );

            //默认返回 json  
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "json", "application/json"));
            //返回格式选择 datatype 可以替换为任何参数   
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("datatype", "xml", "application/xml"));
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings =
                new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local,
                    Culture = CultureInfo.GetCultureInfo("zh-CN"),
                    DateFormatString = "yyyy-MM-dd HH:mm:ss"
                };
        }
    }
}
