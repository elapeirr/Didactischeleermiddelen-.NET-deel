using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DidactischeLeermiddelen.Models.domain;

namespace DidactischeLeermiddelen.Tests.Models
{
    [TestClass]
    public class MateriaalTest
    {

        DummyContext dummyContext = new DummyContext();
        
        [TestMethod]
        public void NieuwMateriaal()
        {
            //Arrange
            string foto = "";
            string naam = "naam";
            string omschrijving = "";
            string artikelNummer = "";
            double prijs = 0.0;
            int aantal = 0;
            bool uitleenbaar = true;
            string plaats = "plaats";

            //Act
            Material materiaal = new Material() { ImagePath = foto, Name = naam, Description = omschrijving, ItemNumber = artikelNummer, Price = prijs, TotalAmount = aantal, Lendable = uitleenbaar, Location = plaats };

            //Assert
            Assert.AreEqual(0.0, materiaal.Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MateriaalNaamMagNietNullZijn()
        {
            Material materiaal = new Material() { ImagePath = "", Name = null, Description = "", ItemNumber = "", Price = 0.0, TotalAmount = 0, Lendable = true, Location = "plaats" };
        }



        
    }
}
