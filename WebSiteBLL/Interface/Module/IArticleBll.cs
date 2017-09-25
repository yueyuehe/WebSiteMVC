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
    }
}
