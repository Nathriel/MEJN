using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Beginvakje : Vakje
	{
		protected Kleur kleur;

		public Kleur Kleur
		{
			get { return kleur; }
			set { kleur = value; }
		}

		public Beginvakje(Kleur kleur)
		{
			Kleur = kleur;
			Pion = new Pion(Kleur);
		}
	}
}
