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
			bord.vulLijsten();
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

			Bord.GroenThuisbasis.zetPion(spelers[0].Pionnen[1], 2);
			Bord.GroenThuisbasis.zetPion(spelers[0].Pionnen[2], 3);
			Bord.GroenThuisbasis.zetPion(spelers[0].Pionnen[3], 4);

			Bord.RoodThuisbasis.zetPion(spelers[1].Pionnen[1], 2);
			Bord.RoodThuisbasis.zetPion(spelers[1].Pionnen[2], 3);
			Bord.RoodThuisbasis.zetPion(spelers[1].Pionnen[3], 4);

			Bord.BlauwThuisbasis.zetPion(spelers[2].Pionnen[1], 2);
			Bord.BlauwThuisbasis.zetPion(spelers[2].Pionnen[2], 3);
			Bord.BlauwThuisbasis.zetPion(spelers[2].Pionnen[3], 4);

			Bord.GeelThuisbasis.zetPion(spelers[3].Pionnen[1], 2);
			Bord.GeelThuisbasis.zetPion(spelers[3].Pionnen[2], 3);
			Bord.GeelThuisbasis.zetPion(spelers[3].Pionnen[3], 4);

			consolePrint();
		}

		public void consolePrint()
		{
			Console.WriteLine(Bord.VakjesLijst.formatForSave());
			Console.WriteLine(Bord.GroenThuisbasis.formatForSave());
			Console.WriteLine(Bord.RoodThuisbasis.formatForSave());
			Console.WriteLine(Bord.BlauwThuisbasis.formatForSave());
			Console.WriteLine(Bord.GeelThuisbasis.formatForSave());
		}

		private int zoekLeegThuisVak(LinkedList thuisbasis)
		{
			int ret = 0;
			if (thuisbasis.zoekOpVakGetal(4).isBezet() == false)
			{
				ret = 4;
			}
			else if (thuisbasis.zoekOpVakGetal(3).isBezet() == false)
			{
				ret = 3;
			}
			else if (thuisbasis.zoekOpVakGetal(2).isBezet() == false)
			{
				ret = 2;
			}
			else if (thuisbasis.zoekOpVakGetal(1).isBezet() == false)
			{
				ret = 1;
			}
			return ret;
		}

		private void TerugNaarThuisbasis(Pion pion)
		{
			if (pion.Kleur == Kleur.Groen)
			{
				int leegThuisVak = zoekLeegThuisVak(Bord.GroenThuisbasis);
				Bord.GroenThuisbasis.zetPion(pion, zoekLeegThuisVak(Bord.GroenThuisbasis));
			}
			else if (pion.Kleur == Kleur.Rood)
			{
				int leegThuisVak = zoekLeegThuisVak(Bord.RoodThuisbasis);
				Bord.RoodThuisbasis.zetPion(pion, zoekLeegThuisVak(Bord.RoodThuisbasis));
			}
			else if (pion.Kleur == Kleur.Groen)
			{
				int leegThuisVak = zoekLeegThuisVak(Bord.BlauwThuisbasis);
				Bord.BlauwThuisbasis.zetPion(pion, zoekLeegThuisVak(Bord.BlauwThuisbasis));
			}
			else if (pion.Kleur == Kleur.Geel)
			{
				int leegThuisVak = zoekLeegThuisVak(Bord.GeelThuisbasis);
				Bord.GeelThuisbasis.zetPion(pion, zoekLeegThuisVak(Bord.GeelThuisbasis));
			}
		}

		internal int pionVerzetten(int vakGetal, String soort)
		{
			int ret = 0;
			int worp = Dobbelsteen.Worp;
			Speler aanZet = spelers[WieIsErAanDeBeurt-1];
			if (Dobbelsteen.Gegooid == true)
			{
				if (aanZet.GetType() == typeof(Bot))
				{
					//Bot is aan zet
					ret = worp;
				}
				else
				{
					//Speler is aan zet
					if (soort == "vakje")
					{
						//vakjeslijst
						Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(vakGetal + worp);
						if (vakje.isBezet())
						{
							TerugNaarThuisbasis(vakje.Pion);
						}

						if (Bord.VakjesLijst.pionVerzetten(vakGetal, Dobbelsteen.Worp, aanZet.Kleur))
						{
							ret = worp;
							consolePrint();
						}
					}
					else if (soort == "grThu")
					{
						//groen thuisbasis
						if (aanZet.Kleur == Kleur.Groen && Dobbelsteen.Worp == 6)
						{
							Vakje thuisbasisVakje = Bord.GroenThuisbasis.zoekOpVakGetal(vakGetal);
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(1);
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								Bord.GroenThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									TerugNaarThuisbasis(vakje.Pion);
								}
								Bord.VakjesLijst.zetPion(tempPion, 1);
								consolePrint();
							}
							ret = worp;
						}
					}
					else if (soort == "roThu")
					{
						//rood thuisbasis
						if (aanZet.Kleur == Kleur.Rood && Dobbelsteen.Worp == 6)
						{
							Vakje thuisbasisVakje = Bord.RoodThuisbasis.zoekOpVakGetal(vakGetal);
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(11);
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								Bord.RoodThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									TerugNaarThuisbasis(vakje.Pion);
								}
								Bord.VakjesLijst.zetPion(tempPion, 11);
								consolePrint();
							}
							ret = worp;
						}
					}
					else if (soort == "blThu")
					{
						//blauw thuisbasis
						if (aanZet.Kleur == Kleur.Blauw && Dobbelsteen.Worp == 6)
						{
							Vakje thuisbasisVakje = Bord.BlauwThuisbasis.zoekOpVakGetal(vakGetal);
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(21);
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								Bord.BlauwThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									TerugNaarThuisbasis(vakje.Pion);
								}
								Bord.VakjesLijst.zetPion(tempPion, 21);
								consolePrint();
							}
							ret = worp;
						}
					}
					else if (soort == "geThu")
					{
						//geel thuisbasis
						if (aanZet.Kleur == Kleur.Geel && Dobbelsteen.Worp == 6)
						{
							Vakje thuisbasisVakje = Bord.GeelThuisbasis.zoekOpVakGetal(vakGetal);
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(31);
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								Bord.GeelThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									TerugNaarThuisbasis(vakje.Pion);
								}
								Bord.VakjesLijst.zetPion(tempPion, 31);
								consolePrint();
							}
							ret = worp;
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
			//Open file
			TextReader tr = new StreamReader(p);
			string savefile = tr.ReadToEnd();
			tr.Close();

			//Split the save file into chunks
			string[] fileChunks = savefile.Split(';');
			
			//We need at least 12 parts
			if (fileChunks.Length < 12)
			{
				Console.WriteLine(fileChunks.Length);
				return;
			}

			int beurt = 0;
			List<Speler> spelertemp = new List<Speler>();
			Bord bordtemp = new Bord();

			//Let's roll through the parts
			for (int i=0; i < fileChunks.Length; i++)
			{
				//Check for MEJN prefix
				if (i == 0)
				{
					if (!fileChunks[i].Equals("MEJN"))
					{
						return;
					}
				}

				//Check for players
				if (i == 1)
				{
					//Split the save file into chunks
					string[] players = fileChunks[i].Split(',');
					Console.WriteLine(players);
					if (players.Length != 4)
					{
						return;
					}
					for (int j = 0; j < players.Length; j++ )
					{
						Kleur kleurtje = Kleur.Groen;
						switch(j)
						{
							case 0:
								kleurtje = Kleur.Groen;
							break;
							case 1:
								kleurtje = Kleur.Rood;
							break;
							case 2:
								kleurtje = Kleur.Geel;
							break;
							case 3:
								kleurtje = Kleur.Blauw;
							break;
						}
						Speler eenSpeler = new Speler(players[j], kleurtje);
						spelertemp.Add(eenSpeler);
					}
				}
				
				//Check beurt
				if (i == 2)
				{
					beurt = Convert.ToInt32(fileChunks[i]);
					if (beurt < 1 || beurt > 4)
					{
						return;
					}
				}

				//Check bord
				if (i == 3)
				{
					beurt = Convert.ToInt32(fileChunks[i]);
					if (beurt < 1 || beurt > 4)
					{
						return;
					}
				}

				Console.WriteLine(i);
				Console.WriteLine(fileChunks[i]);

				Spelers.Clear();
				Spelers = spelertemp;
				wieIsErAanDeBeurt = beurt;
			}
		}
	}
}
