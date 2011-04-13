using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Dobbelsteen
	{
		private int worp;
		private Boolean gegooid;
		private Random generator;

		public int Worp
		{
			get { return worp; }
			set { worp = value; }
		}
		public Boolean Gegooid
		{
			get { return gegooid; }
			set { gegooid = value; }
		}

		public Dobbelsteen()
		{
			worp = 0;
			gegooid = false;
			generator = new Random();
		}

		public int gooiDobbelsteen()
		{
			worp = generator.Next(1, 7);

			return worp;
		}

		public void switchGegooid()
		{
			gegooid = !gegooid;
		}
	}
}
