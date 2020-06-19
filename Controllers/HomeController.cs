using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PickAndPlay.Models;

namespace PickAndPlay.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly PickAndPlayContext _context;

        public HomeController(ILogger<HomeController> logger, PickAndPlayContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Jeu> jeux = _context.Jeux.Include(j => j.NotesJeux)
                                                 .Include(j => j.JeuxImages)
                                                 .ThenInclude(ji => ji.Image);

            List<Jeu> preferes = jeux.OrderByDescending(j => j.NoteMoyenne())
                                     .Take(3)
                                     .ToList();

            List<Jeu> nouveautes = jeux.OrderByDescending(j => j.DateDeSortie)
                                       .Take(3)
                                       .ToList();


            ViewData["preferes"] = preferes;

            ViewData["nouveautes"] = nouveautes;


            return View();
        }


        public ActionResult Jeu(int? id)
        {
            var jeu = _context.Jeux.Where(j => j.Id == id)
                                   .Include(j => j.NotesJeux)
                                   .Include(j => j.JeuxConsolesDeJeu)
                                   .ThenInclude(cj => cj.ConsoleDeJeu)
                                   .Include(j => j.JeuxImages)
                                   .ThenInclude(ji => ji.Image)
                                   .Include(j => j.JeuxGenres)
                                   .ThenInclude(jg => jg.Genre)
                                   .Include(j => j.Editeur)
                                   .FirstOrDefault();
                                   
            if (jeu == null)
            {
                return NotFound();
            }

            return View(jeu);
        }


        public ActionResult ConsoleDeJeu(int? id)
        {
            var console = _context.ConsolesDeJeu.Where(c => c.Id == id)
                                                .Include(c => c.Image)
                                                .FirstOrDefault();
            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }

        public ActionResult Magasin(int? id)
        {
            var magasin = _context.Magasins.Where(m => m.Id == id)
                                           .Include(m => m.AdresseNavigation)
                                           .Include(m => m.MagasinsImages)
                                           .ThenInclude(mi => mi.Image)
                                           .FirstOrDefault();

            if (magasin == null)
            {
                return NotFound();
            }

            return View(magasin);
        }

        public ActionResult Location(int? id) 
        {
            if (!id.HasValue)
            {
                return NotFound();
            }

            Jeu jeu = _context.Jeux.Where(j =>j.Id == id).FirstOrDefault();

            if(jeu == null)
            {
                return NotFound();
            }

            if (!jeu.Disponible.HasValue || !jeu.Disponible.Value)
            {
                return NotFound();
            }

            string idUtilisateur = User.Identity.GetUserId();

            var location = new Location() { IdUtilisateur = idUtilisateur,
                IdJeu = id,
                DateHeureLocation = DateTime.Now,
                DateRestitutionPrevue = (DateTime.Now + TimeSpan.FromDays(10)).Date,
                Prix = jeu.PrixLocation
               };

            jeu.Disponible = false;

            _context.Attach(jeu).State = EntityState.Modified;
            _context.Locations.Add(location);
            _context.SaveChanges();

            return Redirect("/Home/Jeu?id="  + id);
        }

        public ActionResult Actualites()
        {
            List<Actualite> actualites = _context.Actualites
                                                 .OrderByDescending(a => a.Date)
                                                 .Take(10)
                                                 .Include(a => a.ActualitesImages)
                                                 .ThenInclude(ai => ai.Image)
                                                 .ToList();

            Console.WriteLine(actualites[0].Images);
            ViewBag.actualites = actualites;
            return View();
        }


        public ActionResult Rechercher(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
            {
                HttpContext.Response.Redirect("/");
            }

            List<Jeu> jeux = _context.Jeux.Where(j => j.Nom.Contains(query))
                                          .ToList();

            ViewData["resultat"] = jeux;
            ViewData["query"] = query;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
