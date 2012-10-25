using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WXR;

namespace WxrTests
{
	[TestFixture]
	public class SiteTests
	{
		[Test]
		public void MyTest()
		{
			var s = new Site();
			s.Title = "A Test";

			var p = new Post
			{
				Title = "Post One",
				Date = DateTime.Now,
				Id = "postone",
				Content = @"<b>First!</b>",
				Description = "First",
				Tags = new List<string> { "" },
				Categories = new List<string> { "uncategorised" },
				Status = "published"
			};

			s.Posts.Add(p);

			Console.WriteLine(s.GenerateXML().ToString(true));
		}
	}
}
