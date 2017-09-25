using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteEntity;

namespace WebSiteBLL.Interface
{
    public interface IWebColumnBll : IBaseBll<WebColumn>
    {
        /// <summary>
        /// 根据ID找到相关联的父栏目和子栏目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<WebColumn> FindChildAndParent(int id);
    }
}
