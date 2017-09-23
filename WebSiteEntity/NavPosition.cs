using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSiteEntity
{
    public enum NavPosition
    {
        /// <summary>
        /// 头导航栏
        /// </summary>
        TopNav,
        /// <summary>
        ///  底部导航条
        /// </summary>
        BottomNav,
        /// <summary>
        /// 不放在导航条
        /// </summary>
        NoneNav,
        /// <summary>
        /// 都显示
        /// </summary>
        BothNav,
    }
}
