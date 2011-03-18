using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEJN.Model
{
	class LinkedList
	{
		private Link first { set; get; }
		private Link last { set; get; }
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
			Console.Write("Vakjes: ");
			Link current = first;
			while (current != null)
			{
				current.displayLink();
				current = current.next;
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
