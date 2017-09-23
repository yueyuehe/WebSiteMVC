using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity.Module
{
    public class Message
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        //其他联系方式
        public string OtherContacts { get; set; }
        //消息内容
        public string MessageContent { get; set; }
        public DateTime? CommitDate { get; set; }
        //角色身份 游客或其他
        public string Role { get; set; }

        //权限 什么人可以查看
        public string Authority { get; set; }

        //回复内容
        public string ReplyContent { get; set; }

        //是否前台显示
        public bool IsShow { get; set; }

        //状态 0 待审核 -1 未通过 1 通过 最好通过枚举类型统一
        public int Status { get; set; }

        public WebColumn WebColumn { get; set; }
    }
}
