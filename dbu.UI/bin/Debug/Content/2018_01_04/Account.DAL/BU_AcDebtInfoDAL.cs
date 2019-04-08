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
	public class BU_AcDebtInfoDAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_AcDebtInfo";
		#region CommandText
		private  string selectAllText = "select ID,UserID,DebtUserID,SetMoney,PayMoney,Money_Old,Money_Added,Money_Result,AddDate from BU_AcDebtInfo";
		private  string selectByKeyText = "select ID,UserID,DebtUserID,SetMoney,PayMoney,Money_Old,Money_Added,Money_Result,AddDate from BU_AcDebtInfo where ID=@ID";
		private  string selectByWhereText = "select ID,UserID,DebtUserID,SetMoney,PayMoney,Money_Old,Money_Added,Money_Result,AddDate from BU_AcDebtInfo {0}";
		
		private  string insertText = "insert into BU_AcDebtInfo(UserID, DebtUserID, SetMoney, PayMoney, Money_Old, Money_Added, Money_Result, AddDate) values(@UserID, @DebtUserID, @SetMoney, @PayMoney, @Money_Old, @Money_Added, @Money_Result, @AddDate);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_AcDebtInfo set UserID=@UserID, DebtUserID=@DebtUserID, SetMoney=@SetMoney, PayMoney=@PayMoney, Money_Old=@Money_Old, Money_Added=@Money_Added, Money_Result=@Money_Result, AddDate=@AddDate where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_AcDebtInfo where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_AcDebtInfo where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_AcDebtInfo> GetAllList()
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
		public  List<BU_AcDebtInfo> GetModelList(string where)
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
		public  BU_AcDebtInfo GetModel(long iD)
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
		/// <param name="_bU_AcDebtInfo">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_AcDebtInfo _bU_AcDebtInfo)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.UserID}
					,new SqlParameter("@DebtUserID",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.DebtUserID}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.PayMoney}
					,new SqlParameter("@Money_Old",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Old}
					,new SqlParameter("@Money_Added",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Added}
					,new SqlParameter("@Money_Result",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Result}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcDebtInfo.AddDate}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_AcDebtInfo">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_AcDebtInfo _bU_AcDebtInfo)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.UserID}
					,new SqlParameter("@DebtUserID",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.DebtUserID}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.PayMoney}
					,new SqlParameter("@Money_Old",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Old}
					,new SqlParameter("@Money_Added",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Added}
					,new SqlParameter("@Money_Result",SqlDbType.Decimal,10){Value=_bU_AcDebtInfo.Money_Result}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcDebtInfo.AddDate}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.ID}
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
		public  int Delete(BU_AcDebtInfo _bU_AcDebtInfo)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_AcDebtInfo.ID}
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
		public  List<BU_AcDebtInfo> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_AcDebtInfo> bu_acdebtinfos = new List<BU_AcDebtInfo>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_AcDebtInfo>();
			}
			bu_acdebtinfos = DataTableToList(ds.Tables[0]);
			return bu_acdebtinfos; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_AcDebtInfo> DataTableToList(DataTable dt)
		{
			List<BU_AcDebtInfo> bu_acdebtinfos = new List<BU_AcDebtInfo>();
			BU_AcDebtInfo _bu_acdebtinfo = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_acdebtinfo = new BU_AcDebtInfo();
				if(dcs.Contains("id"))
				{
					_bu_acdebtinfo.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userid"))
				{
					_bu_acdebtinfo.UserID = Convert.ToInt64(item["UserID"]);
				}
				if(dcs.Contains("debtuserid"))
				{
					_bu_acdebtinfo.DebtUserID = Convert.ToInt64(item["DebtUserID"]);
				}
				if(dcs.Contains("setmoney"))
				{
					_bu_acdebtinfo.SetMoney = Convert.ToDecimal(item["SetMoney"]);
				}
				if(dcs.Contains("paymoney"))
				{
					_bu_acdebtinfo.PayMoney = Convert.ToDecimal(item["PayMoney"]);
				}
				if(dcs.Contains("money_old"))
				{
					_bu_acdebtinfo.Money_Old = Convert.ToDecimal(item["Money_Old"]);
				}
				if(dcs.Contains("money_added"))
				{
					_bu_acdebtinfo.Money_Added = Convert.ToDecimal(item["Money_Added"]);
				}
				if(dcs.Contains("money_result"))
				{
					_bu_acdebtinfo.Money_Result = Convert.ToDecimal(item["Money_Result"]);
				}
				if(dcs.Contains("adddate"))
				{
					_bu_acdebtinfo.AddDate = Convert.ToDateTime(item["AddDate"]);
				}
				bu_acdebtinfos.Add(_bu_acdebtinfo);
			}
			return bu_acdebtinfos;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userid","debtuserid","setmoney","paymoney","money_old","money_added","money_result","adddate" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_AcDebtInfo DataRowToModel(DataRow dr)
		{
			BU_AcDebtInfo _bu_acdebtinfo = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_acdebtinfo = new BU_AcDebtInfo();
			if(dcs.Contains("id"))
			{
				_bu_acdebtinfo.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userid"))
			{
				_bu_acdebtinfo.UserID = Convert.ToInt64(dr["UserID"]);
			}
			if(dcs.Contains("debtuserid"))
			{
				_bu_acdebtinfo.DebtUserID = Convert.ToInt64(dr["DebtUserID"]);
			}
			if(dcs.Contains("setmoney"))
			{
				_bu_acdebtinfo.SetMoney = Convert.ToDecimal(dr["SetMoney"]);
			}
			if(dcs.Contains("paymoney"))
			{
				_bu_acdebtinfo.PayMoney = Convert.ToDecimal(dr["PayMoney"]);
			}
			if(dcs.Contains("money_old"))
			{
				_bu_acdebtinfo.Money_Old = Convert.ToDecimal(dr["Money_Old"]);
			}
			if(dcs.Contains("money_added"))
			{
				_bu_acdebtinfo.Money_Added = Convert.ToDecimal(dr["Money_Added"]);
			}
			if(dcs.Contains("money_result"))
			{
				_bu_acdebtinfo.Money_Result = Convert.ToDecimal(dr["Money_Result"]);
			}
			if(dcs.Contains("adddate"))
			{
				_bu_acdebtinfo.AddDate = Convert.ToDateTime(dr["AddDate"]);
			}
			return _bu_acdebtinfo;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_acdebtinfos">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_AcDebtInfo> bu_acdebtinfos, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "debtuserid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "setmoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "paymoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_old", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_added", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_result", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "adddate", DataType = typeof(DateTime) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_AcDebtInfo item in bu_acdebtinfos)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["userid"] = item.UserID;
				_row["debtuserid"] = item.DebtUserID;
				_row["setmoney"] = item.SetMoney;
				_row["paymoney"] = item.PayMoney;
				_row["money_old"] = item.Money_Old;
				_row["money_added"] = item.Money_Added;
				_row["money_result"] = item.Money_Result;
				_row["adddate"] = item.AddDate;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

