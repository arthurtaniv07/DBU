using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 登录账号
	/// <summary>
	public class BU_UserLogin
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 注册来源 （微信、QQ、新浪微博）
		/// </summary>
		public int LoginSource { get; set; }

		/// <summary>
		/// 第三方唯一索引
		/// </summary>
		public string UID { get; set; }

		/// <summary>
		/// 对应系统的用户编号  --  默认 ('')
		/// </summary>
		public string UserNO { get { return _userNO; } set { _userNO = value; } }
		private string _userNO = "";

		/// <summary>
		/// 注册时间  --  默认 (getdate())
		/// </summary>
		public DateTime AddTime { get { return _addTime; } set { _addTime = value; } }
		private DateTime _addTime = DateTime.Now;

		/// <summary>
		/// 状态 0未激活 1正常  --  默认 ((0))
		/// </summary>
		public int State { get { return _state; } set { _state = value; } }
		private int _state = 0;

		/// <summary>
		/// 操作用户ID  --  默认 ((0))
		/// </summary>
		public long OpUserID { get { return _opUserID; } set { _opUserID = value; } }
		private long _opUserID = 0;

		/// <summary>
		/// OpUserName 的描述
		/// </summary>
		public string OpUserName { get { return _opUserName; } set { _opUserName = value; } }
		private string _opUserName = "";

		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? OpTime { get; set; }

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 登录账号
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_UserLogin Clone()
		{
			BU_UserLogin c = new BU_UserLogin();
			c.ID = this.ID;
			c.LoginSource = this.LoginSource;
			c.UID = this.UID;
			c.UserNO = this.UserNO;
			c.AddTime = this.AddTime;
			c.State = this.State;
			c.OpUserID = this.OpUserID;
			c.OpUserName = this.OpUserName;
			c.OpTime = this.OpTime;
			return c;
		}
		#endregion 函数  结束

	}
}

