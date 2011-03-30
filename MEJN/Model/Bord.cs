using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Bord
	{
		private LinkedList vakjesLijst;
		private List<LinkedList> finishLijst;
		private List<LinkedList> thuisbasisLijst;

		internal LinkedList VakjesLijst
		{
			get { return vakjesLijst; }
			set { vakjesLijst = value; }
		}
		public List<LinkedList> FinishLijst
		{
			get { return finishLijst; }
			set { finishLijst = value; }
		}
		internal List<LinkedList> ThuisbasisLijst
		{
			get { return thuisbasisLijst; }
			set { thuisbasisLijst = value; }
		}

		public Bord()
		{
			vakjesLijst = new LinkedList();
			finishLijst = new List<LinkedList>();
			thuisbasisLijst = new List<LinkedList>();

			vulLijsten();
			displayLijsten();
		}

		private void vulLijsten()
		{
			LinkedList groenFinishvakjes = new LinkedList();
			LinkedList roodFinishvakjes = new LinkedList();
			LinkedList blauwFinishvakjes = new LinkedList();
			LinkedList geelFinishvakjes = new LinkedList();

			finishLijst.Add(groenFinishvakjes);
			finishLijst.Add(roodFinishvakjes);
			finishLijst.Add(blauwFinishvakjes);
			finishLijst.Add(geelFinishvakjes);

			Finishvakje tempFinishVakje = new Finishvakje("f");

			for (int i = 0; i < finishLijst.Count(); i++)
			{
				finishLijst[i].insertFirst(tempFinishVakje);
				finishLijst[i].insertFirst(tempFinishVakje);
				finishLijst[i].insertFirst(tempFinishVakje);
				finishLijst[i].insertFirst(tempFinishVakje);
			}

			LinkedList groenThuisbasis = new LinkedList();
			LinkedList roodThuisbasis = new LinkedList();
			LinkedList blauwThuisbasis = new LinkedList();
			LinkedList geelThuisbasis = new LinkedList();

			thuisbasisLijst.Add(groenThuisbasis);
			thuisbasisLijst.Add(roodThuisbasis);
			thuisbasisLijst.Add(blauwThuisbasis);
			thuisbasisLijst.Add(geelThuisbasis);

			Normaalvakje tempNormVakje = new Normaalvakje("n");

			for (int i = 0; i < thuisbasisLijst.Count(); i++)
			{
				thuisbasisLijst[i].insertFirst(tempNormVakje);
				thuisbasisLijst[i].insertFirst(tempNormVakje);
				thuisbasisLijst[i].insertFirst(tempNormVakje);
				thuisbasisLijst[i].insertFirst(tempNormVakje);
			}

			for (int i = 0; i < 4; i++)
			{
				Beginvakje tempBeginVakje = new Beginvakje("b");

				if (i == 0)
				{
					tempBeginVakje = new Beginvakje("gb");
					tempBeginVakje.Kleur = Kleur.Groen;
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
					tempBeginVakje = new Beginvakje("eb");
					tempBeginVakje.Kleur = Kleur.Geel;
				}
				vakjesLijst.insertFirst(tempBeginVakje);

				for (int j = 0; j < 9; j++)
				{
					vakjesLijst.insertFirst(tempNormVakje);
					if (j == 8)
					{
						vakjesLijst.First.Finish = finishLijst[i].First;
					}
				}
			}
			VakjesLijst.Last.Next = VakjesLijst.First;
		}

		public void displayLijsten()
		{
			Console.Write("Bord ");
			vakjesLijst.display();

			for (int i = 0; i < finishLijst.Count(); i++)
			{
				Console.Write("Finish " + i + " ");
				finishLijst[i].display();
			}

			for (int i = 0; i < thuisbasisLijst.Count(); i++)
			{
				Console.Write("Thuisbasis " + i + " ");
				thuisbasisLijst[i].display();
			}
		}
	}
}