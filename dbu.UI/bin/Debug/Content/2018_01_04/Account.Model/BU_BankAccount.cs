using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 
	/// <summary>
	public class BU_BankAccount
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
		/// 银行类型 （ 0债务人  1现金 2网络账户  3储蓄卡  4信用卡）  --  默认 ((1))
		/// </summary>
		public int BankType { get { return _bankType; } set { _bankType = value; } }
		private int _bankType = 1;

		/// <summary>
		/// Name 的描述
		/// </summary>
		public string Name { get { return _name; } set { _name = value; } }
		private string _name = "";

		/// <summary>
		/// 账号  --  默认 ('')
		/// </summary>
		public string IDNumber { get { return _iDNumber; } set { _iDNumber = value; } }
		private string _iDNumber = "";

		/// <summary>
		/// 币种类型  --  默认 ((0))
		/// </summary>
		public int MoneyType { get { return _moneyType; } set { _moneyType = value; } }
		private int _moneyType = 0;

		/// <summary>
		/// 账户余额  --  默认 ((0))
		/// </summary>
		public decimal YuMoney { get { return _yuMoney; } set { _yuMoney = value; } }
		private decimal _yuMoney = 0;

		/// <summary>
		/// 余额是否允许小于0（是否信用）  --  默认 ((0))
		/// </summary>
		public int IsBreak { get { return _isBreak; } set { _isBreak = value; } }
		private int _isBreak = 0;

		/// <summary>
		/// 添加日期  --  默认 (getdate())
		/// </summary>
		public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
		private DateTime _addDate = DateTime.Now;

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_BankAccount Clone()
		{
			BU_BankAccount c = new BU_BankAccount();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.BankType = this.BankType;
			c.Name = this.Name;
			c.IDNumber = this.IDNumber;
			c.MoneyType = this.MoneyType;
			c.YuMoney = this.YuMoney;
			c.IsBreak = this.IsBreak;
			c.AddDate = this.AddDate;
			return c;
		}
		#endregion 函数  结束

	}
}

