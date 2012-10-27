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
			var site = new Site { Title = "A Test Site" };

			var post = new Post
			{
				Title = "My First Post",
				Date = DateTime.Now,
				Description = "A post, that was first",
				Content = @"<b>First!</b>",
				Status = "publish",
				Categories = new List<Category> { new Category { Name = "My Cat", NiceName = "mycat" } },
				Tags = new List<Tag> { new Tag { Name = "My Tag", Slug = "mytag" } }
			};

			site.Posts.Add(post);

			site.SerializeToDisk(@"c:\users\ben\desktop");
		}
	}
}
