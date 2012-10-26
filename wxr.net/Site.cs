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
		public IEnumerable<Tag> Tags { get; set; }
		public IEnumerable<Category> Categories { get; set; }

		public Site()
		{
			Posts = new List<Post>();
			Tags = new List<Tag>();
			Categories = new List<Category>();
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
			File.WriteAllText(Path.Combine(targetDir, Title + ".xml"), GenerateXML().ToString(true));
		}

		public XmlDocument GenerateXML()
		{
			var doc = new XmlDocument();

			var rss = doc.Begin("rss");
			rss.Attributes = new Dictionary<string, string>()
			{
				{"version", "2.0"},
				{"xmlns:content", "http://purl.org/rss/1.0/modules/content/"},
				{"xmlns:wfw", "http://wellformedweb.org/CommentAPI/"},
				{"xmlns:dc", "http://purl.org/dc/elements/1.1/"},
				{"xmlns:wp", "http://wordpress.org/export/1.2/"},
				{"xmlns:excerpt", "http://wordpress.org/export/1.2/excerpt/"}
			};

			var channel = rss.Add("channel");
			channel.Add("title", Title).Up()
				.Add("link", Link).Up()
				.Add("description").CData(Description).Up()
				.Add("language", "en").Up()
				.Add("wp:wxr_version", "1.1").Up()
				.Add("generator", "hughesoft.com").Up()
				.Add("pubDate", PubDate.ToString()).Up()
				.Add("wp:base_site_url", BaseUrl).Up()
				.Add("wp:base_blog_url", BlogUrl);

			foreach (var tag in Tags)
				channel.Add("wp:tag")
						.Add("wp:tag_slug", tag.Slug).Up()
						.Add("wp:tag_name", tag.Name).Up();

			foreach (var cat in Categories)
				channel.Add("wp:category")
						.Add("wp:category_nicename", cat.NiceName).Up()
						.Add("wp:cat_name", cat.Name).Up()
						.Add("wp:categor_parent", cat.Parent);

			foreach (var post in Posts)
				channel.Children.Add(post.GenerateXML());

			return doc;
		}
	}
}
