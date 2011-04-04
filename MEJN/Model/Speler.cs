using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Speler
	{
		private String naam;
		private Kleur kleur;
		private Boolean active;

		private List<Pion> pionnen;

		public String Naam
		{
			get { return naam; }
			set { naam = value; }
		}
		internal Kleur Kleur
		{
			get { return kleur; }
			set { kleur = value; }
		}
		public Boolean Active
		{
			get { return active; }
			set { active = value; }
		}
		internal List<Pion> Pionnen
		{
			get { return pionnen; }
			set { pionnen = value; }
		}

		public Speler(String naam ,Kleur kleur)
		{
			this.naam = naam;
			this.kleur = kleur;
			active = true;
			pionnen = new List<Pion>();

			pionnen.Add(new Pion(kleur));
			pionnen.Add(new Pion(kleur));
			pionnen.Add(new Pion(kleur));
			pionnen.Add(new Pion(kleur));

		}

		internal void doFirstMove()
		{
			if (this.GetType() == typeof(Bot))
			{
				//Eerste speler is bot, doe eerste zet
			}

			//Wacht op speler input
		}
	}
}
