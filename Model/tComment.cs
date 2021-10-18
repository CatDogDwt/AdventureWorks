using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tComment:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tComment
	{
		public tComment()
		{}
		#region Model
		private int _id;
		private int _newsid;
		private int _authorid;
		private DateTime _adddate= DateTime.Now;
		private string _contents;
		private string _status="待审核";
		/// <summary>
		/// 评论序号标识
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 评论的新闻ID
		/// </summary>
		public int NewsID
		{
			set{ _newsid=value;}
			get{return _newsid;}
		}
		/// <summary>
		/// 作者ID
		/// </summary>
		public int AuthorID
		{
			set{ _authorid=value;}
			get{return _authorid;}
		}
		/// <summary>
		/// 添加日期
		/// </summary>
		public DateTime AddDate
		{
			set{ _adddate=value;}
			get{return _adddate;}
		}
		/// <summary>
		/// 评论正文
		/// </summary>
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 状态(待审核、可发布、未通过)
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		#endregion Model

	}
}

