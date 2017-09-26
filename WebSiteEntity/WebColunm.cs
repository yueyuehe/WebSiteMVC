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
        //id
        public int Id { get; set; }
        //网站
        public WebSite WebSite { get; set; }
        //排序
        public int Sort { get; set; }
        //名称
        public string Name { get; set; }
        //导航栏位置
        public NavPosition Position { get; set; }
        //模块
        public WebModule WebModule { get; set; }
        //是否新窗口打开
        public bool IsOpenNew { get; set; }
        //添加内容
        public bool CanAddContent { get; set; }
        //SEO
        //标题
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
