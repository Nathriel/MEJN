using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Vakje
	{
		private Pion pion;

		protected Pion Pion
		{
			get { return pion; }
			set { pion = value; }
		}

		public Vakje()
		{
			
		}

		override public string ToString()
		{
			string result = "v";

			if (Pion != null)
			{
				result += ((Pion.ToString() != string.Empty) ? Pion.ToString() : "");
			}
			return result;
		}
	}
}
