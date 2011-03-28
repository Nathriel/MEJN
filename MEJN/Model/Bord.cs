using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class Bord
	{
		private LinkedList vakjesLijst;
		private List<LinkedList> finishList;
		private List<LinkedList> thuisbasisList;

		internal LinkedList VakjesLijst
		{
			get { return vakjesLijst; }
			set { vakjesLijst = value; }
		}
		public List<LinkedList> FinishList
		{
			get { return finishList; }
			set { finishList = value; }
		}
		internal List<LinkedList> ThuisbasisList
		{
			get { return thuisbasisList; }
			set { thuisbasisList = value; }
		}

		public Bord()
		{
			vakjesLijst = new LinkedList();
			finishList = new List<LinkedList>();
			thuisbasisList = new List<LinkedList>();
			LinkedList groenFinishvakjes = new LinkedList();
			LinkedList roodFinishvakjes = new LinkedList();
			LinkedList blauwFinishvakjes = new LinkedList();
			LinkedList geelFinishvakjes = new LinkedList();

			finishList.Add(groenFinishvakjes);
			finishList.Add(roodFinishvakjes);
			finishList.Add(blauwFinishvakjes);
			finishList.Add(geelFinishvakjes);

			Finishvakje tempFinishVakje = new Finishvakje("f");

			for (int i = 0; i < finishList.Count(); i++)
			{
				finishList[i].insertFirst(tempFinishVakje);
				finishList[i].insertFirst(tempFinishVakje);
				finishList[i].insertFirst(tempFinishVakje);
				finishList[i].insertFirst(tempFinishVakje);
			}

			LinkedList groenThuisbasis = new LinkedList();
			LinkedList roodThuisbasis = new LinkedList();
			LinkedList blauwThuisbasis = new LinkedList();
			LinkedList geelThuisbasis = new LinkedList();

			thuisbasisList.Add(groenThuisbasis);
			thuisbasisList.Add(roodThuisbasis);
			thuisbasisList.Add(blauwThuisbasis);
			thuisbasisList.Add(geelThuisbasis);

			Normaalvakje tempNormVakje = new Normaalvakje("n");

			for (int i = 0; i < thuisbasisList.Count(); i++)
			{
				thuisbasisList[i].insertFirst(tempNormVakje);
				thuisbasisList[i].insertFirst(tempNormVakje);
				thuisbasisList[i].insertFirst(tempNormVakje);
				thuisbasisList[i].insertFirst(tempNormVakje);
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
						vakjesLijst.First.Finish = finishList[i].First;
					}
				}
			}
			VakjesLijst.Last.Next = VakjesLijst.First;
			Console.Write("Bord ");
			vakjesLijst.display();


			for (int i = 0; i < finishList.Count(); i++)
			{
				Console.Write("Finish " + i + " ");
				finishList[i].display();
			}

			for (int i = 0; i < thuisbasisList.Count(); i++)
			{
				Console.Write("Thuisbasis " + i + " ");
				thuisbasisList[i].display();
			}
		}
	}
}
