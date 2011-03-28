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
	}
}
