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

		public Finishvakje(String soort)
			: base(soort)
		{

		}
	}
}
