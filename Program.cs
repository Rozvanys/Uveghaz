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
			Console.WriteLine("Ajda meg hogy mekkora legyen a rács:");
			int nagysag = int.Parse(Console.ReadLine());
			UveghazRacs racs = new UveghazRacs(nagysag);
			Console.WriteLine("Kérem adja meg melyik szerepkört szeretné használni \n1. Admin: Mindent tud csinálni az ültetvényeken \n2. Kertész: ültetni, kiszedni és locsolni tud a földeken \n3. Gondnok: csak lechekkolni tudja a növényeket és locsolniu tud \n4. Permetező: a gondnok feladatkörén felül permetezni is tud.");
			int szerepkor = int.Parse(Console.ReadLine());
			
			if (szerepkor == 1) {
				Console.WriteLine("Adja meg az elvégezni kívánt feladatot 1 ültetés \n2 kiszedés \n3 teljes nullázás \n4 lekérdezés kordináta alapján \n5 általános lekérdezés \n6 locsolás \n7 permetezés \n8 hazamenetel (következő nap) \n9 Szerep váltás");
			}
			else if (szerepkor == 2) {
				Console.WriteLine("Adja meg az elvégezni kívánt feladatot 1 ültetés \n2 kiszedés \n3 teljes nullázás \n4 lekérdezés kordináta alapján \n5 általános lekérdezés \n6 locsolás \n8 hazamenetel (következő nap) \n9 Szerep váltás");
			}
			else if (szerepkor == 4)
			{
				Console.WriteLine("Adja meg az elvégezni kívánt feladatot \n4 lekérdezés kordináta alapján \n5 általános lekérdezés \n6 locsolás \n7 permetezés \n8 hazamenetel (következő nap) \n9 Szerep váltás");
			}else
			{
				Console.WriteLine("Adja meg az elvégezni kívánt feladatot \n4 lekérdezés kordináta alapján \n5 általános lekérdezés \n7 locsolás \n8 hazamenetel (következő nap) \n9 Szerep váltás");
			}
			int feladat = int.Parse(Console.ReadLine());

			if (feladat == 1)
			{
				Console.WriteLine("Adja meg hogy milyen növényt szeretne ültetni: ");
				string novenyNev = Console.ReadLine();
				Console.WriteLine("Adja meg hogy hányat szeretne ültetni: ");
				int novenyMeny = int.Parse(Console.ReadLine());
				Console.WriteLine("Adja meg hogy melyik oszlopba szeretné helyezni a növényt: ");
				int novenyY = int.Parse(Console.ReadLine());
				Console.WriteLine("Adja meg hogy melyik Sorba szeretné helyezni a növényt: ");
				int novenyX = int.Parse(Console.ReadLine());
				
				NovenyFaj valasztottNoveny = new NovenyFaj(novenyNev, 8, false, 0);
				racs.Telepit(novenyX, novenyY, valasztottNoveny, 5);
				racs.TerepKiir();
			}
			if (feladat == 5) {
				racs.TerepKiir();
			}
		}
	}
}
