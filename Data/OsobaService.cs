using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prezenty.Data
{
    public class OsobaService
    {
        private static List<Osoba> Osoby = new List<Osoba>();

        public OsobaService()
        {
            Osoby.Add(new Osoba() { 
                Imie ="Daniel",
                Nazwisko ="Kasprzyk",
                Wiek = 24,
                Zaslozyl = false
            });

            Osoby.Add(new Osoba()
            {
                Imie = "Elvior",
                Nazwisko = "RavenClan",
                Wiek = 25,
                Zaslozyl = false
            });

            Osoby.Add(new Osoba()
            {
                Imie = "Jhon",
                Nazwisko = "Snow",
                Wiek = 20,
                Zaslozyl = true
            });
        }

        public static Task<List<Osoba>> PobierzLsteOsobAsync()
        {
            return Task.FromResult(Osoby);
        }

        public static void WylosujOsobAsync()
        {
            Osoba wylosowanaOsoba;

            List<Osoba> pozostałeOsobyDoWylosowania = Osoby.GetRange(0, Osoby.Count);

            if (Osoby.Count == 2)
            {
                Osoby[0].PrezentOd = Osoby[1].Nazwisko;
                Osoby[1].PrezentOd = Osoby[0].Nazwisko;
            }
            else if (Osoby.Count > 2)
            {
                foreach (Osoba osoba in Osoby)
                {
                    if (pozostałeOsobyDoWylosowania.Count > 0)
                    {
                        wylosowanaOsoba = Losuj(pozostałeOsobyDoWylosowania);
                        while (osoba.Nazwisko == wylosowanaOsoba.Nazwisko || wylosowanaOsoba.PrezentOd == osoba.Nazwisko)
                        {
                            wylosowanaOsoba = Losuj(pozostałeOsobyDoWylosowania);
                        }
                        pozostałeOsobyDoWylosowania.Remove(wylosowanaOsoba);
                        osoba.PrezentOd = wylosowanaOsoba.Nazwisko;
                    }
                    else
                    {
                        osoba.PrezentOd = "BRAK DOPASOWANIA";
                    }
                }
            }
            else
            {
                if (Osoby.Count == 1)
                {
                    Osoby[0].PrezentOd = "BRAK DOPASOWANIA";
                }
            }
        }

        private static Osoba Losuj(List<Osoba> randomFrom)
        {
            return randomFrom[new Random().Next(randomFrom.Count)];
        }

        public static void Dodaj(string newName, string newSurname, int age, bool good = true)
        {
            Osoby.Add(new Osoba()
            {
                Imie = newName,
                Nazwisko = newSurname,
                Wiek = age,
                Zaslozyl = good
            });
        }
    }
}
