using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DidactischeLeermiddelen.Models.domain;
using Moq;

namespace DidactischeLeermiddelen.Tests.Models
{
    [TestClass]
    public class UserTest
    {

        private readonly DummyContext dummyContext = new DummyContext();
        private User student, lector;
        private Material materiaalInWishlist, nieuwMateriaal;

        [TestInitialize]
        public void UserInitialize()
        {
            student = dummyContext.Student;
            lector = dummyContext.Lector;
            materiaalInWishlist = dummyContext.Splitsboom;
            student.AddToWishList(materiaalInWishlist);
            lector.AddToWishList(materiaalInWishlist);
            nieuwMateriaal = new Material(){ ImagePath = "~/Images/splitsboomopdrachtkaart.jpg", Name = "Splitsbomen -opdrachtkaarten", Description = "", ItemNumber = "FH5102", TotalAmount = 5, Price = 8.9, Broken = 0, Lendable = false, Location = "GLEDE 1.011 " }; 


        }


        [TestMethod]
        public void WhishlistBehoudtLengteAlsMateriaalWordtToegevoegdDatErAlInzit()
        {
            student.AddToWishList(materiaalInWishlist);
            Assert.AreEqual(student.Wishlist.Count, 1);
        }
        
        [TestMethod]
        public void WishListLengteWordtMetEenVerhoogdAlsAnderMateriaalWordtToegevoegd()
        {
            student.AddToWishList(nieuwMateriaal);
            Assert.AreEqual(student.Wishlist.Count, 2);
        }

        [TestMethod]
        public void ReserverenVanMateriaalDatNietInWishListWordtNietToegevoegd()
        {
            
            student.ReserveMaterial(nieuwMateriaal,1,DateTime.Today,DateTime.Today);
            Assert.AreEqual(student.Reservations.Count, 0);

        }

        [TestMethod]
        public void ReserverenVanMateriaalVoegtMateriaalToeAanReservations()
        {
           
            student.ReserveMaterial(materiaalInWishlist, 1, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1));
            Assert.AreEqual(student.Reservations.Count, 1);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AlsAantalBeschibareMaterialenWordtOverschredenGeefException()
        {
            student.ReserveMaterial(materiaalInWishlist, 6, DateTime.Today.AddDays(1), DateTime.Today.AddDays(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MateriaalKanNietInHetVerledenGereserveerdWorden()
        {
            student.ReserveMaterial(materiaalInWishlist, 1, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1));
        }





    }
}
