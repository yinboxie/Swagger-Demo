using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swagger.Demo.Api.Controllers
{
    /// <summary>
    /// 首页
    /// </summary>
    public class HomeController : Controller
    {

        #region 视图功能
        /// <summary>
        /// 初始化页面
        /// </summary>
        public ActionResult Index()
        {
            return View();
        }  
        #endregion  
    }
}
