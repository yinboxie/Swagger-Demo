using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Swashbuckle.Swagger.Annotations;

namespace Swagger.Demo.Api.Areas.Bms.Controllers
{
    /// <summary>
    /// 仓库数据
    /// </summary>
    public class WareController : ApiController
    {
        #region 获取数据
        /// <summary>
        /// 获取仓库列表
        /// </summary>
        /// <remarks>
        /// 用于同步数据至手持设备<br/>
        /// </remarks>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Wait, Time = "2018-07-26")]
        public void GetList()
        {
        }

        /// <summary>
        /// 获取仓库信息
        /// </summary>
        /// <param name="keyValue">主键值或仓库编码</param>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Wait, Time = "2018-07-26")]
        public string GetEntity(string keyValue)
        {
            return "";
        }
        #endregion
    }
}
