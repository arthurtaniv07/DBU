using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using Account.Model;
using St.DataBase;

namespace Account.DAL
{
	public class BU_PayType3DAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_PayType3";
		#region CommandText
		private  string selectAllText = "select ID,PID,UserID,Name,State,Sort,IsBreak,AddDate from BU_PayType3";
		private  string selectByKeyText = "select ID,PID,UserID,Name,State,Sort,IsBreak,AddDate from BU_PayType3 where ID=@ID";
		private  string selectByWhereText = "select ID,PID,UserID,Name,State,Sort,IsBreak,AddDate from BU_PayType3 {0}";
		
		private  string insertText = "insert into BU_PayType3(PID, UserID, Name, State, Sort, IsBreak, AddDate) values(@PID, @UserID, @Name, @State, @Sort, @IsBreak, @AddDate);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_PayType3 set PID=@PID, UserID=@UserID, Name=@Name, State=@State, Sort=@Sort, IsBreak=@IsBreak, AddDate=@AddDate where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_PayType3 where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_PayType3 where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_PayType3> GetAllList()
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
		public  List<BU_PayType3> GetModelList(string where)
		{
			return Find(string.Format(selectByWhereText,string.IsNullOrWhiteSpace(where)?"":"where "+where), CommandType.Text, null);
		}
		#endregion
		
		#region GetModel
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ID">命名空间</param>
		/// <returns></returns>
		public  BU_PayType3 GetModel(long iD)
		{
			return Find(selectByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=iD}
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
			string sql = db.GetPading(tabName, querystring, "ID", where, take, skip, groupString, orderString, PaddingType.NotIn);
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
			string sql = db.GetPading(tabName, querystring, "ID", where, take, skip, groupString, orderString, PaddingType.MaxID);
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
			string sql = db.GetPading(tabName, querystring, "", where, take, skip, groupString, orderString, PaddingType.RowNumber3);
			DataTable dt = db.ExecuteDataTable(sql, CommandType.Text, null);
			return dt;
		}
		#endregion
		
		#region Add
		/// <summary>
		/// 向数据库插入一条新数据 返回插入的自增长值
		/// </summary>
		/// <param name="_bU_PayType3">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_PayType3 _bU_PayType3)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@PID",SqlDbType.BigInt,19){Value=_bU_PayType3.PID}
					,new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_PayType3.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_PayType3.Name}
					,new SqlParameter("@State",SqlDbType.Int,10){Value=_bU_PayType3.State}
					,new SqlParameter("@Sort",SqlDbType.BigInt,19){Value=_bU_PayType3.Sort}
					,new SqlParameter("@IsBreak",SqlDbType.Bit,1){Value=_bU_PayType3.IsBreak}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_PayType3.AddDate}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_PayType3">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_PayType3 _bU_PayType3)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@PID",SqlDbType.BigInt,19){Value=_bU_PayType3.PID}
					,new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_PayType3.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_PayType3.Name}
					,new SqlParameter("@State",SqlDbType.Int,10){Value=_bU_PayType3.State}
					,new SqlParameter("@Sort",SqlDbType.BigInt,19){Value=_bU_PayType3.Sort}
					,new SqlParameter("@IsBreak",SqlDbType.Bit,1){Value=_bU_PayType3.IsBreak}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_PayType3.AddDate}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_PayType3.ID}
				});
		}
		#endregion
		
		#region 函数 Delete删除指定主键的数据
		/// <summary>
		/// 删除指定主键的数据
		/// </summary>
		/// <param name="iD">要删除的 主键 集合，中间用 , 隔开 </param>
		/// <returns></returns>
		public  int Deletes(string iDs)
		{
			return db.ExecuteNonQuery(string.Format(deleteByKeyInText,iDs), CommandType.Text, null);
		}
		#endregion
		
		#region 函数 Delete 删除指定数据
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="ID">要删除的对象  （通过主键）</param>
		/// <returns></returns>
		public  int Delete(BU_PayType3 _bU_PayType3)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_PayType3.ID}
				});
		}
		#endregion
		
		#region  函数 Delete 删除指定数据
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="ID">主键</param>
		/// <returns></returns>
		public  int Delete(long ID)
		{
			return db.ExecuteNonQuery(selectByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=ID}
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
		public  List<BU_PayType3> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_PayType3> bu_paytype3s = new List<BU_PayType3>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_PayType3>();
			}
			bu_paytype3s = DataTableToList(ds.Tables[0]);
			return bu_paytype3s; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_PayType3> DataTableToList(DataTable dt)
		{
			List<BU_PayType3> bu_paytype3s = new List<BU_PayType3>();
			BU_PayType3 _bu_paytype3 = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_paytype3 = new BU_PayType3();
				if(dcs.Contains("id"))
				{
					_bu_paytype3.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("pid"))
				{
					_bu_paytype3.PID = Convert.ToInt64(item["PID"]);
				}
				if(dcs.Contains("userid"))
				{
					_bu_paytype3.UserID = Convert.ToInt64(item["UserID"]);
				}
				if(dcs.Contains("name"))
				{
					_bu_paytype3.Name = item["Name"].ToString();
				}
				if(dcs.Contains("state"))
				{
					_bu_paytype3.State = Convert.ToInt32(item["State"]);
				}
				if(dcs.Contains("sort"))
				{
					_bu_paytype3.Sort = Convert.ToInt64(item["Sort"]);
				}
				if(dcs.Contains("isbreak"))
				{
					_bu_paytype3.IsBreak = Convert.ToBoolean(item["IsBreak"]);
				}
				if(dcs.Contains("adddate"))
				{
					_bu_paytype3.AddDate = Convert.ToDateTime(item["AddDate"]);
				}
				bu_paytype3s.Add(_bu_paytype3);
			}
			return bu_paytype3s;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","pid","userid","name","state","sort","isbreak","adddate" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_PayType3 DataRowToModel(DataRow dr)
		{
			BU_PayType3 _bu_paytype3 = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_paytype3 = new BU_PayType3();
			if(dcs.Contains("id"))
			{
				_bu_paytype3.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("pid"))
			{
				_bu_paytype3.PID = Convert.ToInt64(dr["PID"]);
			}
			if(dcs.Contains("userid"))
			{
				_bu_paytype3.UserID = Convert.ToInt64(dr["UserID"]);
			}
			if(dcs.Contains("name"))
			{
				_bu_paytype3.Name = dr["Name"].ToString();
			}
			if(dcs.Contains("state"))
			{
				_bu_paytype3.State = Convert.ToInt32(dr["State"]);
			}
			if(dcs.Contains("sort"))
			{
				_bu_paytype3.Sort = Convert.ToInt64(dr["Sort"]);
			}
			if(dcs.Contains("isbreak"))
			{
				_bu_paytype3.IsBreak = Convert.ToBoolean(dr["IsBreak"]);
			}
			if(dcs.Contains("adddate"))
			{
				_bu_paytype3.AddDate = Convert.ToDateTime(dr["AddDate"]);
			}
			return _bu_paytype3;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_paytype3s">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_PayType3> bu_paytype3s, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "pid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "name", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "state", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "sort", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "isbreak", DataType = typeof(bool) });
			_cols.Add(new DataColumn() { ColumnName = "adddate", DataType = typeof(DateTime) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_PayType3 item in bu_paytype3s)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["pid"] = item.PID;
				_row["userid"] = item.UserID;
				_row["name"] = item.Name;
				_row["state"] = item.State;
				_row["sort"] = item.Sort;
				_row["isbreak"] = item.IsBreak;
				_row["adddate"] = item.AddDate;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

