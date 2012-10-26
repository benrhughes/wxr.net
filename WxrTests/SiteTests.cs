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
			s.PubDate = DateTime.Now;

			var p = new Post
			{
				Title = "Post One",
				Date = DateTime.Now,
				Id = "postone",
				Content = @"<b>First!</b>",
				Description = "First",
				Tags = new List<Tag> { new Tag{ Name="A Tag", Slug="tag" } },
				Categories = new List<Category> { new Category { Name = "Cat One", NiceName = "cat1" } },
				Status = "publish"
			};

			s.Posts.Add(p);
			s.Categories = s.Posts.SelectMany(x => x.Categories);
			s.Tags = s.Posts.SelectMany(x => x.Tags);

			Console.WriteLine(s.GenerateXML().ToString(true));
			s.SerializeToDisk(@"c:\users\ben\desktop");
		}
	}
}
