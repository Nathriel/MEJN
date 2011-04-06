using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Vakje
	{
		private Pion pion;

		public Pion Pion
		{
			get { return pion; }
			set { pion = value; }
		}

		public Vakje()
		{
			
		}

		public Boolean isBezet()
		{
			Boolean ret = false;
			if (Pion != null)
			{
				ret = true;
			}
			return ret;
		}

		override public string ToString()
		{
			string result = "v";

			if (Pion != null)
			{
				result += "-";
				result += ((Pion.ToString() != string.Empty) ? Pion.ToString() : "");
			}
			return result;
		}
	}
}
