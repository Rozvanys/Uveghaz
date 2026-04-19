using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Uveghaz
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Ajda meg hogy mekkora legyen a rács:");
			//int nagysag = int.Parse(Console.ReadLine());
			int nagysag;
			while (!int.TryParse(Console.ReadLine(), out nagysag) || nagysag <= 0)
			{
				Console.WriteLine("Kérem adjon meg egy pozitív egész számot a rács méretének:");
			}
			UveghazRacs racs = new UveghazRacs(nagysag);
			Idojaras idojarasMotor = new Idojaras();
			int napokSzama = 1;

			while (true)
			{
				Console.WriteLine($"\n ====================== {napokSzama}. nap =========================");

				IdojarasTipusok maiIdojaras = idojarasMotor.SorsolIdojaras();
				idojarasMotor.IdojarasKiir(maiIdojaras);

				if (maiIdojaras == IdojarasTipusok.Katasztrofa)
				{
					for (int i = 0; i < racs.meret; i++)
					{
						for (int j = 0; j < racs.meret; j++)
						{
							racs.CellaLekerdez(i, j).Urit();
						}
					}
				}
					Console.WriteLine("Kérem adja meg melyik szerepkört szeretné használni \n1. Admin: Mindent tud csinálni az ültetvényeken \n2. Kertész: ültetni, kiszedni és locsolni tud a földeken \n3. Gondnok: csak lechekkolni tudja a növényeket és locsolniu tud \n4. Permetező: a gondnok feladatkörén felül permetezni is tud.");
					int szerepkor;
					int.TryParse(Console.ReadLine(), out szerepkor);
					Kezelo aktualKezelo = new Kezelo((Szerepkor)(szerepkor - 1));

					bool napVege = false;
					while (!napVege)
					{
						Console.WriteLine($"\n---- Menü (Szerepkör: {aktualKezelo.Szerep}) ----");
						Console.WriteLine("Adja meg az elvégezni kívánt feladatot:\n 1 ültetés \n2 kiszedés \n3 teljes nullázás \n4 lekérdezés kordináta alapján \n5 általános lekérdezés \n6 locsolás \n7 permetezés \n8 hazamenetel (következő nap)");
						Console.WriteLine("Válasszon opciót: ");
						int opcio;
						int.TryParse(Console.ReadLine(), out opcio);

						switch (opcio)
						{
							case 1:
								if (aktualKezelo.Szerep == Szerepkor.ADMIN || aktualKezelo.Szerep == Szerepkor.KERTESZ)
								{
									Console.WriteLine("Növény(0:Rozsa, 1:Paradicsom, 2:Krumpli, 3:Cukkini, 4:Paprika, 5:Mak): ");
									int n = int.Parse(Console.ReadLine());
									Console.WriteLine("Mennyiség: ");
									int m = int.Parse(Console.ReadLine());
									Console.WriteLine("Sor (x): ");
									int x = int.Parse(Console.ReadLine());
									Console.WriteLine("oszlop (y): ");
									int y = int.Parse(Console.ReadLine());
									racs.Telepit(x, y, new NovenyFaj((NovenyFajtak)n), m);
								}
								else
								{
									Console.WriteLine("Nincs jogosultsága ehhez a művelethez.");
								}
								break;
							case 2:
								if (aktualKezelo.Szerep == Szerepkor.ADMIN || aktualKezelo.Szerep == Szerepkor.KERTESZ)
								{
									Console.WriteLine("Sor (x): ");
									int x = int.Parse(Console.ReadLine());
									Console.WriteLine("Oszlop (y): ");
									int y = int.Parse(Console.ReadLine());
									racs.CellaLekerdez(x, y).Urit();
									Console.WriteLine("Cella kiürítve.");
								}
								else
								{
									Console.WriteLine("Nincs jogosultsága ehhez a művelethez.");
								}
								break;
							case 3:
								if (aktualKezelo.Szerep == Szerepkor.ADMIN)
								{
									for (int i = 0; i < racs.meret; i++)
									{
										for (int j = 0; j < racs.meret; j++)
										{
											racs.CellaLekerdez(i, j).Urit();
										}
									}
									Console.WriteLine("Az összes cella kiürítve.");

								}
								else
								{
									Console.WriteLine("Nincs jogosultsága ehhez a művelethez.");
								}
								break;
							case 4:
								Console.WriteLine("Sor (x): ");
								int lx = int.Parse(Console.ReadLine());
								Console.WriteLine("Oszlop (y): ");
								int ly = int.Parse(Console.ReadLine());
								racs.ParcellaInfo(lx, ly);
								break;
							case 5:
								racs.TerepKiir();
								break;
							case 6:
								if (aktualKezelo.Szerep != Szerepkor.PERMETEZO)
								{
									Console.WriteLine("Sor (x) vagy a rács méretének kétszerese a teljes növényzeet locsolázásához: ");
									int wx = int.Parse(Console.ReadLine());
									Console.WriteLine("Oszlop (y) vagy a rács méretének kétszerese a teljes növényzeet locsolázásához: ");
									int wy = int.Parse(Console.ReadLine());
									if (wx == nagysag * 2 || wy == nagysag * 2)
									{
										for (int i = 0; i < racs.meret; i++)
										{
											for (int j = 0; j < racs.meret; j++)
											{
												racs.CellaLekerdez(i, j).Locsol();
											}
										}
										Console.WriteLine("Az összes növény locsolva.");
									}
									else
									{
										racs.CellaLekerdez(wx, wy).Locsol();
										Console.WriteLine("A cella meglocsolva!");
									}
								}
								else
								{
									Console.WriteLine("Nincs jogosultsága ehhez a művelethez.");
								}
								break;
							case 7:
								if (aktualKezelo.Szerep == Szerepkor.ADMIN || aktualKezelo.Szerep == Szerepkor.PERMETEZO)
								{
									Console.WriteLine("Sor (x): ");
									int x = int.Parse(Console.ReadLine());
									Console.WriteLine("Oszlop (y): ");
									int y = int.Parse(Console.ReadLine());
									racs.CellaLekerdez(x, y).Permetez();
									Console.WriteLine("A növényt meggyógyítottad");
								}
								else
								{
									Console.WriteLine("Nincs jogosultsága ehhez a művelethez.");
								}
								break;
							case 8:
								napVege = true;
								break;
							default:
								Console.WriteLine("Érvénytelen opció, kérem válasszon a megadott lehetőségek közül.");
								break;
						}
					}
					for (int i = 0; i < racs.meret; i++)
					{
						for (int j = 0; j < racs.meret; j++)
						{
							Cella c = racs.CellaLekerdez(i, j);
							if (maiIdojaras == IdojarasTipusok.Meleg)
							{
								c.BeallitNedvesseg(-20);
							}
							else if (maiIdojaras == IdojarasTipusok.Esos)
							{
								c.BeallitNedvesseg(20);
							}
							else if (maiIdojaras == IdojarasTipusok.Atlagos)
							{
								c.BeallitNedvesseg(-10);
							}
						if (!c.Ures() && !c.IsBeteg)
						{
							int betegsegEsely = 5;
							if (c.Nedvesseg < c.Noveny.Vizigeny - 20)
							{
								betegsegEsely += 30;
							}
							else if (c.Nedvesseg == 100 && c.Noveny.Vizigeny < 50)
							{
								betegsegEsely += 20;
							}
							if (c.Egyedszam > c.Noveny.MaxSuruseg)
							{
								betegsegEsely += 40;
							}
							int sorsolas = new Random().Next(1, 101);
							if (sorsolas <= betegsegEsely)
							{
								c.BetegsegetKap();
							}
						}
					}
					}
				
				napokSzama++;
				Console.WriteLine("\nA nap vége, a növények állapotának frissítése...\nA tövábbhaladáshoz nyomjon meg egy entert!");
				Console.ReadLine();
			}
			
			
		}
	}
}
