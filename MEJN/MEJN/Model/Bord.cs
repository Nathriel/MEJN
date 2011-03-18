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

		public Bord()
		{
			vakjesLijst = new LinkedList();
		}
	}
}
