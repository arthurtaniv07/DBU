using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 
	/// <summary>
	public class BU_AcDebt
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
		/// 关联的债务人名  --  默认 ('')
		/// </summary>
		public string Name { get { return _name; } set { _name = value; } }
		private string _name = "";

		/// <summary>
		/// 该债务人钱用户的未还金额
		/// </summary>
		public decimal Money_Yu { get; set; }

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_AcDebt Clone()
		{
			BU_AcDebt c = new BU_AcDebt();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.Name = this.Name;
			c.Money_Yu = this.Money_Yu;
			return c;
		}
		#endregion 函数  结束

	}
}

