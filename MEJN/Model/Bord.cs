using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Bord
	{
		private LinkedList vakjesLijst;

		private LinkedList groenFinishvakjes;
		private LinkedList roodFinishvakjes;
		private LinkedList blauwFinishvakjes;
		private LinkedList geelFinishvakjes;

		private LinkedList groenThuisbasis;
		private LinkedList roodThuisbasis;
		private LinkedList blauwThuisbasis;
		private LinkedList geelThuisbasis;

		internal LinkedList VakjesLijst
		{
			get { return vakjesLijst; }
			set { vakjesLijst = value; }
		}

		public Bord()
		{
			vakjesLijst = new LinkedList();

			groenFinishvakjes = new LinkedList();
			roodFinishvakjes = new LinkedList();
			blauwFinishvakjes = new LinkedList();
			geelFinishvakjes = new LinkedList();

			groenThuisbasis = new LinkedList();
			roodThuisbasis = new LinkedList();
			blauwThuisbasis = new LinkedList();
			geelThuisbasis = new LinkedList();

			vulLijsten();
		}

		private void vulLijsten()
		{


			Normaalvakje tempNormVakje = new Normaalvakje();

			for (int i = 0; i < 4; i++)
			{
				Beginvakje tempBeginVakje = new Beginvakje(Kleur.Groen);

				if (i == 0)
				{
					tempBeginVakje = new Beginvakje(Kleur.Groen);
				}
				else if (i == 1)
				{
					tempBeginVakje = new Beginvakje(Kleur.Rood);
				}
				else if (i == 2)
				{
					tempBeginVakje = new Beginvakje(Kleur.Blauw);
				}
				else if (i == 3)
				{
					tempBeginVakje = new Beginvakje(Kleur.Geel);
				}
				vakjesLijst.insertFirst(tempBeginVakje);

				for (int j = 0; j < 9; j++)
				{
					vakjesLijst.insertFirst(tempNormVakje);
					if (j == 8)
					{
						if (i == 0)
						{
							vakjesLijst.First.Finish = groenFinishvakjes.First;
						}
						else if (i == 1)
						{
							vakjesLijst.First.Finish = roodFinishvakjes.First;
						}
						else if (i == 2)
						{
							vakjesLijst.First.Finish = blauwFinishvakjes.First;
						}
						else if (i == 3)
						{
							vakjesLijst.First.Finish = geelFinishvakjes.First;
						}
					}
				}
			}
			VakjesLijst.Last.Next = VakjesLijst.First;
		}
	}
}