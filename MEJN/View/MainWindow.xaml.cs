﻿using System;
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
				if (viewControl.Spel.spelOpenen(dlg.FileName))
				{
					foreach (string commandArg in App.args.Args)
					{
						System.Console.WriteLine(commandArg);
						if (commandArg == "-cheats")
						{
							CheatWindow cheatwindow = new CheatWindow(viewControl);
							cheatwindow.Visibility = System.Windows.Visibility.Visible;
						}
					}

					GameBoard game = new GameBoard(viewControl);
					game.vulImageLijst();
					game.updateGameBoard();
					game.Visibility = System.Windows.Visibility.Visible;
					viewControl.Spel.Bordgui = game;
					this.Close();
					viewControl.Spel.checkBotTurn();
				}
			}
		}

		private void startNewGame(object sender, RoutedEventArgs e)
		{
			List<Speler> spelers = viewControl.Spel.Spelers;
			if (GroenTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(GroenNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Groen));
			}
			else if (GroenTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(GroenNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Groen));
			}

			if (RoodTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(RoodNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Rood));
			}
			else if (RoodTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(RoodNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Rood));
			}

			if (BlauwTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(BlauwNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Blauw));
			}
			else if (BlauwTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(BlauwNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Blauw));
			}

			if (GeelTypeBox.Text == "Mens")
			{
				spelers.Add(new Speler(GeelNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Geel));
			}
			else if (GeelTypeBox.Text == "Computer")
			{
				spelers.Add(new Bot(GeelNamefield.Text.Replace(';', ' ').Replace(',', ' ').Replace('-', ' ').Replace('+', ' '), Kleur.Geel));
			}

			foreach (string commandArg in App.args.Args)
			{
				System.Console.WriteLine(commandArg);
				if (commandArg == "-cheats")
				{
					CheatWindow cheatwindow = new CheatWindow(viewControl);
					cheatwindow.Visibility = System.Windows.Visibility.Visible;
				}
			}

			GameBoard game = new GameBoard(viewControl);
			ViewControl.Spel.startPositie();

			game.vulImageLijst();
			game.updateGameBoard();
			game.Visibility = System.Windows.Visibility.Visible;
			viewControl.Spel.Bordgui = game;
			this.Close();
			viewControl.Spel.checkBotTurn();
		}
	}
}
