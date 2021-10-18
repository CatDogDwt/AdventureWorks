using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tUsers:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tUsers
	{
		public tUsers()
		{}
		#region Model
		private int _id;
		private string _userloginid;
		private string _password;
		private string _username;
		private string _useremail;
		private DateTime _userregdate= DateTime.Now;
		private string _usertype="普通用户";
		private string _remark;
		/// <summary>
		/// 序号标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 登录名
		/// </summary>
		public string UserLoginID
		{
			set{ _userloginid=value;}
			get{return _userloginid;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 姓名或昵称
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// E-mail
		/// </summary>
		public string UserEmail
		{
			set{ _useremail=value;}
			get{return _useremail;}
		}
		/// <summary>
		/// 注册日期
		/// </summary>
		public DateTime UserRegDate
		{
			set{ _userregdate=value;}
			get{return _userregdate;}
		}
		/// <summary>
		/// 用户类别(管理员,普通用户)
		/// </summary>
		public string UserType
		{
			set{ _usertype=value;}
			get{return _usertype;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

