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

			GroenLabel.Content = viewcontrol.Spel.Spelers[0].Naam;
			RoodLabel.Content = viewcontrol.Spel.Spelers[1].Naam;
			BlauwLabel.Content = viewcontrol.Spel.Spelers[2].Naam;
			GeelLabel.Content = viewcontrol.Spel.Spelers[3].Naam;
		}
	}
}