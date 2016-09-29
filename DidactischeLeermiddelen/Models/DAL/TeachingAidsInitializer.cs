using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DidactischeLeermiddelen.Models.DAL
{
    public class TeachingAidsInitializer : DropCreateDatabaseAlways<TeachingAidsContext>
    {
    
        protected override void Seed(TeachingAidsContext context)
        {
            // Make companies
            Company SplitsboomSpecialist = new Company() { Name = "SplisboomSpecialist", Email = "bedrijfje@gmail.com", Website = "bedrijfje.com", ContactPerson = "Jan Paternoster" };
            Company company2 = new Company() { Name = "Ikea", Email = "anderbedrijfje@gmail.com", Website = "anderbedrijfje.com", ContactPerson = "Pol Paternoster" };
            var companys = new List<Company>
            {SplitsboomSpecialist,company2


            };     foreach (Company company in companys)
                context.Companies.Add(company);

            context.SaveChanges();

            //Make curriculars
            Curricular Aardrijkskunde = new Curricular() { Name = "Aardrijkskunde" };
            Curricular Geschiedenis = new Curricular() { Name = "Geschiedenis" };
            Curricular Biologie = new Curricular() { Name = "Biologie" };
            Curricular Rekenen = new Curricular() { Name = "Rekenen" };

            var curriculars = new List<Curricular> {
            Aardrijkskunde,Geschiedenis,Rekenen,Biologie};

            foreach (Curricular c in curriculars) { context.Curriculars.Add(c); }
            context.SaveChanges();
            //Make Target audience

            TargetAudience lagerOnderwijs = new TargetAudience() { Name = "LagerOnderwijs" };
            TargetAudience kleuter = new TargetAudience() { Name = "KleuterOnderwijs" };
            TargetAudience middelbaar = new TargetAudience() { Name = "MiddelbaarOnderwijs" };

            var targetaudiences = new List<TargetAudience> {
                lagerOnderwijs,kleuter,middelbaar
            };

            foreach (TargetAudience t in targetaudiences) { context.TargetAudiences.Add(t); }
            context.SaveChanges();
            // Make materials
          
            Material wereldbol = new Material() {ImagePath="~/Images/wereldbol.jpg",Name="Wereldbol",Description="Wereldbol", Price=10,TotalAmount=5,Broken=0, Lendable = true, Location = "GLEDE 1.011" };
        
            Material dobbelsteen1 =new Material() { ImagePath = "~/Images/Material1.jpg", Name = "dobbelsteen-schatkist-162delig", Description = "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers,...", ItemNumber = "MH1447", Price = 35, TotalAmount = 1, Broken = 0, Lendable = true, Location = "GLEDE 1.011"  };
            Material Blanco_draaischijf =new Material() { ImagePath= "~/Images/draaischijf.jpg", Name = "Blanco draaischijf", Description = "met verschillende blanco schijven in hard papier", ItemNumber = "EL5955", Price = 31.45, TotalAmount = 1, Broken = 0, Lendable = true, Location = "GLEDE 1.011" };
          Material Splitsbomen =new Material() { ImagePath = "~/Images/splitsboom.jpg", Name = "Splitsbomen", Description = "aan de hand van rode bolletjes kunnen getallen tot 1, in de stam van de boom gesplitst worden in 2 getallen (kaartjes) of in 2x aantal bolletjes (boom)", ItemNumber = "RK2367", Price = 2.9, TotalAmount = 5, Broken = 0, Lendable = false, Location = "GLEDE 1.011" };
            Material Splitsboom_opdrachtkaart = new Material() { ImagePath = "~/Images/splitsboomopdrachtkaart.jpg", Name = "Splitsbomen -opdrachtkaarten", Description = "", ItemNumber = "FH5102", TotalAmount = 5, Price = 8.9, Broken = 0, Lendable = false, Location = "GLEDE 1.011 " };
            Material Mini_loco_spelbord =new Material(){ImagePath= "~/Images/minilocospelbord.jpg", Name="Mini -loco-spelbord 4 tot 8 jaar",Description="spelbord: klapt open met een rode becijferde kant en een doorzichtige kant +12 blokjes met de getallen van 1 tot en met 12", ItemNumber ="NC2038",Price=15.9,TotalAmount=6, Broken=1,Lendable=false,Location= "GLEDE 1.011"};
            Material Rekenspelletjes_optel_aftrek =new Material() {ImagePath= "~/Images/rekenspelletjes.jpg" , Name="Rekenspelletjes-optellen en aftrekken", Description="spelbord op het opdrachtenboekje leggen > opdracht oplossen door het juiste cijfers van het spelbord op het juiste antwoord in het bokej e te leggen > controle door het spelbord dicht te klappen en om te draaien > de patronen moeten overeenkomen", ItemNumber ="MX2035410", Price=10.9, TotalAmount=1,Broken=0, Lendable=true,Location= "GLEDE 1.011" };
  IList<Material> materials = new List<Material> {
                dobbelsteen1,Blanco_draaischijf,Splitsbomen,Splitsboom_opdrachtkaart,Mini_loco_spelbord,Rekenspelletjes_optel_aftrek,wereldbol
            };

            //Target audience toevoegen aan materialen
            lagerOnderwijs.AddMaterial(dobbelsteen1);
            lagerOnderwijs.AddMaterial(Blanco_draaischijf);
            lagerOnderwijs.AddMaterial(Splitsbomen);
            lagerOnderwijs.AddMaterial(Splitsboom_opdrachtkaart);
            lagerOnderwijs.AddMaterial(wereldbol);
            kleuter.AddMaterial(dobbelsteen1);
            kleuter.AddMaterial(Mini_loco_spelbord);
            lagerOnderwijs.AddMaterial(Rekenspelletjes_optel_aftrek);
            middelbaar.AddMaterial(wereldbol);

            //Curriculars toevoegen aan materialen
            Rekenen.addMaterial(dobbelsteen1);
            Rekenen.addMaterial(Blanco_draaischijf);
            Rekenen.addMaterial(Splitsbomen);
            Rekenen.addMaterial(Splitsboom_opdrachtkaart);
            Rekenen.addMaterial(Mini_loco_spelbord);
            Rekenen.addMaterial(Rekenspelletjes_optel_aftrek);
            Aardrijkskunde.addMaterial(wereldbol);
            Geschiedenis.addMaterial(wereldbol);

            //Materialen toekennen aan bedrijven

            SplitsboomSpecialist.AddMaterial(dobbelsteen1);
            SplitsboomSpecialist.AddMaterial(Splitsbomen);
            SplitsboomSpecialist.AddMaterial(Splitsboom_opdrachtkaart);
            company2.AddMaterial(Blanco_draaischijf);
            company2.AddMaterial(Mini_loco_spelbord);
            company2.AddMaterial(Rekenspelletjes_optel_aftrek);
            company2.AddMaterial(wereldbol);

            foreach (Material material in materials)
                context.Materials.Add(material);
            
            context.SaveChanges();

            // Make users
            IList<User> users = new List<User>();

           // users.Add(new User() { Name = "Axel Desmedt", Username = "axel", Password = "wachtwoord" });

            foreach(User user in users)
                context.Users.Add(user);

            context.SaveChanges();
        }
    }
}