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

		internal ViewController Viewcontrol
		{
			get { return viewcontrol; }
			set { viewcontrol = value; }
		}

		internal GameBoard(ViewController viewcontrol)
		{
			this.InitializeComponent();
			this.viewcontrol = viewcontrol;
			List<Speler> spelers = viewcontrol.Spel.Spelers;

			GroenLabel.Content = spelers[0].Naam;
			RoodLabel.Content = spelers[1].Naam;
			BlauwLabel.Content = spelers[2].Naam;
			GeelLabel.Content = spelers[3].Naam;
		}
	}
}