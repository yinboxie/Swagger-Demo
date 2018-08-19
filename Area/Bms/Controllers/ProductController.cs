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

namespace Swagger.Demo.Api.Areas.Bms.Controllers
{
    /// <summary>
    /// 产品数据
    /// </summary>
    public class ProductController : ApiController
    {

        #region 获取数据
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <remarks>
        /// 用于同步数据至手持设备<br/>
        /// </remarks>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Wait, Time = "2018-07-26")]
        [AllowAnonymous]
        public IEnumerable<MaterielDto> GetList(int index)
        {
            return new List<MaterielDto>();
        }

        /// <summary>
        /// 获取产品信息
        /// </summary>
        /// <param name="keyValue">主键值或产品编码</param>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Dev, Time = "2018-07-26")]
        public string GetEntity(string keyValue)
        {
            return "";
        }

        /// <summary>
        /// 获取产品分页列表
        /// </summary>
        /// <param name="page">当前分页</param>
        /// <param name="pageSize">每页数量</param>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthor(Name = "yinbo.xie", Status = DevStatus.Finish, Time = "2018-08-01")]
        public string GetPageList(int page, int pageSize)
        {
            return "";
        }
        #endregion
    }
}
