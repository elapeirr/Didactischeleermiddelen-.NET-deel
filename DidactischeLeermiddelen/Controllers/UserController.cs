using System;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using DidactischeLeermiddelen.Models.domain;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Web.WebPages;

using System.Collections.Generic;
using System.Runtime.Remoting;
using Antlr.Runtime;

namespace DidactischeLeermiddelen.Controllers
{
    public class UserController : Controller
    {

        private IMaterialRepository materiaalRepo;
        private IUserRepository userRepo;
        private IReservedMaterialRepository reservedRepo;
        private List<Material> wishlist = new List<Material>();

        public UserController(IUserRepository userRepo, IMaterialRepository materiaalRepo, IReservedMaterialRepository reservedRepo)//, IReservedMaterialRepository reservedRepo)
        {

            this.userRepo = userRepo;
            this.materiaalRepo = materiaalRepo;
            this.reservedRepo = reservedRepo;
        }

        public ActionResult Index(User user, String Weken)
        {
            //wishlist = user.Wishlist.ToList();
            List<SelectListItem> items = new List<SelectListItem>();

            List<String> weken = FetchWeeks();

            for (int i = 0; i < weken.Count; i++)
            {
                String counter = i.ToString();
                SelectListItem j = new SelectListItem() { Value = counter, Text = weken[i] };
                items.Add(j);

            }
            ViewBag.Weken = new SelectList(items, "Value", "Text");
            String weeknr = Weken;
            int nr = 0;
            if (weeknr != null)
            {
                nr = int.Parse(weeknr);
            }
            String week = weken[nr];
            String result = week.Split(':').FirstOrDefault();

            DateTime start = DateTime.Now;
            if (String.IsNullOrEmpty(weeknr))
            {
                start = DateTime.Now;

            }
            else
            {
                start = result.AsDateTime();
            }

            //List<Material> hulp = user.Wishlist.ToList();

            //foreach (Material wish in hulp)
            //{

            //    if (wish.GetAmountAvailable(start) > 0)
            //    {
            //        wishlist.Add(wish);

            //    }
            //}

            if (user is Student) return RedirectToAction("Student", "User");
            else return View(user.Wishlist);
        }

        public ActionResult Student(User user, String Weken)
        {

            List<SelectListItem> items = new List<SelectListItem>();

            List<String> weken = FetchWeeks();

            for (int i = 0; i < weken.Count; i++)
            {
                String counter = i.ToString();
                SelectListItem j = new SelectListItem() { Value = counter, Text = weken[i] };
                items.Add(j);
            }
            ViewBag.Weken = new SelectList(items, "Value", "Text");
            String weeknr = Weken;
            int nr = 0;
            if (weeknr != null)
            {
                nr = int.Parse(weeknr);
            }
            String week = weken[nr];
            String result = week.Split(':').FirstOrDefault();

            DateTime start = DateTime.Now;
            if (String.IsNullOrEmpty(weeknr))
            {
                start = DateTime.Now;

            }

            else
            {
                start = result.AsDateTime();
            }

            //List<Material> hulp = new List<Material>();
            //if (user.Wishlist != null)
            //{
            //    hulp = user.Wishlist.ToList();
            //}

            //foreach (Material wish in hulp)
            //{

            //    if (wish.GetAmountAvailable(start) > 0)
            //    {
            //        wishlist.Add(wish);
            //    }
            //}

            return View(user.Wishlist);


        }



        private List<string> FetchWeeks()
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            List<string> week = new List<string>();
            DateTime startDate = DateTime.Now;
            while (startDate.DayOfWeek != DayOfWeek.Friday)
            {
                startDate = startDate.AddDays(1);

            }

            DateTime endDate = startDate.AddDays(6);
            int teller = 0;
            while (teller < 52 && (endDate.Month < 7 || endDate.Month > 8))
            {
                teller++;
                week.Add(string.Format("{0:dd/MM/yyyy} : {1:dd/MM/yyyy}", startDate, endDate));
                startDate = startDate.AddDays(7);
                endDate = endDate.AddDays(7);
            }
            return week;
        }


        [
            HttpPost]
        public ActionResult RemoveFromWishList(int materialId, User user)
        {

            user.RemoveFromWishList(materiaalRepo.FindBy(materialId));
            materiaalRepo.FindBy(materialId).IsInWishlist = false;
            userRepo.SaveChanges();

            TempData["message"] = materiaalRepo.FindBy(materialId).Name + " werd verwijderd van je verlanglijst";


            return RedirectToAction("Index", "User");
        }



        [HttpPost]
        public ActionResult AddToBlocking(int materialId, User user, int amount, DateTime creationdate, DateTime startdate)
        {
            Lector l = (Lector)user;
            Material material = materiaalRepo.FindBy(materialId);

            int delta = DayOfWeek.Friday - startdate.DayOfWeek;
            startdate = startdate.AddDays(delta);
            

            try
            {
                l.ReserveMaterial(material, amount, startdate, creationdate);
                userRepo.SaveChanges();
                TempData["message"] = material.Name + " werd toegevoegd aan je reservatie";
                return RedirectToAction("Index", "User");
            }
            catch (ArgumentException e)
            {
                if (e.Message.Contains("overrulen"))
                {
                    l.ReserveMaterial(material, amount, startdate, creationdate);
                    userRepo.SaveChanges();
                    TempData["message"] ="Je hebt een student overrulet. "+ material.Name + " werd toegevoegd aan je reservatie.";
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    TempData["error"] = e.Message;
                    return RedirectToAction("Index", "User");
                }
            }

        }

        //if (startdate < DateTime.Now)
        //{
        //    TempData["error"] = "Het is niet mogelijk om materiaal te reserveren in het verleden.";
        //    return RedirectToAction("Index", "User");
        //}

        //int amountAvailable = material.GetAmountAvailable(startdate);

        //if (amount > amountAvailable)
        //{ ReservedMaterial m =reservedRepo.FindByName(material.Name);
        //    String email = m.useremail;
        //    String [] stukje = email.Split('@');
        //    if (stukje[1] == "student.hogent.be")
        //    {
        //        TempData["error"] = "Je gaat een student overrulen";
        //        reservedRepo.Delete(m);
        //    }
        //    else
        //    {
        //        TempData["error"] = "Er zijn maar " + amountAvailable + " artikelen beschikbaar van " +
        //                            material.Name + " voor de gewenste datum.";
        //        return RedirectToAction("Index", "User");
        //    }
        //}

        //ReservedMaterial mat = new Blocking
        //{
        //    User = l,
        //    Material = material,
        //    AmountReserved = amount,
        //    StartDate = startdate,
        //    name = material.Name,
        //    useremail=user.Email,
        //    CreationDate = creationdate,
        //    EndDate = einde
        //};
        //Blocking b = (Blocking) mat;
        //reservedRepo.Add(mat);
        //reservedRepo.SaveChanges();

        //if (mat != null)
        //{

        //    l.BlockMaterial(l, material, amount, startdate,creationdate);

        //    TempData["message"] = material.Name + " werd toegevoegd aan je reservatie";
        ////}

        //return RedirectToAction("Index", "User");


        [HttpPost]
        public ActionResult AddToReservation(int materialId, User user, int amount, DateTime creationdate, String Weken)
        {

            List<SelectListItem> items = new List<SelectListItem>();

            List<String> weken = FetchWeeks();

            for (int i = 0; i < weken.Count; i++)
            {
                String counter = i.ToString();
                SelectListItem j = new SelectListItem() { Value = counter, Text = weken[i] };
                items.Add(j);
            }

            ViewBag.Weeks = new SelectList(items, "Value", "Text");
            string weeknr = Weken;

            int nr = 0;
            if (weeknr != null)
            {
                nr = int.Parse(weeknr);
            }
            String week = weken[nr];
            String result = week.Split(':').FirstOrDefault();
            DateTime startdate = result.AsDateTime();



            Material material = materiaalRepo.FindBy(materialId);

            int delta = DayOfWeek.Friday - startdate.DayOfWeek;
            DateTime friday = startdate.AddDays(delta);

            DateTime einde = friday.AddDays(7);

            try
            {
                user.ReserveMaterial(material, amount, startdate, creationdate);
                userRepo.SaveChanges();

                TempData["message"] = material.Name + " werd toegevoegd aan je reservatie";
                return RedirectToAction("Student", "User");
            }
            catch (ArgumentException e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction("Index", "User");
            }

            //    if (startdate < DateTime.Now)
            //    {
            //        TempData["error"] = "Het is niet mogelijk om materiaal te reserveren in het verleden.";
            //        return RedirectToAction("Student", "User");
            //    }
            //    if (amount > material.GetAmountAvailable(startdate))
            //    {
            //        TempData["error"] = "Er is  maar " + material.GetAmountAvailable(startdate) + " beschikbaar van" +
            //        material.Name;
            //        return RedirectToAction("Student", "User");


            //    }
            //    ReservedMaterial mat = new ReservedMaterial
            //    {
            //        User = user,
            //        useremail=user.Email,
            //        Material = material,
            //        AmountReserved = amount,
            //        StartDate = startdate,
            //        name = material.Name,
            //        CreationDate = creationdate,
            //        EndDate = einde,
            //        Location = material.Location
            //    };

            //    reservedRepo.Add(mat);
            //    reservedRepo.SaveChanges();
            //    userRepo.SaveChanges();
            //    if (mat != null)
            //    {
            //        material.AddToReservations(mat);
            //        user.ReserveMaterial(mat);

            //        TempData["message"] = mat.Material.Name + " werd toegevoegd aan je reservatie";
            //    }

            //    return RedirectToAction("Student", "User");
            }
        }
    }

    

