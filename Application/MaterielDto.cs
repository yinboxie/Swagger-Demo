using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// 物料信息
    /// </summary>
    public class MaterielDto
    {
        #region 属性
        /// <summary>
        /// 主键
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 编码
        /// </summary>
        public string EnCode { get; set; }
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName { get; set; }
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
        public int PackingNum { get; set; }
        /// <summary>
        /// 单位
        /// </summary>
        public string UnitName { get; set; }
        /// <summary>
        /// 排序码 
        /// </summary>
        public int SortCode { get; set; }
        /// <summary>
        /// 有效标记
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 删除标记
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 增长属性
        /// </summary>
        public int GrowIndex { get; set; }
        #endregion
    }
}
