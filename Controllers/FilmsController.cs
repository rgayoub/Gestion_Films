using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EFM_MVC.Models;

namespace EFM_MVC.Controllers
{
    public class FilmsController : Controller
    {
        private static List<Film> films = new List<Film>
        {
            new Film { Id = 1, Titre = "Jaws", Réalisateur = "Steven Spielberg", DateDeSortie = new DateTime(1975, 6, 20), Synopsis = "A giant man-eating shark terrorizes a small resort town.", Affiche = "jaws.jpg", BandeAnnonce = "JAWS.mp4" },
            new Film { Id = 2, Titre = "Jurassic Park", Réalisateur = "Steven Spielberg", DateDeSortie = new DateTime(1993, 6, 11), Synopsis = "During a preview tour, a theme park suffers a major power breakdown that allows its cloned dinosaur exhibits to run amok.", Affiche = "jurassicPark.jpg", BandeAnnonce = "JurassicPark.mp4" },
            new Film { Id = 3, Titre = "The Wolf of Wall Street", Réalisateur = "Martin Scorsese", DateDeSortie = new DateTime(2013, 12, 25), Synopsis = "Based on the true story of Jordan Belfort, from his rise to a wealthy stock-broker living the high life to his fall involving crime, corruption and the federal government.", Affiche = "TheWolfOfWallStreet.jpg", BandeAnnonce = "TheWolfOfWallStreet_scorsese.mp4" },
            new Film { Id = 4, Titre = "The Jocker", Réalisateur = "Christopher Nolan", DateDeSortie = new DateTime(2010, 7, 16), Synopsis = "A thief who steals corporate secrets through use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", Affiche = "theJoker.jpg", BandeAnnonce = "THEJOKER_MartinScorsese.mp4" },
            new Film { Id = 5, Titre = "the Irish Man", Réalisateur = "Lana Wachowski, Lilly Wachowski", DateDeSortie = new DateTime(1999, 3, 31), Synopsis = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", Affiche = "theIrishMan.jpg", BandeAnnonce = "TheIrishman_scorsise.mp4" },
            new Film { Id = 6, Titre = "Taxi driver", Réalisateur = "Christopher Nolan", DateDeSortie = new DateTime(2014, 11, 7), Synopsis = "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival.", Affiche = "taxi_driver_affiche.jpg", BandeAnnonce = "TaxiDriver_scrsese.mp4\r\n" },
            new Film { Id = 7, Titre = "Saving Private Ryan", Réalisateur = "Francis Ford Coppola", DateDeSortie = new DateTime(1972, 3, 24), Synopsis = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", Affiche = "Saving_Private_Ryan_poster.jpg", BandeAnnonce = "SavingPrivateRyan.mp4" }
        };

        public IActionResult Index()
        {
            return View(films);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = films.FirstOrDefault(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Titre,Réalisateur,DateDeSortie,Synopsis,Affiche,BandeAnnonce")] Film film)
        {
            if (ModelState.IsValid)
            {
                film.Id = films.Max(f => f.Id) + 1;
                films.Add(film);
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = films.FirstOrDefault(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }
            return View(film);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Titre,Réalisateur,DateDeSortie,Synopsis,Affiche,BandeAnnonce")] Film film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingFilm = films.FirstOrDefault(f => f.Id == id);
                if (existingFilm != null)
                {
                    existingFilm.Titre = film.Titre;
                    existingFilm.Réalisateur = film.Réalisateur;
                    existingFilm.DateDeSortie = film.DateDeSortie;
                    existingFilm.Synopsis = film.Synopsis;
                    existingFilm.Affiche = film.Affiche;
                    existingFilm.BandeAnnonce = film.BandeAnnonce;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = films.FirstOrDefault(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var film = films.FirstOrDefault(m => m.Id == id);
            if (film != null)
            {
                films.Remove(film);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
