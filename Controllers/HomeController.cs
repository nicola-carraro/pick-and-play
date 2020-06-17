using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            IEnumerable<Jeu> jeux = _context.Jeux.Include(j => j.NoteJeu)
                                                 .Include(j => j.JeuImage)
                                                 .ThenInclude(ji => ji.ImageNavigation);

            List<Jeu> preferes = jeux.OrderBy(j => j.NoteMoyenne())
                                     .Take(3)
                                     .ToList();

            List<Jeu> nouveautes = jeux.OrderBy(j => j.DateDeSortie)
                                       .Take(3)
                                       .ToList();


            ViewData["preferes"] = preferes;

            ViewData["nouveautes"] = nouveautes;


            return View();
        }


        public ActionResult Jeu(int? id)
        {
            var jeu = _context.Jeux.Where(j => j.Id == id)
                                   .Include(j => j.NoteJeu)
                                   .Include(j => j.JeuConsoleDeJeu)
                                   .ThenInclude(cj => cj.ConsoleDeJeuNavigation)
                                   .Include(j => j.JeuImage)
                                   .ThenInclude(ji => ji.ImageNavigation)
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
                                                .Include(c => c.ImageNavigation)
                                                .FirstOrDefault();
            if (console == null)
            {
                return NotFound();
            }

            return View(console);
        }


        public ActionResult Rechercher(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
            {

                HttpContext.Response.Redirect("/");
            }

            List<Jeu> jeux = _context.Jeux.Where(j => j.Nom.Contains(query)).ToList();

            /*
            List<object> resultats = new List<object>();
            resultats.AddRange(jeux);*/

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
