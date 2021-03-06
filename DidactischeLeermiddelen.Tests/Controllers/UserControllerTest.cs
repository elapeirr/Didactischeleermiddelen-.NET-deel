﻿using System;
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
    public class UserControllerTest
    {
        private UserController userController;
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
        }

        [TestMethod]
        public void VerwijderenUitWishListVerwijdert()
        {
            ViewResult result = userController.RemoveFromWishList(splitsboom.MaterialId,student) as ViewResult;
            List<Material> wishlist = (result.Model as IEnumerable<Material>).ToList();

            Assert.AreEqual(0, wishlist.Count);
        }

        [TestMethod]
        public void ToevoegenAanReservatiesReserveert()
        {
            userController.AddToReservation(splitsboom.MaterialId, student,1,DateTime.Now,"25:03:2015:31:03:2015");
            ViewResult result = resController.Index(student) as ViewResult;
            List<Material> reservations = (result.Model as IEnumerable<Material>).ToList();

            Assert.AreEqual(1, reservations.Count);
        }
        
    }
}
