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
		private GameBoard bordgui;

		public GameBoard Bordgui
		{
			get { return bordgui; }
			set { bordgui = value; }
		}

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

		public int rollBotDice()
		{
			int worp = Dobbelsteen.gooiDobbelsteen();
			
			return worp;
		}

		public void consolePrint()
		{
			Console.WriteLine(Bord.VakjesLijst.formatForSave());
			Console.WriteLine(Bord.GroenThuisbasis.formatForSave());
			Console.WriteLine(Bord.RoodThuisbasis.formatForSave());
			Console.WriteLine(Bord.BlauwThuisbasis.formatForSave());
			Console.WriteLine(Bord.GeelThuisbasis.formatForSave());
			Console.WriteLine(Bord.GroenFinishvakjes.formatForSave());
			Console.WriteLine(Bord.RoodFinishvakjes.formatForSave());
			Console.WriteLine(Bord.BlauwFinishvakjes.formatForSave());
			Console.WriteLine(Bord.GeelFinishvakjes.formatForSave());
		}

		private int zoekLeegThuisVak(LinkedList thuisbasis)
		{
			int ret = 0;
			if (thuisbasis.zoekOpVakGetal(4).IData.isBezet() == false)
			{
				ret = 4;
			}
			else if (thuisbasis.zoekOpVakGetal(3).IData.isBezet() == false)
			{
				ret = 3;
			}
			else if (thuisbasis.zoekOpVakGetal(2).IData.isBezet() == false)
			{
				ret = 2;
			}
			else if (thuisbasis.zoekOpVakGetal(1).IData.isBezet() == false)
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
						Link vakje = Bord.VakjesLijst.zoekOpVakGetalMetControle(vakGetal, worp, aanZet.Kleur);
						if (vakje != null)
						{
							if (vakje.IData.isBezet())
							{
								TerugNaarThuisbasis(vakje.IData.Pion);
							}
						}

						Link link = Bord.VakjesLijst.pionVerzetten(vakGetal, Dobbelsteen.Worp, aanZet.Kleur);
						if (link != null)
						{
							if (link.Previous != null)
							{
								Vakje tempVakje = Bord.VakjesLijst.zoekOpVakGetal(vakGetal).IData;
								int stepsLeft = Bord.VakjesLijst.StepsLeft;
								Boolean gelukt = false;

								if (link == Bord.GroenFinishvakjes.First)
								{
									gelukt = Bord.GroenFinishvakjes.pionVerzettenFinish(tempVakje.Pion, stepsLeft);
								}
								else if (link == Bord.RoodFinishvakjes.First)
								{
									gelukt = Bord.RoodFinishvakjes.pionVerzettenFinish(tempVakje.Pion, stepsLeft);
								}
								else if (link == Bord.BlauwFinishvakjes.First)
								{
									gelukt = Bord.BlauwFinishvakjes.pionVerzettenFinish(tempVakje.Pion, stepsLeft);
								}
								else if (link == Bord.GeelFinishvakjes.First)
								{
									gelukt = Bord.GeelFinishvakjes.pionVerzettenFinish(tempVakje.Pion, stepsLeft);
								}
								if (gelukt)
								{
									tempVakje.Pion = null;
								}
								ret = worp;
								consolePrint();
							}
						}
					}
					else if (soort == "grThu")
					{
						//groen thuisbasis
						if (aanZet.Kleur == Kleur.Groen && Dobbelsteen.Worp == 6)
						{
							Vakje thuisbasisVakje = Bord.GroenThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(1).IData;
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
							Vakje thuisbasisVakje = Bord.RoodThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(11).IData;
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
							Vakje thuisbasisVakje = Bord.BlauwThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(21).IData;
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
							Vakje thuisbasisVakje = Bord.GeelThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = Bord.VakjesLijst.zoekOpVakGetal(31).IData;
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
			saveStringBuilder.Append(Bord.BlauwThuisbasis.formatForSave());
			//Geel begin
			saveStringBuilder.Append(Bord.GeelThuisbasis.formatForSave());
			 
			//Groen finish
			saveStringBuilder.Append(Bord.GroenFinishvakjes.formatForSave());
			//Rood finish
			saveStringBuilder.Append(Bord.RoodFinishvakjes.formatForSave());
			//Blauw finish
			saveStringBuilder.Append(Bord.BlauwFinishvakjes.formatForSave());
			//Geel finish
			saveStringBuilder.Append(Bord.GeelFinishvakjes.formatForSave());

			if (Spelers[0].GetType() == typeof(Bot))
			{
				saveStringBuilder.Append("0,");
			}
			else
			{
				saveStringBuilder.Append("1,");
			}
			
			if (Spelers[1].GetType() == typeof(Bot))
			{
				saveStringBuilder.Append("0,");
			}
			else
			{
				saveStringBuilder.Append("1,");
			}
			
			if (Spelers[2].GetType() == typeof(Bot))
			{
				saveStringBuilder.Append("0,");
			}
			else
			{
				saveStringBuilder.Append("1,");
			}

			if (Spelers[3].GetType() == typeof(Bot))
			{
				saveStringBuilder.Append("0;");
			}
			else
			{
				saveStringBuilder.Append("1;");
			}

			Console.WriteLine(saveStringBuilder);

			//Save the file
			TextWriter tw = new StreamWriter(fileName);
			tw.WriteLine(saveStringBuilder);
			tw.Close();
		}

		internal bool spelOpenen(string p)
		{
			//Open file
			TextReader tr = new StreamReader(p);
			string savefile = tr.ReadToEnd();
			tr.Close();

			//Split the save file into chunks
			string[] fileChunks = savefile.Split(';');

			//We need at least 12 parts
			if (fileChunks.Length < 13)
			{
				Console.WriteLine(fileChunks.Length);
				return false;
			}

			int beurt = 0;
			List<Speler> spelertemp = new List<Speler>();
			Bord bordtemp = new Bord();

			//Let's roll through the parts
			for (int i = 0; i < fileChunks.Length; i++)
			{
				//Check for MEJN prefix
				if (i == 0)
				{
					if (!fileChunks[i].Equals("MEJN"))
					{
						Console.WriteLine(i); return false;
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
						Console.WriteLine(i); return false;
					}
					for (int j = 0; j < players.Length; j++)
					{
						Kleur kleurtje = Kleur.Groen;
						switch (j)
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
						spelertemp.Add(new Speler(players[j], kleurtje));
					}
					Console.WriteLine(spelertemp);
				}

				//Check beurt
				if (i == 2)
				{
					beurt = Convert.ToInt32(fileChunks[i]);
					if (beurt < 1 || beurt > 4)
					{
						Console.WriteLine(i); return false;
					}
				}

				//Check bord
				if (i == 3)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 40)
					{
						Console.WriteLine("Vak count doesn't match"); return false;
					}
					Console.WriteLine("Vak count DOES match");

					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine("Too many vakchuncks"); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine("Vakinfo has more chunks"); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						if (vakinfo.Length > 1)
						{
							switch (vakinfo[1])
							{
								case "gr":
									vakkleurtje = Kleur.Groen;
									break;
								case "ro":
									vakkleurtje = Kleur.Rood;
									break;
								case "ge":
									vakkleurtje = Kleur.Geel;
									break;
								case "bl":
									vakkleurtje = Kleur.Blauw;
									break;
							}
						}
						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.VakjesLijst.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check groen thuisbasis
				if (i == 4)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;
						if (vakinfo.Length > 1)
						{
							switch (vakinfo[1])
							{
								case "gr":
									vakkleurtje = Kleur.Groen;
									break;
								case "ro":
									vakkleurtje = Kleur.Rood;
									break;
								case "ge":
									vakkleurtje = Kleur.Geel;
									break;
								case "bl":
									vakkleurtje = Kleur.Blauw;
									break;
								default:
									vakkleurtje = Kleur.Neutral;
									break;
							}
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.GroenThuisbasis.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}
				//Check rood thuisbasis
				if (i == 5)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.RoodThuisbasis.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check Blauw thuisbasis
				if (i == 6)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.BlauwThuisbasis.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check Geel thuisbasis
				if (i == 7)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine("WHAT"); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.GeelThuisbasis.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check groen finishvakjes
				if (i == 8)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.GroenFinishvakjes.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}
				//Check rood finishvakjes
				if (i == 9)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.RoodFinishvakjes.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check Blauw finishvakjes
				if (i == 10)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}
						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.BlauwFinishvakjes.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}

				//Check Geel finishvakjes
				if (i == 11)
				{
					string[] bordchunks = fileChunks[i].Split(',');

					if (bordchunks.Length != 4)
					{
						Console.WriteLine(i); return false;
					}


					for (int j = 0; j < bordchunks.Length; j++)
					{
						string[] vakchunks = bordchunks[j].Split('-');
						int grpions = 0;
						int ropions = 0;
						int gepions = 0;
						int blpions = 0;


						if (vakchunks.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						//Do the actual tile first
						string[] vakinfo = vakchunks[0].Split('+');
						if (vakinfo.Length > 2)
						{
							Console.WriteLine(i); return false;
						}

						Vakje tempvakje;
						Kleur vakkleurtje = Kleur.Neutral;

						switch (vakinfo[1])
						{
							case "gr":
								vakkleurtje = Kleur.Groen;
								break;
							case "ro":
								vakkleurtje = Kleur.Rood;
								break;
							case "ge":
								vakkleurtje = Kleur.Geel;
								break;
							case "bl":
								vakkleurtje = Kleur.Blauw;
								break;
							default:
								vakkleurtje = Kleur.Neutral;
								break;
						}

						if (vakinfo[0] == "bv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}
							tempvakje = new Beginvakje(vakkleurtje);
						}
						else if (vakinfo[0] == "fv")
						{
							if (vakkleurtje == Kleur.Neutral)
							{
								Console.WriteLine(i); return false;
							}

							tempvakje = new Finishvakje(vakkleurtje);
						}
						else
						{
							tempvakje = new Normaalvakje();
						}

						bordtemp.GeelFinishvakjes.insertLast(tempvakje);

						//Now the Pion
						if (vakchunks.Length > 1)
						{
							switch (vakchunks[1])
							{
								case "gr":
									tempvakje.Pion = spelertemp[0].Pionnen[grpions];
									grpions++;
									break;
								case "ro":
									tempvakje.Pion = spelertemp[1].Pionnen[ropions];
									ropions++;
									break;
								case "ge":
									tempvakje.Pion = spelertemp[2].Pionnen[gepions];
									gepions++;
									break;
								case "bl":
									tempvakje.Pion = spelertemp[3].Pionnen[blpions];
									blpions++;
									break;
								default:
									Console.WriteLine(i); return false;
							}

						}
					}
				}
				//Check for players
				if (i == 12)
				{
					//Split the save file into chunks
					string[] playersbot = fileChunks[i].Split(',');
					Console.WriteLine(playersbot);
					if (playersbot.Length != 4)
					{
						Console.WriteLine(i); return false;
					}
					for (int j = 0; j < playersbot.Length; j++)
					{
						if (System.Convert.ToInt32(playersbot[j]) == 0)
						{
							spelertemp[j] = new Bot(spelertemp[j].Naam, spelertemp[j].Kleur);
						}
					}
				}

				Console.WriteLine(i);
				Console.WriteLine(fileChunks[i]);
			}

			//Set our save data to 
			this.Spelers.Clear();
			this.Spelers = spelertemp;
			this.wieIsErAanDeBeurt = beurt;
			this.Dobbelsteen.Gegooid = false;
			this.bord = bordtemp;
			Console.WriteLine("Game loaded");
			return true;
		}

		internal void checkBotTurn()
		{
			if (Spelers[WieIsErAanDeBeurt].GetType() == typeof(Bot))
			{
				Spelers[WieIsErAanDeBeurt].doTurn(this);
			}

			//Wacht op speler input
		}
	}
}

