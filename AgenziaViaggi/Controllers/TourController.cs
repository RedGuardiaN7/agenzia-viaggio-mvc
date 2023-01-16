using AgenziaViaggi.Database;
using AgenziaViaggi.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgenziaViaggi.Controllers
{
    public class TourController : Controller
    {

        public IActionResult Index()
        {
            using (TourContext db = new TourContext())
            {
                List<Tour> listTour = db.Tours.OrderBy(title => title.Title).ToList<Tour>();

                ; return View("Index", listTour);
            }

        }

        public IActionResult Details(int id)
        {
            bool FunzioneDiRicercaPostById(Tour tour)
            {
                return tour.Id == id;

            }


            using (TourContext db = new TourContext())
            {
                // LINQ: query syntax
                Tour tourFound =
                    (from Tour in db.Tours
                     where Tour.Id == id
                     select Tour).FirstOrDefault<Tour>();



                if (tourFound != null)
                {
                    return View(tourFound);
                }

                return NotFound("Il viaggio con l'id cercato non esiste!");

            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tour formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using (TourContext db = new TourContext())
            {
                db.Tours.Add(formData);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            using (TourContext db = new TourContext())
            {
                Tour postToUpdate = db.Tours.Where(tour => tour.Id == id).FirstOrDefault();

                if (postToUpdate == null)
                {
                    return NotFound("Il viaggio non è stato trovato");
                }

                return View("Update", postToUpdate);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Tour formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", formData);
            }

            using (TourContext db = new TourContext())
            {
                Tour postToUpdate = db.Tours.Where(tourUpdate => tourUpdate.Id == formData.Id).FirstOrDefault();

                if (postToUpdate != null)
                {
                    postToUpdate.Title = formData.Title;
                    postToUpdate.Description = formData.Description;
                    postToUpdate.Image = formData.Image;
                    postToUpdate.Days = formData.Days;
                    postToUpdate.Destinations = formData.Destinations;
                    postToUpdate.Price = formData.Price;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound("Il viaggio che volevi modificare non è stato trovato!");
                }
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            using (TourContext db = new TourContext())
            {

                Tour tourToDelete = db.Tours.Where(Tour => Tour.Id == id).FirstOrDefault();
                if (tourToDelete != null)
                {
                    db.Tours.Remove(tourToDelete);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }

    }


}

//Codice da "Pizzeria" da modificare



