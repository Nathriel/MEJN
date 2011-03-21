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

		private List<LinkedList> finishList;
		public List<LinkedList> FinishList
		{
			get { return finishList; }
			set { finishList = value; }
		}

		public Bord()
		{
			vakjesLijst = new LinkedList();
			finishList = new List<LinkedList>();
			LinkedList zwartFinishvakjes = new LinkedList();
			LinkedList roodFinishvakjes = new LinkedList();
			LinkedList blauwFinishvakjes = new LinkedList();
			LinkedList geelFinishvakjes = new LinkedList();
			
			finishList.Add(zwartFinishvakjes);
			finishList.Add(roodFinishvakjes);
			finishList.Add(blauwFinishvakjes);
			finishList.Add(geelFinishvakjes);

			Finishvakje tempFinishVakje = new Finishvakje("f");

			for (int y = 0; y < finishList.Count(); y++)
			{
				finishList[y].insertFirst(tempFinishVakje);
				finishList[y].insertFirst(tempFinishVakje);
				finishList[y].insertFirst(tempFinishVakje);
				finishList[y].insertFirst(tempFinishVakje);
			}
			for (int i = 0; i < 4; i++)
			{
				Beginvakje tempBeginVakje = new Beginvakje("b");
				Normaalvakje tempNormVakje = new Normaalvakje("n");

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
					if (j == 8)
					{
						vakjesLijst.First.finish = finishList[i].First;
					}
				}
			}
			VakjesLijst.Last.next = VakjesLijst.First;
			Console.Write("Bord ");
			vakjesLijst.display();


			for (int i = 0; i < finishList.Count(); i++)
			{
				Console.Write("Finish " + i + " ");
				finishList[i].display();
			}
		}
	}
}
