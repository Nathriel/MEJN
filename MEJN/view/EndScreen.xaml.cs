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

namespace MEJN
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class EndScreen : Window
	{
		public EndScreen(string naam)
		{
			this.InitializeComponent();
			spelernaam.Content = naam;
			// Insert code required on object creation below this point.
		}

		private void restartGame(object sender, RoutedEventArgs e)
		{
			MainWindow mainwindow = new MainWindow();
			mainwindow.Visibility = System.Windows.Visibility.Visible;
			this.Close();
		}
	}
}