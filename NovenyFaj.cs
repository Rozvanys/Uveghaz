using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	enum NovenyFajatak
	{
		Rozsa, paradicsom, krumpli, cukkini, paprika, mak
	}
	internal class NovenyFaj
	{

		private string nev;
		private int maxSuruseg;
		private bool betegseg;
		private int betegsegHajlam;
		public NovenyFaj(string nev, int maxSuruseg, bool betegseg, int betegsegHajlam)
		{
			this.nev = nev;
			this.maxSuruseg = maxSuruseg;
			this.betegseg = betegseg;
			this.betegsegHajlam = betegsegHajlam;
		}

		public string Nev { get => nev; set => nev = value; }
		public int MaxSuruseg { get => maxSuruseg; set => maxSuruseg = value; }
		public string Azonosito { get => nev.Substring(0, 3); }
	}
}
