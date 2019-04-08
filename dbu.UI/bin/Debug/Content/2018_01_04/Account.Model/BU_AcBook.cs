using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 账簿
	/// <summary>
	public class BU_AcBook
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 账本所属的用户ID  --  默认 ((0))
		/// </summary>
		public long UserID { get { return _userID; } set { _userID = value; } }
		private long _userID = 0;

		/// <summary>
		/// 账本名称  --  默认 ('')
		/// </summary>
		public string Name { get { return _name; } set { _name = value; } }
		private string _name = "";

		/// <summary>
		/// 账本总收入  --  默认 ((0))
		/// </summary>
		public decimal SetMoney { get { return _setMoney; } set { _setMoney = value; } }
		private decimal _setMoney = 0;

		/// <summary>
		/// 账本总支出  --  默认 ((0))
		/// </summary>
		public decimal PayMoney { get { return _payMoney; } set { _payMoney = value; } }
		private decimal _payMoney = 0;

		/// <summary>
		/// 账本余额  --  默认 ((0))
		/// </summary>
		public decimal YuMoney { get { return _yuMoney; } set { _yuMoney = value; } }
		private decimal _yuMoney = 0;

		/// <summary>
		/// 账本预支金额  --  默认 ((0))
		/// </summary>
		public decimal Money_YuZhi { get { return _money_YuZhi; } set { _money_YuZhi = value; } }
		private decimal _money_YuZhi = 0;

		/// <summary>
		/// 账本剩余预支金额  --  默认 ((0))
		/// </summary>
		public decimal YuMoney_YuZhi { get { return _yuMoney_YuZhi; } set { _yuMoney_YuZhi = value; } }
		private decimal _yuMoney_YuZhi = 0;

		/// <summary>
		/// 添加时间  --  默认 (getdate())
		/// </summary>
		public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
		private DateTime _addDate = DateTime.Now;

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 账簿
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_AcBook Clone()
		{
			BU_AcBook c = new BU_AcBook();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.Name = this.Name;
			c.SetMoney = this.SetMoney;
			c.PayMoney = this.PayMoney;
			c.YuMoney = this.YuMoney;
			c.Money_YuZhi = this.Money_YuZhi;
			c.YuMoney_YuZhi = this.YuMoney_YuZhi;
			c.AddDate = this.AddDate;
			return c;
		}
		#endregion 函数  结束

	}
}

