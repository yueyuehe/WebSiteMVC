using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Download
    {
        public int Id { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 下载地址
        /// </summary>
        public string DownloadLink { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public string Version { get; set; }

        public string FileType { get; set; }


        /// <summary>
        /// 简要说明
        /// </summary>
        public string About { get; set; }
        /// <summary>
        /// 文件描述
        /// </summary>
        public string FileDiscription { get; set; }

        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownloadCount { get; set; }

        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; }
        /// <summary>
        /// 置顶
        /// </summary>
        public bool IsTop { get; set; }

        /// <summary>
        /// 推荐
        /// </summary>
        public bool IsRecommend { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishDate { get; set; }
        /// <summary>
        /// 权限
        /// </summary>
        public string Authority { get; set; }
        /// <summary>
        /// 下载权限
        /// </summary>
        public string DownAuthority { get; set; }
        public string CreateUser { get; set; }

        public int PageView { get; set; }



        //SEO
        /// <summary>
        /// title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 关键字
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 网站栏目
        /// </summary>
        public WebColumn WebColumn { get; set; }
    }
}
