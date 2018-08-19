using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Application;
using Swashbuckle.Swagger.Annotations;

namespace Swagger.Demo.Api.Areas.Mes.Controllers
{
    /// <summary>
    /// 生产任务
    /// </summary>
    public class MTaskController : ApiController
    {

        #region 获取数据
        /// <summary>
        /// 获取生产任务单列表
        /// </summary>
        /// <param name="index">增长属性</param>
        /// <remarks>
        /// </remarks>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Wait, Time = "2018-08-07")]
        public IEnumerable<ProTaskBillDto> GetList(int index)
        {
            return null;
        }

        /// <summary>
        /// 获取生产任务单
        /// </summary>
        /// <param name="keyValue">任务单主键或任务单据号</param>
        /// <remarks>
        /// 生产赋码时，可按生产任务单进行赋码<br/>
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Wait, Time = "2018-07-26")]
        public string GetEntity(string keyValue)
        {
            return "";
        }
        #endregion

        #region 提交数据
        #endregion
    }
}
