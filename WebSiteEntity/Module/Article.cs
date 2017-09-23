using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Article
    {
        public int Id { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 图片 用逗号隔开保存到数据库中 取出后再分割保存到ImageList
        /// </summary>
        public string Images { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public List<string> ImageList { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// 发布日期
        /// </summary>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// 排序号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsRecommend { get; set; }

        /// <summary>
        /// 访问量
        /// </summary>
        public int PageView { get; set; }


        /// <summary>
        /// 所属网站栏目
        /// </summary>
        public WebColumn WebColumn { get; set; }
    }
}
