using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity
{
    /// <summary>
    /// 网站栏目
    /// </summary>
    public class WebColumn
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 所属网站
        /// </summary>
        public WebSite WebSite { get; set; }
        /// <summary>
        /// 栏目排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 栏目名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 导航兰位置
        /// </summary>
        public NavPosition Position { get; set; }
        /// <summary>
        /// 模块
        /// </summary>
        public ModuleType ModuleType { get; set; }
        //是否新窗口打开
        public bool IsOpenNew { get; set; }
        /// <summary>
        /// 是否可添加内容
        /// </summary>
        public bool CanAddContent { get; set; }
        //SEO
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 父栏目
        /// </summary>
        public WebColumn Parent { get; set; }
        /// <summary>
        ///栏目等级 1,2,3
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// 前台显示
        /// </summary>
        public bool IsShow { get; set; }
    }
}
