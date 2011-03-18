using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Link
	{
		public int iData { set; get; }
		public Link next { set; get; }
		public Link previous { set; get; }
		public Link(int number)
		{
			iData = number;
		}

		public void displayLink()
		{
			Console.WriteLine("{" + iData + "}");
		}
	}
}
