using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace WXR
{
	public class Site
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IList<Post> Posts { get; set; }
		public IEnumerable<string> Tags { get; set; }
		public IEnumerable<string> Categories { get; set; }

		public Site()
		{
			Posts = new List<Post>();
		}

		public override string ToString()
		{
			return Title;
		}

		public XmlDocument Serialize()
		{
			throw new NotImplementedException();
		}

		public void DownloadMedia(string targetDir)
		{
			throw new NotImplementedException();
		}

		public object SerializeToDisk(string targetDir)
		{
			throw new NotImplementedException();
		}
	}
}
