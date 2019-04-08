namespace St.DataBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// 数据库类型
    /// </summary>
    public enum StDbType
    {
        //大型数据库
        /// <summary>
        /// Oracle数据库
        /// </summary>
        Oracle = 1,
        /// <summary>
        /// DB2数据库
        /// </summary>
        DB2 = 2,
        /// <summary>
        /// 美国赛贝斯数据库
        /// </summary>
        SyBASE = 4,

        //中型数据库
        /// <summary>
        /// 微软SQL Server数据库
        /// </summary>
        SQLServer = 8,
        /// <summary>
        /// MySQL数据库
        /// </summary>
        MySQL = 16,
        /// <summary>
        /// IBM的INFORMIX数据库
        /// </summary>
        INFORMIX = 32,

        //小型数据库
        /// <summary>
        /// FoxPro数据库
        /// </summary>
        FoxPro = 64,
        /// <summary>
        /// 微软Access数据库
        /// </summary>
        Access = 128,



        /// <summary>
        /// SQLite数据库
        /// </summary>
        SQLite = 256,
        /// <summary>
        /// MongoDB数据库
        /// </summary>
        MongoDB = 512,
        /// <summary>
        /// PostgreSQL数据库
        /// </summary>
        PostgreSQL = 1024,
        /// <summary>
        /// Redis数据库  notsql（key-value内存hash数据库）
        /// </summary>
        Redis = 2048,
        /// <summary>
        /// Memcached  nosql数据库
        /// </summary>
        Memcached = 8096,

        /// <summary>
        /// 日本 Tokyo_Tyrant数据库（key-value内存hash数据库）  大数据量吞吐时推荐使用
        /// </summary>
        Tokyo_Tyrant = 16192,

        Riak,

        HBase
    }

    /// <summary>
    /// 连接数据的库驱动类型
    /// </summary>
    public enum StDbDriveType
    {
        /// <summary>
        /// 有统一标准的数据库连接驱动(标准)    兼容性(开放性)好 但性能较差  需要系统配置DSN
        /// </summary>
        ODBC,
        /// <summary>
        /// 位于ODBC驱动上一层 效率比ODBC驱动高 
        /// </summary>
        OleDB,
        /// <summary>
        /// ADO驱动 Oracle数据库
        /// </summary>
        Oracle,
        /// <summary>
        /// ADO驱动 SQLServer数据库
        /// </summary>
        SQLServer,
        /// <summary>
        /// ADO驱动 MySQL数据库
        /// </summary>
        MySQL,
        /// <summary>
        /// ADO驱动 SQLite数据库
        /// </summary>
        SQLite
    }

    public enum JoinType {
        /// <summary>
        /// 左外链接
        /// </summary>
        LeftJoin =1,
        /// <summary>
        /// 右外链接，以右边为基础
        /// </summary>
        RightJoin=2,
        /// <summary>
        /// 内连接，两边必须有
        /// </summary>
        InnerJoin=3
    }
}