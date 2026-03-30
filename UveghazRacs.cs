using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	internal class UveghazRacs
	{
		private Cella[,] racs;
		public int meret;

		public UveghazRacs(int meret)
		{
			this.meret = meret;
			racs = new Cella[meret, meret];
			for (int i = 0; i < meret; i++)
			{
				for (int j = 0; j < meret; j++)
				{
					racs[i, j] = new Cella(i, j);
				}
			}
		}
		public Cella CellaLekerdez(int x, int y)
		{
			return racs[x, y];
		}
		public void Telepit(int x, int y, NovenyFaj faj, int mennyiseg)
		{
			racs[x, y].Telepit(faj, mennyiseg); 
		}
		public void TerepKiir()
		{
			for (int i = 0; i < meret; i++)
			{
				for (int j = 0; j < meret; j++)
				{
					if (racs[i, j].Ures())
						Console.Write("[ ]");
					else
						Console.Write("[X]");
				}
				Console.WriteLine();
			}
		}
	}
}
