using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 常用支付方式
	/// <summary>
	public class BU_PayType2
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 用户ID  --  默认 ((0))
		/// </summary>
		public long UserID { get { return _userID; } set { _userID = value; } }
		private long _userID = 0;

		/// <summary>
		/// 操作类型 （-1支出 1收入 2转账 3借贷）  --  默认 ((-1))
		/// </summary>
		public int OpWay { get { return _opWay; } set { _opWay = value; } }
		private int _opWay = -1;

		/// <summary>
		/// 收支类型 -1:支 1收  --  默认 ((0))
		/// </summary>
		public int PayType { get { return _payType; } set { _payType = value; } }
		private int _payType = 0;

		/// <summary>
		/// 支付账目  如生活缴费(水费 电费 网费)  充值(流量 话费)  --  默认 ('')
		/// </summary>
		public string Name { get { return _name; } set { _name = value; } }
		private string _name = "";

		/// <summary>
		/// 状态  --  默认 ((1))
		/// </summary>
		public int State { get { return _state; } set { _state = value; } }
		private int _state = 1;

		/// <summary>
		/// 排序 越大越靠后  --  默认 ((0))
		/// </summary>
		public long Sort { get { return _sort; } set { _sort = value; } }
		private long _sort = 0;

		/// <summary>
		/// 是否需要还给该账号（0不需要  1需要）  --  默认 ((0))
		/// </summary>
		public bool IsBreak { get { return _isBreak; } set { _isBreak = value; } }
		private bool _isBreak = false;

		/// <summary>
		/// 添加时间  --  默认 (getdate())
		/// </summary>
		public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
		private DateTime _addDate = DateTime.Now;

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 常用支付方式
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_PayType2 Clone()
		{
			BU_PayType2 c = new BU_PayType2();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.OpWay = this.OpWay;
			c.PayType = this.PayType;
			c.Name = this.Name;
			c.State = this.State;
			c.Sort = this.Sort;
			c.IsBreak = this.IsBreak;
			c.AddDate = this.AddDate;
			return c;
		}
		#endregion 函数  结束

	}
}

