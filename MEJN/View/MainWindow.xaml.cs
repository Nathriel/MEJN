using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MEJN.Model;
using MEJN.View;

namespace MEJN
{
	public partial class MainWindow : Window
	{
		private ViewController viewControl;

		internal ViewController ViewControl
		{
			get { return viewControl; }
			set { viewControl = value; }
		}

		public MainWindow()
		{
			InitializeComponent();
			viewControl = new ViewController();
		}

		private void loadGame(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
			dlg.FileName = "spel";
			dlg.DefaultExt = ".mejns";
			dlg.Filter = "Mens Erger Je Niet Spel Document (.mejns)|*.mejns";

			Nullable<bool> result = dlg.ShowDialog();

			if (result == true)
			{
				viewControl.Spel.spelOpenen(dlg.FileName);
			}
		}

		private void startNewGame(object sender, RoutedEventArgs e)
		{
			List<Speler> spelers = viewControl.Spel.Spelers;
			if (GroenTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(GroenNamefield.Text, Kleur.Groen));
			}
			else if (GroenTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(GroenNamefield.Text, Kleur.Groen));
			}

			if (RoodTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(RoodNamefield.Text, Kleur.Rood));
			}
			else if (RoodTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(RoodNamefield.Text, Kleur.Rood));
			}

			if (BlauwTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(BlauwNamefield.Text, Kleur.Blauw));
			}
			else if (BlauwTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(BlauwNamefield.Text, Kleur.Blauw));
			}

			if (GeelTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(GeelNamefield.Text, Kleur.Geel));
			}
			else if (GeelTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(GeelNamefield.Text, Kleur.Geel));
			}

			GameBoard game = new GameBoard(viewControl);
			game.Visibility = System.Windows.Visibility.Visible;
			this.Close();
		}
	}
}
