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
	public class BU_UserLoginDAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_UserLogin";
		#region CommandText
		private  string selectAllText = "select ID,LoginSource,UID,UserNO,AddTime,State,OpUserID,OpUserName,OpTime from BU_UserLogin";
		private  string selectByKeyText = "select ID,LoginSource,UID,UserNO,AddTime,State,OpUserID,OpUserName,OpTime from BU_UserLogin where ID=@ID";
		private  string selectByWhereText = "select ID,LoginSource,UID,UserNO,AddTime,State,OpUserID,OpUserName,OpTime from BU_UserLogin {0}";
		
		private  string insertText = "insert into BU_UserLogin(LoginSource, UID, UserNO, AddTime, State, OpUserID, OpUserName, OpTime) values(@LoginSource, @UID, @UserNO, @AddTime, @State, @OpUserID, @OpUserName, @OpTime);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_UserLogin set LoginSource=@LoginSource, UID=@UID, UserNO=@UserNO, AddTime=@AddTime, State=@State, OpUserID=@OpUserID, OpUserName=@OpUserName, OpTime=@OpTime where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_UserLogin where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_UserLogin where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_UserLogin> GetAllList()
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
		public  List<BU_UserLogin> GetModelList(string where)
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
		public  BU_UserLogin GetModel(long iD)
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
		/// <param name="_bU_UserLogin">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_UserLogin _bU_UserLogin)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@LoginSource",SqlDbType.Int,10){Value=_bU_UserLogin.LoginSource}
					,new SqlParameter("@UID",SqlDbType.NVarChar,100){Value=_bU_UserLogin.UID}
					,new SqlParameter("@UserNO",SqlDbType.VarChar,32){Value=_bU_UserLogin.UserNO}
					,new SqlParameter("@AddTime",SqlDbType.DateTime,23){Value=_bU_UserLogin.AddTime}
					,new SqlParameter("@State",SqlDbType.Int,10){Value=_bU_UserLogin.State}
					,new SqlParameter("@OpUserID",SqlDbType.BigInt,19){Value=_bU_UserLogin.OpUserID}
					,new SqlParameter("@OpUserName",SqlDbType.NVarChar,50){Value=_bU_UserLogin.OpUserName}
					,new SqlParameter("@OpTime",SqlDbType.DateTime,23){Value=_bU_UserLogin.OpTime}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_UserLogin">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_UserLogin _bU_UserLogin)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@LoginSource",SqlDbType.Int,10){Value=_bU_UserLogin.LoginSource}
					,new SqlParameter("@UID",SqlDbType.NVarChar,100){Value=_bU_UserLogin.UID}
					,new SqlParameter("@UserNO",SqlDbType.VarChar,32){Value=_bU_UserLogin.UserNO}
					,new SqlParameter("@AddTime",SqlDbType.DateTime,23){Value=_bU_UserLogin.AddTime}
					,new SqlParameter("@State",SqlDbType.Int,10){Value=_bU_UserLogin.State}
					,new SqlParameter("@OpUserID",SqlDbType.BigInt,19){Value=_bU_UserLogin.OpUserID}
					,new SqlParameter("@OpUserName",SqlDbType.NVarChar,50){Value=_bU_UserLogin.OpUserName}
					,new SqlParameter("@OpTime",SqlDbType.DateTime,23){Value=_bU_UserLogin.OpTime}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_UserLogin.ID}
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
		public  int Delete(BU_UserLogin _bU_UserLogin)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_UserLogin.ID}
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
		public  List<BU_UserLogin> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_UserLogin> bu_userlogins = new List<BU_UserLogin>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_UserLogin>();
			}
			bu_userlogins = DataTableToList(ds.Tables[0]);
			return bu_userlogins; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_UserLogin> DataTableToList(DataTable dt)
		{
			List<BU_UserLogin> bu_userlogins = new List<BU_UserLogin>();
			BU_UserLogin _bu_userlogin = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_userlogin = new BU_UserLogin();
				if(dcs.Contains("id"))
				{
					_bu_userlogin.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("loginsource"))
				{
					_bu_userlogin.LoginSource = Convert.ToInt32(item["LoginSource"]);
				}
				if(dcs.Contains("uid"))
				{
					_bu_userlogin.UID = item["UID"].ToString();
				}
				if(dcs.Contains("userno"))
				{
					_bu_userlogin.UserNO = item["UserNO"].ToString();
				}
				if(dcs.Contains("addtime"))
				{
					_bu_userlogin.AddTime = Convert.ToDateTime(item["AddTime"]);
				}
				if(dcs.Contains("state"))
				{
					_bu_userlogin.State = Convert.ToInt32(item["State"]);
				}
				if(dcs.Contains("opuserid"))
				{
					_bu_userlogin.OpUserID = Convert.ToInt64(item["OpUserID"]);
				}
				if(dcs.Contains("opusername"))
				{
					_bu_userlogin.OpUserName = item["OpUserName"].ToString();
				}
				if(dcs.Contains("optime"))
				{
					_temp = item["OpTime"];
					if(!(_temp is DBNull))
					{
						_bu_userlogin.OpTime = Convert.ToDateTime(_temp);
					}
				}
				bu_userlogins.Add(_bu_userlogin);
			}
			return bu_userlogins;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","loginsource","uid","userno","addtime","state","opuserid","opusername","optime" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_UserLogin DataRowToModel(DataRow dr)
		{
			BU_UserLogin _bu_userlogin = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_userlogin = new BU_UserLogin();
			if(dcs.Contains("id"))
			{
				_bu_userlogin.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("loginsource"))
			{
				_bu_userlogin.LoginSource = Convert.ToInt32(dr["LoginSource"]);
			}
			if(dcs.Contains("uid"))
			{
				_bu_userlogin.UID = dr["UID"].ToString();
			}
			if(dcs.Contains("userno"))
			{
				_bu_userlogin.UserNO = dr["UserNO"].ToString();
			}
			if(dcs.Contains("addtime"))
			{
				_bu_userlogin.AddTime = Convert.ToDateTime(dr["AddTime"]);
			}
			if(dcs.Contains("state"))
			{
				_bu_userlogin.State = Convert.ToInt32(dr["State"]);
			}
			if(dcs.Contains("opuserid"))
			{
				_bu_userlogin.OpUserID = Convert.ToInt64(dr["OpUserID"]);
			}
			if(dcs.Contains("opusername"))
			{
				_bu_userlogin.OpUserName = dr["OpUserName"].ToString();
			}
			if(dcs.Contains("optime"))
			{
				_temp = dr["OpTime"];
				if(!(_temp is DBNull))
				{
					_bu_userlogin.OpTime = Convert.ToDateTime(_temp);
				}
			}
			return _bu_userlogin;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_userlogins">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_UserLogin> bu_userlogins, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "loginsource", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "uid", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "userno", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "addtime", DataType = typeof(DateTime) });
			_cols.Add(new DataColumn() { ColumnName = "state", DataType = typeof(int) });
			_cols.Add(new DataColumn() { ColumnName = "opuserid", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "opusername", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "optime", DataType = typeof(DateTime) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_UserLogin item in bu_userlogins)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["loginsource"] = item.LoginSource;
				_row["uid"] = item.UID;
				_row["userno"] = item.UserNO;
				_row["addtime"] = item.AddTime;
				_row["state"] = item.State;
				_row["opuserid"] = item.OpUserID;
				_row["opusername"] = item.OpUserName;
				_row["optime"] = item.OpTime;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

