using DidactischeLeermiddelen.Models.DAL;
using DidactischeLeermiddelen.Models.domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DidactischeLeermiddelen.Controllers
{
    public class MaterialController : Controller
    {
        private TeachingAidsContext db = new TeachingAidsContext();
        private IUserRepository userRepository;
        private IMaterialRepository materialRepository;
        private ICompanyRepository companyRepository;
        private ICurricularRepository curricularRepository;
        private ITargetAudienceRepository targetAudienceRepository;

        public MaterialController(IUserRepository userRepository, IMaterialRepository materialRepository, ICompanyRepository companyRepository, ICurricularRepository curricularRepository, ITargetAudienceRepository targetAudienceRepository)
        {
            this.userRepository = userRepository;
            this.materialRepository = materialRepository;
            this.companyRepository = companyRepository;
            this.curricularRepository = curricularRepository;
            this.targetAudienceRepository = targetAudienceRepository;
        }

        public ActionResult Index(string searchString, string sortOrder ,User user)
        {
            IEnumerable<Material> materials;
            ViewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (String.IsNullOrEmpty(searchString)) {
                materials = materialRepository.FindAll().ToList();
                foreach (Material m in materials) {
                    if (!user.Wishlist.Contains(m)){
                        m.IsInWishlist = false;
                    } }
            } else {
                materials = materialRepository.FindAllMaterialsWithSearString(searchString).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    materials = materials.OrderByDescending(m => m.Name);
                    break;
                default:
                    materials = materials.OrderBy(m => m.Name);
                    break;
            }

            return View(materials);
        }
       
        [HttpPost]
        public ActionResult AddToWishlist(int[] wishlist, User user)
        {
            foreach (int materialId in wishlist)
            {
                Material m = materialRepository.FindBy(materialId);
                user.AddToWishList(materialRepository.FindBy(materialId));
             
                user.SetWishlistBoolean(materialRepository.FindBy(materialId));

            
                userRepository.SaveChanges();

                TempData["message"] = "De materialen werden toegevoegd aan je verlanglijst";

            }

            return RedirectToAction("Index", "Material");
        }

        public ActionResult Detail(int materialid)
        {
            Material m = materialRepository.FindBy(materialid);
            return View(m);
        }
    }
}