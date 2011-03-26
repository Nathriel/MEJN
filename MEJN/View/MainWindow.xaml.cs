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
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			ViewController bord = new ViewController();
		}

		private void loadGame(object sender, RoutedEventArgs e)
		{

		}

		private void startNewGame(object sender, RoutedEventArgs e)
		{
			GameBoard game = new GameBoard();
			game.Visibility = System.Windows.Visibility.Visible;
			this.Close();
		}
	}
}
