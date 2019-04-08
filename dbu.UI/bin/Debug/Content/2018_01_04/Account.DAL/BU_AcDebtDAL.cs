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
	public class BU_AcDebtDAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_AcDebt";
		#region CommandText
		private  string selectAllText = "select ID,UserID,Name,Money_Yu from BU_AcDebt";
		private  string selectByKeyText = "select ID,UserID,Name,Money_Yu from BU_AcDebt where ID=@ID";
		private  string selectByWhereText = "select ID,UserID,Name,Money_Yu from BU_AcDebt {0}";
		
		private  string insertText = "insert into BU_AcDebt(UserID, Name, Money_Yu) values(@UserID, @Name, @Money_Yu);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_AcDebt set UserID=@UserID, Name=@Name, Money_Yu=@Money_Yu where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_AcDebt where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_AcDebt where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_AcDebt> GetAllList()
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
		public  List<BU_AcDebt> GetModelList(string where)
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
		public  BU_AcDebt GetModel(long iD)
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
		/// <param name="_bU_AcDebt">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_AcDebt _bU_AcDebt)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcDebt.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_AcDebt.Name}
					,new SqlParameter("@Money_Yu",SqlDbType.Decimal,18){Value=_bU_AcDebt.Money_Yu}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_AcDebt">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_AcDebt _bU_AcDebt)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcDebt.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_AcDebt.Name}
					,new SqlParameter("@Money_Yu",SqlDbType.Decimal,18){Value=_bU_AcDebt.Money_Yu}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_AcDebt.ID}
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
		public  int Delete(BU_AcDebt _bU_AcDebt)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_AcDebt.ID}
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
		public  List<BU_AcDebt> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_AcDebt> bu_acdebts = new List<BU_AcDebt>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_AcDebt>();
			}
			bu_acdebts = DataTableToList(ds.Tables[0]);
			return bu_acdebts; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_AcDebt> DataTableToList(DataTable dt)
		{
			List<BU_AcDebt> bu_acdebts = new List<BU_AcDebt>();
			BU_AcDebt _bu_acdebt = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_acdebt = new BU_AcDebt();
				if(dcs.Contains("id"))
				{
					_bu_acdebt.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userid"))
				{
					_bu_acdebt.UserID = Convert.ToInt64(item["UserID"]);
				}
				if(dcs.Contains("name"))
				{
					_bu_acdebt.Name = item["Name"].ToString();
				}
				if(dcs.Contains("money_yu"))
				{
					_bu_acdebt.Money_Yu = Convert.ToDecimal(item["Money_Yu"]);
				}
				bu_acdebts.Add(_bu_acdebt);
			}
			return bu_acdebts;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userid","name","money_yu" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_AcDebt DataRowToModel(DataRow dr)
		{
			BU_AcDebt _bu_acdebt = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_acdebt = new BU_AcDebt();
			if(dcs.Contains("id"))
			{
				_bu_acdebt.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userid"))
			{
				_bu_acdebt.UserID = Convert.ToInt64(dr["UserID"]);
			}
			if(dcs.Contains("name"))
			{
				_bu_acdebt.Name = dr["Name"].ToString();
			}
			if(dcs.Contains("money_yu"))
			{
				_bu_acdebt.Money_Yu = Convert.ToDecimal(dr["Money_Yu"]);
			}
			return _bu_acdebt;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_acdebts">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_AcDebt> bu_acdebts, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "name", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "money_yu", DataType = typeof(decimal) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_AcDebt item in bu_acdebts)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["userid"] = item.UserID;
				_row["name"] = item.Name;
				_row["money_yu"] = item.Money_Yu;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

