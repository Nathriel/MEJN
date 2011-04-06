using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	public enum Kleur
	{
		Groen, Rood, Blauw, Geel , Neutral
	}


	public static class KleurMethods
	{
		public static string returnString(Kleur val)
		{
			if (val.Equals(Kleur.Groen))
			{
				return "gr";
			}

			if (val.Equals(Kleur.Rood))
			{
				return "ro";
			}

			if (val.Equals(Kleur.Blauw))
			{
				return "bl";
			}

			if (val.Equals(Kleur.Geel))
			{
				return "ge";
			}

			return"";
		}
	}
}
