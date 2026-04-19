using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	enum IdojarasTipusok
	{
		Meleg, Atlagos, Esos, Katasztrofa
	}

	internal class Idojaras
	{
		private Random random;
		public Idojaras(){
			random = new Random();
		}

		public IdojarasTipusok SorsolIdojaras()
		{
			int ertek = random.Next(0, 100);
			if (ertek < 50)
				return IdojarasTipusok.Meleg;
			else if (ertek < 80)
				return IdojarasTipusok.Atlagos;
			else if (ertek < 95)
				return IdojarasTipusok.Esos;
			else
				return IdojarasTipusok.Katasztrofa;
		}

		public void IdojarasKiir(IdojarasTipusok maiIdojaras){
			Console.WriteLine($"A mai időjárás: {maiIdojaras.ToString()}");

			if (maiIdojaras == IdojarasTipusok.Katasztrofa)
			{
				Console.WriteLine("Természeti katasztrófa történt! Az összes növény elpusztult.");
			}
		}
	}
}
