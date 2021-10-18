using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// tNews:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class tNews
	{
		public tNews()
		{}
		#region Model
		private int _id;
		private string _title;
		private int _authorid;
		private int _categoryid;
		private DateTime _adddate= DateTime.Now;
		private string _referinfo;
		private string _contents;
		private string _status="待审核";
		private string _commentstatus="允许评论";
		private string _remark;
		private int _liulan=0;
		/// <summary>
		/// 主键，自增长
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 新闻标题
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 作者标识
		/// </summary>
		public int AuthorID
		{
			set{ _authorid=value;}
			get{return _authorid;}
		}
		/// <summary>
		/// 新闻类别序列
		/// </summary>
		public int CategoryID
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
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
		/// 出处
		/// </summary>
		public string ReferInfo
		{
			set{ _referinfo=value;}
			get{return _referinfo;}
		}
		/// <summary>
		/// 正文
		/// </summary>
		public string Contents
		{
			set{ _contents=value;}
			get{return _contents;}
		}
		/// <summary>
		/// 状态(待审核，可发布，未通过)
		/// </summary>
		public string Status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 评论状态(允许评论、禁止评论)
		/// </summary>
		public string CommentStatus
		{
			set{ _commentstatus=value;}
			get{return _commentstatus;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 浏览次数
		/// </summary>
		public int LiuLan
		{
			set{ _liulan=value;}
			get{return _liulan;}
		}
		#endregion Model

	}
}

