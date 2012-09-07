using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;

namespace WXR
{
	public class Site
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Content { get; set; }
		public string Link { get; set; }
		public DateTime PubDate { get; set; }
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

		public void DownloadMedia(string targetDir)
		{
			throw new NotImplementedException();
		}

		public void SerializeToDisk(string targetDir, bool includeMedia = true)
		{
			var w = XmlWriter.Create(Path.Combine(targetDir, Title + ".xml"));

			w.WriteStartDocument();
			w.WriteStartElement("channel");

			w.WriteStartElement("title");
			w.WriteCData(Title);
			w.WriteEndElement();

			w.WriteElementString("link", Link);
			w.WriteElementString("pubDate", PubDate.ToString());
			w.WriteElementString("dc:creator", "hughesoft.com");
			w.WriteElementString("description", Description);

			w.WriteStartElement("content:encoded");
			w.WriteCData(Content);
			w.WriteEndElement();

			w.WriteEndElement();
			w.WriteEndDocument();
			w.Flush();
		}
	}
}
