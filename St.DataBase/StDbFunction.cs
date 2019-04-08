using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using Oracle.DataAccess.Client;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data.SQLite;
using System.Data;
//using System.Data.
namespace St.DataBase
{
    /// <summary>
    /// 数据库工厂帮助类
    /// </summary>
    public static class StDbFunction
    {

        #region 函数 CreateDbConnection 创建一个新的数据库连接对象

        /// <summary>
        /// 创建一个新的数据库连接对象
        /// </summary>
        /// <param name="driveType">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        /// <returns></returns>
        public static DbConnection CreateDbConnection(this StDbDriveType driveType, string connectionString)
        {
            
            DbConnection conn = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    conn = new OdbcConnection(connectionString);
                    break;
                case StDbDriveType.OleDB:
                    conn = new OleDbConnection(connectionString);
                    break;
                case StDbDriveType.Oracle:
                    conn = new OracleConnection(connectionString);
                    break;
                case StDbDriveType.SQLServer:
                    conn = new SqlConnection(connectionString);
                    break;
                case StDbDriveType.MySQL:
                    conn = new MySqlConnection(connectionString);
                    break;
                case StDbDriveType.SQLite:
                    conn = new SQLiteConnection(connectionString);
                    break;
            }
            return conn;
        }
        /// <summary>
        /// 创建一个新的数据库连接对象
        /// </summary>
        /// <param name="driveType">数据库类型</param>
        /// <returns></returns>
        public static DbConnection CreateDbConnection(this StDbDriveType driveType)
        {
            return driveType.CreateDbConnection(string.Empty);
        }
        #endregion

        #region 函数 OpenConn 开启数据库连接
        /// <summary>
        ///  打开数据库连接  如果数据库连接是打开的则忽视
        /// </summary>
        /// <param name="conn">将要关闭的连接</param>
        /// <returns></returns>
        public static bool OpenConn(this DbConnection conn)
        {
            if (conn == null) { return false; }
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                return true;
            }
            return false;
        }

        #endregion

        #region 函数 CloseConn 关闭数据库连接
        /// <summary>
        ///  关闭数据库连接 同时释放资源  如果数据库连接是打开的则忽视
        /// </summary>
        /// <param name="conn">将要关闭的连接</param>
        /// <returns></returns>
        public static bool CloseConn(this DbConnection conn)
        {
            if (conn == null) { return false; }
            bool result = false;
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                result = true;
            }
            conn.Dispose();
            conn = null;
            return result;
        }
        #endregion

        #region 函数 CreateDbCommand 创建一个新的DBCommand
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="text">执行的命令文本</param>
        /// <param name="type">执行方式</param>
        /// <param name="tran">一个事务  此项可为null</param>
        /// <param name="pars">参数数组，如果没有可为null</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, string connString, string text, CommandType type, DbTransaction tran, params DbParameter[] pars)
        {
            DbCommand cmd = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    cmd = new OdbcCommand();
                    break;
                case StDbDriveType.OleDB:
                    cmd = new OleDbCommand();
                    break;
                case StDbDriveType.Oracle:
                    cmd = new OracleCommand();
                    break;
                case StDbDriveType.SQLServer:
                    cmd = new SqlCommand();
                    break;
                case StDbDriveType.MySQL:
                    cmd = new MySqlCommand();
                    break;
                case StDbDriveType.SQLite:
                    cmd = new SQLiteCommand();
                    break;
                default:
                    break;
            }
            cmd.CommandType = type;
            cmd.Connection = driveType.CreateDbConnection(connString);
            if (tran != null)
            {
                cmd.Transaction = tran;
            }
            cmd.CommandText = text;
            if (pars != null && pars.Length > 0)
            {
                cmd.Parameters.AddRange(pars);
            }
            return cmd;
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接对象</param>
        /// <param name="text">执行的命令文本</param>
        /// <param name="type">执行方式</param>
        /// <param name="tran">一个事务  此项可为null</param>
        /// <param name="pars">参数数组，如果没有可为null</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, DbConnection conn, string text, CommandType type, DbTransaction tran,params DbParameter[] pars)
        {
            DbCommand cmd = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    cmd = new OdbcCommand();
                    break;
                case StDbDriveType.OleDB:
                    cmd = new OleDbCommand();
                    break;
                case StDbDriveType.Oracle:
                    cmd = new OracleCommand();
                    break;
                case StDbDriveType.SQLServer:
                    cmd = new SqlCommand();
                    break;
                case StDbDriveType.MySQL:
                    cmd = new MySqlCommand();
                    break;
                case StDbDriveType.SQLite:
                    cmd = new SQLiteCommand();
                    break;
                default:
                    break;
            }
            cmd.CommandType = type;
            cmd.Connection =conn;
            if (tran != null)
            { cmd.Transaction = tran; }
            cmd.CommandText = text;
            if (pars != null && pars.Length > 0) {
                cmd.Parameters.AddRange(pars);
            }
            return cmd;
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="text">执行的命令文本</param>
        /// <param name="type">执行方式</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, string connString, string text, CommandType type)
        {
            return driveType.CreateDbCommand(connString, text, type, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接对象</param>
        /// <param name="text">执行的命令文本</param>
        /// <param name="type">执行方式</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, DbConnection conn, string text, CommandType type)
        {
            return driveType.CreateDbCommand(conn, text, type, null);
        }
        /// <summary>
        /// 获取DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="text">执行的命令文本</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, string connString, string text)
        {
            return driveType.CreateDbCommand(connString, text, CommandType.Text, null);
        }
        /// <summary>
        /// 获取DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接对象</param>
        /// <param name="text">执行的命令文本</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, DbConnection conn, string text)
        {
            return driveType.CreateDbCommand(conn, text, CommandType.Text, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接字符串</param>
        /// <param name="type">执行方式</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, string connString, CommandType type)
        {
            return driveType.CreateDbCommand(connString, string.Empty, type, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接对象</param>
        /// <param name="type">执行方式</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, DbConnection conn, CommandType type)
        {
            return driveType.CreateDbCommand(conn, string.Empty, type, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接字符串</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, string connString)
        {
            return driveType.CreateDbCommand(connString, string.Empty, CommandType.Text, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connString">数据库连接对象</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType, DbConnection conn)
        {
            return driveType.CreateDbCommand(conn, string.Empty, CommandType.Text, null);
        }
        /// <summary>
        /// 创建一个新的DBCommand
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <returns></returns>
        public static DbCommand CreateDbCommand(this StDbDriveType driveType)
        {
            return driveType.CreateDbCommand(string.Empty, string.Empty, CommandType.Text, null);
        }


        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        public static DbCommand CreateDbCommand( this StDbDriveType driveType, DbConnection connection, string storedProcName, DbParameter[] parameters)
        {
            //DbParameter
            DbCommand comm = driveType.CreateDbCommand(connection, storedProcName, CommandType.StoredProcedure);
            if (parameters != null && parameters.Length > 0)
            {
                comm.Parameters.AddRange(parameters);
            }
            return comm;
        }

        #endregion

        #region 函数 CloseCmd 关闭并释放指定DbCommand占用的资源
        /// <summary>
        /// 关闭并释放指定DbCommand占用的资源
        /// </summary>
        /// <param name="cmd">需要释放支援的连接对象</param>
        public static void CloseCmd(DbCommand cmd)
        {
            if (cmd == null) { return; }
            cmd.Connection.Close();
            cmd.Dispose();
            cmd = null;
        }
        #endregion

        #region 函数 CreateDbDataAdapter 创建一个新的DataAdapter
        /// <summary>
        /// 创建一个新的DataAdapter
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <returns></returns>
        public static DbDataAdapter CreateDbDataAdapter(this StDbDriveType driveType)
        {
            DbDataAdapter da = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    da = new OdbcDataAdapter();
                    break;
                case StDbDriveType.OleDB:
                    da = new OleDbDataAdapter();
                    break;
                case StDbDriveType.Oracle:
                    da = new OracleDataAdapter();
                    break;
                case StDbDriveType.SQLServer:
                    da = new SqlDataAdapter();
                    break;
                case StDbDriveType.MySQL:
                    da = new MySqlDataAdapter();
                    break;
                case StDbDriveType.SQLite:
                    da = new SQLiteDataAdapter();
                    break;
                default:
                    break;
            }

            return da;
        }
        /// <summary>
        /// 创建一个新的DataAdapter
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <returns></returns>
        public static DbDataAdapter CreateDbDataAdapter(this StDbDriveType driveType,DbConnection conn)
        {
            DbDataAdapter da = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    da = new OdbcDataAdapter();
                    break;
                case StDbDriveType.OleDB:
                    da = new OleDbDataAdapter();
                    break;
                case StDbDriveType.Oracle:
                    da = new OracleDataAdapter();
                    break;
                case StDbDriveType.SQLServer:
                    da = new SqlDataAdapter();
                    break;
                case StDbDriveType.MySQL:
                    da = new MySqlDataAdapter();
                    break;
                case StDbDriveType.SQLite:
                    da = new SQLiteDataAdapter();
                    break;
                default:
                    break;
            }

            return da;
        }
        #endregion

        #region 函数 CreateDbParameter 创建一个DbCommand的参数项
        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type)
        {
            DbParameter par = null;

            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    par = new OdbcParameter();
                    break;
                case StDbDriveType.OleDB:
                    par = new OleDbParameter();
                    break;
                case StDbDriveType.Oracle:
                    par = new OracleParameter();
                    break;
                case StDbDriveType.SQLServer:
                    par = new SqlParameter();
                    break;
                case StDbDriveType.MySQL:
                    par = new MySqlParameter();
                    break;
                case StDbDriveType.SQLite:
                    par = new SQLiteParameter();
                    break;
                default:
                    break;
            }
            par.ParameterName = parName;
            if (type != default(DbType))
            {
                par.DbType = type;
            }
            return par;
        }

        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="obj">参数的值</param>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, object obj)
        {
            DbParameter par = null;
            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    par = new OdbcParameter(parName, obj);
                    break;
                case StDbDriveType.OleDB:
                    par = new OleDbParameter(parName, obj);
                    break;
                case StDbDriveType.Oracle:
                    par = new OracleParameter(parName,obj);
                    break;
                case StDbDriveType.SQLServer:
                    par = new SqlParameter();
                    break;
                case StDbDriveType.MySQL:
                    par = new MySqlParameter(parName, obj);
                    break;
                case StDbDriveType.SQLite:
                    par = new SQLiteParameter(parName,obj);
                    break;
                default:
                    break;
            }
            return par;
        }
        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="val">参数的值</param>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType dbType,object val)
        {
            DbParameter par = null;

            switch (driveType)
            {
                case StDbDriveType.ODBC:
                    par = new OdbcParameter();
                    
                    break;
                case StDbDriveType.OleDB:
                    par = new OleDbParameter();
                    break;
                case StDbDriveType.Oracle:
                    par = new OracleParameter();
                    break;
                case StDbDriveType.SQLServer:
                    par = new SqlParameter();
                    break;
                case StDbDriveType.MySQL:
                    par = new MySqlParameter();
                    break;
                case StDbDriveType.SQLite:
                    par = new SQLiteParameter();
                    break;
                default:
                    break;
            }
            par.ParameterName = parName;
            par.Value = val;
            par.DbType = (DbType)dbType;
            return par;
        }
        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        /// <param name="val">要创建的对象的值  为空表示不设置</param>
        /// <param name="size">要创建的对象的最大大小  小于或等于0表示不设置 </param>
        /// <param name="souceSourceColumnName">该对象映射到数据集中的列明</param>
        /// <returns></returns>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type, int size, object val, string souceSourceColumnName)
        {

            DbParameter par = driveType.CreateDbParameter(parName, type);
            if (size > 0)
            {
                par.Size = size;
            }

            if (val != null)
            {
                par.Value = val;
            }
            else
            {
                par.Value = DBNull.Value;
            }
            if (string.IsNullOrWhiteSpace(souceSourceColumnName))
            {
                par.SourceColumn = souceSourceColumnName;
            }
            return par;
        }

        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        /// <param name="val">要创建的对象的值  为空表示不设置</param>
        /// <param name="size">要创建的对象的最大大小  小于或等于0表示不设置 </param>
        /// <param name="direction">参数类型 指定是输出参数 输入参数还是输入输出参数</param>
        /// <param name="souceSourceColumnName">该对象映射到数据集中的列明</param>
        /// <returns></returns>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type, int size, object val, ParameterDirection direction, string souceSourceColumnName)
        {
            DbParameter par = driveType.CreateDbParameter(parName, type);
            if (size > 0)
            {
                par.Size = size;
            }

            if (val != null)
            {
                par.Value = val;
            }
            else
            {
                par.Value = DBNull.Value;
            }
            if (string.IsNullOrWhiteSpace(souceSourceColumnName))
            {
                par.SourceColumn = souceSourceColumnName;
            }
            par.Direction = direction;
            return par;
        }
        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        /// <param name="val">要创建的对象的值  为空表示不设置</param>
        /// <param name="size">要创建的对象的最大大小  小于或等于0表示不设置 </param>
        /// <param name="direction">参数类型 指定是输出参数 输入参数还是输入输出参数</param>
        /// <returns></returns>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type, int size, object val, ParameterDirection direction)
        {
            DbParameter par = driveType.CreateDbParameter(parName, type);

            if (size != 0)
            {
                par.Size = size;
            }

            if (val != null)
            {
                par.Value = val;
            }
            else
            {
                par.Value = DBNull.Value;
            }
            par.Direction = direction;
            return par;
        }

        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        /// <param name="val">要创建的对象的值  为空表示不设置</param>
        /// <param name="size">要创建的对象的最大大小  小于或等于0表示不设置 </param>
        /// <returns></returns>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type, int size, object val)
        {
            DbParameter par = driveType.CreateDbParameter(parName, type);
            if (size != 0)
            {
                par.Size = size;
            }

            if (val != null)
            {
                par.Value = val;
            }
            else
            {
                par.Value = DBNull.Value;
            }
            return par;
        }

        /// <summary>
        /// 创建一个DbCommand的参数项
        /// </summary>
        /// <param name="driveType">数据库驱动类型</param>
        /// <param name="parName">要创建的对象的名称 如：@pageIndex、@id等</param>
        /// <param name="type">数据库中的类型</param>
        /// <param name="val">要创建的对象的值  为空表示不设置</param>
        /// <param name="size">要创建的对象的最大大小  小于或等于0表示不设置 </param>
        /// <returns></returns>
        public static DbParameter CreateDbParameter(this StDbDriveType driveType, string parName, DbType type, int size)
        {
            DbParameter par = driveType.CreateDbParameter(parName, type);

            if (size != 0)
            {
                par.Size = size;
            }
            
            return par;
        }


        #endregion

        public static DbType GetDbType(object obj) {
            DbType t = default(DbType);

            return t;
        }
    }
}