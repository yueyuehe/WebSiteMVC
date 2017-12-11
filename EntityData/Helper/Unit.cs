using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Helper
{
    public class Unit
    {

        /// <summary>
        /// 判断一个类是否是另一个类的子类
        /// </summary>
        /// <param name="type">子类</param>
        /// <param name="baseType">基类</param>
        /// <returns></returns>
        static bool IsSubClassOf(Type type, Type baseType)
        {
            var b = type.BaseType;
            while (b != null)
            {
                if (b.Equals(baseType))
                {
                    return true;
                }
                b = b.BaseType;
            }
            return false;
        }
    }
}
