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
		public int x;
		public int y;
		public NovenyFaj noveny;
		public int egyedszam;

		public Cella(int x, int y)
		{
			this.x = x;
			this.y = y;
			this.noveny = null;
			this.egyedszam = 0;
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
		}
	}
}
