﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace MEJN
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static StartupEventArgs args;

		private void AppStartup(object sender, StartupEventArgs e)
		{
			args = e;
		}

	}
}
