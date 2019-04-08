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
	public class BU_AcBookDAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_AcBook";
		#region CommandText
		private  string selectAllText = "select ID,UserID,Name,SetMoney,PayMoney,YuMoney,Money_YuZhi,YuMoney_YuZhi,AddDate from BU_AcBook";
		private  string selectByKeyText = "select ID,UserID,Name,SetMoney,PayMoney,YuMoney,Money_YuZhi,YuMoney_YuZhi,AddDate from BU_AcBook where ID=@ID";
		private  string selectByWhereText = "select ID,UserID,Name,SetMoney,PayMoney,YuMoney,Money_YuZhi,YuMoney_YuZhi,AddDate from BU_AcBook {0}";
		
		private  string insertText = "insert into BU_AcBook(UserID, Name, SetMoney, PayMoney, YuMoney, Money_YuZhi, YuMoney_YuZhi, AddDate) values(@UserID, @Name, @SetMoney, @PayMoney, @YuMoney, @Money_YuZhi, @YuMoney_YuZhi, @AddDate);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_AcBook set UserID=@UserID, Name=@Name, SetMoney=@SetMoney, PayMoney=@PayMoney, YuMoney=@YuMoney, Money_YuZhi=@Money_YuZhi, YuMoney_YuZhi=@YuMoney_YuZhi, AddDate=@AddDate where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_AcBook where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_AcBook where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_AcBook> GetAllList()
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
		public  List<BU_AcBook> GetModelList(string where)
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
		public  BU_AcBook GetModel(long iD)
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
		/// <param name="_bU_AcBook">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_AcBook _bU_AcBook)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcBook.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_AcBook.Name}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.PayMoney}
					,new SqlParameter("@YuMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.YuMoney}
					,new SqlParameter("@Money_YuZhi",SqlDbType.Decimal,10){Value=_bU_AcBook.Money_YuZhi}
					,new SqlParameter("@YuMoney_YuZhi",SqlDbType.Decimal,10){Value=_bU_AcBook.YuMoney_YuZhi}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcBook.AddDate}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_AcBook">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_AcBook _bU_AcBook)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcBook.UserID}
					,new SqlParameter("@Name",SqlDbType.NVarChar,50){Value=_bU_AcBook.Name}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.PayMoney}
					,new SqlParameter("@YuMoney",SqlDbType.Decimal,10){Value=_bU_AcBook.YuMoney}
					,new SqlParameter("@Money_YuZhi",SqlDbType.Decimal,10){Value=_bU_AcBook.Money_YuZhi}
					,new SqlParameter("@YuMoney_YuZhi",SqlDbType.Decimal,10){Value=_bU_AcBook.YuMoney_YuZhi}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcBook.AddDate}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_AcBook.ID}
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
		public  int Delete(BU_AcBook _bU_AcBook)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_AcBook.ID}
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
		public  List<BU_AcBook> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_AcBook> bu_acbooks = new List<BU_AcBook>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_AcBook>();
			}
			bu_acbooks = DataTableToList(ds.Tables[0]);
			return bu_acbooks; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_AcBook> DataTableToList(DataTable dt)
		{
			List<BU_AcBook> bu_acbooks = new List<BU_AcBook>();
			BU_AcBook _bu_acbook = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_acbook = new BU_AcBook();
				if(dcs.Contains("id"))
				{
					_bu_acbook.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userid"))
				{
					_bu_acbook.UserID = Convert.ToInt64(item["UserID"]);
				}
				if(dcs.Contains("name"))
				{
					_bu_acbook.Name = item["Name"].ToString();
				}
				if(dcs.Contains("setmoney"))
				{
					_bu_acbook.SetMoney = Convert.ToDecimal(item["SetMoney"]);
				}
				if(dcs.Contains("paymoney"))
				{
					_bu_acbook.PayMoney = Convert.ToDecimal(item["PayMoney"]);
				}
				if(dcs.Contains("yumoney"))
				{
					_bu_acbook.YuMoney = Convert.ToDecimal(item["YuMoney"]);
				}
				if(dcs.Contains("money_yuzhi"))
				{
					_bu_acbook.Money_YuZhi = Convert.ToDecimal(item["Money_YuZhi"]);
				}
				if(dcs.Contains("yumoney_yuzhi"))
				{
					_bu_acbook.YuMoney_YuZhi = Convert.ToDecimal(item["YuMoney_YuZhi"]);
				}
				if(dcs.Contains("adddate"))
				{
					_bu_acbook.AddDate = Convert.ToDateTime(item["AddDate"]);
				}
				bu_acbooks.Add(_bu_acbook);
			}
			return bu_acbooks;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userid","name","setmoney","paymoney","yumoney","money_yuzhi","yumoney_yuzhi","adddate" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_AcBook DataRowToModel(DataRow dr)
		{
			BU_AcBook _bu_acbook = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_acbook = new BU_AcBook();
			if(dcs.Contains("id"))
			{
				_bu_acbook.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userid"))
			{
				_bu_acbook.UserID = Convert.ToInt64(dr["UserID"]);
			}
			if(dcs.Contains("name"))
			{
				_bu_acbook.Name = dr["Name"].ToString();
			}
			if(dcs.Contains("setmoney"))
			{
				_bu_acbook.SetMoney = Convert.ToDecimal(dr["SetMoney"]);
			}
			if(dcs.Contains("paymoney"))
			{
				_bu_acbook.PayMoney = Convert.ToDecimal(dr["PayMoney"]);
			}
			if(dcs.Contains("yumoney"))
			{
				_bu_acbook.YuMoney = Convert.ToDecimal(dr["YuMoney"]);
			}
			if(dcs.Contains("money_yuzhi"))
			{
				_bu_acbook.Money_YuZhi = Convert.ToDecimal(dr["Money_YuZhi"]);
			}
			if(dcs.Contains("yumoney_yuzhi"))
			{
				_bu_acbook.YuMoney_YuZhi = Convert.ToDecimal(dr["YuMoney_YuZhi"]);
			}
			if(dcs.Contains("adddate"))
			{
				_bu_acbook.AddDate = Convert.ToDateTime(dr["AddDate"]);
			}
			return _bu_acbook;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_acbooks">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_AcBook> bu_acbooks, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "name", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "setmoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "paymoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "yumoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_yuzhi", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "yumoney_yuzhi", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "adddate", DataType = typeof(DateTime) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_AcBook item in bu_acbooks)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["userid"] = item.UserID;
				_row["name"] = item.Name;
				_row["setmoney"] = item.SetMoney;
				_row["paymoney"] = item.PayMoney;
				_row["yumoney"] = item.YuMoney;
				_row["money_yuzhi"] = item.Money_YuZhi;
				_row["yumoney_yuzhi"] = item.YuMoney_YuZhi;
				_row["adddate"] = item.AddDate;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

