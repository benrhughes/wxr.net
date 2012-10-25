using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using XmlGuy;

namespace WXR
{
	public class Site
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public string Link { get; set; }
		public string BaseUrl { get; set; }
		public string BlogUrl { get; set; }
		public DateTime PubDate { get; set; }
		public IList<Post> Posts { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public IEnumerable<string> Categories { get; set; }

		public Site()
		{
			Posts = new List<Post>();
			Tags = new List<string>();
			Categories = new List<string>();
		}

		public override string ToString()
		{
			return Title;
		}

		public void DownloadMedia(string targetDir)
		{
			throw new NotImplementedException();
		}

		public void SerializeToDisk(string targetDir, bool includeMedia = true)
		{

		}

		public XmlDocument GenerateXML()
		{
			var doc = new XmlDocument();

			var root = doc.Begin("channel");

			root.Add("title", Title).Up()
				.Add("link", Link).Up()
				.Add("description").CData(Description).Up()
				.Add("language", "en").Up()
				.Add("wp:wxr_version", "1.1").Up()
				.Add("generator", "hughesoft.com").Up()
				.Add("pubDate", PubDate.ToString()).Up()
				.Add("wp:base_site_url", BaseUrl).Up()
				.Add("wp:base_blog_url", BlogUrl);

			foreach (var tag in Tags)
				root.Add("wp:tag")
						.Add("wp:tag_slug", tag).Up()
						.Add("wp:tag_name", tag).Up();

			foreach (var post in Posts)
				root.Children.Add(post.GenerateXML());

			return doc;
		}
	}
}
