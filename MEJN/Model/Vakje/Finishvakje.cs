using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Finishvakje : Vakje
	{
		protected Kleur kleur;

		public Kleur Kleur
		{
			get { return kleur; }
			set { kleur = value; }
		}

		public Finishvakje(Kleur kleur)
		{
			Kleur = kleur;
		}

		override public string ToString()
		{
			string result = "fv";

			result += "+";
			result += kleur.ToString();

			if (Pion != null)
			{
				result += "-";
				result += ((Pion.ToString() != string.Empty) ? Pion.ToString() : "");
			}
			return result;
		}

	}
}
