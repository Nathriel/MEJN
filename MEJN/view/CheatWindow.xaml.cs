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
using System.Windows.Shapes;

namespace MEJN.View
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class CheatWindow : Window
	{
		private ViewController viewcontrol;

		internal CheatWindow(ViewController viewcontrol)
		{
			this.viewcontrol = viewcontrol;
			InitializeComponent();
		}

		private void setThedice(object sender, RoutedEventArgs e)
		{
			viewcontrol.Spel.Dobbelsteen.Gegooid = true;
			viewcontrol.Spel.Dobbelsteen.Worp =dicebox.SelectedIndex+1;
			viewcontrol.Spel.Bordgui.dobbelsteen_changeimage(viewcontrol.Spel.Dobbelsteen.Worp);
		}
	}
}
