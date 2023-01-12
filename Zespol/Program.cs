// See https://aka.ms/new-console-template for more information
using Zespol;

namespace Zespol
{
    class Program
    {
        static void TestZespolu()
        {
            KierownikZespolu kierownik = new("Karol", "Polak", "23-01-1997", "98453423456", EnumPlec.M, 8, 789453011);
            CzlonekZespolu cz1 = new("Beata", "Nowak", "12-04-2001", "45345678921", EnumPlec.K, new DateTime(2022, 10, 23), "lider");
            CzlonekZespolu cz2 = new("Joanna", "Albinos", "09-11-2001", "88834567892", EnumPlec.K, new DateTime(2022, 10, 9), "tester");
            Zespol zespol = new("GrupaIT", kierownik);
            zespol.DodajCzlonka(cz1);
            zespol.DodajCzlonka(cz2);
            zespol.DodajCzlonka(new CzlonekZespolu("Tomasz", "Majewski", "10-01-1990", "34928374632", EnumPlec.M, new DateTime(2021, 1, 10), "programista"));
            zespol.DodajCzlonka(new CzlonekZespolu("Karol", "Piela", "15-12-1999", "99121598765", EnumPlec.M, new DateTime(2020, 4, 30), "programista"));
            Console.WriteLine(zespol);
            #region Testy1
            Console.WriteLine($"Po sortowaniu (Nazwisko, imie) {new string('-', 50)}");
            zespol.SortujNazwiskoImie(); // sortowanie czlonkow zespolu wg nazwiska i imienia
            Console.WriteLine(zespol);
            Console.WriteLine($"Po sortowaniu (Pesel) {new string('-', 50)}");
            zespol.SortujPesel();
            Console.WriteLine(zespol);
            Console.WriteLine($"Po sortowaniu (Data wstąpienia) {new string('-', 50)}");
            zespol.SortujDataWstapienia();
            Console.WriteLine(zespol);
            Console.WriteLine($"Kopia {new string('-', 50)}");
            Zespol? zkopia = zespol.Clone() as Zespol;
            if (zkopia is not null)
            {
                Console.WriteLine(zkopia);
            }
            #endregion

            string fname = "zespol.xml";
            zespol.ZapiszDC(fname);
            Zespol zespolodczyt = Zespol.OdczytDC(fname);
            Console.WriteLine("Po odczycie:");
            Console.WriteLine(zespolodczyt);
        }
        static void Main()
        {
            TestZespolu();
        }
    }
}