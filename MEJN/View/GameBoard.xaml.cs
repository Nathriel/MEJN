using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MEJN.View;
using MEJN.Model;

namespace MEJN
{
	public partial class GameBoard : Window
	{
		private ViewController viewcontrol;
		private List<Image> vakImageLijst;
		private List<ImageSource> dobbelsteenImages;

		private List<Image> groenFinishImages;
		private List<Image> roodFinishImages;
		private List<Image> blauwFinishImages;
		private List<Image> geelFinishImages;

		private List<Image> groenThuisImages;
		private List<Image> roodThuisImages;
		private List<Image> blauwThuisImages;
		private List<Image> geelThuisImages;

		internal ViewController Viewcontrol
		{	get { return viewcontrol; }
			set { viewcontrol = value; }
		}
		public List<Image> VakImageLijst
		{
		get { return vakImageLijst; }
		set { vakImageLijst = value; }
		}

		internal GameBoard(ViewController viewcontrol)
		{
			this.InitializeComponent();
			this.viewcontrol = viewcontrol;
			vakImageLijst = new List<Image>();
			dobbelsteenImages = new List<ImageSource>();

			groenFinishImages = new List<Image>();
			roodFinishImages = new List<Image>();
			blauwFinishImages = new List<Image>();
			geelFinishImages = new List<Image>();

			groenThuisImages = new List<Image>();
			roodThuisImages = new List<Image>();
			blauwThuisImages = new List<Image>();
			geelThuisImages = new List<Image>();

			List<Speler> spelers = viewcontrol.Spel.Spelers;

			GroenLabel.Content = spelers[0].Naam;
			RoodLabel.Content = spelers[1].Naam;
			BlauwLabel.Content = spelers[2].Naam;
			GeelLabel.Content = spelers[3].Naam;

			Viewcontrol.Spel.startPositie();

			vulImageLijst();
		}

		private void vulImageLijst()
		{
			// Dobbelsteen imagecollectie vullen
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbeleen.png", UriKind.Relative)));
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbeltwee.png", UriKind.Relative)));
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbeldrie.png", UriKind.Relative)));
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbelvier.png", UriKind.Relative)));
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbelvijf.png", UriKind.Relative)));
			dobbelsteenImages.Add(new BitmapImage(new Uri("/MEJN;component/Resources/dobbelzes.png", UriKind.Relative)));

			// Finish imagecollectie vullen
			groenFinishImages.Add(grFin1);
			groenFinishImages.Add(grFin2);
			groenFinishImages.Add(grFin3);
			groenFinishImages.Add(grFin4);

			roodFinishImages.Add(roFin1);
			roodFinishImages.Add(roFin2);
			roodFinishImages.Add(roFin3);
			roodFinishImages.Add(roFin4);

			blauwFinishImages.Add(blFin1);
			blauwFinishImages.Add(blFin2);
			blauwFinishImages.Add(blFin3);
			blauwFinishImages.Add(blFin4);

			geelFinishImages.Add(geFin1);
			geelFinishImages.Add(geFin2);
			geelFinishImages.Add(geFin3);
			geelFinishImages.Add(geFin4);

			// Thuisbasis imagecollectie vullen
			groenThuisImages.Add(grThu1);
			groenThuisImages.Add(grThu2);
			groenThuisImages.Add(grThu3);
			groenThuisImages.Add(grThu4);

			roodThuisImages.Add(roThu1);
			roodThuisImages.Add(roThu2);
			roodThuisImages.Add(roThu3);
			roodThuisImages.Add(roThu4);

			blauwThuisImages.Add(blThu1);
			blauwThuisImages.Add(blThu2);
			blauwThuisImages.Add(blThu3);
			blauwThuisImages.Add(blThu4);

			geelThuisImages.Add(geThu1);
			geelThuisImages.Add(geThu2);
			geelThuisImages.Add(geThu3);
			geelThuisImages.Add(geThu4);

			// normale image lijst vullen
			vakImageLijst.Add(vakje1);
			vakImageLijst.Add(vakje2);
			vakImageLijst.Add(vakje3);
			vakImageLijst.Add(vakje4);
			vakImageLijst.Add(vakje5);
			vakImageLijst.Add(vakje6);
			vakImageLijst.Add(vakje7);
			vakImageLijst.Add(vakje8);
			vakImageLijst.Add(vakje9);
			vakImageLijst.Add(vakje10);

			vakImageLijst.Add(vakje11);
			vakImageLijst.Add(vakje12);
			vakImageLijst.Add(vakje13);
			vakImageLijst.Add(vakje14);
			vakImageLijst.Add(vakje15);
			vakImageLijst.Add(vakje16);
			vakImageLijst.Add(vakje17);
			vakImageLijst.Add(vakje18);
			vakImageLijst.Add(vakje19);
			vakImageLijst.Add(vakje20);

			vakImageLijst.Add(vakje21);
			vakImageLijst.Add(vakje22);
			vakImageLijst.Add(vakje23);
			vakImageLijst.Add(vakje24);
			vakImageLijst.Add(vakje25);
			vakImageLijst.Add(vakje26);
			vakImageLijst.Add(vakje27);
			vakImageLijst.Add(vakje28);
			vakImageLijst.Add(vakje29);
			vakImageLijst.Add(vakje30);

			vakImageLijst.Add(vakje31);
			vakImageLijst.Add(vakje32);
			vakImageLijst.Add(vakje33);
			vakImageLijst.Add(vakje34);
			vakImageLijst.Add(vakje35);
			vakImageLijst.Add(vakje36);
			vakImageLijst.Add(vakje37);
			vakImageLijst.Add(vakje38);
			vakImageLijst.Add(vakje39);
			vakImageLijst.Add(vakje40);
		}

		internal void updateGameBoard()
		{
			LinkedList vakjesLijst = viewcontrol.Spel.Bord.VakjesLijst;

			LinkedList groenFinishvakjes = viewcontrol.Spel.Bord.GroenFinishvakjes;
			LinkedList roodFinishvakjes = viewcontrol.Spel.Bord.RoodFinishvakjes;
			LinkedList blauwFinishvakjes = viewcontrol.Spel.Bord.BlauwFinishvakjes;
			LinkedList geelFinishvakjes = viewcontrol.Spel.Bord.GeelFinishvakjes;

			LinkedList groenThuisbasis = viewcontrol.Spel.Bord.GroenThuisbasis;
			LinkedList roodThuisbasis = viewcontrol.Spel.Bord.RoodThuisbasis;
			LinkedList blauwThuisbasis = viewcontrol.Spel.Bord.BlauwThuisbasis;
			LinkedList geelThuisbasis = viewcontrol.Spel.Bord.GeelThuisbasis;

			doorloopLijst(vakjesLijst, VakImageLijst);

			doorloopLijst(groenFinishvakjes, groenFinishImages);
			doorloopLijst(roodFinishvakjes, roodFinishImages);
			doorloopLijst(blauwFinishvakjes, blauwFinishImages);
			doorloopLijst(geelFinishvakjes, geelFinishImages);

			doorloopLijst(groenThuisbasis, groenThuisImages);
			doorloopLijst(roodThuisbasis, roodThuisImages);
			doorloopLijst(blauwThuisbasis, blauwThuisImages);
			doorloopLijst(geelThuisbasis, geelThuisImages);
		}

		private void doorloopLijst(LinkedList lijst, List<Image> imageLijst)
		{
			for (int i = 0; i < imageLijst.Count; i++)
			{
				Vakje vakje = lijst.zoekOpVakGetal(i+1).IData;
				if (vakje.Pion != null)
				{
					vakImageChange(imageLijst[i], vakje.Pion.Kleur);
				}
				else
				{
					vakImageChange(imageLijst[i], Kleur.Neutral);
				}
			}
		}

		private void vakImageChange(Image vakImage, Kleur kleur)
		{
			if (kleur == Kleur.Groen)
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/piongroen.png", UriKind.Relative));
			}
			else if (kleur == Kleur.Rood)
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/pionrood.png", UriKind.Relative));
			}
			else if (kleur == Kleur.Blauw)
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/pionblauw.png", UriKind.Relative));
			}
			else if (kleur == Kleur.Geel)
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/piongeel.png", UriKind.Relative));
			}
			else
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/noimage.png", UriKind.Relative));
			}
		}

		private void makeCursorHand()
		{
			Mouse.OverrideCursor = Cursors.Hand;
		}

		private void makeCursorArrow()
		{
			Mouse.OverrideCursor = Cursors.Arrow;
		}

		// eventhandlers
		private void spelOpslaanClicked(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
			dlg.FileName = "spel";
			dlg.DefaultExt = ".mejns";
			dlg.Filter = "Mens Erger Je Niet Spel Document (.mejns)|*.mejns";

			Nullable<bool> result = dlg.ShowDialog();

			if (result == true)
			{
				Viewcontrol.Spel.spelOpslaan(dlg.FileName);
			}
		}

		private void spelLadenClicked(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.FileName = "spel";
			dlg.DefaultExt = ".mejns";
			dlg.Filter = "Mens Erger Je Niet Spel Document (.mejns)|*.mejns";

			Nullable<bool> result = dlg.ShowDialog();

			if (result == true)
			{
				if (Viewcontrol.Spel.spelOpenen(dlg.FileName))
				{
					this.updateGameBoard();
				}
			}

		}

		internal void dobbelsteen_changeimage(int worp)
		{
			dobbelsteenImage.Source = dobbelsteenImages[worp - 1];
		}

		private void dobbelsteen_MouseUp(object sender, MouseEventArgs e)
		{
			if (viewcontrol.Spel.Dobbelsteen.Gegooid == false)
			{
				int worp = viewcontrol.Spel.Dobbelsteen.gooiDobbelsteen();

				dobbelsteenImage.Source = dobbelsteenImages[worp - 1];

				Viewcontrol.Spel.Dobbelsteen.switchGegooid();
				Mouse.OverrideCursor = Cursors.Arrow;
			}
		}

		private void dobbelsteen_MouseEnter(object sender, MouseEventArgs e)
		{
			if (viewcontrol.Spel.Dobbelsteen.Gegooid == false)
			{
				makeCursorHand();
			}
		}

		private void dobbelsteen_MouseLeave(object sender, MouseEventArgs e)
		{
			makeCursorArrow();
		}

		private void vak_MouseUp(object sender, MouseEventArgs e)
		{
			Image clickedObject = sender as Image;
			String soort = clickedObject.Name.Substring(0, 5);
			int vakGetal = Int32.Parse(clickedObject.Name.Substring(5));

			int worp = viewcontrol.Spel.pionVerzetten(vakGetal, soort);
			if (worp != 0)
			{
				updateGameBoard();
				if (worp != 6)
				{
					BeurtDoorgeven();
				}
				else
				{
					viewcontrol.Spel.Dobbelsteen.switchGegooid();
				}
			}
		}

		private void vak_MouseEnter(object sender, MouseEventArgs e)
		{
			makeCursorHand();
		}

		private void vak_MouseLeave(object sender, MouseEventArgs e)
		{
			makeCursorArrow();
		}

		private void turnindicatorSwitch(Image img)
		{
			String tempSource = img.Source.ToString().Substring(48);

			if (tempSource == "turnindicator.png")
			{
				img.Source = new BitmapImage(new Uri("/MEJN;component/Resources/turnindicatornotactive.png", UriKind.Relative));
			}
			else
			{
				img.Source = new BitmapImage(new Uri("/MEJN;component/Resources/turnindicator.png", UriKind.Relative));
			}
		}

		private void BeurtDoorgeven()
		{
			viewcontrol.Spel.beurtDoorgeven();

			int WieIsErAanDeBeurt = viewcontrol.Spel.WieIsErAanDeBeurt;

			if (WieIsErAanDeBeurt == 1)
			{
				turnindicatorSwitch(Speler1Turnindicator);
				turnindicatorSwitch(Speler4Turnindicator);
			}
			else if (WieIsErAanDeBeurt == 2)
			{
				turnindicatorSwitch(Speler2Turnindicator);
				turnindicatorSwitch(Speler1Turnindicator);
			}
			else if (WieIsErAanDeBeurt == 3)
			{
				turnindicatorSwitch(Speler3Turnindicator);
				turnindicatorSwitch(Speler2Turnindicator);
			}
			else if (WieIsErAanDeBeurt == 4)
			{
				turnindicatorSwitch(Speler4Turnindicator);
				turnindicatorSwitch(Speler3Turnindicator);
			}
		}

		private void spelVerlatenClicked(object sender, RoutedEventArgs e)
		{
			Viewcontrol = null;
			MainWindow mainscreen = new MainWindow();
			mainscreen.Visibility = System.Windows.Visibility.Visible;
			this.Close();
		}
	}
}