using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEJN.Control;

namespace MEJN.Model
{
	class Bot : Speler
	{
		public Bot(String naam, Kleur kleur)
			: base(naam, kleur)
		{

		}

		internal void doTurn(MEJN.Control.Spel sender)
		{
			sender.Dobbelsteen.gooiDobbelsteen();

		}
	}
}
