﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MEJN.Model;

namespace MEJN
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();
			Bord bord = new Bord();
			Console.WriteLine(bord.VakjesLijst.isEmpty());
		}
	}
}
