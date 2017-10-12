using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteEntity.Module;

namespace WebSiteBLL.Interface.Module
{
    public interface IArticleBll : IBaseBll<Article>
    {
        List<Article> GetArticlesByColumnID(int id);

        /// <summary>
        /// 获取网站所有的文章
        /// </summary>
        /// <param name="websiteId"></param>
        /// <returns></returns>
        List<Article> GetArticles(int websiteId);
    }
}
