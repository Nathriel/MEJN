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
		private Spel spel { set; get; }
		private Bord bord { set; get; }

		public ViewController()
		{
			bord = new Bord();
		}
	}
}
