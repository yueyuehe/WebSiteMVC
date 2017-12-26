using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Interface
{
    public interface IDbSession<T>
    {
        /// <summary>
        /// 保存修改
        /// </summary>
        /// <returns></returns>
        int SaveChange();
    }
}
