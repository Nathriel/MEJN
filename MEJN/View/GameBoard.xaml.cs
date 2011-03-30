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
		
		internal ViewController Viewcontrol
		{
			get { return viewcontrol; }
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
			List<Speler> spelers = viewcontrol.Spel.Spelers;

			GroenLabel.Content = spelers[0].Naam;
			RoodLabel.Content = spelers[1].Naam;
			BlauwLabel.Content = spelers[2].Naam;
			GeelLabel.Content = spelers[3].Naam;

			vulVakImageLijst();
		}

		private void vulVakImageLijst()
		{
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
			String tempSource = vakImage.Source.ToString().Substring(50);

			if (tempSource == "noimage.png")
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/View/Images/turnindicator.png", UriKind.Relative));
			}
			else if(tempSource == "turnindicator.png")
			{
				vakImage.Source = new BitmapImage(new Uri("/MEJN;component/View/Images/noimage.png", UriKind.Relative));
			}
		}

		void vak_MouseUp(object sender, MouseButtonEventArgs e)
		{
			vakImageChange(sender as Image);
		}

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
	}
}