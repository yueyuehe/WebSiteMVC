using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData
{
    public class ParameterCollection
    {
        List<SqlParameter> list = new List<SqlParameter>();

        //
        // 摘要:
        //     初始化 System.Data.Common.SqlParameterCollection 类的新实例。
        public ParameterCollection()
        {

        }

        //
        // 摘要:
        //     获取并设置指定索引处的 System.Data.Common.SqlParameter。
        //
        // 参数:
        //   index:
        //     参数的从零开始的索引。
        //
        // 返回结果:
        //     指定索引处的 System.Data.Common.SqlParameter。
        //
        // 异常:
        //   T:System.IndexOutOfRangeException:
        //     指定的索引不存在。
        public SqlParameter this[int index]
        {
            get
            {
                return list[index];
            }
            set
            {
                list[index] = value;
            }
        }
        //
        // 摘要:
        //     获取并设置具有指定名称的 System.Data.Common.SqlParameter。
        //
        // 参数:
        //   parameterName:
        //     参数名。
        //
        // 返回结果:
        //     具有指定名称的 System.Data.Common.SqlParameter。
        //
        // 异常:
        //   T:System.IndexOutOfRangeException:
        //     指定的索引不存在。
        public SqlParameter this[string parameterName]
        {
            get
            {
                foreach (var item in list)
                {
                    if (item.ParameterName == parameterName)
                    {
                        return item;
                    }
                }
                return null;
            }
            set
            {
                list.Add(value);
            }
        }

        //
        // 摘要:
        //     指定集合中项的数目。
        //
        // 返回结果:
        //     集合中的项数。

        public int Count { get { return list.Count(); } }





        //
        // 摘要:
        //     将指定的 System.Data.Common.SqlParameter 对象添加到 System.Data.Common.SqlParameterCollection
        //     中。
        //
        // 参数:
        //   value:
        //     要添加到集合中的 System.Data.Common.SqlParameter 的 System.Data.Common.SqlParameter.Value。
        //
        // 返回结果:
        //     集合中 System.Data.Common.SqlParameter 对象的索引。
        public void Add(SqlParameter value)
        {
            list.Add(value);
        }
        public void Add(string name, object value)
        {
            list.Add(new SqlParameter(name, value));
        }


        //
        // 摘要:
        //     将具有指定值的项的数组添加到 System.Data.Common.SqlParameterCollection。
        //
        // 参数:
        //   values:
        //     要添加到集合的 System.Data.Common.SqlParameter 类型值的数组。
        public void AddRange(IEnumerable<SqlParameter> values)
        {
            list.AddRange(values);
        }
        //
        // 摘要:
        //     从 System.Data.Common.SqlParameterCollection 中移除所有 System.Data.Common.SqlParameter
        //     值。
        public void Clear()
        {
            list.Clear();
        }
        //
        // 摘要:
        //     指示集合中是否包含具有指定 System.Data.Common.SqlParameter.Value 的 System.Data.Common.SqlParameter。
        //
        // 参数:
        //   value:
        //     要在集合中查找的 System.Data.Common.SqlParameter 的 System.Data.Common.SqlParameter.Value。
        //
        // 返回结果:
        //     如果 System.Data.Common.SqlParameter 在集合中，则为 true；否则为 false。
        public bool Contains(SqlParameter value)
        {
            foreach (var item in list)
            {
                if (item.ParameterName == value.ParameterName)
                {
                    return true;
                }
            }
            return false;
        }
        //
        // 摘要:
        //     指示集合中是否存在具有指定名称的 System.Data.Common.SqlParameter。
        //
        // 参数:
        //   value:
        //     要在集合中查找的 System.Data.Common.SqlParameter 的名称。
        //
        // 返回结果:
        //     如果 System.Data.Common.SqlParameter 在集合中，则为 true；否则为 false。
        public bool Contains(string value)
        {
            foreach (var item in list)
            {
                if (item.ParameterName == value)
                {
                    return true;
                }
            }
            return false;
        }

        //
        // 摘要:
        //     返回指定的 System.Data.Common.SqlParameter 对象的索引。
        //
        // 参数:
        //   value:
        //     集合中的 System.Data.Common.SqlParameter 对象。
        //
        // 返回结果:
        //     指定的 System.Data.Common.SqlParameter 对象的索引。
        public int IndexOf(SqlParameter value)
        {
            return list.IndexOf(value);
        }
        //
        // 摘要:
        //     返回具有指定名称的 System.Data.Common.SqlParameter 对象的索引。
        //
        // 参数:
        //   parameterName:
        //     集合中 System.Data.Common.SqlParameter 对象的名称。
        //
        // 返回结果:
        //     具有指定名称的 System.Data.Common.SqlParameter 对象的索引。
        public int IndexOf(string parameterName)
        {
            foreach (var item in list)
            {
                if (item.ParameterName == parameterName)
                {
                    return list.IndexOf(item);
                }
            }
            return -1;


        }
        //
        // 摘要:
        //     将具有指定名称的 System.Data.Common.SqlParameter 对象的指定索引插入到集合中指定的索引位置。
        //
        // 参数:
        //   index:
        //     插入 System.Data.Common.SqlParameter 对象的索引位置。
        //
        //   value:
        //     要插入到集合中的 System.Data.Common.SqlParameter 对象。
        public void Insert(int index, SqlParameter value)
        {
            list.Insert(index, value);
        }
        //
        // 摘要:
        //     从集合中移除指定的 System.Data.Common.SqlParameter 对象。
        //
        // 参数:
        //   value:
        //     要移除的 System.Data.Common.SqlParameter 对象。
        public void Remove(SqlParameter value)
        {
            list.Remove(value);
        }
        //
        // 摘要:
        //     从集合中删除具有指定名称的 System.Data.Common.SqlParameter 对象。
        //
        // 参数:
        //   parameterName:
        //     要移除的 System.Data.Common.SqlParameter 对象的名称。
        public void Remove(string parameterName)
        {
            foreach (var item in list)
            {
                if (item.ParameterName == parameterName)
                {
                    list.Remove(item);
                    return;
                }
            }
        }
        //
        // 摘要:
        //     从集合中移除位于指定索引位置的 System.Data.Common.SqlParameter 对象。
        //
        // 参数:
        //   index:
        //     System.Data.Common.SqlParameter 对象所处的索引位置。
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }
        //
        // 摘要:
        //     返回具有指定名称的 System.Data.Common.SqlParameter 对象。
        //
        // 参数:
        //   parameterName:
        //     集合中 System.Data.Common.SqlParameter 的名称。
        //
        // 返回结果:
        //     具有指定名称的 System.Data.Common.SqlParameter 对象。
        protected SqlParameter GetParameter(string parameterName)
        {
            foreach (var item in list)
            {
                if (item.ParameterName == parameterName)
                {
                    return item;
                }
            }
            return null;
        }
        //
        // 摘要:
        //     返回集合中指定索引处的 System.Data.Common.SqlParameter 对象。
        //
        // 参数:
        //   index:
        //     集合中 System.Data.Common.SqlParameter 的索引。
        //
        // 返回结果:
        //     集合中指定索引处的 System.Data.Common.SqlParameter 对象。
        protected SqlParameter GetParameter(int index)
        {
            return list[index];
        }
        //
        // 摘要:
        //     将指定索引处的 System.Data.Common.SqlParameter 对象设置为一个新值。
        //
        // 参数:
        //   index:
        //     System.Data.Common.SqlParameter 对象所处的索引位置。
        //
        //   value:
        //     新 System.Data.Common.SqlParameter 值。
        protected void SetParameter(int index, SqlParameter value)
        {
            Insert(index, value);
        }
        //
        // 摘要:
        //     将具有指定名称的 System.Data.Common.SqlParameter 对象设置为新的值。
        //
        // 参数:
        //   parameterName:
        //     集合中 System.Data.Common.SqlParameter 对象的名称。
        //
        //   value:
        //     新 System.Data.Common.SqlParameter 值。
        protected void SetParameter(string parameterName, object value)
        {
            SqlParameter param = new SqlParameter(parameterName, value);
            list.Add(param);
        }
    }
}
