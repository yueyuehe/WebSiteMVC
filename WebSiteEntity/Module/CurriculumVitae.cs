using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class CurriculumVitae
    {
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }


        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace { get; set; }

        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 学位
        /// </summary>
        public string Degree { get; set; }

        public string School { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string Profession { get; set; }

        public string HomePlace { get; set; }

        /// <summary>
        /// 所获奖项
        /// </summary>
        public string Award { get; set; }

        /// <summary>
        /// 职业经理
        /// </summary>
        public string WorkHistory { get; set; }

        /// <summary>
        /// 爱好
        /// </summary>
        public string Hobby { get; set; }

        /// <summary>
        /// 个人照片
        /// </summary>
        public string PersionPhoto { get; set; }

        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? CommiteDate { get; set; }
        /// <summary>
        /// 应聘职位
        /// </summary>
        public Job ApplyJob { get; set; }
    }
}
