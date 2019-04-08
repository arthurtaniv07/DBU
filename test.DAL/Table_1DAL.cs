using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using test.Model;
using St.DataBase;

namespace test.DAL
{
	public class Table_1DAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "Table_1";
		#region CommandText
		private  string selectAllText = "select ID,UserID,Iden,s1,s2,sSum from Table_1";
		private  string selectByKeyText = "select ID,UserID,Iden,s1,s2,sSum from Table_1 where UserID=@UserID";
		private  string selectByWhereText = "select ID,UserID,Iden,s1,s2,sSum from Table_1 {0}";
		
		private  string insertText = "insert into Table_1(ID, UserID, Iden, s1, s2) values(@ID, @UserID, @Iden, @S1, @S2);select @@IDENTITY";
		private  string updateByKeyText = "update  Table_1 set ID=@ID, UserID=@UserID, Iden=@Iden, S1=@S1, S2=@S2 where UserID=@UserID1";

		private  string deleteByKeyText = "delete from Table_1 where UserID=@UserID";
		private  string deleteByKeyInText = "delete from Table_1 where UserID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<Table_1> GetAllList()
		{
			return Find(selectAllText, CommandType.Text, null);
		}
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 查询指定条件的数据
		/// </summary>
		/// <param name="where">查询条件 不加where关键字</param>
		/// <returns></returns>
		public  List<Table_1> GetModelList(string where)
		{
			return Find(string.Format(selectByWhereText,string.IsNullOrWhiteSpace(where)?"":"where "+where), CommandType.Text, null);
		}
		#endregion
		
		#region GetModel
		/// <summary>
		/// 
		/// </summary>
		/// <param name="UserID">命名空间</param>
		/// <returns></returns>
		public  Table_1 GetModelByUserID(string userID)
		{
			return Find(selectByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.VarChar,50){Value=userID}
				}).FirstOrDefault();
		}
		#endregion
		
		#region 函数 GetPageData_NotIn 使用PaddingType.NotIn的方式提取数据库数据
		/// <summary>
		/// 使用 PaddingType.NotIn 的方式提取数据库数据
		/// </summary>
		/// <param name="querystring">要查询的列</param>
		/// <param name="where">查询条件 前面不加where关键字</param>
		/// <param name="take">要提取的数量</param>
		/// <param name="skip">要跳过的数量</param>
		/// <param name="groupString">分组字段  前面不加group by</param>
		/// <param name="orderString">排序字段  前面不加order by</param>
		/// <returns></returns>
		public  DataTable GetPageData_NotIn(string querystring , string where, int take, int skip, string groupString, string orderString)
		{
			string sql = db.GetPading(tabName, querystring, "UserID", where, take, skip, groupString, orderString, "", PaddingType.NotIn);
			DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, null);
			return dt;
		}
		#endregion
		
		#region 函数 GetPageData_MaxID 使用PaddingType.MaxID的方式提取数据库数据
		/// <summary>
		/// 使用 PaddingType.MaxID 的方式提取数据库数据
		/// </summary>
		/// <param name="querystring">要查询的列</param>
		/// <param name="where">查询条件 前面不加where关键字</param>
		/// <param name="take">要提取的数量</param>
		/// <param name="skip">要跳过的数量</param>
		/// <param name="groupString">分组字段  前面不加group by</param>
		/// <param name="orderString">排序字段  前面不加order by</param>
		/// <returns></returns>
		public  DataTable GetPageData_MaxID(string querystring , string where, int take, int skip, string groupString, string orderString)
		{
			string sql = db.GetPading(tabName, querystring, "UserID", where, take, skip, groupString, orderString, "", PaddingType.MaxID);
			DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, null);
			return dt;
		}
		#endregion
		
		#region 函数 GetPageData_RowNumber3 使用PaddingType.RowNumber3的方式提取数据库数据
		/// <summary>
		/// 使用 PaddingType.RowNumber3 的方式提取数据库数据
		/// </summary>
		/// <param name="querystring">要查询的列</param>
		/// <param name="where">查询条件 前面不加where关键字</param>
		/// <param name="take">要提取的数量</param>
		/// <param name="skip">要跳过的数量</param>
		/// <param name="groupString">分组字段  前面不加group by</param>
		/// <param name="orderString">排序字段  前面不加order by</param>
		/// <returns></returns>
		public  DataTable GetPageData_RowNumber3(string querystring , string where, int take, int skip, string groupString, string orderString)
		{
			string sql = db.GetPading(tabName, querystring, "", where, take, skip, groupString, orderString, "", PaddingType.RowNumber3);
			DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, null);
			return dt;
		}
		#endregion
		
		#region Add
		/// <summary>
		/// 向数据库插入一条新数据 返回受影响行数
		/// </summary>
		/// <param name="_table_1">需要插入的对象</param>
		/// <returns></returns>
		public  int Add(Table_1 _table_1)
		{
			return db.ExecuteNonQuery(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_table_1.ID}
					,new SqlParameter("@UserID",SqlDbType.VarChar,50){Value=_table_1.UserID}
					,new SqlParameter("@Iden",SqlDbType.Int,10){Value=_table_1.Iden}
					,new SqlParameter("@S1",SqlDbType.Decimal,18){Value=_table_1.S1}
					,new SqlParameter("@S2",SqlDbType.Decimal,10){Value=_table_1.S2}
				});
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_table_1">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(Table_1 _table_1)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_table_1.ID}
					,new SqlParameter("@UserID",SqlDbType.VarChar,50){Value=_table_1.UserID}
					,new SqlParameter("@Iden",SqlDbType.Int,10){Value=_table_1.Iden}
					,new SqlParameter("@S1",SqlDbType.Decimal,18){Value=_table_1.S1}
					,new SqlParameter("@S2",SqlDbType.Decimal,10){Value=_table_1.S2}
					,new SqlParameter("@UserID1",SqlDbType.VarChar,50){Value=_table_1.UserID}
				});
		}
		#endregion
		
		#region 函数 Delete删除指定唯一键的数据
		/// <summary>
		/// 删除指定唯一键的数据
		/// </summary>
		/// <param name="userID">要删除的 唯一键 集合，中间用 , 隔开 </param>
		/// <returns></returns>
		public  int DeleteByUserIDs(string userIDs)
		{
			return db.ExecuteNonQuery(string.Format(deleteByKeyInText,userIDs), CommandType.Text, null);
		}
		#endregion
		
		#region 函数 Delete 删除指定数据
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="UserID">要删除的对象  （通过唯一键）</param>
		/// <returns></returns>
		public  int Delete(Table_1 _table_1)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.VarChar,50){Value=_table_1.UserID}
				});
		}
		#endregion
		
		#region  函数 Delete 删除指定数据
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="UserID">唯一键</param>
		/// <returns></returns>
		public  int DeleteByUserID(string UserID)
		{
			return db.ExecuteNonQuery(selectByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.VarChar,50){Value=UserID}
				});
		}
		#endregion
		
		#region Find
		/// <summary>
		/// 通过指定文本查询结果
		/// </summary>
		/// <param name="text">要执行的命令或文本</param>
		/// <param name="type">执行的方式</param>
		/// <param name="pars">执行参数</param>
		/// <returns></returns>
		public  List<Table_1> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<Table_1> table_1s = new List<Table_1>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<Table_1>();
			}
			table_1s = DataTableToList(ds.Tables[0]);
			return table_1s; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<Table_1> DataTableToList(DataTable dt)
		{
			List<Table_1> table_1s = new List<Table_1>();
			Table_1 _table_1 = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_table_1 = new Table_1();
				if(dcs.Contains("id"))
				{
					_table_1.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userid"))
				{
					_table_1.UserID = item["UserID"].ToString();
				}
				if(dcs.Contains("iden"))
				{
					_table_1.Iden = Convert.ToInt32(item["Iden"]);
				}
				if(dcs.Contains("s1"))
				{
					_table_1.S1 = Convert.ToDecimal(item["s1"]);
				}
				if(dcs.Contains("s2"))
				{
					_table_1.S2 = Convert.ToDecimal(item["s2"]);
				}
				if(dcs.Contains("ssum"))
				{
					_temp = item["SSum"];
					if(!(_temp is DBNull))
					{
						_table_1.SSum = Convert.ToDecimal(_temp);
					}
				}
				table_1s.Add(_table_1);
			}
			return table_1s;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userid","iden","s1","s2","ssum" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  Table_1 DataRowToModel(DataRow dr)
		{
			Table_1 _table_1 = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_table_1 = new Table_1();
			if(dcs.Contains("id"))
			{
				_table_1.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userid"))
			{
				_table_1.UserID = dr["UserID"].ToString();
			}
			if(dcs.Contains("iden"))
			{
				_table_1.Iden = Convert.ToInt32(dr["Iden"]);
			}
			if(dcs.Contains("s1"))
			{
				_table_1.S1 = Convert.ToDecimal(dr["s1"]);
			}
			if(dcs.Contains("s2"))
			{
				_table_1.S2 = Convert.ToDecimal(dr["s2"]);
			}
			if(dcs.Contains("ssum"))
			{
				_temp = dr["SSum"];
				if(!(_temp is DBNull))
				{
					_table_1.SSum = Convert.ToDecimal(_temp);
				}
			}
			return _table_1;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="table_1s">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<Table_1> table_1s, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "iden", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "s1", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "s2", DataType = typeof(decimal) });
			if(IsComputed)
				_cols.Add(new DataColumn() { ColumnName = "ssum", DataType = typeof(decimal) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (Table_1 item in table_1s)
			{
				_row = dt.NewRow();
				_row["id"] = item.ID;
				_row["userid"] = item.UserID;
				_row["iden"] = item.Iden;
				_row["s1"] = item.S1;
				_row["s2"] = item.S2;
				if(IsComputed)
					_row["ssum"] = item.SSum;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

