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
			Console.WriteLine("List (first-->last): ");
			Link current = first;
			while (current != null)
			{
				current.displayLink();
				current = current.next;
			}
			Console.WriteLine("");
		}

		public void insertFirst(int number)
		{
			Link newLink = new Link(number);
			if (isEmpty())
			{
				last = newLink;
			}
			else
			{
				first.previous = newLink;
			}
			first = newLink;
		}

		public void insertLast(int number)
		{
			Link newLink = new Link(number);
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
