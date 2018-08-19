using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// 生产任务单
    /// </summary>
    public class ProTaskBillDto
    {
        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 单据号
        /// </summary>
        public string BillNo { get; set; }

        /// <summary>
        /// 产品简称 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 批次
        /// </summary>
        public string BatchNo { get; set; }

        /// <summary>
        /// 品牌
        /// </summary>
        public string BrandName { get; set; }

        /// <summary>
        /// 规格
        /// </summary>
        public string SpecName { get; set; }

        /// <summary>
        /// 装箱数量
        /// </summary>
        public int PackageCount { get; set; }

        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }

        /// <summary>
        /// 增长属性
        /// </summary>
        public int GrowIndex { get; set; }
        #endregion
    }
}
