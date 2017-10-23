using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSiteBLL.Interface.Module;
using WebSiteEntity.Module;

namespace WebSiteBLL.Implements.Module
{
    public class SummaryBll : BaseBll<Summary>, ISummaryBll
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
                this.Delete(query.ToList()[0]);
            }
        }
        public override Summary FindById(int id)
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
