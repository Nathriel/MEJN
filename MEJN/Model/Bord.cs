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

		internal LinkedList GroenFinishvakjes
		{
			get { return groenFinishvakjes; }
			set { groenFinishvakjes = value; }
		}

		internal LinkedList RoodFinishvakjes
		{
			get { return roodFinishvakjes; }
			set { roodFinishvakjes = value; }
		}
		internal LinkedList BlauwFinishvakjes
		{
			get { return blauwFinishvakjes; }
			set { blauwFinishvakjes = value; }
		}
		internal LinkedList GeelFinishvakjes
		{
			get { return geelFinishvakjes; }
			set { geelFinishvakjes = value; }
		}
		internal LinkedList GroenThuisbasis
		{
			get { return groenThuisbasis; }
			set { groenThuisbasis = value; }
		}
		internal LinkedList RoodThuisbasis
		{
			get { return roodThuisbasis; }
			set { roodThuisbasis = value; }
		}
		internal LinkedList BlauwThuisbasis
		{
			get { return blauwThuisbasis; }
			set { blauwThuisbasis = value; }
		}
		internal LinkedList GeelThuisbasis
		{
			get { return geelThuisbasis; }
			set { geelThuisbasis = value; }
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
			///Thuisbasis
			//GROEN
			Beginvakje groenThuisBasis1 = new Beginvakje(Kleur.Groen);
			Beginvakje groenThuisBasis2 = new Beginvakje(Kleur.Groen);
			Beginvakje groenThuisBasis3 = new Beginvakje(Kleur.Groen);
			Beginvakje groenThuisBasis4 = new Beginvakje(Kleur.Groen);
			GroenThuisbasis.insertFirst(groenThuisBasis1);
			GroenThuisbasis.insertFirst(groenThuisBasis2);
			GroenThuisbasis.insertFirst(groenThuisBasis3);
			GroenThuisbasis.insertFirst(groenThuisBasis4);

			//ROOD
			Beginvakje roodThuisBasis1 = new Beginvakje(Kleur.Rood);
			Beginvakje roodThuisBasis2 = new Beginvakje(Kleur.Rood);
			Beginvakje roodThuisBasis3 = new Beginvakje(Kleur.Rood);
			Beginvakje roodThuisBasis4 = new Beginvakje(Kleur.Rood);
			RoodThuisbasis.insertFirst(roodThuisBasis1);
			RoodThuisbasis.insertFirst(roodThuisBasis2);
			RoodThuisbasis.insertFirst(roodThuisBasis3);
			RoodThuisbasis.insertFirst(roodThuisBasis4);

			//BLAUW
			Beginvakje blauwThuisBasis1 = new Beginvakje(Kleur.Blauw);
			Beginvakje blauwThuisBasis2 = new Beginvakje(Kleur.Blauw);
			Beginvakje blauwThuisBasis3 = new Beginvakje(Kleur.Blauw);
			Beginvakje blauwThuisBasis4 = new Beginvakje(Kleur.Blauw);
			BlauwThuisbasis.insertFirst(blauwThuisBasis1);
			BlauwThuisbasis.insertFirst(blauwThuisBasis2);
			BlauwThuisbasis.insertFirst(blauwThuisBasis3);
			BlauwThuisbasis.insertFirst(blauwThuisBasis4);

			LinkedList groenThuisbasis = new LinkedList();
			LinkedList roodThuisbasis = new LinkedList();
			LinkedList blauwThuisbasis = new LinkedList();
			LinkedList geelThuisbasis = new LinkedList();

			//GEEl
			Beginvakje geelThuisBasis1 = new Beginvakje(Kleur.Geel);
			Beginvakje geelThuisBasis2 = new Beginvakje(Kleur.Geel);
			Beginvakje geelThuisBasis3 = new Beginvakje(Kleur.Geel);
			Beginvakje geelThuisBasis4 = new Beginvakje(Kleur.Geel);
			GeelThuisbasis.insertFirst(geelThuisBasis1);
			GeelThuisbasis.insertFirst(geelThuisBasis2);
			GeelThuisbasis.insertFirst(geelThuisBasis3);
			GeelThuisbasis.insertFirst(geelThuisBasis4);

			///Finishvakjes
			//GROEN
			Finishvakje groenFinishVakje1 = new Finishvakje(Kleur.Groen);
			Finishvakje groenFinishVakje2 = new Finishvakje(Kleur.Groen);
			Finishvakje groenFinishVakje3 = new Finishvakje(Kleur.Groen);
			Finishvakje groenFinishVakje4 = new Finishvakje(Kleur.Groen);
			groenFinishvakjes.insertFirst(groenFinishVakje1);
			groenFinishvakjes.insertFirst(groenFinishVakje2);
			groenFinishvakjes.insertFirst(groenFinishVakje3);
			groenFinishvakjes.insertFirst(groenFinishVakje4);

			//ROOD
			Finishvakje roodFinishVakje1 = new Finishvakje(Kleur.Rood);
			Finishvakje roodFinishVakje2 = new Finishvakje(Kleur.Rood);
			Finishvakje roodFinishVakje3 = new Finishvakje(Kleur.Rood);
			Finishvakje roodFinishVakje4 = new Finishvakje(Kleur.Rood);
			roodFinishvakjes.insertFirst(roodFinishVakje1);
			roodFinishvakjes.insertFirst(roodFinishVakje2);
			roodFinishvakjes.insertFirst(roodFinishVakje3);
			roodFinishvakjes.insertFirst(roodFinishVakje4);

			//BLAUW
			Finishvakje blauwFinishVakje1 = new Finishvakje(Kleur.Blauw);
			Finishvakje blauwFinishVakje2 = new Finishvakje(Kleur.Blauw);
			Finishvakje blauwFinishVakje3 = new Finishvakje(Kleur.Blauw);
			Finishvakje blauwFinishVakje4 = new Finishvakje(Kleur.Blauw);
			blauwFinishvakjes.insertFirst(blauwFinishVakje1);
			blauwFinishvakjes.insertFirst(blauwFinishVakje2);
			blauwFinishvakjes.insertFirst(blauwFinishVakje3);
			blauwFinishvakjes.insertFirst(blauwFinishVakje4);

			//GEEL
			Finishvakje geelFinishVakje1 = new Finishvakje(Kleur.Geel);
			Finishvakje geelFinishVakje2 = new Finishvakje(Kleur.Geel);
			Finishvakje geelFinishVakje3 = new Finishvakje(Kleur.Geel);
			Finishvakje geelFinishVakje4 = new Finishvakje(Kleur.Geel);
			geelFinishvakjes.insertFirst(geelFinishVakje1);
			geelFinishvakjes.insertFirst(geelFinishVakje2);
			geelFinishvakjes.insertFirst(geelFinishVakje3);
			geelFinishvakjes.insertFirst(geelFinishVakje4);

			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 9; j++)
				{
					vakjesLijst.insertFirst(new Normaalvakje());
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
			}
			VakjesLijst.Last.Next = VakjesLijst.First;
			VakjesLijst.First.Previous = VakjesLijst.Last;
		}
	}
}