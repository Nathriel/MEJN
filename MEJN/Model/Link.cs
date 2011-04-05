using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Link
	{
		private Vakje iData;
		private Link next;
		private Link previous;
		private Link finish;

		public Vakje IData
		{
			get { return iData; }
			set { iData = value; }
		}
		public Link Next
		{
			get { return next; }
			set { next = value; }
		}
		public Link Previous
		{
			get { return previous; }
			set { previous = value; }
		}
		public Link Finish
		{
			get { return finish; }
			set { finish = value; }
		}

		public Link(Vakje vakje)
		{
			iData = vakje;
		}

		public void displayLink()
		{
			Console.Write("{" + iData);
		}

		public Boolean heeftFinishLink()
		{
			Boolean ret = false;

			if(Finish != null)
			{
				ret = true;
			}

			return ret;
		}
	}
}
