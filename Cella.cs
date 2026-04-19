using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	internal class Cella
	{
		private int x;
		private int y;
		private NovenyFaj noveny;
		private int egyedszam;
		private int nedvesseg;
		private bool isBeteg;

		public NovenyFaj Noveny { get => noveny; set => noveny = value; }
		public int Egyedszam { get => egyedszam; set => egyedszam = value; }
		public int Nedvesseg { get => nedvesseg; set => nedvesseg = value; }
		public bool IsBeteg { get => isBeteg; set => isBeteg = value; }

		public Cella(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.noveny = null;
			this.egyedszam = 0;
			this.nedvesseg = 50;
			this.isBeteg = false;
		}

		public bool Ures()
		{
			return noveny == null || egyedszam == 0;
		}

		public void Telepit(NovenyFaj faj, int mennyiseg)
		{
			noveny = faj;
			egyedszam += mennyiseg;
		}
		public void Csokkentes(int mennyiseg)
		{
			egyedszam -= mennyiseg;

			if (egyedszam <= 0)
			{
				Urit();
			}
		}
		public void Urit()
		{
			noveny = null;
			egyedszam = 0;
			isBeteg = false;
		}
		public void Locsol(){
			nedvesseg += 30;
			if (nedvesseg > 100) nedvesseg = 100;
		}
		public void Permetez(){
			isBeteg = false;
		}

		public void BeallitNedvesseg(int valtozas){
  			nedvesseg += valtozas;
			if (nedvesseg < 0) nedvesseg = 0;
			if (nedvesseg > 100) nedvesseg = 100;	
		}

		public void BetegsegetKap(){
			isBeteg = true;
		}
	}
}
