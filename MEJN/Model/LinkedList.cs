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

		public LinkedList()
		{
			first = null;
			last = null;
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

		private Link zoekOpVakGetal(int vakGetal)
		{
			Link current = first;
			for(int i = 1; i < vakGetal; i++)
			{
				current = current.Next;
			}
			return current;
		}

		public void zetPion(Pion pion, int zoekNummer)
		{
			Link link = zoekOpVakGetal(zoekNummer);
			link.IData.Pion = pion;
		}

		public void pionVerzetten(int vakGetal, int worp)
		{
			Link start = zoekOpVakGetal(vakGetal);
			Link end = zoekOpVakGetal(vakGetal + worp);

			end.IData.Pion = start.IData.Pion;
			start.IData.Pion = null;
		}
	}
}
