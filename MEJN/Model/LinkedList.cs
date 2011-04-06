using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class LinkedList
	{
		private Link first;
		private Link last;
		private int stepsLeft;

		internal Link First
		{
			get { return first; }
			set { first = value; }
		}
		internal Link Last
		{
			get { return last; }
			set { last = value; }
		}
		public int StepsLeft
		{
			get { return stepsLeft; }
			set { stepsLeft = value; }
		}

		public LinkedList()
		{
			first = null;
			last = null;
			stepsLeft = 0;
		}

		public Boolean isEmpty()
		{
			return (first == null);
		}

		public void display()
		{
			Console.Write("vakjes: ");
			Link current = first;
			int i = 1;
			while (current != null)
			{
				current.displayLink();
				Console.Write(i + "}");
				current = current.Next;
				i++;
				if (current == last.Next)
				{
					break;
				}
			}
			Console.WriteLine("");
		}

		public string formatForSave()
		{
			string saveString = "";
			Link current = first;
			int i = 1;
			while (current != null)
			{
				saveString += current.IData.ToString();

				current = current.Next;
				i++;
				if (current == last.Next)
				{
					saveString += ";";
					break;
				}
				saveString += ",";
			}
			return saveString;
		}

		public void insertFirst(Vakje vakje)
		{
			Link newLink = new Link(vakje);
			if (isEmpty())
			{
				last = newLink;
			}
			else
			{
				first.Previous = newLink;
			}
			newLink.Next = first;
			first = newLink;
		}

		public void insertLast(Vakje vakje)
		{
			Link newLink = new Link(vakje);
			if (isEmpty())
			{
				first = newLink;
			}
			else
			{
				last.Next = newLink;
				newLink.Previous = last;
			}
			last = newLink;
		}

		public int length()
		{
			int leng = 0;
			Link current = first;
			while (current != null)
			{
				leng++;
				current = current.Next;
			}
			return leng;
		}

		public Link zoekOpVakGetal(int vakGetal)
		{
			Link current = first;
			for(int i = 1; i < vakGetal; i++)
			{
				current = current.Next;
			}
			return current;
		}

		private Link zoekOpVakGetalMetControle(int vakGetal, Kleur wieIsErAanDeBeurt)
		{
			Link current = first;
			for (int i = 1; i < vakGetal; i++)
			{
				Vakje next = current.Next.IData;
				if (next.GetType() == typeof(Beginvakje))
				{
					Beginvakje nextFinish = next as Beginvakje;
					if (nextFinish.Kleur == wieIsErAanDeBeurt)
					{
						current = current.Finish;
						StepsLeft = vakGetal - i;
						break;
					}
				}
				else
				{
					current = current.Next;
				}
			}
			return current;
		}

		public void zetPion(Pion pion, int zoekNummer)
		{
			Link vakje = zoekOpVakGetal(zoekNummer);
			vakje.IData.Pion = pion;
		}

		public Link pionVerzetten(int vakGetal, int worp, Kleur wieIsErAanDeBeurt)
		{
			Link ret = null;
			Link start = zoekOpVakGetal(vakGetal);
			Link end = zoekOpVakGetalMetControle(vakGetal + worp, wieIsErAanDeBeurt);

			if (end != null)
			{
				if (end.Previous != null)
				{
					if (start.IData.Pion != null)
					{
						if (start.IData.Pion.Kleur == wieIsErAanDeBeurt)
						{
							end.IData.Pion = start.IData.Pion;
							start.IData.Pion = null;
							ret = end;
						}
					}
				}
				else
				{
					ret = end;
				}
			}
			return ret;
		}

		public void pionVerzettenFinish(Pion pion, int steps)
		{
			Link current = First;
			for (int i = 1; i <= steps; i++)
			{
				

				controlleerVolgendVakje(current);
			}
			current.IData.Pion = pion;
		}

		private void controlleerVolgendVakje(Link current)
		{
			if (current.Next != null)
			{
				current = current.Next;
			}
			else
			{
				current = First;
			}

			if (current.IData.isBezet())
			{
				current = current.Next;
			}
		}
	}
}
