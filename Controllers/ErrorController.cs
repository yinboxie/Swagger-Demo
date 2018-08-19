using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swagger.Demo.Api.Controllers
{
    /// <summary>
    /// 描 述：错误处理
    /// </summary>
    public class ErrorController : Controller
    {
        #region 视图功能
        /// <summary>
        /// 错误页面（异常页面）
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public ActionResult ErrorMessage(string message)
        {
            Dictionary<string, string> modulesError = (Dictionary<string, string>)HttpContext.Application["error"];
            ViewData["Message"] = modulesError;
            return View();
        }
        /// <summary>
        /// 错误页面（错误路径404）
        /// </summary>
        /// <returns></returns>
        public ActionResult Error404(string errorUrl)
        {
            ViewBag.ErrorUrl = errorUrl;
            return View();
        }
        /// <summary>
        /// 错误页面（内部错误500）
        /// </summary>
        /// <returns></returns>
        public ActionResult Error500(string data)
        {
            return View(data);
        }
        /// <summary>
        /// 错误页面（升级浏览器软件）
        /// </summary>
        /// <returns></returns>
        public ActionResult ErrorBrowser()
        {
            return View();
        }
        #endregion
	}
}