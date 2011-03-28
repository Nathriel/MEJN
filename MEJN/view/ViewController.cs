using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Control;
using MEJN.Model;

namespace MEJN.View
{
	class ViewController
	{
		private Spel spel;

		internal Spel Spel
		{
			get { return spel; }
			set { spel = value; }
		}

		public ViewController()
		{
			spel = new Spel();
		}
	}
}
