using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DidactischeLeermiddelen.Models.domain;

namespace DidactischeLeermiddelen.Tests.Models
{
    [TestClass]
    public class ReservedMaterialTest
    {
        private DummyContext dummyContext= new DummyContext();
        Material materiaal;
        User user;

        [TestInitialize]
        public void ReservedMaterialInitialize()
        {
            materiaal = dummyContext.Splitsboom;
            user = dummyContext.Student;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AantalGereserveerdKanNietNegatiefZijn()
        {
            ReservedMaterial res = new ReservedMaterial()
            {
                Material = materiaal,
                AmountReserved = -1,
                StartDate = DateTime.Today,
                User = user
            };
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AantalGereserveerdKanNietNulZijn()
        {
            ReservedMaterial res = new ReservedMaterial()
            {
                Material = materiaal,
                AmountReserved = 0,
                StartDate = DateTime.Today,
                User = user
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UserKanNietNullZijn()
        {
            ReservedMaterial res = new ReservedMaterial()
            {
                Material = materiaal,
                AmountReserved = 1,
                StartDate = DateTime.Today,
                User = null
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MateriaalKanNietNullZijn()
        {
            ReservedMaterial res = new ReservedMaterial()
            {
                Material = null,
                AmountReserved = 1,
                StartDate = DateTime.Today,
                User = user
            };
        }


    }
}
