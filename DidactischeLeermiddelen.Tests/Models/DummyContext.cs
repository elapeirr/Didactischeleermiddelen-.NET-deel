using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidactischeLeermiddelen.Tests.Models
{
    class DummyContext
    {
        private Company bedrijfje;
        private Company anderBedrijf;
        private Curricular Rekenen;
        private TargetAudience lagerOnderwijs;
        private IList<Material> materialen;
        string foto = "";
        string naam = "naam";
        string omschrijving = "blabla";
        string artikelNummer = "123";
        double prijs = 25;
        int aantal = 2;
        bool uitleenbaar = true;
        string plaats = "plaats";


        public DummyContext()
        {
            materialen = new List<Material>();
          
            Rekenen = new Curricular();
            lagerOnderwijs = new TargetAudience();

            bedrijfje = new Company() { Name = "Bedrijfje", Email = "bedrijfje@gmail.com", Website = "bedrijfje.com", ContactPerson = "Jan Paternoster" };
            anderBedrijf = new Company() { Name = "anderBedrijf", Email = "anderbedrijfje@gmail.com", Website = "anderbedrijfje.com", ContactPerson = "Pol Paternoster" };

            var companys = new List<Company>
            {bedrijfje,anderBedrijf


            };


            materialen.Add(new Material() { ImagePath = foto, Name = "Splitsboom", Description = omschrijving, ItemNumber = artikelNummer, Price = prijs, TotalAmount = aantal, Lendable = uitleenbaar, Location = plaats });
            materialen.Add(new Material() { ImagePath = null, Name = "Splitsbomen-opdrachtkaarten", Description = "", Company = Companies.First(), ItemNumber = "FH5102", TotalAmount = 5, Price = 8.9, Broken = 4, Lendable = false, Location = "GLEDE 1.011 " });
            materialen.Add(new Material() { ImagePath = null, Name = "Mini-loco-spelbord 4 tot 8 jaar", Description = "spelbord: klapt open met een rode becijferde kant en een doorzichtige kant +12 blokjes met de getallen van 1 tot en met 12", Company = companys.First(), ItemNumber = "NC2038", Price = 15.9, TotalAmount = 6, Broken = 5, Lendable = false, Location = "GLEDE 1.011" });
            materialen.Add(new Material() { ImagePath = null, Name = "Rekenspelletjes-optellen en aftrekken", Description = "spelbord op het opdrachtenboekje leggen > opdracht oplossen door het juiste cijfers van het spelbord op het juiste antwoord in het bokej e te leggen > controle door het spelbord dicht te klappen en om te draaien > de patronen moeten overeenkomen", Company = companys.First(), ItemNumber = "MX2035410", Price = 10.9, TotalAmount = 1, Broken = 1, Lendable = true, Location = "GLEDE 1.011" });

        }
        public IQueryable<Company> Companies {
            get {
                return new List<Company> {
                    bedrijfje,anderBedrijf
                }.AsQueryable();
            }


        }
        public IQueryable<Material> Materials { get { return materialen.AsQueryable(); } }
        public Material Splitsboom
        {
            get { return materialen.Where(m => m.Name == "Splitsboom").FirstOrDefault(); }
        }

        public Student Student
        {
            get {
                //List<Material> wishlist= new List<Material>();
                return new Student { FirstName = "Elise", LastName = "Lapeirre", Email = "elise.lapeirre.s3756@student.hogent.be", Faculty = "Schoonmeersen", Picture = "" };
            }

        }

        public Lector Lector
        {
            get
            {
                return new Lector { FirstName = "Karine", LastName = "Samyn", Email = "karine.samyn@hogent.be", Faculty = "Schoonmeersen", Picture = "" };
            }
        }
    }
}
