using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DidactischeLeermiddelen.Controllers;
using DidactischeLeermiddelen.Models.domain;
using Moq;
using DidactischeLeermiddelen.Tests.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DidactischeLeermiddelen.Tests.Controllers
{
    [TestClass]
    public class ReservedMaterialControllerTest
    {

        private ReservedMaterialController resController;
        private Mock<IMaterialRepository> mockMaterialRepository;
        private Mock<IUserRepository> mockUserRepository;
        private readonly DummyContext dummyContext = new DummyContext();
        private Material splitsboom;
        private User student, lector;

        [TestInitialize]
        public void MyTestInitializer()
        {

            mockMaterialRepository = new Mock<IMaterialRepository>();
            mockUserRepository = new Mock<IUserRepository>();
            splitsboom = dummyContext.Splitsboom;

            mockMaterialRepository.Setup(m => m.FindAll()).Returns(dummyContext.Materials);
            mockMaterialRepository.Setup(m => m.Add(It.IsNotNull<Material>()));
            mockMaterialRepository.Setup(m => m.SaveChanges());
            splitsboom = dummyContext.Splitsboom;

            student = dummyContext.Student;
            lector = dummyContext.Lector;
            student.AddToWishList(splitsboom);
            lector.AddToWishList(splitsboom);
            student.ReserveMaterial(splitsboom,1,DateTime.Now,DateTime.Now);
        }

        [TestMethod]
        public void RemoveFromReservationsVerwijdert()
        {
            ViewResult result = resController.RemoveFromReservation(splitsboom.MaterialId, student) as ViewResult;
            List<Material> reservations = (result.Model as IEnumerable<Material>).ToList();

            Assert.AreEqual(0,reservations.Count);
        }
    }
}
