using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	enum Szerepkor
	{
		TRECHNIKUS, ADMIN, KERTESZ
	}
	internal class Kezelo
	{
		private string nev;
		private string azonosito;
		private Szerepkor szerep;

		public Kezelo(string nev, string azonosito, Szerepkor szerep)
		{
			this.nev = nev;
			this.azonosito = this.nev.Substring(0, 3);
			this.szerep = szerep;
		}

		public string Nev { get => nev; set => nev = value; }
		public string Azonosito { get => azonosito;}
		internal Szerepkor Szerep { get => szerep; set => szerep = value; }

		public override string ToString()
		{
			return $"{this.nev} ({this.azonosito}) {this.szerep}";
		}
	}
}
