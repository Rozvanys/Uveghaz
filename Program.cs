using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	internal class Program
	{
		static void Main(string[] args)
		{
			UveghazRacs racs = new UveghazRacs(5);
			NovenyFaj paradicsom = new NovenyFaj("Paradicsom", 8);
			racs.Telepit(1, 1, paradicsom, 5);
			racs.TerepKiir();
		}
	}
}
