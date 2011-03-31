using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Dobbelsteen
	{
		private int worp;

		public Dobbelsteen()
		{
			worp = 0;
		}

		public int gooiDobbelsteen()
		{
			Random generator; generator = new Random();

			worp = generator.Next(1, 7);

			return worp;
		}
	}
}
