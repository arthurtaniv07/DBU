using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 流水账目表
	/// <summary>
	public class BU_AcIO
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
		/// 账本ID  --  默认 ((0))
		/// </summary>
		public long AcBookID { get { return _acBookID; } set { _acBookID = value; } }
		private long _acBookID = 0;

		/// <summary>
		/// 账本名称  --  默认 ('')
		/// </summary>
		public string AcBookName { get { return _acBookName; } set { _acBookName = value; } }
		private string _acBookName = "";

		/// <summary>
		/// 操作类型 （-1支出 1收入 2转账 3借贷）  --  默认 ((-1))
		/// </summary>
		public int OpWay { get { return _opWay; } set { _opWay = value; } }
		private int _opWay = -1;

		/// <summary>
		/// 支付类型 0未发生对外交易(如取款)  1收入  -1支出   --  默认 ((-1))
		/// </summary>
		public int PayType { get { return _payType; } set { _payType = value; } }
		private int _payType = -1;

		/// <summary>
		/// 支付账目  如生活缴费(水费 电费 网费)  充值(流量 话费)  --  默认 ('')
		/// </summary>
		public string PayType2 { get { return _payType2; } set { _payType2 = value; } }
		private string _payType2 = "";

		/// <summary>
		/// 支付类型 如水费 电费 工资  --  默认 ('')
		/// </summary>
		public string PayType3 { get { return _payType3; } set { _payType3 = value; } }
		private string _payType3 = "";

		/// <summary>
		/// 媒介ID  --  默认 ((0))
		/// </summary>
		public long MediID { get { return _mediID; } set { _mediID = value; } }
		private long _mediID = 0;

		/// <summary>
		/// 媒介名称，如支付宝 微信   --  默认 ('')
		/// </summary>
		public string MediName { get { return _mediName; } set { _mediName = value; } }
		private string _mediName = "";

		/// <summary>
		/// 支付的账户  --  默认 ((0))
		/// </summary>
		public long PayWayID { get { return _payWayID; } set { _payWayID = value; } }
		private long _payWayID = 0;

		/// <summary>
		/// 支付的账户名称  如花呗 现金 余额宝  --  默认 ('')
		/// </summary>
		public string PayWayName { get { return _payWayName; } set { _payWayName = value; } }
		private string _payWayName = "";

		/// <summary>
		/// 债务人ID  --  默认 ((0))
		/// </summary>
		public long YouDebtID { get { return _youDebtID; } set { _youDebtID = value; } }
		private long _youDebtID = 0;

		/// <summary>
		/// 对方所属单位名称  --  默认 ('')
		/// </summary>
		public string YouComName { get { return _youComName; } set { _youComName = value; } }
		private string _youComName = "";

		/// <summary>
		/// 对方名称  --  默认 ('')
		/// </summary>
		public string YouName { get { return _youName; } set { _youName = value; } }
		private string _youName = "";

		/// <summary>
		/// 对方账户ID  --  默认 ((0))
		/// </summary>
		public long YouWayID { get { return _youWayID; } set { _youWayID = value; } }
		private long _youWayID = 0;

		/// <summary>
		/// 对方账户名称  --  默认 ('')
		/// </summary>
		public string YouWayName { get { return _youWayName; } set { _youWayName = value; } }
		private string _youWayName = "";

		/// <summary>
		/// 对方账户号码  比如银行卡号  --  默认 ('')
		/// </summary>
		public string YouWayIDNumber { get { return _youWayIDNumber; } set { _youWayIDNumber = value; } }
		private string _youWayIDNumber = "";

		/// <summary>
		/// 交易时间  --  默认 (getdate())
		/// </summary>
		public DateTime PayDate { get { return _payDate; } set { _payDate = value; } }
		private DateTime _payDate = DateTime.Now;

		/// <summary>
		/// 交易时间 不确定的时间段（如2017春节期间）  --  默认 ('')
		/// </summary>
		public string PayDateStr { get { return _payDateStr; } set { _payDateStr = value; } }
		private string _payDateStr = "";

		/// <summary>
		/// 应付款  --  默认 ((0))
		/// </summary>
		public decimal Money_Old { get { return _money_Old; } set { _money_Old = value; } }
		private decimal _money_Old = 0;

		/// <summary>
		/// 增加的金额、优惠的金额  --  默认 ((0))
		/// </summary>
		public decimal Money_Added { get { return _money_Added; } set { _money_Added = value; } }
		private decimal _money_Added = 0;

		/// <summary>
		/// (单位:%)  增加的百分比、减少的百分比  --  默认 ((0))
		/// </summary>
		public int Money_Percent { get { return _money_Percent; } set { _money_Percent = value; } }
		private int _money_Percent = 0;

		/// <summary>
		/// 收入金额  --  默认 ((0))
		/// </summary>
		public decimal SetMoney { get { return _setMoney; } set { _setMoney = value; } }
		private decimal _setMoney = 0;

		/// <summary>
		/// 支出金额  --  默认 ((0))
		/// </summary>
		public decimal PayMoney { get { return _payMoney; } set { _payMoney = value; } }
		private decimal _payMoney = 0;

		/// <summary>
		/// 最终交易的金额  --  默认 ((0))
		/// </summary>
		public decimal Money_Result { get { return _money_Result; } set { _money_Result = value; } }
		private decimal _money_Result = 0;

		/// <summary>
		/// 用户备注  --  默认 ('')
		/// </summary>
		public string Remark { get { return _remark; } set { _remark = value; } }
		private string _remark = "";

		/// <summary>
		/// 未还的金额（为付则是需要还给对方的金额）  --  默认 ((0))
		/// </summary>
		public decimal YuMoney { get { return _yuMoney; } set { _yuMoney = value; } }
		private decimal _yuMoney = 0;

		/// <summary>
		/// 是否需要还（0不需要  1需要）（针对制定的用户）  --  默认 ((0))
		/// </summary>
		public int IsBreakToLinkUser { get { return _isBreakToLinkUser; } set { _isBreakToLinkUser = value; } }
		private int _isBreakToLinkUser = 0;

		/// <summary>
		/// 是否需要还（0不需要  1需要）(针对支付方式)  --  默认 ((0))
		/// </summary>
		public int IsBreakToPayWay { get { return _isBreakToPayWay; } set { _isBreakToPayWay = value; } }
		private int _isBreakToPayWay = 0;

		/// <summary>
		/// 是否已经报销（只有支出才有值  -1不报销   0待报销 1已经报销 2未报销）  --  默认 ((-1))
		/// </summary>
		public int IsBaoXiao { get { return _isBaoXiao; } set { _isBaoXiao = value; } }
		private int _isBaoXiao = -1;

		/// <summary>
		/// 该记录制定的用户ID  --  默认 ((0))
		/// </summary>
		public long LinkUserID { get { return _linkUserID; } set { _linkUserID = value; } }
		private long _linkUserID = 0;

		/// <summary>
		/// 该记录制定的用户名称  --  默认 ('')
		/// </summary>
		public string LinkUserName { get { return _linkUserName; } set { _linkUserName = value; } }
		private string _linkUserName = "";

		/// <summary>
		/// 关联的ID  --  默认 ((0))
		/// </summary>
		public long LinkTableID { get { return _linkTableID; } set { _linkTableID = value; } }
		private long _linkTableID = 0;

		/// <summary>
		/// 申请表表名  --  默认 ('')
		/// </summary>
		public string ApplyTableName { get { return _applyTableName; } set { _applyTableName = value; } }
		private string _applyTableName = "";

		/// <summary>
		/// 申请表ID  --  默认 ((0))
		/// </summary>
		public long ApplyTableID { get { return _applyTableID; } set { _applyTableID = value; } }
		private long _applyTableID = 0;

		/// <summary>
		/// 添加时间  --  默认 (getdate())
		/// </summary>
		public DateTime AddDate { get { return _addDate; } set { _addDate = value; } }
		private DateTime _addDate = DateTime.Now;

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 流水账目表
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_AcIO Clone()
		{
			BU_AcIO c = new BU_AcIO();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.AcBookID = this.AcBookID;
			c.AcBookName = this.AcBookName;
			c.OpWay = this.OpWay;
			c.PayType = this.PayType;
			c.PayType2 = this.PayType2;
			c.PayType3 = this.PayType3;
			c.MediID = this.MediID;
			c.MediName = this.MediName;
			c.PayWayID = this.PayWayID;
			c.PayWayName = this.PayWayName;
			c.YouDebtID = this.YouDebtID;
			c.YouComName = this.YouComName;
			c.YouName = this.YouName;
			c.YouWayID = this.YouWayID;
			c.YouWayName = this.YouWayName;
			c.YouWayIDNumber = this.YouWayIDNumber;
			c.PayDate = this.PayDate;
			c.PayDateStr = this.PayDateStr;
			c.Money_Old = this.Money_Old;
			c.Money_Added = this.Money_Added;
			c.Money_Percent = this.Money_Percent;
			c.SetMoney = this.SetMoney;
			c.PayMoney = this.PayMoney;
			c.Money_Result = this.Money_Result;
			c.Remark = this.Remark;
			c.YuMoney = this.YuMoney;
			c.IsBreakToLinkUser = this.IsBreakToLinkUser;
			c.IsBreakToPayWay = this.IsBreakToPayWay;
			c.IsBaoXiao = this.IsBaoXiao;
			c.LinkUserID = this.LinkUserID;
			c.LinkUserName = this.LinkUserName;
			c.LinkTableID = this.LinkTableID;
			c.ApplyTableName = this.ApplyTableName;
			c.ApplyTableID = this.ApplyTableID;
			c.AddDate = this.AddDate;
			return c;
		}
		#endregion 函数  结束

	}
}

