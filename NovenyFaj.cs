using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	enum NovenyFajtak
	{
		Rozsa, Paradicsom, Krumpli, Cukkini, Paprika, Mak
	}
	internal class NovenyFaj
	{

		private NovenyFajtak fajta;
		private int maxSuruseg;
		private int vizigeny;
		public NovenyFaj(NovenyFajtak valasztottFajta)
		{
			this.fajta = valasztottFajta;
			switch (valasztottFajta){
				case NovenyFajtak.Rozsa:
					this.maxSuruseg = 4;
					this.vizigeny = 60;
					break;
				case NovenyFajtak.Paradicsom:
					this.maxSuruseg = 6;
					this.vizigeny = 80;
					break;
				case NovenyFajtak.Krumpli:
					this.maxSuruseg = 8;
					this.vizigeny = 40;
					break;
				case NovenyFajtak.Cukkini:
					this.maxSuruseg = 3;
					this.vizigeny = 70;
					break;
				case NovenyFajtak.Paprika:
					this.maxSuruseg = 5;
					this.vizigeny = 65;
					break;
				case NovenyFajtak.Mak:
					this.maxSuruseg = 10;
					this.vizigeny = 30;
					break;
			}
		}

		public int MaxSuruseg { get => maxSuruseg; set => maxSuruseg = value; }
		public int Vizigeny { get => vizigeny; set => vizigeny = value; }
		public NovenyFajtak Fajta { get => fajta; set => fajta = value; }
		public string Azonosito => Fajta.ToString().Substring(0, 3).ToUpper();
	}
}
