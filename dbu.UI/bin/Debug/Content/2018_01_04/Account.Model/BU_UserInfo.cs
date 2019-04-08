using System;
using System.Text;


namespace Account.Model
{
	[Serializable]
	/// <summary>
	/// 用户信息表
	/// <summary>
	public class BU_UserInfo
	{
		#region 属性

		/// <summary>
		/// ID 的描述
		/// </summary>
		public long ID { get; set; }

		/// <summary>
		/// 用户编号
		/// </summary>
		public string UserNO { get; set; }

		/// <summary>
		/// 用户中文名  --  默认 ('')
		/// </summary>
		public string UserName { get { return _userName; } set { _userName = value; } }
		private string _userName = "";

		/// <summary>
		/// 登录名  --  默认 ('')
		/// </summary>
		public string LoginName { get { return _loginName; } set { _loginName = value; } }
		private string _loginName = "";

		/// <summary>
		/// 密码 加密后  --  默认 ('')
		/// </summary>
		public string Pwd { get { return _pwd; } set { _pwd = value; } }
		private string _pwd = "";

		/// <summary>
		/// 登录令牌  --  默认 ('')
		/// </summary>
		public string ToKen { get { return _toKen; } set { _toKen = value; } }
		private string _toKen = "";

		/// <summary>
		/// 性别
		/// </summary>
		public string Gender { get; set; }

		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime BirthDate { get; set; }

		/// <summary>
		/// 联系电话（手机）
		/// </summary>
		public string Mobile { get; set; }

		/// <summary>
		/// 联系电话（座机）
		/// </summary>
		public string Telephone { get; set; }

		/// <summary>
		/// 传真  --  默认 ('')
		/// </summary>
		public string Fax { get { return _fax; } set { _fax = value; } }
		private string _fax = "";

		/// <summary>
		/// QQ号码
		/// </summary>
		public string QQ { get; set; }

		/// <summary>
		/// 电子邮件
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// 创建时间  --  默认 (getdate())
		/// </summary>
		public DateTime CreateTime { get { return _createTime; } set { _createTime = value; } }
		private DateTime _createTime = DateTime.Now;

		/// <summary>
		/// UpdateTime 的描述
		/// </summary>
		public DateTime? UpdateTime { get; set; }

		/// <summary>
		/// ProvinceCode 的描述
		/// </summary>
		public string ProvinceCode { get { return _provinceCode; } set { _provinceCode = value; } }
		private string _provinceCode = "";

		/// <summary>
		/// 省份  --  默认 ('')
		/// </summary>
		public string Province { get { return _province; } set { _province = value; } }
		private string _province = "";

		/// <summary>
		/// CityCode 的描述
		/// </summary>
		public string CityCode { get { return _cityCode; } set { _cityCode = value; } }
		private string _cityCode = "";

		/// <summary>
		/// 城市  --  默认 ('')
		/// </summary>
		public string City { get { return _city; } set { _city = value; } }
		private string _city = "";

		#endregion 属性  结束

		#region 函数

		/// <summary>
		/// 深度克隆 用户信息表
		/// </summary>
		/// <returns>克隆后的对象</returns>
		public BU_UserInfo Clone()
		{
			BU_UserInfo c = new BU_UserInfo();
			c.ID = this.ID;
			c.UserNO = this.UserNO;
			c.UserName = this.UserName;
			c.LoginName = this.LoginName;
			c.Pwd = this.Pwd;
			c.ToKen = this.ToKen;
			c.Gender = this.Gender;
			c.BirthDate = this.BirthDate;
			c.Mobile = this.Mobile;
			c.Telephone = this.Telephone;
			c.Fax = this.Fax;
			c.QQ = this.QQ;
			c.Email = this.Email;
			c.CreateTime = this.CreateTime;
			c.UpdateTime = this.UpdateTime;
			c.ProvinceCode = this.ProvinceCode;
			c.Province = this.Province;
			c.CityCode = this.CityCode;
			c.City = this.City;
			return c;
		}
		#endregion 函数  结束

	}
}

