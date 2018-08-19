using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Swashbuckle.Application;
using Swagger.Demo.Api;
using System.Web.Http.Description;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]
namespace Swagger.Demo.Api
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            ConfigureSwaggerUi();
        }

        private static void ConfigureSwaggerUi()
        {
            //访问地址: http://localhost:11008//apis/index
            GlobalConfiguration.Configuration.EnableSwagger(c =>
                {
                    c.MultipleApiVersions(ResolveAreasSupportByRouteConstraint, (vc) =>
                    {
                        vc.Version("v1", "Common API", true).Description("登录，公共服务")
                        .Contact(x =>
                        {
                            x.Name("2018").Email("nj_ybxie@sina.com").Url("https://www.cnblogs.com/xyb0226/");
                        }); ;

                        vc.Version("Bms", "基础资料 API").Description("基础数据");
                        vc.Version("Mes", "生产管理 API").Description("生产管理");
                    });

                    //增加token至请求头部
                    c.ApiKey("Authorization").Description("token 唯一值").In("header").Name("token");

                    //xml描述文档
                    c.IncludeXmlComments(string.Format("{0}/bin/Application.XML", AppDomain.CurrentDomain.BaseDirectory));
                    c.IncludeXmlComments(string.Format("{0}/bin/Swagger.Demo.Api.XML", AppDomain.CurrentDomain.BaseDirectory));

                    //增加Swagger区域选择
                    c.DocumentFilter<SwaggerAreasSupportDocumentFilter>();

                    //增加上传文件过滤操作
                    c.OperationFilter<AddUploadOperationFilter>();

                    //显示开发者信息
                    c.ShowDeveloperInfo();
                })
                .EnableSwaggerUi("apis/{*assetPath}", c =>
                {
                    c.InjectStylesheet(typeof(SwaggerConfig).Assembly, "Swagger.Demo.Api.Swagger.theme-flattop.css");
                    c.InjectJavaScript(typeof(SwaggerConfig).Assembly, "Swagger.Demo.Api.Swagger.translator.js");

                    c.EnableApiKeySupport("Authorization", "header");
                });
        }

        private static bool ResolveAreasSupportByRouteConstraint(ApiDescription apiDescription, string targetApiVersion)
        {
            if (targetApiVersion == "v1")
            {
                return apiDescription.Route.RouteTemplate.StartsWith("api/{controller}");
            }
            var routeTemplateStart = "api/" + targetApiVersion;
            return apiDescription.Route.RouteTemplate.StartsWith(routeTemplateStart);
        }
    }
}
