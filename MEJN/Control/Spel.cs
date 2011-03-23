using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Model;

namespace MEJN.Control
{
	class Spel
	{
		private Bord bord { set; get; }
		private Dobbelsteen dobbelsteen { set; get; }
		private int wieIsErAanDeBeurt { set; get; }
		private List<Speler> spelers { set; get; }

		public Spel()
		{
			bord = new Bord();
			dobbelsteen = new Dobbelsteen();
		}
	}
}
