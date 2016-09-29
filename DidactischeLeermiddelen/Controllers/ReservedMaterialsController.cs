using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DidactischeLeermiddelen.Models.DAL;
using DidactischeLeermiddelen.Models.domain;

namespace DidactischeLeermiddelen.Controllers
{
    public class ReservedMaterialController : Controller
    {
        private TeachingAidsContext context = new TeachingAidsContext();
        private IReservedMaterialRepository reservedRepo;
        private IUserRepository userRepo;
        private IMaterialRepository materialRepo;
        private List<ReservedMaterial> reservations;

        public ReservedMaterialController(IReservedMaterialRepository reservedRepo, IUserRepository userRepo ,IMaterialRepository materialRepo ) {

            this.reservedRepo = reservedRepo;
            this.userRepo = userRepo;
            this.materialRepo = materialRepo;

        }
        // GET: ReservedMaterials
        public ActionResult Index(User user)
        {
            reservations = user.Reservations.ToList();

            return View(reservations);
            
        }

        [HttpPost]
        public ActionResult RemoveFromReservation(int reservedmaterialId, User user)
        {
            ReservedMaterial m = reservedRepo.FindBy(reservedmaterialId);
            DateTime start = m.StartDate;

            if (start.CompareTo(DateTime.Now) > 0)
            {
                String naam = m.name;
                Material mat = materialRepo.FindByName(naam);

                user.RemoveFromReservations(m);
                mat.RemoveFromReservations(m);

                userRepo.SaveChanges();
                reservedRepo.SaveChanges();

                TempData["message"] = naam + " werd verwijderd van je reservaties";
            }
            else
            {

                TempData["error"] = "Je kan geen reservatie verwijderen die al bezig of afgelopen is";
            }

            return RedirectToAction("Index", "ReservedMaterial");
        }


    }
}
