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

			s.SerializeToDisk(@"c:\users\ben\desktop");
		}
	}
}
