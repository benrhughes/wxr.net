﻿using System;
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
				post.Add("wp:tag")
						.Add("wp:tag_slug", tag.Slug).Up()
						.Add("wp:tag_name", tag.Name).Up();

			foreach (var cat in Categories)
				post.Add("wp:category")
						.Add("wp:category_nicename", cat.NiceName).Up()
						.Add("wp:cat_name", cat.Name).Up()
						.Add("wp:categor_parent", cat.Parent);

			return post;
		}
	}
}
