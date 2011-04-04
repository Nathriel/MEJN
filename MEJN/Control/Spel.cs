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

		public void beurtDoorgeven()
		{
			if (WieIsErAanDeBeurt == 4)
			{
				WieIsErAanDeBeurt = 1;
			}
			else
			{
				WieIsErAanDeBeurt++;
			}
		}

		internal void spelOpslaan(string fileName)
		{
			StringBuilder saveStringBuilder = new StringBuilder("MEJN;");

			//Add players
			saveStringBuilder.Append(Spelers[0].Naam);
			saveStringBuilder.Append(",");
			saveStringBuilder.Append(Spelers[1].Naam);
			saveStringBuilder.Append(",");
			saveStringBuilder.Append(Spelers[2].Naam);
			saveStringBuilder.Append(",");
			saveStringBuilder.Append(Spelers[3].Naam);
			saveStringBuilder.Append(";");

			//Turn
			saveStringBuilder.Append(WieIsErAanDeBeurt);
			saveStringBuilder.Append(";");

			//Board
			saveStringBuilder.Append(Bord.VakjesLijst.formatForSave());

			//Groen begin
			saveStringBuilder.Append(Bord.GroenThuisbasis.formatForSave());
			//Rood begin
			saveStringBuilder.Append(Bord.RoodThuisbasis.formatForSave());
			//Blauw begin
			saveStringBuilder.Append(Bord.GeelThuisbasis.formatForSave());
			//Geel begin
			saveStringBuilder.Append(Bord.GroenThuisbasis.formatForSave());
			 
			//Groen finish
			saveStringBuilder.Append(Bord.GroenFinishvakjes.formatForSave());
			//Rood finish
			saveStringBuilder.Append(Bord.RoodFinishvakjes.formatForSave());
			//Blauw finish
			saveStringBuilder.Append(Bord.BlauwFinishvakjes.formatForSave());
			//Geel finish
			saveStringBuilder.Append(Bord.GeelFinishvakjes.formatForSave());

			Console.WriteLine(saveStringBuilder);
		}

		internal void spelOpenen(string p)
		{
			//Doe eens laden hier
		}
	}
}
