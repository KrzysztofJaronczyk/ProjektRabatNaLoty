using System;
using System.Threading;

namespace Projekt_Szkolny
{
    class Program
    {
        static void Main(string[] args)
        {
            var rabat = 0;
            var now = DateTime.Now;
            var dana = now.ToString("dd/MM/yyyy");
            Console.WriteLine($"Witaj w linii lotniczej XYZ! Mamy dzisiaj {dana}\nW celu zakupu biletu krajowego kliknij 1 " +
                "\nW celu zakupu biletu międzynarodowego kliknij 2 \nWybierz proszę opcję: ");

            int wybor1 = int.Parse(Console.ReadLine());
            switch (wybor1)
            {
                case 1:
                    Console.Write("Wybrałeś bilet krajowy.\nPodaj teraz datę urodzenia pasażera (dzień miesiąc rok): ");
                    break;
                case 2:
                    Console.Write("Wybrałeś bilet międzynarodowy.\nPodaj teraz datę urodzenia pasażera (dzień miesiąc rok): ");
                    break;
                default:
                    Console.WriteLine("Wprowadzono niewłaściwą wartość!");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

            var dataurodzenia = Console.ReadLine();

            DateTime du;

            var isValidDate = DateTime.TryParse(dataurodzenia, out du);

            if (!isValidDate || du > DateTime.Now)
            {
                Console.WriteLine($"{dataurodzenia} wprowadzono niepoprawną datę!");
                Environment.Exit(0);
            }

            TimeSpan interval = DateTime.Now - du;
            var ResultDays = interval.TotalDays;
            //Console.WriteLine($"No of Days: {ResultDays}"); //test sprawdzenia dat
            if (ResultDays < 730)// 2 lata
            {
                rabat += 70;
                if (wybor1 == 1)
                    rabat += 10;
            }

            else if (ResultDays >= 730 && ResultDays < 5844)//16 lat i 4 dni
            {
                rabat += 10;
            }

            Console.WriteLine("Aktualny rabat {0}%", rabat);

            Console.Write("Kiedy ma się odbyć podróż? (dzień miesiąc rok): ");

            var datapodrozy = Console.ReadLine();

            DateTime dp;

            var isValidDate2 = DateTime.TryParse(datapodrozy, out dp);

            if (!isValidDate || DateTime.Now > dp)
            {
                Console.WriteLine($"{datapodrozy} wprowadzono niepoprawną datę!");

                Environment.Exit(0);
            }
            #region rabat rezerwacji

            var rok = dp.Year;
            var x = dp.Month;
            var y = dp.Day;
            if (x > 5)
                x = x - 5;
            else if (x == 5)
            {
                rok--;
                x = 12;
            }
            else if (x == 4)
            {
                rok--;
                x = 11;
            }
            else if (x == 3) // rabat wcześniejsza rezerwacja biletu 
            {
                rok--;
                x = 10;
            }
            else if (x == 2)
            {
                rok--;
                x = 9;
            }
            else if (x == 1)
            {
                rok--;
                x = 8;
            }
            DateTime rezerwacja = new DateTime(rok, x, y);//5 miesięcy albo więcej

            if (rezerwacja > DateTime.Now)
            {
                Console.WriteLine("Przyznano rabat wcześniejszej rezerwacji biletu.");
                rabat += 10;
                Console.WriteLine("Aktualny rabat {0}%", rabat);
            }
            #endregion rabat rezerwacji


            #region rabat sezon
            DateTime[] styczen = new DateTime[31];

            DateTime jeden = new DateTime(rok, 01, 01);
            for (int i = 0; i < styczen.Length; i++)
            {
                DateTime newDate2 = jeden.AddDays(i);
                styczen[i] = newDate2;
            }

            //DateTime[] luty = new DateTime[28];


            //if (((rok % 4 == 0) && (rok % 100 != 0)) || (rok % 400 == 0))
            //    luty = new DateTime[29];

            //DateTime dwa = new DateTime(rok, 02, 01);
            //for (int i = 0; i < luty.Length; i++)
            //{
            //    DateTime newDate2 = dwa.AddDays(i);
            //    luty[i] = newDate2;
            //}

            DateTime[] marzec = new DateTime[31];
            DateTime trzy = new DateTime(rok, 03, 01);
            for (int i = 0; i < marzec.Length; i++)
            {
                DateTime newDate2 = trzy.AddDays(i);
                marzec[i] = newDate2;
            }
            DateTime[] kwiecien = new DateTime[30];
            DateTime cztery = new DateTime(rok, 04, 01);
            for (int i = 0; i < kwiecien.Length; i++)
            {
                DateTime newDate2 = cztery.AddDays(i);
                kwiecien[i] = newDate2;
            }
            //DateTime[] maj = new DateTime[31];
            //DateTime piec = new DateTime(rok, 05, 01);
            //for (int i = 0; i < maj.Length; i++)
            //{
            //    DateTime newDate2 = piec.AddDays(i);
            //    maj[i] = newDate2;
            //}
            //DateTime[] czerwiec = new DateTime[30];
            //DateTime szesc = new DateTime(rok, 06, 01);
            //for (int i = 0; i < czerwiec.Length; i++)
            //{
            //    DateTime newDate2 = szesc.AddDays(i);
            //    czerwiec[i] = newDate2;
            //}
            DateTime[] lipiec = new DateTime[31];
            DateTime siedem = new DateTime(rok, 07, 01);
            for (int i = 0; i < lipiec.Length; i++)
            {
                DateTime newDate2 = siedem.AddDays(i);
                lipiec[i] = newDate2;
            }
            DateTime[] sierpien = new DateTime[31];
            DateTime osiem = new DateTime(rok, 08, 01);
            for (int i = 0; i < sierpien.Length; i++)
            {
                DateTime newDate2 = osiem.AddDays(i);
                sierpien[i] = newDate2;
            }
            //DateTime[] wrzesien = new DateTime[30];
            //DateTime dziewiec = new DateTime(rok, 09, 01);
            //for (int i = 0; i < wrzesien.Length; i++)
            //{
            //    DateTime newDate2 = dziewiec.AddDays(i);
            //    wrzesien[i] = newDate2;
            //}
            //DateTime[] pazdziernik = new DateTime[31];
            //DateTime dziesiec = new DateTime(rok, 10, 01);
            //for (int i = 0; i < pazdziernik.Length; i++)
            //{
            //    DateTime newDate2 = dziesiec.AddDays(i);
            //    pazdziernik[i] = newDate2;
            //}
            //DateTime[] listopad = new DateTime[30];
            //DateTime jedenascie = new DateTime(rok, 11, 01);
            //for (int i = 0; i < listopad.Length; i++)
            //{
            //    DateTime newDate2 = jedenascie.AddDays(i);
            //    listopad[i] = newDate2;
            //}
            DateTime[] grudzien = new DateTime[31];
            DateTime dwanascie = new DateTime(rok, 12, 01);
            for (int i = 0; i < grudzien.Length; i++)
            {
                DateTime newDate2 = dwanascie.AddDays(i);
                grudzien[i] = newDate2;
            }
            //gorący sezon cały
            DateTime[] kompletnysezon = new DateTime[106];

            Array.Copy(grudzien, 19, kompletnysezon, 0, 12);
            Array.Copy(styczen, 0, kompletnysezon, 12, 10);
            Array.Copy(marzec, 19, kompletnysezon, 22, 12);
            Array.Copy(kwiecien, 0, kompletnysezon, 34, 10);
            Array.Copy(lipiec, 0, kompletnysezon, 44, 31);
            Array.Copy(sierpien, 0, kompletnysezon, 75, 31);

            if (Array.IndexOf(kompletnysezon, dp) == -1)
                rabat += 10;//jeśli nie znajdzie przyznaj rabat
            Console.WriteLine("Przyznano rabat za podróżowanie poza sezonem.\nAktualny rabat {0}%", rabat);
            #endregion rabat sezon


            Console.WriteLine("Czy osoba jest stałym klientem?\nKliknij 1 jeżeli tak.\nKliknij 2 jeżeli nie.");
            int wybor2 = int.Parse(Console.ReadLine());
            switch (wybor2)
            {
                case 1:
                    Console.WriteLine("Trwa sprawdzanie kliena w bazie danych...");
                    Thread.Sleep(2000); //dodatek urozmaicający
                    if (wybor2 == 1 && ResultDays >= 6575)//18 lat
                    {
                        rabat += 15;
                        Console.WriteLine("Pomyślnie aktywowano zniżkę stałego klienta!\nTrwa obliczanie wszystkich zniżek...");
                        Console.WriteLine("Aktualny rabat {0}%", rabat);
                    }
                    else
                        Console.WriteLine("Niestety, osoba nie ma ukończonych 18 lat. Zniżka nie została aktywowana.\nTrwa obliczanie wszystkich zniżek...");
                    break;
                case 2:
                    Console.WriteLine("Trwa obliczanie wszystkich zniżek...");
                    break;
                default:
                    Console.WriteLine("Wprowadzono niewłaściwa wartość!");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

            if (rabat > 80 && ResultDays < 730)// korekta rabatów
                rabat = 80;

            if (rabat > 30 && ResultDays > 730)
                rabat = 30;

            Thread.Sleep(3000); //dodatek urozmaicający
            Console.WriteLine($"Przyznano łączny rabat wysokości: {rabat}%");

            Console.ReadKey();
        }
    }
}