using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

		public IEnumerable<string> Tags { get; set; }
		public IEnumerable<string> Categories { get; set; }

		public Post()
		{
			this.Tags = new List<string>();
		}
	}
}
