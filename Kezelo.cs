using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	enum Szerepkor
	{
		ADMIN, KERTESZ, GONDNOK, PERMETEZO
	}
	internal class Kezelo
	{
		private Szerepkor szerep;

		public Kezelo(Szerepkor szerep)
		{
			this.szerep = szerep;
		}
		internal Szerepkor Szerep { get => szerep; set => szerep = value; }

		public override string ToString()
		{
			return szerep.ToString();
		}
	}
}
