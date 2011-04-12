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
		private Boolean forwards;
		private int lengte;

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
			forwards = true;
			lengte = 0;
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
			lengte++;
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
			lengte++;
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

		public Link zoekOpVakGetalMetControle(int vakGetal, int worp, Kleur wieIsErAanDeBeurt)
		{
			Link current = zoekOpVakGetal(vakGetal);

			for (int i = 0; i < worp; i++)
			{
				if (current != null)
				{
					Link volgende = current.Next;
					if (volgende != null)
					{
						if (volgende.IData.GetType() == typeof(Beginvakje))
						{
							Beginvakje beginvakje = volgende.IData as Beginvakje;
							if (beginvakje.Kleur == wieIsErAanDeBeurt)
							{
								current = current.Finish;
								StepsLeft = worp - i;
								break;
							}
						}
					}
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
			Link end = zoekOpVakGetalMetControle(vakGetal, worp, wieIsErAanDeBeurt);
			//Link end = zoekOpVakGetal(vakGetal + worp);

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

		public Boolean isAllesBezet()
		{
			Link current = first;
			for (int i = 1; i <= lengte; i++)
			{
				if (current != null)
				{
					if (current.IData != null)
					{
						if (!current.IData.isBezet())
						{
							return false;
						}
					}
				}
				current = current.Next;
			}
			return true;
		}

		public int hoeveelBezet()
		{
			int ret = 0;
			Link current = first;
			for (int i = 1; i <= lengte; i++)
			{
				if (current != null)
				{
					if (current.IData != null)
					{
						if (current.IData.isBezet())
						{
							ret++;
						}
					}
				}
				current = current.Next;
			}
			return ret;
		}

		public Boolean pionVerzettenFinish(Pion pion, int steps)
		{
			Link current = First;
			forwards = true;
			for (int i = 1; i <= steps; i++)
			{
				if (controlleerVolgendVakje(current, forwards) == null)
				{
					return false;
				}
			}

			if (current.IData.isBezet())
			{
				return false;
			}
			current.IData.Pion = pion;
			return true;
		}

		private Link controlleerVolgendVakje(Link current, Boolean forwards)
		{
			if (forwards)
			{
				if (current.Next != null)
				{
					current = current.Next;
				}
				else
				{
					forwards = !forwards;
				}
			}
			else
			{
				if (current.Previous != null)
				{
					current = current.Previous;
				}
				else
				{
					forwards = !forwards;
				}
			}
			return current;
		}
	}
}
