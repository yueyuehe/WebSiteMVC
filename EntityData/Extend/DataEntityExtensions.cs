using EntityData.Implement;
using EntityData.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Extend
{
    public static class DataEntityExtensions
    {
        #region 新增 修改 删除方法


        /// <summary>
        /// 向数据库插入当前数据实体
        ///  备注: 根据当前数据对象的值向数据库插入一条数据库记录。如果没有为对象添加任何属性，则不会产生任何效果。
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static void Insert<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            var context = dataEntity.GetDbContext();
            context.Set(dataEntity.GetType()).Attach(dataEntity);
            context.Entry(dataEntity).State = EntityState.Added;
            context.SaveChanges();
        }

        /// <summary>
        /// 保存数据实体值到数据库
        /// 备注:
        /// 根据当前数据对象的主键值判断是向数据库插入一条新记录还是更新现有记录。
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static void Save<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            if (dataEntity.ExistsInDb())
            {
                dataEntity.Update();
            }
            else
            {
                dataEntity.Insert();
            }
        }

        /// <summary>
        /// 更新数据实体值到数据库
        ///备注: 根据当前数据对象的值向数据库插入一条数据库记录。如果没有为对象添加任何属性，则不会产生任何效果。
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static void Update<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            var context = dataEntity.GetDbContext();
            context.Set(dataEntity.GetType()).Attach(dataEntity);
            context.Entry(dataEntity).State = EntityState.Modified;
            context.SaveChanges();
        }

        /// <summary>
        /// 从数据库中删除当前数据对象（对应的数据库记录）。
        /// 备注:删除后仍然可以使用 Save 方法将对象再次保存到数据库。
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static void Delete<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            //获取DbContext
            var context = dataEntity.GetDbContext();
            context.Set(dataEntity.GetType()).Attach(dataEntity);
            context.Entry(dataEntity).State = EntityState.Deleted;
            context.SaveChanges();
        }

        #endregion

        #region 加载数据 判断是否存在

        /// <summary>
        /// 从数据库读取  必须有Key特性
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static bool Read<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            var context = dataEntity.GetDbContext();
            var properties = dataEntity.GetType().GetProperties();
            var result = false;
            object model = null;
            foreach (var item in properties)
            {
                if (item.GetCustomAttribute(typeof(KeyAttribute)) != null)
                {
                    var keyValue = item.GetValue(dataEntity);
                    model = context.Set(dataEntity.GetType()).Find(keyValue);
                    break;
                }
            }
            if (model != null)
            {
                result = true;
                foreach (var item in properties)
                {
                    item.SetValue(dataEntity, item.GetValue(model));
                }
            }
            return result;
        }

        /// <summary>
        /// 判断数据实体是否在数据库中存在 必须有Key特性
        /// </summary>
        /// <param name="dataEntity">数据实体</param>
        public static bool ExistsInDb<T>(this IDataEntity<T> dataEntity) where T : DbContext, new()
        {
            var context = dataEntity.GetDbContext();
            var properties = dataEntity.GetType().GetProperties();
            foreach (var item in properties)
            {
                if (item.GetCustomAttribute(typeof(KeyAttribute)) != null)
                {
                    var keyValue = item.GetValue(dataEntity);
                    var model = context.Set(dataEntity.GetType()).Find(keyValue);
                    if (model == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            throw new Exception("未找到实体类主键");
        }
        #endregion


        /// <summary>
        /// 实体值复制、连同子对象和引用对象一并复制。
        /// </summary>
        /// <param name="dataEntity">源实体</param>
        /// <param name="target">目标实体</param>
        private static void CopyTo(this IDataEntity dataEntity, IDataEntity target)
        {
            //需要判断两个类是否相同
            if (dataEntity.GetType().FullName != target.GetType().FullName)
            {
                throw new Exception("类型不一致");
            }
            else
            {
                throw new Exception("未实现");
            }
        }

        /// <summary>
        /// 获取指定类型的列元数据
        /// </summary>
        /// <param name="dataType">列定义集合</param>
        /// <returns></returns>
        public static ReadOnlyCollection<DataColumn> GetColumnMetaData(this Type dataType)
        {
            return null;
        }


        #region 查询方法 

        /// <summary>
        /// 实体查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dataEntity">数据实体</param>
        /// <returns>符合条件的数据对象</returns>
        public static IQueryable<TEntity> Select<TEntity, T>(this IDataEntity<T> dataEntity) where T : DbContext, new() where TEntity : class, IDataEntity<T>, new()
        {
            return dataEntity.GetDbContext().Set<TEntity>().Where(m => true);
        }

        /// <summary>
        /// 实体查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataEntity">数据实体</param>
        /// <param name="where">数据查询条件</param>
        /// <returns>符合条件的数据对象</returns>
        public static IQueryable<TEntity> Select<TEntity, T>(this IDataEntity<T> dataEntity, Expression<Func<TEntity, bool>> where) where T : DbContext, new() where TEntity : class, IDataEntity<T>, new()
        {
            return dataEntity.GetDbContext().Set<TEntity>().Where(where);
        }

        /// <summary>
        /// 实体查询
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="dataEntity">数据实体</param>
        /// <param name="skip">跳过开始的N条记录,小于等于0则忽略</param>
        /// <param name="count">要返回的记录总数,小于等于0则忽略。</param>
        /// <returns>查询结果</returns>
        public static IQueryable<TEntity> Select<TEntity, T>(this IDataEntity<T> dataEntity, int skip, int count) where T : DbContext, new() where TEntity : class, IDataEntity<T>, new()
        {
            return dataEntity.GetDbContext().Set<TEntity>().Skip(skip).Take(count);
        }

        /// <summary>
        /// 实体查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataEntity">数据实体</param>
        /// <param name="where">数据查询条件</param>
        /// <param name="skip"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static IQueryable<TEntity> Select<TEntity, T>(this IDataEntity<T> dataEntity, Expression<Func<TEntity, bool>> where, int skip, int count) where T : DbContext, new() where TEntity : class, IDataEntity<T>, new()
        {
            return dataEntity.GetDbContext().Set<TEntity>().Where(where).Skip(skip).Take(count);
        }

        #endregion

        #region 其他工具方法

        /// <summary>
        /// IDataReader转实体对象
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="dataReader">IDataReader对象</param>
        /// <returns>实体集合</returns>
        public static T ToDataEntity<T>(this IDataReader dataReader) where T : class, new()
        {
            var list = dataReader.ToList<T>();
            if (list != null && list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// IDataReader转实体集合
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="dataReader">IDataReader对象</param>
        /// <returns>实体集合</returns>
        public static List<T> ToList<T>(this IDataReader dataReader) where T : class, new()
        {
            var table = dataReader.GetSchemaTable();
            return table.ToList<T>();
        }

        /// <summary>
        /// 实体集合转DataTable
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="dataList">实体集合</param>
        /// <returns>DataTable对象</returns>
        public static DataTable ToDataTable<T>(this IList<T> dataList) where T : class, new()
        {
            var dataTable = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var proItem in properties)
            {
                dataTable.Columns.Add(proItem.Name, proItem.GetType());
            }
            foreach (var item in dataList)
            {
                var row = dataTable.NewRow();
                foreach (var temp in properties)
                {
                    row[temp.Name] = temp.GetValue(item);
                }
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

        /// <summary>
        /// DataTable转实体集合
        /// </summary>
        /// <typeparam name="T">数据实体类型</typeparam>
        /// <param name="dataTable">DataTable对象</param>
        /// <returns>实体集合</returns>
        public static List<T> ToList<T>(this DataTable dataTable) where T : class, new()
        {
            var list = new List<T>();
            var properties = typeof(T).GetProperties();
            foreach (DataRow dr in dataTable.Rows)
            {
                T model = new T();
                // 获得此模型的公共属性      
                PropertyInfo[] propertys = typeof(T).GetProperties();
                foreach (PropertyInfo item in propertys)
                {
                    if (dataTable.Columns.Contains(item.Name))
                    {
                        // 判断此属性是否有Setter      
                        if (!item.CanWrite) continue;
                        if (dr[item.Name] != DBNull.Value)
                        {
                            item.SetValue(model, dr[item.Name]);
                        }
                    }
                }
                list.Add(model);
            }
            #region  第一版 有bug 效率低
            /*
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var model = new T();
                for (int k = 0; k < dataTable.Columns.Count; k++)
                {
                    foreach (var item in properties)
                    {
                        if (!item.CanWrite) continue;
                        if (item.Name == dataTable.Columns[k].ColumnName)
                        {
                            if (dataTable.Rows[i][k] != DBNull.Value)
                            {
                                item.SetValue(model, dataTable.Rows[i][k]);
                            }
                        }
                    }
                }
                list.Add(model);
            }
            */
            #endregion

            return list;
        }



        #endregion

    }
}
