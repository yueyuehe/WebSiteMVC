using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface;
using WebSiteEntity;

namespace WebSiteBLL.Implements
{
    public class WebModuleBll : BaseBll<WebModule>, IWebModuleBll
    {
        /// <summary>
        ///判断对象是否存在p
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool IsExist(int id)
        {
            var query = Find(model => model.Id == id);
            return query.Count() > 0;
        }
        public override void Delete(int id)
        {
            var query = Find(model => model.Id == id);
            if (query.Count() > 0)
            {
                dal.Delete(query.ToList()[0]);
            }
        }

        /// <summary>
        /// 根据ID查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override WebModule FindById(int id)
        {
            var query = Find(model => model.Id == id);
            if (query.Count() > 0)
            {
                return query.ToList()[0];
            }
            return null;
        }
    }
}
