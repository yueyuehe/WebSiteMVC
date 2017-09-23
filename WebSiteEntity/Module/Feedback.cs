using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Feedback
    {
        public int Id { get; set; }
        /// <summary>
        /// 反馈主题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 您的姓名
        /// </summary>
        public string PersionName { get; set; }
        /// <summary>
        /// 职业
        /// </summary>
        public string Job { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 公司单位
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 怎么找到我  后期用用枚举
        /// </summary>
        public string FindMeWay { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? CommintDate { get; set; }

        /// <summary>
        /// 反馈者身份
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// 网站冷漠
        /// </summary>
        public WebColumn WebColumn { get; set; }
    }
}
