using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Link
	{
		public Vakje iData { set; get; }
		public Link next { set; get; }
		public Link previous { set; get; }
		public Link finish { set; get; }
		public Link(Vakje vakje)
		{
			iData = vakje;
		}

		public void displayLink()
		{
			Console.Write("{" + iData.Soort);
		}
	}
}
