using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Pion
	{
		private Kleur kleur;

		internal Kleur Kleur
		{
			get { return kleur; }
			set { kleur = value; }
		}

		public Pion(Kleur kleur)
		{
			this.kleur = kleur;
		}

		override public string ToString()
		{
			if(kleur.Equals(Kleur.Groen))
			{
				return "gr";
			}

			if (kleur.Equals(Kleur.Rood))
			{
				return "ro";
			}

			if (kleur.Equals(Kleur.Blauw))
			{
				return "bl";
			}

			if (kleur.Equals(Kleur.Geel))
			{
				return "ge";
			}

			return "";
		}
	}
}
