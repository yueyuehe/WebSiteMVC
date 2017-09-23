using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Produce
    {
        public int Id { get; set; }
        //内容
        public string Name { get; set; }

        public decimal Price { get; set; }
        public string Spec { get; set; }

        public string Brand { get; set; }

        public string Images { get; set; }

        public List<string> ImageList { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 想详细描述
        /// </summary>
        public string Discription { get; set; }


        /// <summary>
        /// 指定
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 是否热销
        /// </summary>
        public bool IsSellHot { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishDate { get; set; }
        
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        public int PageView { get; set; }
    }
}
