using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using Account.Model;
using Account.DAL;

namespace Account.BLL
{
	public class BU_UserInfoBLL
	{
		
		BU_UserInfoDAL _dal = new BU_UserInfoDAL();
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<BU_UserInfo> GetAllList()
		{
			return _dal.GetAllList();
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
			return _dal.GetModelList(where);
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
			return _dal.GetModel(iD);
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
			return _dal.GetPageData_NotIn( querystring , where, take, skip, groupString, orderString);
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
			return _dal.GetPageData_MaxID( querystring , where, take, skip, groupString, orderString);
		}
		#endregion
		
		#region 函数 GetPageData_RowNumber3 使用PaddingType.NotIn的方式提取数据库数据
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
			return _dal.GetPageData_RowNumber3( querystring , where, take, skip, groupString, orderString);
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
			return _dal.Add(_bU_UserInfo);
		}
		#endregion
		
		#region Update
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_bU_UserInfo">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(BU_UserInfo _bU_UserInfo)
		{
			return _dal.Update(_bU_UserInfo);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定主键的数据
		/// </summary>
		/// <param name="iD">要删除的 主键 集合，中间用 , 隔开 </param>
		/// <returns></returns>
		public  int Deletes(string iDs)
		{
			return _dal.Deletes(iDs);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="ID">要删除的对象  （通过主键）</param>
		/// <returns></returns>
		public  int Delete(BU_UserInfo _bU_UserInfo)
		{
			return _dal.Delete(_bU_UserInfo);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="ID">主键</param>
		/// <returns></returns>
		public  int Delete(long ID)
		{
			return _dal.Delete(ID);
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
			return _dal.DataTableToList(dt);
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  BU_UserInfo DataRowToModel(DataRow dr)
		{
			return _dal.DataRowToModel(dr);
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
			return _dal.ListToDataTable(bu_userinfos,IsIdentity,IsComputed);
		}
		#endregion
		
	}
}

