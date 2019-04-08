using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 
	/// <summary>
	public class BU_AcDebtInfo
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 关联的用户ID  --  默认 ((0))
		/// </summary>
		public long UserID { get { return _userID; } set { _userID = value; } }
		private long _userID = 0;

		/// <summary>
		/// 关联的债务人ID  --  默认 ((0))
		/// </summary>
		public long DebtUserID { get { return _debtUserID; } set { _debtUserID = value; } }
		private long _debtUserID = 0;

		/// <summary>
		/// 收入的金额  --  默认 ((0))
		/// </summary>
		public decimal SetMoney { get { return _setMoney; } set { _setMoney = value; } }
		private decimal _setMoney = 0;

		/// <summary>
		/// 支出的金额  --  默认 ((0))
		/// </summary>
		public decimal PayMoney { get { return _payMoney; } set { _payMoney = value; } }
		private decimal _payMoney = 0;

		/// <summary>
		/// 利息  --  默认 ((0))
		/// </summary>
		public decimal Money_Old { get { return _money_Old; } set { _money_Old = value; } }
		private decimal _money_Old = 0;

		/// <summary>
		/// Money_Added 的描述
		/// </summary>
		public decimal Money_Added { get { return _money_Added; } set { _money_Added = value; } }
		private decimal _money_Added = 0;

		/// <summary>
		/// 原金额  --  默认 ((0))
		/// </summary>
		public decimal Money_Result { get { return _money_Result; } set { _money_Result = value; } }
		private decimal _money_Result = 0;

		/// <summary>
		/// 添加时间  --  默认 (getdate())
		/// </summary>
		public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
		private DateTime _addDate = DateTime.Now;

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_AcDebtInfo Clone()
		{
			BU_AcDebtInfo c = new BU_AcDebtInfo();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.DebtUserID = this.DebtUserID;
			c.SetMoney = this.SetMoney;
			c.PayMoney = this.PayMoney;
			c.Money_Old = this.Money_Old;
			c.Money_Added = this.Money_Added;
			c.Money_Result = this.Money_Result;
			c.AddDate = this.AddDate;
			return c;
		}
		#endregion 函数  结束

	}
}

