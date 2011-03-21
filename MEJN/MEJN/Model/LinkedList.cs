using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class LinkedList
	{
		private Link first;

		internal Link First
		{
			get { return first; }
			set { first = value; }
		}
		private Link last;

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
				current = current.next;
				i++;
				if (current == last.next)
				{
					break;
				}
			}
			Console.WriteLine("");
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
				first.previous = newLink;
			}
			newLink.next = first;
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
				last.next = newLink;
				newLink.previous = last;
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
				current = current.next;
			}
			return leng;
		}
	}
}
