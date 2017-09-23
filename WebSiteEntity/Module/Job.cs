using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Job
    {
        public int Id { get; set; }

        public String JobName { get; set; }
        //是否置顶
        public bool IsTop { get; set; }
        //是否急聘
        public bool IsEmergency { get; set; }
        //职位名称
        public String Place { get; set; }
        //工资
        public string Salary { get; set; }
        //招聘人数
        public int Number { get; set; }

        /// <summary>
        /// 到什么时候结束
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime? PublishDate { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Content { get; set; }

        /// <summary>
        /// 权限
        /// </summary>
        public String Authority { get; set; }

        /// <summary>
        /// 是否前台显示
        /// </summary>
        public bool IsShow { get; set; }

        public DateTime? CreateDate { get; set; }

        //创建人
        public string CreateUser { get; set; }

        /// <summary>
        /// 所属网站栏目
        /// </summary>
        public WebColumn WebColumn { get; set; }

        public int Sort { get; set; }
    }
}
