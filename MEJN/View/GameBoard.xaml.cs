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
		private LinkedList<Image> vakImageLijst;
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
		public LinkedList<Image> VakImageLijst
		{
			get { return vakImageLijst; }
			set { vakImageLijst = value; }
		}

		internal GameBoard(ViewController viewcontrol)
		{
			this.InitializeComponent();
			this.viewcontrol = viewcontrol;
			vakImageLijst = new LinkedList<Image>();
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
			groenFinishImages.Add(groenFinish1);
			groenFinishImages.Add(groenFinish2);
			groenFinishImages.Add(groenFinish3);
			groenFinishImages.Add(groenFinish4);

			roodFinishImages.Add(roodFinish1);
			roodFinishImages.Add(roodFinish2);
			roodFinishImages.Add(roodFinish3);
			roodFinishImages.Add(roodFinish4);

			blauwFinishImages.Add(blauwFinish1);
			blauwFinishImages.Add(blauwFinish2);
			blauwFinishImages.Add(blauwFinish3);
			blauwFinishImages.Add(blauwFinish4);

			geelFinishImages.Add(geelFinish1);
			geelFinishImages.Add(geelFinish2);
			geelFinishImages.Add(geelFinish3);
			geelFinishImages.Add(geelFinish4);

			// Thuisbasis imagecollectie vullen
			groenThuisImages.Add(groenThuis1);
			groenThuisImages.Add(groenThuis2);
			groenThuisImages.Add(groenThuis3);
			groenThuisImages.Add(groenThuis4);

			roodThuisImages.Add(roodThuis1);
			roodThuisImages.Add(roodThuis2);
			roodThuisImages.Add(roodThuis3);
			roodThuisImages.Add(roodThuis4);

			blauwThuisImages.Add(blauwThuis1);
			blauwThuisImages.Add(blauwThuis2);
			blauwThuisImages.Add(blauwThuis3);
			blauwThuisImages.Add(blauwThuis4);

			geelThuisImages.Add(geelThuis1);
			geelThuisImages.Add(geelThuis2);
			geelThuisImages.Add(geelThuis3);
			geelThuisImages.Add(geelThuis4);

			// normale image lijst vullen
			vakImageLijst.AddFirst(vak1);
			vakImageLijst.AddFirst(vak2);
			vakImageLijst.AddFirst(vak3);
			vakImageLijst.AddFirst(vak4);
			vakImageLijst.AddFirst(vak5);
			vakImageLijst.AddFirst(vak6);
			vakImageLijst.AddFirst(vak7);
			vakImageLijst.AddFirst(vak8);
			vakImageLijst.AddFirst(vak9);
			vakImageLijst.AddFirst(vak10);

			vakImageLijst.AddFirst(vak11);
			vakImageLijst.AddFirst(vak12);
			vakImageLijst.AddFirst(vak13);
			vakImageLijst.AddFirst(vak14);
			vakImageLijst.AddFirst(vak15);
			vakImageLijst.AddFirst(vak16);
			vakImageLijst.AddFirst(vak17);
			vakImageLijst.AddFirst(vak18);
			vakImageLijst.AddFirst(vak19);
			vakImageLijst.AddFirst(vak20);
			
			vakImageLijst.AddFirst(vak21);
			vakImageLijst.AddFirst(vak22);
			vakImageLijst.AddFirst(vak23);
			vakImageLijst.AddFirst(vak24);
			vakImageLijst.AddFirst(vak25);
			vakImageLijst.AddFirst(vak26);
			vakImageLijst.AddFirst(vak27);
			vakImageLijst.AddFirst(vak28);
			vakImageLijst.AddFirst(vak29);
			vakImageLijst.AddFirst(vak30);
			
			vakImageLijst.AddFirst(vak31);
			vakImageLijst.AddFirst(vak32);
			vakImageLijst.AddFirst(vak33);
			vakImageLijst.AddFirst(vak34);
			vakImageLijst.AddFirst(vak35);
			vakImageLijst.AddFirst(vak36);
			vakImageLijst.AddFirst(vak37);
			vakImageLijst.AddFirst(vak38);
			vakImageLijst.AddFirst(vak39);
			vakImageLijst.AddFirst(vak40);
		}

		private void vakImageChange(Image vakImage)
		{
			String tempSource = vakImage.Source.ToString().Substring(48);
			int beurt = viewcontrol.Spel.WieIsErAanDeBeurt;

			if (tempSource == "noimage.png")
			{
				if (beurt == 1)
				{
					vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/piongroen.png", UriKind.Relative));
				}
				else if (beurt == 2)
				{
					vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/pionrood.png", UriKind.Relative));
				}
				else if (beurt == 3)
				{
					vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/pionblauw.png", UriKind.Relative));
				}
				else if (beurt == 4)
				{
					vakImage.Source = new BitmapImage(new Uri("/MEJN;component/Resources/piongeel.png", UriKind.Relative));
				}
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
				Viewcontrol.Spel.spelOpenen(dlg.FileName);
			}

		}

		private void dobbelsteen_MouseUp(object sender, MouseEventArgs e)
		{
			if (viewcontrol.Spel.Dobbelsteen.Gegooid == false)
			{
				int worp = viewcontrol.Spel.Dobbelsteen.gooiDobbelsteen();

				dobbelsteenImage.Source = dobbelsteenImages[worp - 1];

				Viewcontrol.Spel.Dobbelsteen.switchGegooid();
				Mouse.OverrideCursor = Cursors.Arrow;

				//Kijk welke pionen er beschikbaar zijn en update het bord
				
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
			int vakGetal = Int32.Parse(clickedObject.Name.Substring(3));

			viewcontrol.Spel.pionVerzetten(vakGetal);
			BeurtDoorgeven();
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
	}
}