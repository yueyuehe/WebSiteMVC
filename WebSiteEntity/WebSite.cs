using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity
{
    /// <summary>
    /// 网站的基本信息
    /// </summary>
    public class WebSite
    {
        // 网站基本信息
        // 网站ID
        public int Id { get; set; }
        // 网站名称
        public string Name { get; set; }
        // 网站地址
        public string WebUrl { get; set; }
        // 网站logo
        public string Logo { get; set; }
        // 地址栏图标
        public string Icon { get; set; }
        //SEO
        //title
        public string Title { get; set; }
        // 网站关键词
        public string Keyword { get; set; }
        // 网站描述
        public string Description { get; set; }
       
        //版权信息
        public string Copyright { get; set; }
        //地址邮编
        public string Place { get; set; }
        public string ZipCode { get; set; }
        //联系方式
        public string Phone { get; set; }
        public string Email { get; set; }
        //其他信息
        public string Others { get; set; }

        //创建时间
        public DateTime? CreateDate { get; set; }

    }
}
