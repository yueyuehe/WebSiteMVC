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
        public string Position { get; set; }
        //模块
        public WebModule WebModule { get; set; }
        //是否新窗口打开
        public bool IsOpenNewWindow { get; set; }
        //添加内容
        public bool CanAddContent { get; set; }
        //SEO
        //标题
        public string Title { get; set; }
        //关键字
        public string Keyword { get; set; }
        //描述
        public string Description { get; set; }
        //静态页面名称
        public string StaticName { get; set; }
        //
        //与模板相关
        // 栏目标识
        //public string Title { get; set; }
        //栏目修改名称
        //public string Title { get; set; }
        //栏目图片
        //public string Title { get; set; }
        //
        //父栏目
        public WebColumn Parent { get; set; }
        //栏目等级 1,2,3
        public int Level { get; set; }

        //权限
        //访问权限
        //前台显示
        public bool IsShow { get; set; }
    }
}
