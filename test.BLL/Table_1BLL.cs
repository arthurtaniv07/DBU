using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

using test.Model;
using test.DAL;

namespace test.BLL
{
	public class Table_1BLL
	{
		
		Table_1DAL _dal = new Table_1DAL();
		
		#region GetModelList
		/// <summary>
		/// 获取全部数据
		/// </summary>
		/// <returns>全部数据</returns>
		public  List<Table_1> GetAllList()
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
		public  List<Table_1> GetModelList(string where)
		{
			return _dal.GetModelList(where);
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
			return _dal.GetModelByUserID(userID);
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
		/// 向数据库插入一条新数据 返回受影响行数
		/// </summary>
		/// <param name="_table_1">需要插入的对象</param>
		/// <returns></returns>
		public  int Add(Table_1 _table_1)
		{
			return _dal.Add(_table_1);
		}
		#endregion
		
		#region Update
		/// <summary>
		/// 更新数据库的一条记录
		/// </summary>
		/// <param name="_table_1">需要更新的对象</param>
		/// <returns></returns>
		public  int Update(Table_1 _table_1)
		{
			return _dal.Update(_table_1);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定唯一键的数据
		/// </summary>
		/// <param name="userID">要删除的 唯一键 集合，中间用 , 隔开 </param>
		/// <returns></returns>
		public  int DeleteByUserIDs(string userIDs)
		{
			return _dal.DeleteByUserIDs(userIDs);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="UserID">要删除的对象  （通过唯一键）</param>
		/// <returns></returns>
		public  int Delete(Table_1 _table_1)
		{
			return _dal.Delete(_table_1);
		}
		#endregion
		
		#region Delete
		/// <summary>
		/// 删除指定数据
		/// </summary>
		/// <param name="UserID">唯一键</param>
		/// <returns></returns>
		public  int DeleteByUserID(string UserID)
		{
			return _dal.DeleteByUserID(UserID);
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
			return _dal.DataTableToList(dt);
		}
		#endregion
		
		#region DataTableToList
		/// <summary>
		/// 将数据行转换为对象
		/// </summary>
		/// <param name="dt">要转换的数据行</param>
		/// <returns></returns>
		public  Table_1 DataRowToModel(DataRow dr)
		{
			return _dal.DataRowToModel(dr);
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
			return _dal.ListToDataTable(table_1s,IsIdentity,IsComputed);
		}
		#endregion
		
	}
}

