using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DidactischeLeermiddelen.Controllers;
using DidactischeLeermiddelen.Models.domain;
using Moq;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using DidactischeLeermiddelen.Tests.Models;

namespace DidactischeLeermiddelen.Tests.Controllers
{
    [TestClass]
    public class MaterialControllerTest


    {

        private MaterialController materialController;
        private UserController userController;
        private Mock<IMaterialRepository> mockMaterialRepository;
        private Mock<ICompanyRepository> mockcompanyRepository;
        private Mock<ICurricularRepository> mockCurricularRepository;
        private Mock<ITargetAudienceRepository> mockTargRepository;
        private Mock<IUserRepository> mockUserRepository;
        private readonly DummyContext dummyContext = new DummyContext();
        private Material splitsboom;
        private int splitsboomId;
        private Material nieuwMaterial;
        private User user;

        [TestInitialize]
        public void MyTestInitializer()
        {
            
            mockMaterialRepository = new Mock<IMaterialRepository>();
            mockUserRepository = new Mock<IUserRepository>();
            mockcompanyRepository = new Mock<ICompanyRepository>();
            mockCurricularRepository = new Mock<ICurricularRepository>();
            mockTargRepository = new Mock<ITargetAudienceRepository>();
            //materialController = new MaterialController(mockUserRepository , mockMaterialRepository, mockcompanyRepository,mockCurricularRepository,mockTargRepository);
            splitsboom = dummyContext.Splitsboom;
            mockMaterialRepository.Setup(m => m.FindAll()).Returns(dummyContext.Materials);
            mockMaterialRepository.Setup(m => m.Add(It.IsNotNull<Material>()));
            mockMaterialRepository.Setup(m => m.Delete(dummyContext.Splitsboom));
            mockMaterialRepository.Setup(m => m.SaveChanges());
            nieuwMaterial = new Material
            {
                ImagePath = "~/Images/Material1.jpg",
                Name = "dobbelsteen-schatkist-162delig",
                Description = "koffertje met verschillende soorten dobbelstenen: blanco, met cijfers,...",

                ItemNumber = "MH1447",
                Price = 35,
                TotalAmount = 1,
                Broken = 1,
                Lendable = true,
                Location = "GLEDE 1.011"
            };
            user = dummyContext.Student;
        }


        [TestMethod]
        public void IndexRetourneertAlleMaterialenGesorteerdOpNaam()
        {
            ViewResult result = materialController.Index("", "") as ViewResult;
            List<Material> materials = (result.Model as IEnumerable<Material>).ToList();

            Assert.AreEqual(3, materials.Count);
            Assert.AreEqual("Mini-loco-spelbord 4 tot 8 jaar", materials[0].Name);
            Assert.AreEqual("Splitsbomen - opdrachtkaarten", materials[2].Name);
        }

        [TestMethod]
        public void AddToWishListVoegtToeAanVerlanglijstjeUser()
        {
            materialController.AddToWishlist(new int[]{splitsboom.MaterialId}, user);
            ViewResult result = userController.Index(user, "") as ViewResult;
            List<Material> wishlist = (result.Model as IEnumerable<Material>).ToList();

            Assert.AreEqual("Splitsboom", wishlist[0].Name);
        }
        

    }
}
