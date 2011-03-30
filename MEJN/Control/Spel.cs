using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Model;

namespace MEJN.Control
{
	class Spel
	{
		private Bord bord;
		private Dobbelsteen dobbelsteen;
		private int wieIsErAanDeBeurt;
		private List<Speler> spelers;

		internal Bord Bord
		{
			get { return bord; }
			set { bord = value; }
		}
		internal Dobbelsteen Dobbelsteen
		{
			get { return dobbelsteen; }
			set { dobbelsteen = value; }
		}
		public int WieIsErAanDeBeurt
		{
			get { return wieIsErAanDeBeurt; }
			set { wieIsErAanDeBeurt = value; }
		}
		internal List<Speler> Spelers
		{
			get { return spelers; }
			set { spelers = value; }
		}

		public Spel()
		{
			bord = new Bord();
			dobbelsteen = new Dobbelsteen();
			spelers = new List<Speler>();
		}

		internal void spelOpslaan(string fileName)
		{
			//Doe eens opslaan hier
		}

		internal void spelOpenen(string p)
		{
			//Doe eens laden hier
		}
	}
}
