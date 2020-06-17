using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
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
            IEnumerable<Jeu> jeux = _context.Jeux.Include(j => j.JeuImage).ThenInclude(ji => ji.ImageNavigation);
            
            foreach (Jeu jeu in jeux)
            {
                if (jeu.JeuImage != null)
                {
                    jeu.ImagePrincipale = (from ji in jeu.JeuImage
                                where ji.ImagePrincipale == true
                                select ji.ImageNavigation).FirstOrDefault();
                   
                }
            }


            ViewData["NouveautesJeux"] = jeux;


            return View();
        }


        public ActionResult Jeu(int? id)
        {
            var query = (from j in _context.Jeux
                         where j.Id == id
                         select j).Include(j => j.JeuImage)
                                    .ThenInclude(ji => ji.ImageNavigation);

            Jeu jeu = query.FirstOrDefault();

            if (jeu == null)
            {
                return NotFound();
            }

            jeu.ImagePrincipale = (from ji in jeu.JeuImage
                           where ji.ImageNavigation.Largeur >= 1000
                           select ji.ImageNavigation).FirstOrDefault();

            jeu.Notes = _context.NotesJeus.Where(n => n.IdJeu == jeu.Id).ToList();

            return View(jeu);
        }


        public ActionResult Rechercher(string query)
        {

            if (string.IsNullOrWhiteSpace(query))
            {

                HttpContext.Response.Redirect("/");
            }
            List<Jeu> jeux= _context.Jeux.Where(j => j.Nom.Contains(query)).ToList();

            Console.WriteLine(jeux);
            foreach (var jeu in jeux)
            {
                Console.WriteLine(jeu.Nom);
            }

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
