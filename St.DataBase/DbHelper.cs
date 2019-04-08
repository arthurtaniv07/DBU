using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.Common;
using System.Configuration;

namespace St.DataBase
{
    /// <summary>
    /// 表示一个数据库事务   可嵌套
    /// </summary>
    internal class TransConnection
    {
        public TransConnection()
        {
            this.Deeps = 0;
        }
        /// <summary>
        /// 表示一个事务
        /// </summary>
        public DbTransaction DBTransaction { get; set; }
        /// <summary>
        /// 当前事务的深度
        /// </summary>
        public int Deeps { get; set; }
    }
    /// <summary>
    /// 数据库帮助类
    /// 使用该类需要在configuration--》appSettings下加入以下三个节点
    /// 1、数据库类型（DBType）：值为St.DataBase.StDbType枚举值之一，区分大小写，如MySQL
    /// 2、数据库驱动类型（DBDriveType）：值为St.DataBase.StDbDriveType枚举值之一，区分大小写，如SQLServer(用IP连接时加上Network Library = DBMSSOCN;)
    /// 3、数据库连接字符串（键为DBDriveType对应的值或者DBConnectionString）：值为数据库的连接字符串
    /// </summary>
    public class DbHelper
    {

        #region 函数 DbHelper 重载构造函数

        /// <summary>
        /// 从程序配置文件里  初始化一个数据库连接 但必须保证节点存在
        /// </summary>
        public DbHelper()
        {
            Init();
        }

        /// <summary>
        /// 用指定参数实例化一个数据库连接
        /// </summary>
        /// <param name="dbDriveTypeString">数据库驱动类型</param>
        /// <param name="dbTypeString">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public DbHelper(string dbDriveTypeString, string dbTypeString, string connectionString)
        {
            Init(dbDriveTypeString, dbTypeString, connectionString);
        }

        /// <summary>
        /// 用指定参数实例化一个数据库连接
        /// </summary>
        /// <param name="dbDriveType">数据库驱动类型</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        public DbHelper(StDbDriveType dbDriveType, StDbType dbType, string connectionString)
        {
            Init(dbDriveType, dbType, connectionString);
        }
        #endregion

        #region 函数 Init 实例化一个数据库连接 

        /// <summary>
        /// 从程序配置文件里  初始化一个数据库连接 单必须保证节点存在
        /// </summary>
        private void Init()
        {
            //初始化数据库驱动类型
            _dbDriveTypeString = ConfigurationManager.AppSettings["DBDriveType"];
            Enum.TryParse(_dbDriveTypeString, out _dbDriveType);

            //初始化数据库类型
            _dbTypeString = ConfigurationManager.AppSettings["DBType"];
            Enum.TryParse(_dbTypeString, out _dbType);

            //数据库连接字符串
            _connectionString = ConfigurationManager.AppSettings["DBConnectionString"];
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                _connectionString = ConfigurationManager.AppSettings[_dbDriveTypeString];
            }
        }
        /// <summary>
        /// 用指定参数实例化一个数据库连接
        /// </summary>
        /// <param name="dbDriveTypeString">数据库驱动类型</param>
        /// <param name="dbTypeString">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        private void Init(string dbDriveTypeString, string dbTypeString, string connectionString)
        {
            //初始化数据库驱动类型
            _dbDriveTypeString = dbDriveTypeString;
            Enum.TryParse(_dbDriveTypeString, out _dbDriveType);

            //初始化数据库类型
            _dbTypeString = dbTypeString;
            Enum.TryParse(_dbTypeString, out _dbType);

            //数据库连接字符串
            _connectionString = connectionString;
        }
        /// <summary>
        /// 用指定参数实例化一个数据库连接
        /// </summary>
        /// <param name="dbDriveType">数据库驱动类型</param>
        /// <param name="dbType">数据库类型</param>
        /// <param name="connectionString">数据库连接字符串</param>
        private void Init(StDbDriveType dbDriveType, StDbType dbType, string connectionString)
        {
            //初始化数据库驱动类型
            _dbDriveType = dbDriveType;
            //初始化数据库类型
            _dbType = dbType;
            //数据库连接字符串
            _connectionString = connectionString;
        }
        #endregion

        #region 私有全局变量

        private string _dbDriveTypeString = ConfigurationManager.AppSettings["DBDriveType"];
        private StDbDriveType _dbDriveType = default(StDbDriveType);

        private string _dbTypeString = ConfigurationManager.AppSettings["DBType"];
        private StDbType _dbType = default(StDbType);

        private string _connectionString = "";


        [ThreadStatic]//静态线程
        private TransConnection TransConnectionObj = null;
        #endregion


        /// <summary>
        /// 获取数据库驱动类型
        /// </summary>
        public StDbDriveType DbDriveType { get { return _dbDriveType; } }
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        public string ConnectionString { get { return _connectionString; } }
        /// <summary>
        /// 获取数据库驱动类型
        /// </summary>
        public StDbType DbType { get { return _dbType; } }

        #region 函数 ExecuteNonQuery 执行返回受影响行数的sql
        /// <summary>
        /// 执行返回受影响行数的sql
        /// </summary>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">执行命令的方式</param>
        /// <param name="pars">命令中包含的参数</param>
        /// <returns></returns>
        public int ExecuteNonQuery(string cmdText, CommandType cmdType, params DbParameter[] pars)
        {
            int result = 0;
            bool mustCloseConn = true;

            DbCommand cmd = PrepareCmd(cmdType, cmdText, pars, out mustCloseConn);
            OpenConn(cmd.Connection);
            result = cmd.ExecuteNonQuery();

            if (mustCloseConn)
            {
                DisposeConn(cmd.Connection);
            }
            ClearCmdParameters(cmd);
            cmd.Dispose();

            return result;
        }

        #endregion ExecuteNonQuery

        #region 函数 ExecuteScalar 执行查询语句  该方法只返回第一行第一列
        /// <summary>
        /// 执行查询语句  该方法只返回第一行第一列
        /// </summary>
        /// <param name="cmdText">执行的命令</param>
        /// <param name="cmdType">执行命令的方式</param>
        /// <param name="pars">命令中包含的参数</param>
        /// <returns></returns>
        public object ExecuteScalar( string cmdText, CommandType cmdType,params DbParameter[] pars)
        {
            object result = 0;
            bool mustCloseConn = true;

            DbCommand cmd = PrepareCmd(cmdType, cmdText, pars, out mustCloseConn);
            OpenConn(cmd.Connection);
            result = cmd.ExecuteScalar();

            if (mustCloseConn) DisposeConn(cmd.Connection);
            ClearCmdParameters(cmd);
            cmd.Dispose();
            
            return result;
        }
        #endregion ExecuteScalar

        #region 函数 ExecuteReader 执行命令返回数据库读取对象DataReader
        /// <summary>
        /// 执行命令返回数据库读取对象DataReader
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pars">命令参数</param>
        /// <returns></returns>
        public DbDataReader ExecuteReader(string cmdText,CommandType cmdType,  params DbParameter[] pars)
        {
            DbDataReader result = null;
            bool mustCloseConn = true;
            DbCommand cmd = PrepareCmd(cmdType, cmdText, pars, out mustCloseConn);
            try
            {
                OpenConn(cmd.Connection);
                if (mustCloseConn)
                {
                    result = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                else
                {
                    result = cmd.ExecuteReader();
                }
                ClearCmdParameters(cmd);
                return result;
            }
            catch (Exception ex)
            {
                if (mustCloseConn) DisposeConn(cmd.Connection);
                ClearCmdParameters(cmd);
                cmd.Dispose();
                throw;
            }
        }
        #endregion ExecuteReader

        #region 函数 ExecuteDataset 执行命令返回数据集  多条查询语句之间的分隔符根据数据库类型而定
        /// <summary>
        /// 执行命令返回数据集  多条查询语句之间的分隔符根据数据库类型而定
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pars">命令参数 </param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string cmdText,CommandType cmdType,  params DbParameter[] pars)
        {
            DataSet result = null;
            bool mustCloseConn = true;

            DbCommand cmd = PrepareCmd(cmdType, cmdText, pars, out mustCloseConn);
            using (DbDataAdapter da = _dbDriveType.CreateDbDataAdapter())
            {
                da.SelectCommand = cmd;
                result = new DataSet();
                da.Fill(result);
            }

            if (mustCloseConn) DisposeConn(cmd.Connection);
            ClearCmdParameters(cmd);
            cmd.Dispose();

            return result;
        }


        #endregion ExecuteDataset

        #region 函数 ExecuteDataTable 执行命令返回数据集的第一张表  如果查询结果为空或不足一张表返回null
        /// <summary>
        /// 执行命令返回数据集的第一张表  如果查询结果为空或不足一张表返回null
        /// </summary>
        /// <param name="cmdText">命令文本</param>
        /// <param name="cmdType">命令类型</param>
        /// <param name="pars">命令参数 </param>
        /// <returns></returns>
        public DataTable ExecuteDataTable( string cmdText,CommandType cmdType, params DbParameter[] pars)
        {
            DataSet ds = ExecuteDataSet( cmdText,cmdType, pars);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            else
                return null;
        }
        #endregion

        //#region ExecutePaging
        //public DataTable ExecutePagingDataTable(CommandType cmdType,string tableName, string cmdText, int pageIndex, int pageSize, string orderInfo, params DbParameter[] parameterValues)
        //{
        //    StDbQueryParameter q=new StDbQueryParameter(tableName,)
        //    cmdText = StDbSqlFunction.GetQuerySql(DbType, null);
        //    //cmdText = DBClient.GetPagingSql(cmdText, pageIndex, pageSize, orderInfo);
        //    return ExecuteDataTable(CommandType.Text, cmdText, parameterValues);
        //}

        //public DbDataReader ExecutePagingReader(CommandType cmdType, string cmdText, int pageIndex, int pageSize, string orderInfo, params DbParameter[] parameterValues)
        //{
        //    cmdText = DBClient.GetPagingSql(cmdText, pageIndex, pageSize, orderInfo);
        //    return ExecuteReader(CommandType.Text, cmdText, parameterValues);
        //}
        //#endregion

        #region Transaction
        /// <summary>
        /// 开始该帮助类创建的事务
        /// </summary>
        public void BeginTransaction()
        {
            if (TransConnectionObj == null)
            {
                DbConnection conn = _dbDriveType.CreateDbConnection(_connectionString);
                OpenConn(conn);
                DbTransaction trans = conn.BeginTransaction();
                TransConnectionObj = new TransConnection();
                TransConnectionObj.DBTransaction = trans;
            }
            else
            {
                TransConnectionObj.Deeps += 1;
            }
        }
        /// <summary>
        /// 提交该帮助类创建的事务  持久化数据
        /// </summary>
        public void CommitTransaction()
        {
            if (TransConnectionObj == null) return;
            if (TransConnectionObj.Deeps > 0)
            {
                TransConnectionObj.Deeps -= 1;
            }
            else
            {
                TransConnectionObj.DBTransaction.Commit();
                ReleaseTransaction();
            }
        }
        /// <summary>
        /// 回滚该帮助类创建的事务
        /// </summary>
        public void RollbackTransaction()
        {
            if (TransConnectionObj == null) { return; }
            if (TransConnectionObj.Deeps > 0)
            {
                TransConnectionObj.Deeps -= 1;
            }
            else
            {
                TransConnectionObj.DBTransaction.Rollback();
                ReleaseTransaction();
            }
        }
        /// <summary>
        /// 关闭连接 清除事务占用的资源
        /// </summary>
        private void ReleaseTransaction()
        {
            if (TransConnectionObj == null) { return; }
            DbConnection conn = TransConnectionObj.DBTransaction.Connection;
            TransConnectionObj.DBTransaction.Dispose();
            TransConnectionObj = null;
            DisposeConn(conn);
        }

        #endregion

        #region Connection - private
        /// <summary>
        /// 打开一个数据库连接
        /// </summary>
        /// <param name="conn"></param>
        private void OpenConn(DbConnection conn)
        {
            if (conn == null) { conn = _dbDriveType.CreateDbConnection(_connectionString); }
            if (conn.State == ConnectionState.Closed) { conn.Open();}
        }
        /// <summary>
        /// 关闭连接对像
        /// </summary>
        /// <param name="conn"></param>
        private void DisposeConn(DbConnection conn)
        {
            if (conn == null) { return; }
            if (conn.State == ConnectionState.Open) { conn.Close(); }
            conn.Dispose();
            conn = null;
        }
        #endregion

        #region Create DbParameter

        /// <summary>
        /// 创建一个输入参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateInDbParameter(string paraName, DbType type, int size, object value)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, size, value, ParameterDirection.Input);
        }

        /// <summary>
        /// 创建一个输入参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter CreateInDbParameter(string paraName, DbType type, object value)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, 0, value, ParameterDirection.Input);
        }
        /// <summary>
        /// 创建一个输出参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public DbParameter CreateOutDbParameter(string paraName, DbType type, int size)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, size, null, ParameterDirection.Output);
        }

        /// <summary>
        /// 创建一个输出参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DbParameter CreateOutDbParameter(string paraName, DbType type)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, 0, null, ParameterDirection.Output);
        }

        /// <summary>
        /// 创建一个返回值参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DbParameter CreateReturnDbParameter(string paraName, DbType type, int size)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, size, null, ParameterDirection.ReturnValue);
        }
        /// <summary>
        /// 创建一个返回值参数
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DbParameter CreateReturnDbParameter(string paraName, DbType type)
        {
            return _dbDriveType.CreateDbParameter(paraName, type, 0, null, ParameterDirection.ReturnValue);
        }


        #endregion

        #region Command and Parameter  - private
        /// <summary>
        /// 预处理用户提供的命令,数据库连接/事务/命令类型/参数
        /// </summary>
        ///// <param name="cmdType">要处理的DbCommand</param>
        ///// <param name="cmdText">数据库连接</param>
        ///// <param name="cmdParams">一个有效的事务或者是null值</param>
        /// <param name="cmdType">命令类型 (存储过程,命令文本, 其它.)</param>
        /// <param name="cmdText">存储过程名或都T-SQL命令文本</param>
        /// <param name="cmdParams">和命令相关联的DbParameter参数数组,如果没有参数为'null'</param>
        /// <param name="mustCloseConn"><c>true</c> 如果连接是打开的,则为true,其它情况下为false.</param>
        private DbCommand PrepareCmd(CommandType cmdType, string cmdText, DbParameter[] cmdParams, out bool mustCloseConn)
        {

            DbConnection conn = null;
            DbCommand cmd = _dbDriveType.CreateDbCommand();// DBClient.GetDbCommand(cmdText);
            if (TransConnectionObj != null)
            {
                conn = TransConnectionObj.DBTransaction.Connection;
                cmd.Transaction = TransConnectionObj.DBTransaction;
                mustCloseConn = false;
            }
            else
            {
                conn = _dbDriveType.CreateDbConnection(_connectionString);
                mustCloseConn = true;
            }
            cmd.CommandText = cmdText;
            cmd.Connection = conn;
            cmd.CommandType = cmdType;
            AppendParameters(cmd, cmdParams);

            return cmd;
        }

        /// <summary>
        /// 将DbParameter参数数组(参数值)分配给DbCommand命令.
        /// 这个方法将给任何一个参数分配DBNull.Value;
        /// 该操作将阻止默认值的使用.
        /// </summary>
        /// <param name="command">命令名</param>
        /// <param name="commandParameters">SqlParameters数组</param>
        private void AppendParameters(DbCommand command, DbParameter[] commandParameters)
        {
            if (command == null)
            {
                return;//throw new ArgumentNullException("command is null");
            }
            if (commandParameters != null)
            {
                foreach (DbParameter p in commandParameters)
                {
                    if (p != null)
                    {
                        // 检查未分配值的输出参数,将其分配以DBNull.Value.
                        if ((p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Input) &&
                        (p.Value == null))
                        {
                            p.Value = DBNull.Value;
                        }
                        command.Parameters.Add(p);
                    }
                }
            }
        }
        /// <summary>
        /// 清除cmd的参数  除非参数的类型不包含输入参数
        /// </summary>
        /// <param name="cmd">要清除参数的命令</param>
        private void ClearCmdParameters(DbCommand cmd)
        {
            bool canClear = true;
            if (cmd.Connection != null && cmd.Connection.State != ConnectionState.Open)
            {
                foreach (DbParameter commandParameter in cmd.Parameters)
                {
                    if (commandParameter.Direction != ParameterDirection.Input)
                    {
                        canClear = false;
                        break;
                    }
                }
            }
            if (canClear)
            {
                cmd.Parameters.Clear();
            }
        }
        #endregion

        #region 函数 RunProcedure 执行存储过程  返回结果集

        /// <summary>
        /// 执行存储过程  返回结果集
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="pars">存储过程参数</param>
        /// <returns>DataSet</returns>
        public DataSet RunProcedure(string storedProcName, DbParameter[] pars)
        {
            using (DbConnection connection = StDbFunction.CreateDbConnection(DbDriveType, ConnectionString))
            {
                DataSet dataSet = new DataSet();
                connection.Open();
                DbDataAdapter sqlDA = DbDriveType.CreateDbDataAdapter();
                sqlDA.SelectCommand = StDbFunction.CreateDbCommand(DbDriveType, connection, storedProcName, pars);
                sqlDA.Fill(dataSet, "ds");
                connection.Close();
                return dataSet;
            }
        }
        #endregion
        //====(3)=====

        #region 函数 GetPading 获取提取指定数量的sql
        
        /// <summary>
        /// 获取提取指定数量的sql  分页类型为maxId或者rownumber(效率：rowNumber3大于maxID大于notIn) 这依据primaryName而定  默认使用notin
        /// </summary>
        /// <param name="tabName">表名</param>
        /// <param name="queryStrings">查询的列名</param>
        /// <param name="primaryName">此项可为空  唯一、主键或索引列  如果此项为空则使用maxid方式进行分页</param>
        /// <param name="where">where条件  前后不加and和where关键字</param>
        /// <param name="take">要获取的条数</param>
        /// <param name="skip">跳过的条数</param>
        /// <param name="groupString">分组字段  前面不加group by</param>
        /// <param name="orderString">orderBy语句 不加order by关键字</param>
        /// <param name="tableSpecialColumn">单独查询的列 前面不需要加,</param>
        /// <param name="padType">分页方式 不区分大小写 rowNumber、maxID、notIn  如果为空 则以maxid进行分页 此项暂时未启用</param>
        /// <returns></returns>
        public string GetPading(string tabName, string queryStrings, string primaryName, string where, int take, int skip, string groupString, string orderString, string tableSpecialColumn = "", PaddingType padType = PaddingType.NotIn)
        {
            StringBuilder sql = new StringBuilder();

            //if (padType != null && padType.Trim() != "") { padingType = padType.Trim().ToLower();}
            if (!string.IsNullOrWhiteSpace(groupString)) { groupString = " group by " + groupString; }
            if (!string.IsNullOrWhiteSpace(orderString)) { orderString = "order by " + orderString; }
            if (!string.IsNullOrWhiteSpace(where)) { where = "where " + where; }
            if (!string.IsNullOrWhiteSpace(tableSpecialColumn)) { tableSpecialColumn = "," + tableSpecialColumn; }
            switch (padType)
            {
                case PaddingType.MaxID:

                    //建议优化的时候，加上主键和索引，查询效率会提高。
                    //要分页的表显示的条数
                    sql.AppendFormat("select {0} {1}{2} from {3} ", take > 0 ? "top " + take : "", queryStrings, tableSpecialColumn, tabName);
                    sql.AppendFormat("{0} ", where);
                    if (skip != 0 && skip > 0 && take > 0)
                    {
                        sql.AppendFormat(string.IsNullOrWhiteSpace(where) ? " where " : " and ");
                        sql.AppendFormat("{0}>(select isnull(max({0}),0) from (select top {1} {0} from {2} {3} {4} {5}) a) ", primaryName, skip, tabName, where, groupString, orderString);
                    }
                    sql.AppendFormat(groupString);
                    sql.AppendFormat(orderString);

                    break;
                case PaddingType.NotIn:

                    //建议优化的时候，加上主键和索引，查询效率会提高。
                    //要分页的表显示的条数
                    sql.AppendFormat("select {0} {1}{2} from {3} ", take > 0 ? "top " + take : "", queryStrings, tableSpecialColumn, tabName);
                    sql.AppendFormat("{0} ", where);
                    if (skip != 0 && skip > 0 && take > 0)
                    {
                        sql.AppendFormat(string.IsNullOrWhiteSpace(where) ? " where " : " and ");
                        sql.AppendFormat("{0} not in(select top {1} {0} from {2} {3} {4} {5}) ", primaryName, skip, tabName, where, groupString, orderString);
                    }
                    sql.AppendFormat(groupString);
                    sql.AppendFormat(orderString);

                    break;
                case PaddingType.RowNumber3:
                    if (string.IsNullOrWhiteSpace(orderString)) { orderString = "order by getdate()"; }
                    sql.AppendFormat("select * from (select row_number() over ({0}) __rowNumber,{1}{2} from {3} {4} {5}) ___a", orderString, queryStrings, tableSpecialColumn, tabName, where, groupString);

                    if (skip > 0)
                    {
                        sql.AppendFormat(" where ___a.__rowNumber between {0} and {1}", skip + 1, skip + take);
                    }
                    /*
                    sql.AppendFormat("select {0} {1}{2} from {3} ", pageSize > 0 ? "top " + pageSize : "", queryStrings, tableSpecialColumn, tabName);
                    sql.AppendFormat("{0} ", where);
                    if (skip != 0 && pageIndex > 0 && pageSize > 0)
                    {
                        sql.AppendFormat(string.IsNullOrWhiteSpace(where) ? " where " : " and ");
                        sql.AppendFormat("{0} not in(select top {1} {0} from {2} {3} {4}) ", primaryName, skip, tabName, where, orderString);
                    }
                    sql.AppendFormat(orderString);
                    */
                    break;
                default:
                    break;
            }
            return sql.ToString();
        }
        #endregion

    }

    /// <summary>
    /// 查询的方式  效率：rowNumber3大于maxID大于notIn(数据量大于10万时)  小于10万时用notIn效率较好
    /// </summary>
    public enum PaddingType
    {
        /// <summary>
        /// not in/top的分页方式  ,这需要有唯一键或主键，查询效率最低（表的总数据量在10万以上时）
        /// </summary>
        NotIn,
        /// <summary>
        /// max top分页方式   ,这需要有唯一键或主键，查询效率比较好（表的总数据量在10万以上时）
        /// </summary>
        MaxID,
        /// <summary>
        /// 用row_number()的分页方式，支持有主键或无主键，查询效率最好（数据量在10万以上时）
        /// </summary>
        RowNumber3
    }
}

/* 数据库连接字符串  
    SqlServer：string connection = "server=32.1.1.48;database=数据库名;user=sa;password=sa2008";
    access 2007：

    //无密码的连接字符串
 
    string conStr = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=E://111.accdb;Persist Security Info=False";
 
　　　 　    //有密码的连接字符串
 
    string conStr = "Provider=Microsoft.Ace.OleDb.12.0;Data Source=E://111.accdb;Jet OleDb:DataBase Password=111";
    access 2003：　

    //无密码的连接字符串
 
    string conStr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=E://111.mdb;Persist Security Info=False";
 
　　　 　    //有密码的连接字符串
 
    string conStr = "Provider=Microsoft.Jet.OleDb.4.0;Data Source=E://111.mdb;Jet OleDb:DataBase Password=111";
    链接access数据库若出现 无法启动应用程序 工作组信息文件丢失 有可能是链接字符串链接不正确
    Sqlite ：　　　　

    string conStr = "Data Source=E://111.db;Password=111";
    在使用SQLite时需要添加一个引用 System.Data.SQLite，C#在运行时候会提示混合模式程序集是针对“v2.0.50727”版的运行时生成的，在没有配置其他信息的情况下，无法在 4.0 运行时中加载该程序集 ，这个问题可以在app.config中添加一个配置节：startup

    <startup useLegacyV2RuntimeActivationPolicy="true">
    <supportedRuntime version="v4.0"/>
    </startup>
*/
