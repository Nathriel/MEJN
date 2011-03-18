using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Bord
	{
		private LinkedList vakjesLijst;
		
		internal LinkedList VakjesLijst
		{
			get { return vakjesLijst; }
			set { vakjesLijst = value; }
		}

		public Bord()
		{
			vakjesLijst = new LinkedList();

			for (int i = 0; i < 4; i++)
			{
				Beginvakje tempBeginVakje = new Beginvakje("b");
				Normaalvakje tempNormVakje = new Normaalvakje("n");
				Finishvakje tempFinishVakje = new Finishvakje("f");
				if (i == 0)
				{
					tempBeginVakje = new Beginvakje("zb");
					tempBeginVakje.Kleur = Kleur.Zwart;
				}
				else if (i == 1)
				{
					tempBeginVakje = new Beginvakje("rb");
					tempBeginVakje.Kleur = Kleur.Rood;
				}
				else if (i == 2)
				{
					tempBeginVakje = new Beginvakje("bb");
					tempBeginVakje.Kleur = Kleur.Blauw;
				}
				else if (i == 3)
				{
					tempBeginVakje = new Beginvakje("gb");
					tempBeginVakje.Kleur = Kleur.Geel;
				}
				vakjesLijst.insertFirst(tempBeginVakje);

				for (int j = 0; j < 9; j++)
				{
					vakjesLijst.insertFirst(tempNormVakje);
				}
			}

			vakjesLijst.display();
		}
	}
}
