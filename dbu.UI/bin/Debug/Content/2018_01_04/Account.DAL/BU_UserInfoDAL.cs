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
	public class BU_UserInfoDAL
	{
		
		private  DbHelper db=new DbHelper();

		private  string tabName = "BU_UserInfo";
		#region CommandText
		private  string selectAllText = "select ID,UserNO,UserName,LoginName,Pwd,ToKen,Gender,BirthDate,Mobile,Telephone,Fax,QQ,Email,CreateTime,UpdateTime,ProvinceCode,Province,CityCode,City from BU_UserInfo";
		private  string selectByKeyText = "select ID,UserNO,UserName,LoginName,Pwd,ToKen,Gender,BirthDate,Mobile,Telephone,Fax,QQ,Email,CreateTime,UpdateTime,ProvinceCode,Province,CityCode,City from BU_UserInfo where ID=@ID";
		private  string selectByWhereText = "select ID,UserNO,UserName,LoginName,Pwd,ToKen,Gender,BirthDate,Mobile,Telephone,Fax,QQ,Email,CreateTime,UpdateTime,ProvinceCode,Province,CityCode,City from BU_UserInfo {0}";
		
		private  string insertText = "insert into BU_UserInfo(UserNO, UserName, LoginName, Pwd, ToKen, Gender, BirthDate, Mobile, Telephone, Fax, QQ, Email, CreateTime, UpdateTime, ProvinceCode, Province, CityCode, City) values(@UserNO, @UserName, @LoginName, @Pwd, @ToKen, @Gender, @BirthDate, @Mobile, @Telephone, @Fax, @QQ, @Email, @CreateTime, @UpdateTime, @ProvinceCode, @Province, @CityCode, @City);select @@IDENTITY";
		private  string updateByKeyText = "update  BU_UserInfo set UserNO=@UserNO, UserName=@UserName, LoginName=@LoginName, Pwd=@Pwd, ToKen=@ToKen, Gender=@Gender, BirthDate=@BirthDate, Mobile=@Mobile, Telephone=@Telephone, Fax=@Fax, QQ=@QQ, Email=@Email, CreateTime=@CreateTime, UpdateTime=@UpdateTime, ProvinceCode=@ProvinceCode, Province=@Province, CityCode=@CityCode, City=@City where ID=@ID1";

		private  string deleteByKeyText = "delete from BU_UserInfo where ID=@ID";
		private  string deleteByKeyInText = "delete from BU_UserInfo where ID in ({0})";
		#endregion
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_UserInfo> GetAllList()
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
		public  List<BU_UserInfo> GetModelList(string where)
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
		public  BU_UserInfo GetModel(long iD)
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
		/// <param name="_bU_UserInfo">需要插入的对象</param>
		/// <returns></returns>
		public  long Add(BU_UserInfo _bU_UserInfo)
		{
			object obj = db.ExecuteScalar(insertText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserNO",SqlDbType.VarChar,32){Value=_bU_UserInfo.UserNO}
					,new SqlParameter("@UserName",SqlDbType.NVarChar,50){Value=_bU_UserInfo.UserName}
					,new SqlParameter("@LoginName",SqlDbType.NVarChar,50){Value=_bU_UserInfo.LoginName}
					,new SqlParameter("@Pwd",SqlDbType.NVarChar,500){Value=_bU_UserInfo.Pwd}
					,new SqlParameter("@ToKen",SqlDbType.NVarChar,50){Value=_bU_UserInfo.ToKen}
					,new SqlParameter("@Gender",SqlDbType.VarChar,2){Value=_bU_UserInfo.Gender}
					,new SqlParameter("@BirthDate",SqlDbType.DateTime,23){Value=_bU_UserInfo.BirthDate}
					,new SqlParameter("@Mobile",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Mobile}
					,new SqlParameter("@Telephone",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Telephone}
					,new SqlParameter("@Fax",SqlDbType.NVarChar,32){Value=_bU_UserInfo.Fax}
					,new SqlParameter("@QQ",SqlDbType.NVarChar,50){Value=_bU_UserInfo.QQ}
					,new SqlParameter("@Email",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Email}
					,new SqlParameter("@CreateTime",SqlDbType.DateTime,23){Value=_bU_UserInfo.CreateTime}
					,new SqlParameter("@UpdateTime",SqlDbType.DateTime,23){Value=_bU_UserInfo.UpdateTime}
					,new SqlParameter("@ProvinceCode",SqlDbType.NVarChar,6){Value=_bU_UserInfo.ProvinceCode}
					,new SqlParameter("@Province",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Province}
					,new SqlParameter("@CityCode",SqlDbType.NVarChar,6){Value=_bU_UserInfo.CityCode}
					,new SqlParameter("@City",SqlDbType.NVarChar,50){Value=_bU_UserInfo.City}
				});
			return obj is DBNull ? 0 : Convert.ToInt64(obj);
		}
		#endregion
		
		#region 函数 Update 更新数据库的一条记录
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_UserInfo">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_UserInfo _bU_UserInfo)
		{
			return db.ExecuteNonQuery(updateByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@UserNO",SqlDbType.VarChar,32){Value=_bU_UserInfo.UserNO}
					,new SqlParameter("@UserName",SqlDbType.NVarChar,50){Value=_bU_UserInfo.UserName}
					,new SqlParameter("@LoginName",SqlDbType.NVarChar,50){Value=_bU_UserInfo.LoginName}
					,new SqlParameter("@Pwd",SqlDbType.NVarChar,500){Value=_bU_UserInfo.Pwd}
					,new SqlParameter("@ToKen",SqlDbType.NVarChar,50){Value=_bU_UserInfo.ToKen}
					,new SqlParameter("@Gender",SqlDbType.VarChar,2){Value=_bU_UserInfo.Gender}
					,new SqlParameter("@BirthDate",SqlDbType.DateTime,23){Value=_bU_UserInfo.BirthDate}
					,new SqlParameter("@Mobile",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Mobile}
					,new SqlParameter("@Telephone",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Telephone}
					,new SqlParameter("@Fax",SqlDbType.NVarChar,32){Value=_bU_UserInfo.Fax}
					,new SqlParameter("@QQ",SqlDbType.NVarChar,50){Value=_bU_UserInfo.QQ}
					,new SqlParameter("@Email",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Email}
					,new SqlParameter("@CreateTime",SqlDbType.DateTime,23){Value=_bU_UserInfo.CreateTime}
					,new SqlParameter("@UpdateTime",SqlDbType.DateTime,23){Value=_bU_UserInfo.UpdateTime}
					,new SqlParameter("@ProvinceCode",SqlDbType.NVarChar,6){Value=_bU_UserInfo.ProvinceCode}
					,new SqlParameter("@Province",SqlDbType.NVarChar,50){Value=_bU_UserInfo.Province}
					,new SqlParameter("@CityCode",SqlDbType.NVarChar,6){Value=_bU_UserInfo.CityCode}
					,new SqlParameter("@City",SqlDbType.NVarChar,50){Value=_bU_UserInfo.City}
					,new SqlParameter("@ID1",SqlDbType.BigInt,19){Value=_bU_UserInfo.ID}
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
		public  int Delete(BU_UserInfo _bU_UserInfo)
		{
			return db.ExecuteNonQuery(deleteByKeyText, CommandType.Text, 
				new SqlParameter[]{
					new SqlParameter("@ID",SqlDbType.BigInt,19){Value=_bU_UserInfo.ID}
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
		public  List<BU_UserInfo> Find(string text,CommandType type,params SqlParameter[] pars)
		{
			List<BU_UserInfo> bu_userinfos = new List<BU_UserInfo>(); 
			DataSet ds = db.ExecuteDataSet(text, type, pars); 
			if(ds == null || ds.Tables.Count == 0)
			{
				return new List<BU_UserInfo>();
			}
			bu_userinfos = DataTableToList(ds.Tables[0]);
			return bu_userinfos; 
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将表转换为对象集合
		/// </summary>
		/// <param name="dt">要转换的表</param>
		/// <returns></returns>
		public  List<BU_UserInfo> DataTableToList(DataTable dt)
		{
			List<BU_UserInfo> bu_userinfos = new List<BU_UserInfo>();
			BU_UserInfo _bu_userinfo = null;
			object _temp = null;
			DataColumnCollection dcs = dt.Columns;
			foreach (DataRow item in dt.Rows)
			{
				_bu_userinfo = new BU_UserInfo();
				if(dcs.Contains("id"))
				{
					_bu_userinfo.ID = Convert.ToInt64(item["ID"]);
				}
				if(dcs.Contains("userno"))
				{
					_bu_userinfo.UserNO = item["UserNO"].ToString();
				}
				if(dcs.Contains("username"))
				{
					_temp = item["UserName"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.UserName = _temp.ToString();
					}
				}
				if(dcs.Contains("loginname"))
				{
					_bu_userinfo.LoginName = item["LoginName"].ToString();
				}
				if(dcs.Contains("pwd"))
				{
					_bu_userinfo.Pwd = item["Pwd"].ToString();
				}
				if(dcs.Contains("token"))
				{
					_bu_userinfo.ToKen = item["ToKen"].ToString();
				}
				if(dcs.Contains("gender"))
				{
					_temp = item["Gender"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.Gender = _temp.ToString();
					}
				}
				if(dcs.Contains("birthdate"))
				{
					_bu_userinfo.BirthDate = Convert.ToDateTime(item["BirthDate"]);
				}
				if(dcs.Contains("mobile"))
				{
					_temp = item["Mobile"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.Mobile = _temp.ToString();
					}
				}
				if(dcs.Contains("telephone"))
				{
					_temp = item["Telephone"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.Telephone = _temp.ToString();
					}
				}
				if(dcs.Contains("fax"))
				{
					_temp = item["Fax"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.Fax = _temp.ToString();
					}
				}
				if(dcs.Contains("qq"))
				{
					_temp = item["QQ"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.QQ = _temp.ToString();
					}
				}
				if(dcs.Contains("email"))
				{
					_temp = item["Email"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.Email = _temp.ToString();
					}
				}
				if(dcs.Contains("createtime"))
				{
					_bu_userinfo.CreateTime = Convert.ToDateTime(item["CreateTime"]);
				}
				if(dcs.Contains("updatetime"))
				{
					_temp = item["UpdateTime"];
					if(!(_temp is DBNull))
					{
						_bu_userinfo.UpdateTime = Convert.ToDateTime(_temp);
					}
				}
				if(dcs.Contains("provincecode"))
				{
					_bu_userinfo.ProvinceCode = item["ProvinceCode"].ToString();
				}
				if(dcs.Contains("province"))
				{
					_bu_userinfo.Province = item["Province"].ToString();
				}
				if(dcs.Contains("citycode"))
				{
					_bu_userinfo.CityCode = item["CityCode"].ToString();
				}
				if(dcs.Contains("city"))
				{
					_bu_userinfo.City = item["City"].ToString();
				}
				bu_userinfos.Add(_bu_userinfo);
			}
			return bu_userinfos;
		}
		#endregion
		

		private  List<string> cols = new List<string>() { "id","userno","username","loginname","pwd","token","gender","birthdate","mobile","telephone","fax","qq","email","createtime","updatetime","provincecode","province","citycode","city" };

		#region DataRowToModel
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_UserInfo DataRowToModel(DataRow dr)
		{
			BU_UserInfo _bu_userinfo = null;
			object _temp = null;
			DataColumnCollection dcs = dr.Table.Columns;
			_bu_userinfo = new BU_UserInfo();
			if(dcs.Contains("id"))
			{
				_bu_userinfo.ID = Convert.ToInt64(dr["ID"]);
			}
			if(dcs.Contains("userno"))
			{
				_bu_userinfo.UserNO = dr["UserNO"].ToString();
			}
			if(dcs.Contains("username"))
			{
				_temp = dr["UserName"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.UserName = _temp.ToString();
				}
			}
			if(dcs.Contains("loginname"))
			{
				_bu_userinfo.LoginName = dr["LoginName"].ToString();
			}
			if(dcs.Contains("pwd"))
			{
				_bu_userinfo.Pwd = dr["Pwd"].ToString();
			}
			if(dcs.Contains("token"))
			{
				_bu_userinfo.ToKen = dr["ToKen"].ToString();
			}
			if(dcs.Contains("gender"))
			{
				_temp = dr["Gender"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.Gender = _temp.ToString();
				}
			}
			if(dcs.Contains("birthdate"))
			{
				_bu_userinfo.BirthDate = Convert.ToDateTime(dr["BirthDate"]);
			}
			if(dcs.Contains("mobile"))
			{
				_temp = dr["Mobile"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.Mobile = _temp.ToString();
				}
			}
			if(dcs.Contains("telephone"))
			{
				_temp = dr["Telephone"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.Telephone = _temp.ToString();
				}
			}
			if(dcs.Contains("fax"))
			{
				_temp = dr["Fax"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.Fax = _temp.ToString();
				}
			}
			if(dcs.Contains("qq"))
			{
				_temp = dr["QQ"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.QQ = _temp.ToString();
				}
			}
			if(dcs.Contains("email"))
			{
				_temp = dr["Email"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.Email = _temp.ToString();
				}
			}
			if(dcs.Contains("createtime"))
			{
				_bu_userinfo.CreateTime = Convert.ToDateTime(dr["CreateTime"]);
			}
			if(dcs.Contains("updatetime"))
			{
				_temp = dr["UpdateTime"];
				if(!(_temp is DBNull))
				{
					_bu_userinfo.UpdateTime = Convert.ToDateTime(_temp);
				}
			}
			if(dcs.Contains("provincecode"))
			{
				_bu_userinfo.ProvinceCode = dr["ProvinceCode"].ToString();
			}
			if(dcs.Contains("province"))
			{
				_bu_userinfo.Province = dr["Province"].ToString();
			}
			if(dcs.Contains("citycode"))
			{
				_bu_userinfo.CityCode = dr["CityCode"].ToString();
			}
			if(dcs.Contains("city"))
			{
				_bu_userinfo.City = dr["City"].ToString();
			}
			return _bu_userinfo;
		}
		#endregion
		
		#region ListToDataTable
		/// <summary>
		/// 将对象集合转换为表
		/// </summary>
		/// <param name="bu_userinfos">要转换的对象集合</param>
		/// <param name="IsIdentity">是否加入自增列 默认不添加</param>
		/// <param name="IsComputed">是否加入计算列 默认不添加</param>
		/// <returns></returns>
		public  DataTable ListToDataTable(List<BU_UserInfo> bu_userinfos, bool IsIdentity = false, bool IsComputed = false)
		{
			DataTable dt = new DataTable();
			List<DataColumn> _cols = new List<DataColumn>();
			
			//添加列
			if(IsIdentity)
				_cols.Add(new DataColumn() { ColumnName = "id", DataType = typeof(long) });
			_cols.Add(new DataColumn() { ColumnName = "userno", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "username", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "loginname", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "pwd", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "token", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "gender", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "birthdate", DataType = typeof(DateTime) });
			_cols.Add(new DataColumn() { ColumnName = "mobile", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "telephone", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "fax", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "qq", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "email", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "createtime", DataType = typeof(DateTime) });
			_cols.Add(new DataColumn() { ColumnName = "updatetime", DataType = typeof(DateTime) });
			_cols.Add(new DataColumn() { ColumnName = "provincecode", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "province", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "citycode", DataType = typeof(string) });
			_cols.Add(new DataColumn() { ColumnName = "city", DataType = typeof(string) });
			dt.Columns.AddRange(_cols.ToArray());
			
			//添加行
			DataRow _row = null;
			foreach (BU_UserInfo item in bu_userinfos)
			{
				_row = dt.NewRow();
				if(IsIdentity)
					_row["id"] = item.ID;
				_row["userno"] = item.UserNO;
				_row["username"] = item.UserName;
				_row["loginname"] = item.LoginName;
				_row["pwd"] = item.Pwd;
				_row["token"] = item.ToKen;
				_row["gender"] = item.Gender;
				_row["birthdate"] = item.BirthDate;
				_row["mobile"] = item.Mobile;
				_row["telephone"] = item.Telephone;
				_row["fax"] = item.Fax;
				_row["qq"] = item.QQ;
				_row["email"] = item.Email;
				_row["createtime"] = item.CreateTime;
				_row["updatetime"] = item.UpdateTime;
				_row["provincecode"] = item.ProvinceCode;
				_row["province"] = item.Province;
				_row["citycode"] = item.CityCode;
				_row["city"] = item.City;
				dt.Rows.Add(_row);
			}
			return dt;
		}
		#endregion
		
	}
}

