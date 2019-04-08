using System;
using System.Text;


namespace test.Model
{
	[Serializable]
	/// <summary>
	/// 
	/// <summary>
	public class Table_1
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserID { get; set; }

		/// <summary>
		/// 测试2自增
		/// </summary>
		public int Iden { get; set; }

		/// <summary>
		/// 成绩1  --  默认 ((0))
		/// </summary>
		public decimal S1 { get { return _s1; } set { _s1 = value; } }
		private decimal _s1 = 0;

		/// <summary>
		/// 成绩2  --  默认 ((0))
		/// </summary>
		public decimal S2 { get { return _s2; } set { _s2 = value; } }
		private decimal _s2 = 0;

		/// <summary>
		/// 总成绩
		/// </summary>
		public decimal? SSum { get; set; }

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public Table_1 Clone()
		{
			Table_1 c = new Table_1();
			c.ID = this.ID;
			c.UserID = this.UserID;
			c.Iden = this.Iden;
			c.S1 = this.S1;
			c.S2 = this.S2;
			c.SSum = this.SSum;
			return c;
		}
		#endregion 函数  结束

	}
}

