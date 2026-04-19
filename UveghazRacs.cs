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
			if (racs[x,y].Ures())
			{
				racs[x, y].Telepit(faj, mennyiseg);
				Console.WriteLine($"Telepítettél {mennyiseg} db {faj.Fajta}-t!");
			}else{
				Console.WriteLine("A cellába már van telepítve növény!");
			}
			
		}
		public void TerepKiir()
		{
			Console.WriteLine($"\n---- Üvegház térkép ----");
			for (int i = 0; i < meret; i++)
			{
				for (int j = 0; j < meret; j++)
				{
					Cella aktualis = racs[i, j];
					if (aktualis.Ures())
						Console.Write($"[{"[Üres]\t"} ]");
					else{
						string betegJelzo = " ";
						if (aktualis.IsBeteg)
							betegJelzo = "!";
						Console.Write($"[{aktualis.Noveny.Azonosito}:{aktualis.Egyedszam,2} {betegJelzo}]\t");
					}
						
				}
				Console.WriteLine("\n");
			}
		}
		public void ParcellaInfo(int x, int y)
		{
			Cella vizsgaltCella = racs[x, y];
			Console.WriteLine($"\n---- Parcella Info ({x}, {y}) ----");
			if (vizsgaltCella.Ures())
			{
				Console.WriteLine("A parcella üres.");
				Console.WriteLine($"A föld nedvessége: {vizsgaltCella.Nedvesseg}%");
			}
			else
			{
				Console.WriteLine($"Növényfaj: {vizsgaltCella.Noveny.Fajta}");
				Console.WriteLine($"Egyedszám: {vizsgaltCella.Egyedszam} / {vizsgaltCella.Noveny.MaxSuruseg}");
				Console.WriteLine($"A föld nedvessége: {vizsgaltCella.Nedvesseg}% (igény: {vizsgaltCella.Noveny.Vizigeny}%)");
				Console.WriteLine($"Beteg-e a növény? {(vizsgaltCella.IsBeteg ? "Igen" : "Nem")}");
			}
			Console.WriteLine("");
		}
	}
}
