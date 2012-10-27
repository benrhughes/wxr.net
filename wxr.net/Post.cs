using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlGuy;

namespace WXR
{
	public class Post
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public string Id { get; set; }
		public DateTime Date { get; set; }
		public string Status { get; set; }

		public IEnumerable<Tag> Tags { get; set; }
		public IEnumerable<Category> Categories { get; set; }

		public Post()
		{
			Tags = new List<Tag>();
			Categories = new List<Category>();
		}

		public XmlElement GenerateXML()
		{
			var post = new XmlElement { Name = "item" };

			post.Add("title").CData(Title).Up()
				.Add("description", Description).Up()
				.Add("pubDate", Date.ToString()).Up()
				.Add("content:encoded").CData(Content).Up()
				.Add("wp:post_id", Id).Up()
				.Add("wp:post_date", Date.ToString()).Up()
				.Add("wp:post_date_gmt", Date.ToUniversalTime().ToString()).Up()
				.Add("wp:post_type", "post").Up()
				.Add("wp:status", Status).Up();

			foreach (var tag in Tags)
				post.Add("category", new { nicename = tag.Slug, domain = "post_tag" })
					.CData(tag.Name);

			foreach (var cat in Categories)
				post.Add("category", new { nicename = cat.NiceName, domain = "category"})
					.CData(cat.Name);

			return post;
		}
	}
}
