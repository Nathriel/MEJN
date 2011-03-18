using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Vakje
	{
		protected String soort;

		public String Soort
		{
			get { return soort; }
			set { soort = value; }
		}

		public Vakje(String soort)
		{
			this.soort = soort;
		}
	}
}
