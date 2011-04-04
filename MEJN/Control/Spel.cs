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
			wieIsErAanDeBeurt = 1;
			spelers = new List<Speler>();
		}

		internal void doFirstMove()
		{
			if (spelers[0].GetType() == typeof(Bot))
			{
				//Eerste speler is bot, doe eerste zet
			}

			//Wacht op speler input
		}

		internal void spelOpslaan(string fileName)
		{
			//Savefile start
			string saveFile = "MEJN;";

			//Add players
			saveFile += Spelers[0].Naam;
			saveFile += ",";
			saveFile += Spelers[1].Naam;
			saveFile += ",";
			saveFile += Spelers[2].Naam;
			saveFile += ",";
			saveFile += Spelers[3].Naam;
			saveFile += ";";

			//Turn
			saveFile += WieIsErAanDeBeurt;
			saveFile += ";";

			//Board
			saveFile += Bord.VakjesLijst.formatForSave();

			//Groen finish
			saveFile += Bord.GroenFinishvakjes.formatForSave();
			//Rood finish
			saveFile += Bord.RoodFinishvakjes.formatForSave();
			//Blauw finish
			saveFile += Bord.BlauwFinishvakjes.formatForSave();
			//Geel finish
			saveFile += Bord.GeelFinishvakjes.formatForSave();

			Console.Write(saveFile);
		}

		internal void spelOpenen(string p)
		{
			//Doe eens laden hier
		}
	}
}
