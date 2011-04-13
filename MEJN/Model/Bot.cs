using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Control;

namespace MEJN.Model
{
	class Bot : Speler
	{
		public Bot(String naam, Kleur kleur)
			: base(naam, kleur)
		{

		}

		internal override void doTurn(MEJN.Control.Spel sender)
		{
			//Roll the dice
			sender.Dobbelsteen.gooiDobbelsteen();
			sender.Dobbelsteen.switchGegooid();
			sender.Bordgui.dobbelsteen_changeimage(sender.Dobbelsteen.Worp);
			Console.WriteLine(sender.Spelers[sender.WieIsErAanDeBeurt-1].Kleur + " Bot gooit " + sender.Dobbelsteen.Worp);

			//Search pions on board
			int ret = 0;
			Speler aanZet = sender.Spelers[sender.WieIsErAanDeBeurt - 1];
			int vakgetal = sender.Bord.VakjesLijst.zoekOpVakPion(sender.Spelers[sender.WieIsErAanDeBeurt-1].Kleur);
			if (vakgetal != 0)
			{
				Link vakje = sender.Bord.VakjesLijst.zoekOpVakGetalMetControle(vakgetal, sender.Dobbelsteen.Worp, aanZet.Kleur);
				if (vakje != null)
				{
					if (vakje.IData.isBezet() && vakje.IData.GetType() != typeof(Finishvakje))
					{
						sender.TerugNaarThuisbasis(vakje.IData.Pion);
						Console.WriteLine("Pion van " + vakje.IData.Pion.Kleur + "Eraf");
					}
				}

				Link link = sender.Bord.VakjesLijst.pionVerzetten(vakgetal, sender.Dobbelsteen.Worp, aanZet.Kleur);
				if (link != null)
				{
					Vakje tempVakje = sender.Bord.VakjesLijst.zoekOpVakGetal(vakgetal).IData;
					Boolean gelukt = false;

					if (link == sender.Bord.GroenFinishvakjes.First)
					{
						gelukt = sender.Bord.GroenFinishvakjes.pionVerzettenFinish(tempVakje.Pion);
					}
					else if (link == sender.Bord.RoodFinishvakjes.First)
					{
						gelukt = sender.Bord.RoodFinishvakjes.pionVerzettenFinish(tempVakje.Pion);
					}
					else if (link == sender.Bord.BlauwFinishvakjes.First)
					{
						gelukt = sender.Bord.BlauwFinishvakjes.pionVerzettenFinish(tempVakje.Pion);
					}
					else if (link == sender.Bord.GeelFinishvakjes.First)
					{
						gelukt = sender.Bord.GeelFinishvakjes.pionVerzettenFinish(tempVakje.Pion);
					}
					if (gelukt)
					{
						tempVakje.Pion = null;
						Kleur winnaarkleur = sender.Bord.isEenFinishLijstVol();
						string spelernaam = "";
						if (winnaarkleur != Kleur.Neutral)
						{
							switch (winnaarkleur)
							{
								case Kleur.Groen:
									spelernaam = sender.Spelers[0].Naam;
									break;
								case Kleur.Rood:
									spelernaam = sender.Spelers[1].Naam;
									break;
								case Kleur.Blauw:
									spelernaam = sender.Spelers[2].Naam;
									break;
								case Kleur.Geel:
									spelernaam = sender.Spelers[3].Naam;
									break;
							}

							EndScreen screen = new EndScreen(spelernaam);
							screen.Visibility = System.Windows.Visibility.Visible;
							sender.Bordgui.Close();
						}
					}
					ret = sender.Dobbelsteen.Worp;
					sender.consolePrint();
					if (sender.Dobbelsteen.Worp == 6)
					{
						this.doTurn(sender);
					}
				}
			}
			else
			{
				if (sender.Dobbelsteen.Worp == 6)
				{
					if (aanZet.Kleur == Kleur.Groen)
					{
						//groen thuisbasis
						if (aanZet.Kleur == Kleur.Groen && sender.Dobbelsteen.Worp == 6)
						{
							int vakGetal = sender.Bord.GroenThuisbasis.zoekOpVakPion(Kleur.Groen);
							Vakje thuisbasisVakje = sender.Bord.GroenThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = sender.Bord.VakjesLijst.zoekOpVakGetal(1).IData;
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								sender.Bord.GroenThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									sender.TerugNaarThuisbasis(vakje.Pion);
								}
								sender.Bord.VakjesLijst.zetPion(tempPion, 1);
								sender.consolePrint();
							}
							Console.WriteLine("Nieuwe Pion erop");
							ret = sender.Dobbelsteen.Worp;
						}
					}
					else if (aanZet.Kleur == Kleur.Rood)
					{
						//rood thuisbasis
						if (aanZet.Kleur == Kleur.Rood && sender.Dobbelsteen.Worp == 6)
						{
							int vakGetal = sender.Bord.GroenThuisbasis.zoekOpVakPion(Kleur.Groen);
							Vakje thuisbasisVakje = sender.Bord.RoodThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = sender.Bord.VakjesLijst.zoekOpVakGetal(11).IData;
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								sender.Bord.RoodThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									sender.TerugNaarThuisbasis(vakje.Pion);
								}
								sender.Bord.VakjesLijst.zetPion(tempPion, 11);
								sender.consolePrint();
							}
							Console.WriteLine("Nieuwe Pion erop");
							ret = sender.Dobbelsteen.Worp;
						}
					}
					else if (aanZet.Kleur == Kleur.Blauw)
					{
						//blauw thuisbasis
						if (aanZet.Kleur == Kleur.Blauw && sender.Dobbelsteen.Worp == 6)
						{
							int vakGetal = sender.Bord.GroenThuisbasis.zoekOpVakPion(Kleur.Groen);
							Vakje thuisbasisVakje = sender.Bord.BlauwThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = sender.Bord.VakjesLijst.zoekOpVakGetal(21).IData;
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								sender.Bord.BlauwThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									sender.TerugNaarThuisbasis(vakje.Pion);
								}
								sender.Bord.VakjesLijst.zetPion(tempPion, 21);
								sender.consolePrint();
							}
							Console.WriteLine("Nieuwe Pion erop");
							ret = sender.Dobbelsteen.Worp;
						}
					}
					else if (aanZet.Kleur == Kleur.Geel)
					{
						//geel thuisbasis
						if (aanZet.Kleur == Kleur.Geel && sender.Dobbelsteen.Worp == 6)
						{
							int vakGetal = sender.Bord.GroenThuisbasis.zoekOpVakPion(Kleur.Groen);
							Vakje thuisbasisVakje = sender.Bord.GeelThuisbasis.zoekOpVakGetal(vakGetal).IData;
							Vakje vakje = sender.Bord.VakjesLijst.zoekOpVakGetal(31).IData;
							if (thuisbasisVakje.isBezet())
							{
								Pion tempPion = thuisbasisVakje.Pion;
								sender.Bord.GeelThuisbasis.zetPion(null, vakGetal);
								if (vakje.isBezet())
								{
									sender.TerugNaarThuisbasis(vakje.Pion);
								}
								sender.Bord.VakjesLijst.zetPion(tempPion, 31);
								sender.consolePrint();
							}
							Console.WriteLine("Nieuwe Pion erop");
							ret = sender.Dobbelsteen.Worp;
						}
					}
					Console.WriteLine("Nog een Keer");
					this.doTurn(sender);
				}
			}
			sender.beurtDoorgeven();
			sender.Bordgui.updateGameBoard();
		}
	}
}
