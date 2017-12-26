using EntityData.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityData.Extend
{
    public static class EntityContextExtensions
    {
        /*
        /// <summary>
        /// 在当前操作环境中启动一个事务，显示的支持简单的事务调用。
        /// </summary>
        /// <returns> 事务对象，事务启动成功返回事务对象实例</returns>
        public static  void CreateTransaction<T>(this IEntityContext<T> context) where T : class, IDataEntity, new()
        {

        }

        //
        // 摘要:
        //     在当前操作环境中启动一个事务，显示的支持简单的事务调用。
        //
        // 参数:
        //   il:
        //     事务隔离级别。
        //
        // 返回结果:
        //     事务对象，事务启动成功返回事务对象实例。
        public static void CreateTransaction<T>(this IEntityContext<T> context, IsolationLevel il) where T : class, IDataEntity, new()
        {

        }
      */
      
        #region 普通执行


        /// <summary>
        /// 执行sql语句 或者存储过程
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="context">DbContext</param>
        /// <param name="sql">执行语句</param>
        /// <returns>影响行数</returns>
        public static int Execute<T>(this IEntityContext<T> context, string sql) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.ExecuteSqlCommand(sql);
        }

        /// <summary>
        /// 执行sql语句 或者存储过程
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="context">DbContext</param>
        /// <param name="sql">执行语句</param>
        /// <param name="parameters"></param>
        /// <returns>影响行数</returns>
        public static int Execute<T>(this IEntityContext<T> context, string sql, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.ExecuteSqlCommand(sql, parameters);
        }
        #endregion

        #region 查询
        #endregion 
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="context">context管理</param>
        /// <param name="sql">sql语句或者存储过程</param>
        /// <returns></returns>
        public static object Query<T>(this IEntityContext<T> context, string sql) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.SqlQuery<object>(sql);
        }

        //
        // 摘要:
        //     执行给定的数据库查询命令。
        //
        // 参数:
        //   commandText:
        //     要执行的命令语句，可能是select语句，也可能是存储过程名称。
        //
        //   parameters:
        //     命令执行需要的参数。
        //
        // 返回结果:
        //     返回查询到的数据结果。
        //
        // 备注:
        //     如果命令执行时数据访问环境还没有打开，则内部会自动打开数据访问环境，当执行完毕后自动关闭访问环境；如果命令执行时数据访问环境已经打开，则命令执行完毕后该方法不会关闭访问环境，而是保持其打开状态。
        //     如果要求的结果为DataReader，则必须由调用方在外部打开数据访问环境，当DataReader执行完毕后再关闭访问环境；否则该方法将自动打开访问环境，并在DataReader返回前自动关闭访问环境，这样会导致在外部无法使用（因为该DataReader所依赖的数据连接已经关闭）DataReader读取数据。

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="context"></param>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns></returns>
        public static object Query<T>(this IEntityContext<T> context, string sql, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.SqlQuery<T>(sql, parameters);
        }

        //
        // 摘要:
        //     执行给定的数据库查询命令。
        //
        // 参数:
        //   commandText:
        //     要执行的命令语句，可能是select语句，也可能是存储过程名称。
        //
        //   resultType:
        //     调用方要求的返回结果的类型。
        //
        // 返回结果:
        //     返回查询到的数据结果。
        //
        // 备注:
        //     如果命令执行时数据访问环境还没有打开，则内部会自动打开数据访问环境，当执行完毕后自动关闭访问环境；如果命令执行时数据访问环境已经打开，则命令执行完毕后该方法不会关闭访问环境，而是保持其打开状态。
        //     如果要求的结果为DataReader，则必须由调用方在外部打开数据访问环境，当DataReader执行完毕后再关闭访问环境；否则该方法将自动打开访问环境，并在DataReader返回前自动关闭访问环境，这样会导致在外部无法使用（因为该DataReader所依赖的数据连接已经关闭）DataReader读取数据。

        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <param name="resultType"> 调用方要求的返回结果的类型。</param>
        /// <returns>返回查询到的数据结果。</returns>
        public static object Query<T>(this IEntityContext<T> context, string commandText, ResultType resultType) where T : class, IDataEntity, new()
        {
            using (SqlConnection conn = new System.Data.SqlClient.SqlConnection())
            {
                conn.ConnectionString = context.GetDbContext().Database.Connection.ConnectionString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                switch (resultType)
                {
                    case ResultType.DataReader:
                        return cmd.ExecuteReader();
                    case ResultType.DataSet:
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    case ResultType.DataTable:
                        SqlDataAdapter adapterDt = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapterDt.Fill(table);
                        return table;
                    case ResultType.Dictionary:
                        break;
                    case ResultType.List:
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable table2 = new DataTable();
                        adapterList.Fill(table2);
                        return table2.ToList<T>();
                    default:
                        throw new Exception("数据转化错误!");
                }
                return null;
            }
        }

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters">命令执行需要的参数</param>
        /// <param name="resultType">调用方要求的返回结果的类型。</param>
        /// <returns>返回查询到的数据结果。</returns>
        public static object Query<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters, ResultType resultType) where T : class, IDataEntity, new()
        {
            using (SqlConnection conn = new System.Data.SqlClient.SqlConnection())
            {
                conn.ConnectionString = context.GetDbContext().Database.Connection.ConnectionString;
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = commandText;
                if (parameters != null && parameters.Count > 0)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                switch (resultType)
                {
                    case ResultType.DataReader:
                        return cmd.ExecuteReader();
                    case ResultType.DataSet:
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataSet dataSet = new DataSet();
                        adapter.Fill(dataSet);
                        return dataSet;
                    case ResultType.DataTable:
                        SqlDataAdapter adapterDt = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapterDt.Fill(table);
                        return table;
                    case ResultType.Dictionary:
                        break;
                    case ResultType.List:
                        SqlDataAdapter adapterList = new SqlDataAdapter(cmd);
                        DataTable table2 = new DataTable();
                        adapterList.Fill(table2);
                        return table2.ToList<T>();
                    default:
                        throw new Exception("数据转化错误!");
                }
                return null;
            }
        }

        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"> 要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <returns> 查询结果的 System.Data.IDataReader对象。</returns>
        public static IDataReader QueryDataReader<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return (IDataReader)Query<T>(context, commandText, ResultType.DataReader);
        }


        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"> 要执行的命令语句，可能是select语句，也可能是存储过程名称</param>
        /// <param name="parameters">命令执行需要的参数。</param>
        /// <returns>查询结果的 System.Data.IDataReader对象。</returns>
        public static IDataReader QueryDataReader<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return (IDataReader)Query<T>(context, commandText, parameters, ResultType.DataReader);
        }



        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称</param>
        /// <returns> 返回查询结果集。</returns>
        public static DataSet QueryDataSet<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return (DataSet)Query<T>(context, commandText, ResultType.DataSet);
        }


        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"> 要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <param name="parameters"> 命令执行需要的参数。</param>
        /// <returns>  返回查询结果集。</returns>
        public static DataSet QueryDataSet<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return (DataSet)Query<T>(context, commandText, parameters, ResultType.DataSet);
        }


        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <returns>返回查询结果集的第一个DataTable。</returns>
        public static DataTable QueryDataTable<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return (DataTable)Query<T>(context, commandText, ResultType.DataTable);
        }

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"></param>
        /// <param name="parameters"> 命令执行需要的参数。</param>
        /// <returns>返回查询结果集的第一个DataTable。</returns>
        public static DataTable QueryDataTable<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return (DataTable)Query<T>(context, commandText, parameters, ResultType.DataTable);
        }

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称</param>
        /// <returns> 返回第一行的Key-Value。</returns>
        public static IDictionary<string, object> QueryDictionary<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return (IDictionary<string, object>)Query<T>(context, commandText, ResultType.Dictionary);
        }
        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <param name="parameters">命令执行需要的参数。</param>
        /// <returns>返回第一行的Key-Value。</returns>
        public static IDictionary<string, object> QueryDictionary<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return (IDictionary<string, object>)Query<T>(context, commandText, ResultType.Dictionary);
        }

        /// <summary>
        ///  执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <returns> 返回第一列的值。</returns>
        public static IList<T> QueryList<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return (IList<T>)Query<T>(context, commandText, ResultType.List);
        }

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称</param>
        /// <param name="parameters">  命令执行需要的参数。</param>
        /// <returns></returns>
        public static IList<T> QueryList<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return (IList<T>)Query<T>(context, commandText, parameters, ResultType.List);
        }


        /// <summary>
        ///   执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText"> 要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <returns> 返回查询结果的第一行第一列。</returns>
        public static object QueryScalar<T>(this IEntityContext<T> context, string commandText) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.SqlQuery<object>(commandText);
        }

        /// <summary>
        /// 执行给定的数据库查询命令。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <param name="commandText">要执行的命令语句，可能是select语句，也可能是存储过程名称。</param>
        /// <param name="parameters">命令执行需要的参数</param>
        /// <returns>返回查询结果的第一行第一列。</returns>
        public static object QueryScalar<T>(this IEntityContext<T> context, string commandText, IList<SqlParameter> parameters) where T : class, IDataEntity, new()
        {
            return context.GetDbContext().Database.SqlQuery<object>(commandText, parameters);
        }


        /*
        //
        // 摘要:
        //     在事务环境中执行给定的 EAS.Data.Access.TransactionHandler，该EAS.Data.Access.TransactionHandler中包括了要在事务中执行的所有数据库操作。
        //
        // 参数:
        //   handler:
        //     要执行的 EAS.Data.Access.TransactionHandler 对象。
        //
        // 返回结果:
        //     返回受影响的行数，该值为 EAS.Data.Access.TransactionHandler 返回的结果，默认返回 0。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     handler 为空引用。
        //
        //   T:System.InvalidOperationException:
        //     还没有设置数据访问环境。
        //
        // 备注:
        //     如果命令执行时数据访问环境还没有打开，则内部会自动打开数据访问环境，当执行完毕后自动关闭访问环境；如果命令执行时数据访问环境已经打开，则命令执行完毕后该方法不会关闭访问环境，而是保持其打开状态。
        //     不要在 EAS.Data.Access.TransactionHandler 对象中处理事务，事务的开始和结束都由该方法负责，即使执行中出现异常，该方法也会正确地回滚事务。
        [Obsolete("请参考新写法CreateTransaction")]
        void TransactionExecute(TransactionHandler handler)
        {

        }
        //
        // 摘要:
        //     在事务环境中执行给定的 TransactionHandler，该TransactionHandler中包括了要在事务中执行的所有数据库操作。
        //
        // 参数:
        //   handler:
        //     要执行的 TransactionHandler 对象。
        //
        //   parameters:
        //     调用参数。
        //
        // 返回结果:
        //     返回受影响的行数，该值为 TransactionHandler 返回的结果，默认返回 0。
        //
        // 异常:
        //   T:System.ArgumentNullException:
        //     handler 为空引用。
        //
        //   T:System.InvalidOperationException:
        //     还没有设置数据访问环境。
        //
        // 备注:
        //     如果命令执行时数据访问环境还没有打开，则内部会自动打开数据访问环境，当执行完毕后自动关闭访问环境；如果命令执行时数据访问环境已经打开，则命令执行完毕后该方法不会关闭访问环境，而是保持其打开状态。
        //     不要在 EAS.Data.Access.TransactionHandler 对象中处理事务，事务的开始和结束都由该方法负责，即使执行中出现异常，该方法也会正确地回滚事务。
        [Obsolete("请参考新写法CreateTransaction")]
        void TransactionExecute(TransactionHandler2 handler, params object[] parameters)
        {

        }
        */


        public static void Add(this IList<SqlParameter> list,string name,object value)
        {
            list.Add(new SqlParameter(name, value));
        }
    }
}
