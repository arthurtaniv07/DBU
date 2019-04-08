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
	public class BU_AcIODAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_AcIO";
		#region CommandText
		private  string selectAllText = "select ID,UserID,AcBookID,AcBookName,OpWay,PayType,PayType2,PayType3,MediID,MediName,PayWayID,PayWayName,YouDebtID,YouComName,YouName,YouWayID,YouWayName,YouWayIDNumber,PayDate,PayDateStr,Money_Old,Money_Added,Money_Percent,SetMoney,PayMoney,Money_Result,Remark,YuMoney,IsBreakToLinkUser,IsBreakToPayWay,IsBaoXiao,LinkUserID,LinkUserName,LinkTableID,ApplyTableName,ApplyTableID,AddDate from BU_AcIO";
		private  string selectByKeyText = "select ID,UserID,AcBookID,AcBookName,OpWay,PayType,PayType2,PayType3,MediID,MediName,PayWayID,PayWayName,YouDebtID,YouComName,YouName,YouWayID,YouWayName,YouWayIDNumber,PayDate,PayDateStr,Money_Old,Money_Added,Money_Percent,SetMoney,PayMoney,Money_Result,Remark,YuMoney,IsBreakToLinkUser,IsBreakToPayWay,IsBaoXiao,LinkUserID,LinkUserName,LinkTableID,ApplyTableName,ApplyTableID,AddDate from BU_AcIO where ID=@ID";
		private  string selectByWhereText = "select ID,UserID,AcBookID,AcBookName,OpWay,PayType,PayType2,PayType3,MediID,MediName,PayWayID,PayWayName,YouDebtID,YouComName,YouName,YouWayID,YouWayName,YouWayIDNumber,PayDate,PayDateStr,Money_Old,Money_Added,Money_Percent,SetMoney,PayMoney,Money_Result,Remark,YuMoney,IsBreakToLinkUser,IsBreakToPayWay,IsBaoXiao,LinkUserID,LinkUserName,LinkTableID,ApplyTableName,ApplyTableID,AddDate from BU_AcIO {0}";
		
		private  string insertText = "insert into BU_AcIO(UserID, AcBookID, AcBookName, OpWay, PayType, PayType2, PayType3, MediID, MediName, PayWayID, PayWayName, YouDebtID, YouComName, YouName, YouWayID, YouWayName, YouWayIDNumber, PayDate, PayDateStr, Money_Old, Money_Added, Money_Percent, SetMoney, PayMoney, Money_Result, Remark, YuMoney, IsBreakToLinkUser, IsBreakToPayWay, IsBaoXiao, LinkUserID, LinkUserName, LinkTableID, ApplyTableName, ApplyTableID, AddDate) values(@UserID, @AcBookID, @AcBookName, @OpWay, @PayType, @PayType2, @PayType3, @MediID, @MediName, @PayWayID, @PayWayName, @YouDebtID, @YouComName, @YouName, @YouWayID, @YouWayName, @YouWayIDNumber, @PayDate, @PayDateStr, @Money_Old, @Money_Added, @Money_Percent, @SetMoney, @PayMoney, @Money_Result, @Remark, @YuMoney, @IsBreakToLinkUser, @IsBreakToPayWay, @IsBaoXiao, @LinkUserID, @LinkUserName, @LinkTableID, @ApplyTableName, @ApplyTableID, @AddDate);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_AcIO set UserID=@UserID, AcBookID=@AcBookID, AcBookName=@AcBookName, OpWay=@OpWay, PayType=@PayType, PayType2=@PayType2, PayType3=@PayType3, MediID=@MediID, MediName=@MediName, PayWayID=@PayWayID, PayWayName=@PayWayName, YouDebtID=@YouDebtID, YouComName=@YouComName, YouName=@YouName, YouWayID=@YouWayID, YouWayName=@YouWayName, YouWayIDNumber=@YouWayIDNumber, PayDate=@PayDate, PayDateStr=@PayDateStr, Money_Old=@Money_Old, Money_Added=@Money_Added, Money_Percent=@Money_Percent, SetMoney=@SetMoney, PayMoney=@PayMoney, Money_Result=@Money_Result, Remark=@Remark, YuMoney=@YuMoney, IsBreakToLinkUser=@IsBreakToLinkUser, IsBreakToPayWay=@IsBreakToPayWay, IsBaoXiao=@IsBaoXiao, LinkUserID=@LinkUserID, LinkUserName=@LinkUserName, LinkTableID=@LinkTableID, ApplyTableName=@ApplyTableName, ApplyTableID=@ApplyTableID, AddDate=@AddDate where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_AcIO where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_AcIO where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_AcIO> GetAllList()
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
		public  List<BU_AcIO> GetModelList(string where)
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
		public  BU_AcIO GetModel(long iD)
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
		/// <param name="_bU_AcIO">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_AcIO _bU_AcIO)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcIO.UserID}
					,new SqlParameter("@AcBookID",SqlDbType.BigInt,19){Value=_bU_AcIO.AcBookID}
					,new SqlParameter("@AcBookName",SqlDbType.NVarChar,50){Value=_bU_AcIO.AcBookName}
					,new SqlParameter("@OpWay",SqlDbType.Int,10){Value=_bU_AcIO.OpWay}
					,new SqlParameter("@PayType",SqlDbType.Int,10){Value=_bU_AcIO.PayType}
					,new SqlParameter("@PayType2",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayType2}
					,new SqlParameter("@PayType3",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayType3}
					,new SqlParameter("@MediID",SqlDbType.BigInt,19){Value=_bU_AcIO.MediID}
					,new SqlParameter("@MediName",SqlDbType.NVarChar,50){Value=_bU_AcIO.MediName}
					,new SqlParameter("@PayWayID",SqlDbType.BigInt,19){Value=_bU_AcIO.PayWayID}
					,new SqlParameter("@PayWayName",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayWayName}
					,new SqlParameter("@YouDebtID",SqlDbType.BigInt,19){Value=_bU_AcIO.YouDebtID}
					,new SqlParameter("@YouComName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouComName}
					,new SqlParameter("@YouName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouName}
					,new SqlParameter("@YouWayID",SqlDbType.BigInt,19){Value=_bU_AcIO.YouWayID}
					,new SqlParameter("@YouWayName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouWayName}
					,new SqlParameter("@YouWayIDNumber",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouWayIDNumber}
					,new SqlParameter("@PayDate",SqlDbType.DateTime,23){Value=_bU_AcIO.PayDate}
					,new SqlParameter("@PayDateStr",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayDateStr}
					,new SqlParameter("@Money_Old",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Old}
					,new SqlParameter("@Money_Added",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Added}
					,new SqlParameter("@Money_Percent",SqlDbType.Int,10){Value=_bU_AcIO.Money_Percent}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.PayMoney}
					,new SqlParameter("@Money_Result",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Result}
					,new SqlParameter("@Remark",SqlDbType.NVarChar,500){Value=_bU_AcIO.Remark}
					,new SqlParameter("@YuMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.YuMoney}
					,new SqlParameter("@IsBreakToLinkUser",SqlDbType.Int,10){Value=_bU_AcIO.IsBreakToLinkUser}
					,new SqlParameter("@IsBreakToPayWay",SqlDbType.Int,10){Value=_bU_AcIO.IsBreakToPayWay}
					,new SqlParameter("@IsBaoXiao",SqlDbType.Int,10){Value=_bU_AcIO.IsBaoXiao}
					,new SqlParameter("@LinkUserID",SqlDbType.BigInt,19){Value=_bU_AcIO.LinkUserID}
					,new SqlParameter("@LinkUserName",SqlDbType.NVarChar,50){Value=_bU_AcIO.LinkUserName}
					,new SqlParameter("@LinkTableID",SqlDbType.BigInt,19){Value=_bU_AcIO.LinkTableID}
					,new SqlParameter("@ApplyTableName",SqlDbType.NVarChar,50){Value=_bU_AcIO.ApplyTableName}
					,new SqlParameter("@ApplyTableID",SqlDbType.BigInt,19){Value=_bU_AcIO.ApplyTableID}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcIO.AddDate}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_AcIO">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_AcIO _bU_AcIO)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserID",SqlDbType.BigInt,19){Value=_bU_AcIO.UserID}
					,new SqlParameter("@AcBookID",SqlDbType.BigInt,19){Value=_bU_AcIO.AcBookID}
					,new SqlParameter("@AcBookName",SqlDbType.NVarChar,50){Value=_bU_AcIO.AcBookName}
					,new SqlParameter("@OpWay",SqlDbType.Int,10){Value=_bU_AcIO.OpWay}
					,new SqlParameter("@PayType",SqlDbType.Int,10){Value=_bU_AcIO.PayType}
					,new SqlParameter("@PayType2",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayType2}
					,new SqlParameter("@PayType3",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayType3}
					,new SqlParameter("@MediID",SqlDbType.BigInt,19){Value=_bU_AcIO.MediID}
					,new SqlParameter("@MediName",SqlDbType.NVarChar,50){Value=_bU_AcIO.MediName}
					,new SqlParameter("@PayWayID",SqlDbType.BigInt,19){Value=_bU_AcIO.PayWayID}
					,new SqlParameter("@PayWayName",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayWayName}
					,new SqlParameter("@YouDebtID",SqlDbType.BigInt,19){Value=_bU_AcIO.YouDebtID}
					,new SqlParameter("@YouComName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouComName}
					,new SqlParameter("@YouName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouName}
					,new SqlParameter("@YouWayID",SqlDbType.BigInt,19){Value=_bU_AcIO.YouWayID}
					,new SqlParameter("@YouWayName",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouWayName}
					,new SqlParameter("@YouWayIDNumber",SqlDbType.NVarChar,50){Value=_bU_AcIO.YouWayIDNumber}
					,new SqlParameter("@PayDate",SqlDbType.DateTime,23){Value=_bU_AcIO.PayDate}
					,new SqlParameter("@PayDateStr",SqlDbType.NVarChar,50){Value=_bU_AcIO.PayDateStr}
					,new SqlParameter("@Money_Old",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Old}
					,new SqlParameter("@Money_Added",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Added}
					,new SqlParameter("@Money_Percent",SqlDbType.Int,10){Value=_bU_AcIO.Money_Percent}
					,new SqlParameter("@SetMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.SetMoney}
					,new SqlParameter("@PayMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.PayMoney}
					,new SqlParameter("@Money_Result",SqlDbType.Decimal,10){Value=_bU_AcIO.Money_Result}
					,new SqlParameter("@Remark",SqlDbType.NVarChar,500){Value=_bU_AcIO.Remark}
					,new SqlParameter("@YuMoney",SqlDbType.Decimal,10){Value=_bU_AcIO.YuMoney}
					,new SqlParameter("@IsBreakToLinkUser",SqlDbType.Int,10){Value=_bU_AcIO.IsBreakToLinkUser}
					,new SqlParameter("@IsBreakToPayWay",SqlDbType.Int,10){Value=_bU_AcIO.IsBreakToPayWay}
					,new SqlParameter("@IsBaoXiao",SqlDbType.Int,10){Value=_bU_AcIO.IsBaoXiao}
					,new SqlParameter("@LinkUserID",SqlDbType.BigInt,19){Value=_bU_AcIO.LinkUserID}
					,new SqlParameter("@LinkUserName",SqlDbType.NVarChar,50){Value=_bU_AcIO.LinkUserName}
					,new SqlParameter("@LinkTableID",SqlDbType.BigInt,19){Value=_bU_AcIO.LinkTableID}
					,new SqlParameter("@ApplyTableName",SqlDbType.NVarChar,50){Value=_bU_AcIO.ApplyTableName}
					,new SqlParameter("@ApplyTableID",SqlDbType.BigInt,19){Value=_bU_AcIO.ApplyTableID}
					,new SqlParameter("@AddDate",SqlDbType.DateTime,23){Value=_bU_AcIO.AddDate}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_AcIO.ID}
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
		public  int Delete(BU_AcIO _bU_AcIO)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_AcIO.ID}
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
		public  List<BU_AcIO> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_AcIO> bu_acios = new List<BU_AcIO>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_AcIO>();
			}
			bu_acios = DataTableToList(ds.Tables[0]);
			return bu_acios; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_AcIO> DataTableToList(DataTable dt)
		{
			List<BU_AcIO> bu_acios = new List<BU_AcIO>();
			BU_AcIO _bu_acio = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_acio = new BU_AcIO();
				if(dcs.Contains("id"))
				{
					_bu_acio.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userid"))
				{
					_bu_acio.UserID = Convert.ToInt64(item["UserID"]);
				}
				if(dcs.Contains("acbookid"))
				{
					_bu_acio.AcBookID = Convert.ToInt64(item["AcBookID"]);
				}
				if(dcs.Contains("acbookname"))
				{
					_bu_acio.AcBookName = item["AcBookName"].ToString();
				}
				if(dcs.Contains("opway"))
				{
					_bu_acio.OpWay = Convert.ToInt32(item["OpWay"]);
				}
				if(dcs.Contains("paytype"))
				{
					_bu_acio.PayType = Convert.ToInt32(item["PayType"]);
				}
				if(dcs.Contains("paytype2"))
				{
					_bu_acio.PayType2 = item["PayType2"].ToString();
				}
				if(dcs.Contains("paytype3"))
				{
					_bu_acio.PayType3 = item["PayType3"].ToString();
				}
				if(dcs.Contains("mediid"))
				{
					_bu_acio.MediID = Convert.ToInt64(item["MediID"]);
				}
				if(dcs.Contains("mediname"))
				{
					_bu_acio.MediName = item["MediName"].ToString();
				}
				if(dcs.Contains("paywayid"))
				{
					_bu_acio.PayWayID = Convert.ToInt64(item["PayWayID"]);
				}
				if(dcs.Contains("paywayname"))
				{
					_bu_acio.PayWayName = item["PayWayName"].ToString();
				}
				if(dcs.Contains("youdebtid"))
				{
					_bu_acio.YouDebtID = Convert.ToInt64(item["YouDebtID"]);
				}
				if(dcs.Contains("youcomname"))
				{
					_bu_acio.YouComName = item["YouComName"].ToString();
				}
				if(dcs.Contains("youname"))
				{
					_bu_acio.YouName = item["YouName"].ToString();
				}
				if(dcs.Contains("youwayid"))
				{
					_bu_acio.YouWayID = Convert.ToInt64(item["YouWayID"]);
				}
				if(dcs.Contains("youwayname"))
				{
					_bu_acio.YouWayName = item["YouWayName"].ToString();
				}
				if(dcs.Contains("youwayidnumber"))
				{
					_bu_acio.YouWayIDNumber = item["YouWayIDNumber"].ToString();
				}
				if(dcs.Contains("paydate"))
				{
					_bu_acio.PayDate = Convert.ToDateTime(item["PayDate"]);
				}
				if(dcs.Contains("paydatestr"))
				{
					_bu_acio.PayDateStr = item["PayDateStr"].ToString();
				}
				if(dcs.Contains("money_old"))
				{
					_bu_acio.Money_Old = Convert.ToDecimal(item["Money_Old"]);
				}
				if(dcs.Contains("money_added"))
				{
					_bu_acio.Money_Added = Convert.ToDecimal(item["Money_Added"]);
				}
				if(dcs.Contains("money_percent"))
				{
					_bu_acio.Money_Percent = Convert.ToInt32(item["Money_Percent"]);
				}
				if(dcs.Contains("setmoney"))
				{
					_bu_acio.SetMoney = Convert.ToDecimal(item["SetMoney"]);
				}
				if(dcs.Contains("paymoney"))
				{
					_bu_acio.PayMoney = Convert.ToDecimal(item["PayMoney"]);
				}
				if(dcs.Contains("money_result"))
				{
					_bu_acio.Money_Result = Convert.ToDecimal(item["Money_Result"]);
				}
				if(dcs.Contains("remark"))
				{
					_bu_acio.Remark = item["Remark"].ToString();
				}
				if(dcs.Contains("yumoney"))
				{
					_bu_acio.YuMoney = Convert.ToDecimal(item["YuMoney"]);
				}
				if(dcs.Contains("isbreaktolinkuser"))
				{
					_bu_acio.IsBreakToLinkUser = Convert.ToInt32(item["IsBreakToLinkUser"]);
				}
				if(dcs.Contains("isbreaktopayway"))
				{
					_bu_acio.IsBreakToPayWay = Convert.ToInt32(item["IsBreakToPayWay"]);
				}
				if(dcs.Contains("isbaoxiao"))
				{
					_bu_acio.IsBaoXiao = Convert.ToInt32(item["IsBaoXiao"]);
				}
				if(dcs.Contains("linkuserid"))
				{
					_bu_acio.LinkUserID = Convert.ToInt64(item["LinkUserID"]);
				}
				if(dcs.Contains("linkusername"))
				{
					_bu_acio.LinkUserName = item["LinkUserName"].ToString();
				}
				if(dcs.Contains("linktableid"))
				{
					_bu_acio.LinkTableID = Convert.ToInt64(item["LinkTableID"]);
				}
				if(dcs.Contains("applytablename"))
				{
					_bu_acio.ApplyTableName = item["ApplyTableName"].ToString();
				}
				if(dcs.Contains("applytableid"))
				{
					_bu_acio.ApplyTableID = Convert.ToInt64(item["ApplyTableID"]);
				}
				if(dcs.Contains("adddate"))
				{
					_bu_acio.AddDate = Convert.ToDateTime(item["AddDate"]);
				}
				bu_acios.Add(_bu_acio);
			}
			return bu_acios;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userid","acbookid","acbookname","opway","paytype","paytype2","paytype3","mediid","mediname","paywayid","paywayname","youdebtid","youcomname","youname","youwayid","youwayname","youwayidnumber","paydate","paydatestr","money_old","money_added","money_percent","setmoney","paymoney","money_result","remark","yumoney","isbreaktolinkuser","isbreaktopayway","isbaoxiao","linkuserid","linkusername","linktableid","applytablename","applytableid","adddate" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_AcIO DataRowToModel(DataRow dr)
		{
			BU_AcIO _bu_acio = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_acio = new BU_AcIO();
			if(dcs.Contains("id"))
			{
				_bu_acio.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userid"))
			{
				_bu_acio.UserID = Convert.ToInt64(dr["UserID"]);
			}
			if(dcs.Contains("acbookid"))
			{
				_bu_acio.AcBookID = Convert.ToInt64(dr["AcBookID"]);
			}
			if(dcs.Contains("acbookname"))
			{
				_bu_acio.AcBookName = dr["AcBookName"].ToString();
			}
			if(dcs.Contains("opway"))
			{
				_bu_acio.OpWay = Convert.ToInt32(dr["OpWay"]);
			}
			if(dcs.Contains("paytype"))
			{
				_bu_acio.PayType = Convert.ToInt32(dr["PayType"]);
			}
			if(dcs.Contains("paytype2"))
			{
				_bu_acio.PayType2 = dr["PayType2"].ToString();
			}
			if(dcs.Contains("paytype3"))
			{
				_bu_acio.PayType3 = dr["PayType3"].ToString();
			}
			if(dcs.Contains("mediid"))
			{
				_bu_acio.MediID = Convert.ToInt64(dr["MediID"]);
			}
			if(dcs.Contains("mediname"))
			{
				_bu_acio.MediName = dr["MediName"].ToString();
			}
			if(dcs.Contains("paywayid"))
			{
				_bu_acio.PayWayID = Convert.ToInt64(dr["PayWayID"]);
			}
			if(dcs.Contains("paywayname"))
			{
				_bu_acio.PayWayName = dr["PayWayName"].ToString();
			}
			if(dcs.Contains("youdebtid"))
			{
				_bu_acio.YouDebtID = Convert.ToInt64(dr["YouDebtID"]);
			}
			if(dcs.Contains("youcomname"))
			{
				_bu_acio.YouComName = dr["YouComName"].ToString();
			}
			if(dcs.Contains("youname"))
			{
				_bu_acio.YouName = dr["YouName"].ToString();
			}
			if(dcs.Contains("youwayid"))
			{
				_bu_acio.YouWayID = Convert.ToInt64(dr["YouWayID"]);
			}
			if(dcs.Contains("youwayname"))
			{
				_bu_acio.YouWayName = dr["YouWayName"].ToString();
			}
			if(dcs.Contains("youwayidnumber"))
			{
				_bu_acio.YouWayIDNumber = dr["YouWayIDNumber"].ToString();
			}
			if(dcs.Contains("paydate"))
			{
				_bu_acio.PayDate = Convert.ToDateTime(dr["PayDate"]);
			}
			if(dcs.Contains("paydatestr"))
			{
				_bu_acio.PayDateStr = dr["PayDateStr"].ToString();
			}
			if(dcs.Contains("money_old"))
			{
				_bu_acio.Money_Old = Convert.ToDecimal(dr["Money_Old"]);
			}
			if(dcs.Contains("money_added"))
			{
				_bu_acio.Money_Added = Convert.ToDecimal(dr["Money_Added"]);
			}
			if(dcs.Contains("money_percent"))
			{
				_bu_acio.Money_Percent = Convert.ToInt32(dr["Money_Percent"]);
			}
			if(dcs.Contains("setmoney"))
			{
				_bu_acio.SetMoney = Convert.ToDecimal(dr["SetMoney"]);
			}
			if(dcs.Contains("paymoney"))
			{
				_bu_acio.PayMoney = Convert.ToDecimal(dr["PayMoney"]);
			}
			if(dcs.Contains("money_result"))
			{
				_bu_acio.Money_Result = Convert.ToDecimal(dr["Money_Result"]);
			}
			if(dcs.Contains("remark"))
			{
				_bu_acio.Remark = dr["Remark"].ToString();
			}
			if(dcs.Contains("yumoney"))
			{
				_bu_acio.YuMoney = Convert.ToDecimal(dr["YuMoney"]);
			}
			if(dcs.Contains("isbreaktolinkuser"))
			{
				_bu_acio.IsBreakToLinkUser = Convert.ToInt32(dr["IsBreakToLinkUser"]);
			}
			if(dcs.Contains("isbreaktopayway"))
			{
				_bu_acio.IsBreakToPayWay = Convert.ToInt32(dr["IsBreakToPayWay"]);
			}
			if(dcs.Contains("isbaoxiao"))
			{
				_bu_acio.IsBaoXiao = Convert.ToInt32(dr["IsBaoXiao"]);
			}
			if(dcs.Contains("linkuserid"))
			{
				_bu_acio.LinkUserID = Convert.ToInt64(dr["LinkUserID"]);
			}
			if(dcs.Contains("linkusername"))
			{
				_bu_acio.LinkUserName = dr["LinkUserName"].ToString();
			}
			if(dcs.Contains("linktableid"))
			{
				_bu_acio.LinkTableID = Convert.ToInt64(dr["LinkTableID"]);
			}
			if(dcs.Contains("applytablename"))
			{
				_bu_acio.ApplyTableName = dr["ApplyTableName"].ToString();
			}
			if(dcs.Contains("applytableid"))
			{
				_bu_acio.ApplyTableID = Convert.ToInt64(dr["ApplyTableID"]);
			}
			if(dcs.Contains("adddate"))
			{
				_bu_acio.AddDate = Convert.ToDateTime(dr["AddDate"]);
			}
			return _bu_acio;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_acios">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_AcIO> bu_acios, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "acbookid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "acbookname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "opway", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "paytype", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "paytype2", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "paytype3", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "mediid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "mediname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "paywayid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "paywayname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "youdebtid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "youcomname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "youname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "youwayid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "youwayname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "youwayidnumber", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "paydate", DataType = typeof(DateTime) });
			_cols.Add(new DataColumn() { ColumnName = "paydatestr", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "money_old", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_added", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_percent", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "setmoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "paymoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "money_result", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "remark", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "yumoney", DataType = typeof(decimal) });
			_cols.Add(new DataColumn() { ColumnName = "isbreaktolinkuser", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "isbreaktopayway", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "isbaoxiao", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "linkuserid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "linkusername", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "linktableid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "applytablename", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "applytableid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "adddate", DataType = typeof(DateTime) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_AcIO item in bu_acios)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["userid"] = item.UserID;
				_row["acbookid"] = item.AcBookID;
				_row["acbookname"] = item.AcBookName;
				_row["opway"] = item.OpWay;
				_row["paytype"] = item.PayType;
				_row["paytype2"] = item.PayType2;
				_row["paytype3"] = item.PayType3;
				_row["mediid"] = item.MediID;
				_row["mediname"] = item.MediName;
				_row["paywayid"] = item.PayWayID;
				_row["paywayname"] = item.PayWayName;
				_row["youdebtid"] = item.YouDebtID;
				_row["youcomname"] = item.YouComName;
				_row["youname"] = item.YouName;
				_row["youwayid"] = item.YouWayID;
				_row["youwayname"] = item.YouWayName;
				_row["youwayidnumber"] = item.YouWayIDNumber;
				_row["paydate"] = item.PayDate;
				_row["paydatestr"] = item.PayDateStr;
				_row["money_old"] = item.Money_Old;
				_row["money_added"] = item.Money_Added;
				_row["money_percent"] = item.Money_Percent;
				_row["setmoney"] = item.SetMoney;
				_row["paymoney"] = item.PayMoney;
				_row["money_result"] = item.Money_Result;
				_row["remark"] = item.Remark;
				_row["yumoney"] = item.YuMoney;
				_row["isbreaktolinkuser"] = item.IsBreakToLinkUser;
				_row["isbreaktopayway"] = item.IsBreakToPayWay;
				_row["isbaoxiao"] = item.IsBaoXiao;
				_row["linkuserid"] = item.LinkUserID;
				_row["linkusername"] = item.LinkUserName;
				_row["linktableid"] = item.LinkTableID;
				_row["applytablename"] = item.ApplyTableName;
				_row["applytableid"] = item.ApplyTableID;
				_row["adddate"] = item.AddDate;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

