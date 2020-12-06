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
                Nazwiso ="Kasprzyk",
                Wiek = 24,
                PrezentOd = "Mikołaj",
                Zaslozyl = false
            });

            Osoby.Add(new Osoba()
            {
                Imie = "Elvior",
                Nazwiso = "RavenClan",
                Wiek = 25,
                PrezentOd = "Sigurd",
                Zaslozyl = false
            });

            Osoby.Add(new Osoba()
            {
                Imie = "Jhon",
                Nazwiso = "Snow",
                Wiek = 20,
                PrezentOd = "Daenerys",
                Zaslozyl = true
            });
        }

        public static Task<List<Osoba>> PobierzLsteOsobAsync()
        {
            return Task.FromResult(Osoby);
        }
    }
}
