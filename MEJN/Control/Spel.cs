using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Model;
using System.IO;

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

		public void startPositie()
		{
			Bord.VakjesLijst.zetPion(spelers[0].Pionnen[0], 1);
			Bord.VakjesLijst.zetPion(spelers[1].Pionnen[0], 11);
			Bord.VakjesLijst.zetPion(spelers[2].Pionnen[0], 21);
			Bord.VakjesLijst.zetPion(spelers[3].Pionnen[0], 31);

			Console.WriteLine(Bord.VakjesLijst.formatForSave());
		}

		internal Boolean pionVerzetten(int vakGetal, String soort)
		{
			Boolean ret = false;
			Speler aanZet = spelers[WieIsErAanDeBeurt-1];
			if (Dobbelsteen.Gegooid == true)
			{
				if (aanZet.GetType() == typeof(Bot))
				{
					//Bot is aan zet
					ret = true;
				}
				else
				{
					//Speler is aan zet
					if (soort == "vakje")
					{
						//vakjeslijst
						Bord.pionVerzetten(Dobbelsteen.Worp, vakGetal);
						ret = true;
					}
					else if (soort == "grThu")
					{
						//groen thuisbasis
						if (aanZet.Kleur == Kleur.Groen && Dobbelsteen.Worp == 6)
						{
							ret = true;
						}
					}
					else if (soort == "roThu")
					{
						//rood thuisbasis
						if (aanZet.Kleur == Kleur.Rood && Dobbelsteen.Worp == 6)
						{
							ret = true;
						}
					}
					else if (soort == "blThu")
					{
						//blauw thuisbasis
						if (aanZet.Kleur == Kleur.Blauw && Dobbelsteen.Worp == 6)
						{
							ret = true;
						}
					}
					else if (soort == "geThu")
					{
						//geel thuisbasis
						if (aanZet.Kleur == Kleur.Geel && Dobbelsteen.Worp == 6)
						{
							ret = true;
						}
					}
					else if (soort == "grFin")
					{
						//groen Finish
					}
					else if (soort == "roFin")
					{
						//rood Finish
					}
					else if (soort == "blFin")
					{
						//blauw Finish
					}
					else if (soort == "geFin")
					{
						//geel Finish
					}
				}
			}
			return ret;
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
			Dobbelsteen.switchGegooid();
		}

		internal void spelOpslaan(string fileName)
		{
			//Start putting the save file together
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

			//Save the file
			TextWriter tw = new StreamWriter(fileName);
			tw.WriteLine(saveStringBuilder);
			tw.Close();
		}

		internal void spelOpenen(string p)
		{
			//Doe eens laden hier
		}
	}
}
